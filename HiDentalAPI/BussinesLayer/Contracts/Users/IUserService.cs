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
        /// <summary>
        /// Actualiza el detalle del usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateDetailAsync(UserDetail model);
        Task<IEnumerable<User>> FilterAsync(FilterUserViewModel filters);
        /// <summary>
        /// Envia el email con un codigo para cambiar la contraseña
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SendEmailChangePasswordAsync(EmailViewModel model);
        /// <summary>
        /// Valida que el codigo enviado al correo para 
        /// cambiar la contraseña es valido
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> ValidateKeyOfChangePassword(string key);
        /// <summary>
        /// Cambia la contraseña
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel user);
        Task<bool> AddUserToRoleAsync(UserToRoleViewModel model);
        Task<bool> RemoveUserFromRoleAsync(UserToRoleViewModel model);
        /// <summary>
        /// Verifica si el usuario esta en cierto rol
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UserIsInRoleAsync(UserToRoleViewModel model);
        /// <summary>
        /// Cambia el tipo al usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateUserToTypeAsync(UserToTypeViewModel model);
        /// <summary>
        /// Cambia de sucursal al usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateDentalBranchAsync(UserToDentalBranchViewModel model);
        Task<IEnumerable<User>> GetAllUserByDentalBranchAsync(Guid id);
        Task<User> GetByUserName(string userName);
    }
}
