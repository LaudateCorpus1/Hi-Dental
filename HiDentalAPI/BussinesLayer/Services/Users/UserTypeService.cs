using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class UserTypeService : BaseRepository<UserType> , IUserTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserType>> Filter(string name) => await Filter(x => x.Name.Contains(name)).ToListAsync();

        public async Task<bool> SoftDelete(Guid param)
        {
            var result = await _dbContext.UserTypes.FirstOrDefaultAsync(x => x.Id == param);
            if (result == null) return false;
            result.State = DatabaseLayer.Enums.State.Removed;
            _dbContext.Update(result);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
