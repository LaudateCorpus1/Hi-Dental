using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Services
{
    public class UserDetailService : BaseRepository<UserDetail>, IUserDetailService
    {
        public UserDetailService(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
