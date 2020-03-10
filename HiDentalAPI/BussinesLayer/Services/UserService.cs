using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using Common.ExtensionsMethods;
using DatabaseLayer.Enums;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BussinesLayer.Services
{
    public class UserService : BaseRepository<User>, IUserService 
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public UserService(ApplicationDbContext dbContext , UserManager<User> userManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
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

        public async Task<IEnumerable<User>> GetAllByUserAsync(string id)
            => await GetAll().Where(x => x.CreatedBy == id).ToListAsync();

        public async Task<User> GetUserById(string id) 
            => await _dbContext.Users.Include(x => x.UserDetail).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> SoftDelete(string param)
        {
            var result =  await _userManager.FindByIdAsync(param);
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
            _dbContext.Update(result);
            return await _dbContext.SaveChangesAsync() > 0;
        }





    }
}
