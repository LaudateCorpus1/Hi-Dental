using Auth.Interfaces;
using Auth.Models;
using Auth.ViewModels;
using DatabaseLayer.Models;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AuthSetting _settings;
        private readonly ApplicationDbContext _dbContext;

        public AuthService(UserManager<User> userManager
            , SignInManager<User> signInManager,
            IOptions<AuthSetting> options,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _settings = options.Value;
            _dbContext = dbContext;
        }
        public async Task<AuthResult> BuildToken(UserViewModel model)
        {
            var claims = await GetUserClaims(model.UserName);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
            issuer: _settings.ValidIssuer,
            audience: _settings.ValidAudience,
            claims: claims,
            signingCredentials: creds);
            var authResult = new AuthResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = DateTime.Today,
                Expire = false,
                Permissions = await GetUserPermissionAsync(model.UserName),
                UserName = model.UserName
            };
            return authResult;
        }

        /// <summary>
        /// Get users claims from database
        /// </summary>
        /// <param name="userName">User</param>
        /// <returns>Claim[]</returns>
        private async Task<List<Claim>> GetUserClaims(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var rols = await _userManager.GetRolesAsync(user);
            var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var item in rols) claim.Add(new Claim(ClaimTypes.Role, item));
            return claim;
        }
        /// <summary>
        /// Get users permisions from database
        /// </summary>
        /// <param name="userName">User</param>
        /// <returns>Claim[]</returns>
        private async Task<List<PermissionViewModel>> GetUserPermissionAsync(string userName)
        {
            var user = await _dbContext.Users.Include(x => x.UserRoles)
                .FirstOrDefaultAsync(x => x.UserName == userName);
            var result = new List<PermissionViewModel>();
            foreach (var item in user.UserRoles)
            {
                var res = new PermissionViewModel
                {
                    CreateAt = item.Role.CreateAt,
                    HasChild = item.Role.HasChild,
                    Id = item.Role.Id,
                    IsChecked = item.Role.IsChecked,
                    IsExpanded = item.Role.IsExpanded,
                    MenuName = item.Role.MenuName,
                    ParentId = item.Role.ParentId,
                    UpdateAt = item.Role.UpdateAt,
                    Name = item.Role.Name
                    
                }; // TODO: add with autoMapper in the next commit
                result.Add(res);
            }
            return result;
        }

        public async Task<bool> Register(CreateUserViewModel model)
        {
            var result = await _userManager.CreateAsync(new User
            {
                UserName = model.UserName,
                Email = model.UserName,
                Names = model.Names,
                LastNames = model.LastNames
            }, model.Password); ///TODO : WITH aUTOMAPPER
            return result.Succeeded;
        }

        public async Task<bool> SignIn(UserViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return result.Succeeded;
        }
    }
}
