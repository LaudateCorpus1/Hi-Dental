using AutoMapper;
using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using Common.ExtensionsMethods;
using DatabaseLayer.Enums;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DatabaseLayer.Users.ViewModels;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Settings;
using DataBaseLayer.ViewModels.Email;
using DataBaseLayer.ViewModels.Pagination;
using DataBaseLayer.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;


namespace BussinesLayer.Services
{
    public class UserService : BaseRepository<User>, IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly AppSetting _settings;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext dbContext, UserManager<User> userManager, 
            IOptions<AppSetting> options ,
            IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _settings = options.Value;
            _mapper = mapper;
        }


        public async Task<IEnumerable<User>> FilterAsync(FilterUserViewModel filters)
        {
            if (!filters.IndentityDocument.IsNull())
            {
                return await _dbContext.Users.Include(x => x.UserDetail).Where(x => x.UserDetail.IdentityDocument == filters.IndentityDocument).ToListAsync();
            }
            var result = Filter(x => x.Names.Contains(filters.Names));
            if (!filters.LastNames.IsNull()) result = result.Where(x => x.LastNames == filters.LastNames);
            return await result.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
            => await _dbContext.Users.Include(x => x.UserDetail).Include(x => x.DentalBranch).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> SoftDelete(string param)
        {
            var result = await _userManager.FindByIdAsync(param);
            result.State = State.Removed;
            return await Update(result);
        }

        public async Task<bool> UpdateAsync(User model)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            result.LastNames = model.LastNames.Evaluate(result.LastNames);
            result.Names = model.Names.Evaluate(result.Names);
            result.Email = model.Email.Evaluate(result.Email);
            result.PhoneNumber = model.PhoneNumber.Evaluate(result.PhoneNumber);
            _dbContext.Update(result);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDetailAsync(UserDetail model)
        {
            var result = await _dbContext.UserDetails.FirstOrDefaultAsync(x => x.UserId == model.UserId);
            result.Description = model.Description.Evaluate(result.Description);
            result.Gender = model.Gender.Evaluate(result.Gender);
            result.IdentityDocument = model.IdentityDocument.Evaluate(result.IdentityDocument);
            result.UpdateAt = model.UpdateAt;
            _dbContext.Update(result);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> SendEmailChangePasswordAsync(EmailViewModel email)
        {
            var user = await _userManager.FindByNameAsync(email.UserName);
            if (user == null) return false;

            MailMessage message = new MailMessage
            {
                From = new MailAddress("orbisalonzo25@gmail.com") ///TODO : evaluate for sucursales
            };
            message.To.Add(email.UserName);
            message.Subject = email.Subject;
            message.IsBodyHtml = true;
            message.Body = await GetPassEmailTemplate(user.FullName, $"{_settings.Route}{_settings.Email.ChangePasswordEndPoint}{user.SecurityStamp}");

            SmtpClient smtpClient = new SmtpClient
            {
                UseDefaultCredentials = false,
                Host = _settings.Email.Smtp,
                Port = _settings.Email.Port,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(_settings.Email.BaseEmail, _settings.Email.Password)
            };
            try
            {
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<string> GetPassEmailTemplate(string name, string url)
        {
            var readContentResult = await File.ReadAllTextAsync($@"{Directory.GetCurrentDirectory()}\wwwroot\Emails\ChangePassword.html");
            readContentResult = readContentResult.Replace("{name}", name);
            readContentResult = readContentResult.Replace("{route}", url);
            return readContentResult;
        }

        public async Task<bool> ValidateKeyOfChangePassword(string key) => await _dbContext.Users.AnyAsync(x => x.SecurityStamp == key);

        public async Task<bool> ChangePasswordAsync(UserChangePasswordViewModel user)
        {
            var userResult = await _userManager.FindByNameAsync(user.UserName);
            if (userResult == null) return false;
            var newPassword = _userManager.PasswordHasher.HashPassword(userResult, user.Password);
            userResult.PasswordHash = newPassword;
            var result = await _userManager.UpdateAsync(userResult);
            return result.Succeeded;
        }

        public async Task<bool> AddUserToRoleAsync(UserToRoleViewModel model)
        {
            var user = await UserAndRoleExist(model);
            if (user == null) return false;
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            return result.Succeeded;
        }

        public async Task<bool> RemoveUserFromRoleAsync(UserToRoleViewModel model)
        {
            var user = await UserAndRoleExist(model);
            if (user == null) return false;
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == model.RoleName);
            var userRole = await _dbContext.UserRoles.FirstOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == model.UserId);
            _dbContext.UserRoles.Remove(userRole);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UserIsInRoleAsync(UserToRoleViewModel model)
        {
            var user = await UserAndRoleExist(model);
            if (user == null) return false;
            var role = await _userManager.GetRolesAsync(user);
            var result = role.Contains(model.RoleName);
            return result;
        }

        private async Task<User> UserAndRoleExist(UserToRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == model.RoleName);
            if (user == null || role == null) return null;
            return user;
        }

        public async Task<PaginationViewModel<UserViewModel>> GetAllWithPaginateAsync(FilterUserViewModel model)
        {


            var result = GetAll().Include(x => x.UserDetail).Where(x => x.CreatedBy == model.Id);
           
            if (!model.IndentityDocument.IsNull())
            {
                return new PaginationViewModel<UserViewModel>
                {
                    ActualPage = model.Page,
                    Entities = _mapper.Map<IEnumerable<UserViewModel>>(result.Where(x => x.UserDetail.IdentityDocument == model.IndentityDocument)),
                    Total = result.Count(),
                    Pages = model.Page
                };
            }

            if (!model.Names.IsNull()) result = result.Where(x => x.Names.Contains(model.Names));
            if (!model.LastNames.IsNull()) result = result.Where(x => x.LastNames.Contains(model.LastNames));

            var total = result.Count();
            var pages = total / model.QuantityByPage;

            return new PaginationViewModel<UserViewModel>
            {
                ActualPage = model.Page,
                Entities = _mapper.Map<IEnumerable<UserViewModel>>(await result.Skip((model.Page - 1) * model.QuantityByPage).Take(model.QuantityByPage).OrderByDescending(x => x.CreateAt).ToListAsync()),
                Total = total,
                Pages = pages
            };
        }

        public async Task<bool> UpdateUserToTypeAsync(UserToTypeViewModel model)
        {
            var user = await _dbContext.UserDetails.FirstOrDefaultAsync(x => x.Id == model.UserDetailId);
            if (user == null) return false;
            var type = await _dbContext.UserTypes.FirstOrDefaultAsync(x => x.Id == model.TypeId);
            if (type == null) return false;
            user.UserTypeId = model.TypeId;
            _dbContext.UserDetails.Update(user);
            return await _dbContext.SaveChangesAsync() > 0;   
        }

        public async Task<bool> UpdateDentalBranchAsync(UserToDentalBranchViewModel model)
        {
            var exist = await _dbContext.DentalBranch.FirstOrDefaultAsync(x => x.Id == model.DentalBranchId);
            if (exist == null) return false;
            var user = await GetUserById(model.UserId);
            if (user == null) return false;
            user.DentalBranchId = model.DentalBranchId;
            user.UpdateAt = DateTime.Now;
            _dbContext.Users.Update(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
