using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Contracts
{
    public interface IUserTypeService : IBaseRepository<UserType> , IHelperServiceStructure<Guid>
    {

    }
}
