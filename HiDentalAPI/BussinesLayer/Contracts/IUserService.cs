using BussinesLayer.Repository.Contracts;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Email;
using DataBaseLayer.ViewModels.Pagination;
using DataBaseLayer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IUserService : IBaseRepository<User> , IHelperService<string> , IPaginationService<UserViewModel,FilterUserViewModel>
    {
        Task<User> GetUserById(string id);
        Task<bool> UpdateAsync(User model);
        Task<bool> UpdateDetailAsync(UserDetail model);
        Task<IEnumerable<User>> FilterAsync(FilterUserViewModel filters);
        Task<bool> SendEmailChangePasswordAsync(EmailViewModel model);
        Task<bool> ValidateKeyOfChangePassword(string key);
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel user);
        Task<bool> AddUserToRoleAsync(UserToRoleViewModel model);
        Task<bool> RemoveUserFromRoleAsync(UserToRoleViewModel model);
        Task<bool> UserIsInRoleAsync(UserToRoleViewModel model);
        Task<bool> UpdateUserToTypeAsync(UserToTypeViewModel model);
        Task<bool> UpdateDentalBranchAsync(UserToDentalBranchViewModel model);
    }
}
