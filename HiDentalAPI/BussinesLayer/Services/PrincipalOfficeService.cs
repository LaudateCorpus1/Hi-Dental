using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class PrincipalOfficeService : BaseRepository<PrincipalOffice>,
        IPrincipalOfficeService
    {
        private readonly ApplicationDbContext _dbContext;
        public PrincipalOfficeService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PrincipalOffice> GetWithChildrenBranchsAsync(Guid id)
            => await _dbContext.PrincipalOffices.Include(x => x.DentalBranches).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> SoftDelete(Guid param)
        {
            var model = await _dbContext.PrincipalOffices.FirstOrDefaultAsync(x => x.Id == param);
            if (model == null) return false;
            model.State = DatabaseLayer.Enums.State.Removed;
            _dbContext.Update(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }


    }
}
