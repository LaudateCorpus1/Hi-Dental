using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class UserTypeService : BaseRepository<UserType> , IUserTypeService
    {

        public UserTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> SoftDelete(Guid param)
        {
            throw new NotImplementedException();
        }
    }
}
