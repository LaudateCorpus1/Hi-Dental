using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IPermissionService : IBaseRepository<Permission> , IHelperService<string>
    {
        Task<Permission> GetByIdentifier(string id);
        Task<bool> Create(Permission permission);
        Task<bool> ExistByIdAsync(string id);
        Task<bool> ExistByNameAsync(string name);
        Task<bool> UpdateByProperties(Permission model);


    }
}
