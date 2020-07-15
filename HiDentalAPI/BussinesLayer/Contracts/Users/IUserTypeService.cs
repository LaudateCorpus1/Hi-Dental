using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IUserTypeService : IBaseRepository<UserType>, IHelperServiceStructure<Guid>
    {
        Task<IEnumerable<UserType>> Filter(string name);
    }
}
