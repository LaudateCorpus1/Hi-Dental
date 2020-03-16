using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class DentalBranchService : BaseRepository<DentalBranch>, IDentalBranchService
    {
        private readonly ApplicationDbContext _dbContext;
        public DentalBranchService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DentalBranch>> GetAllByPrincipalOfficeId(Guid id)
            => await GetAll().Where(x => x.PrincipalOfficeId == id).ToListAsync();

        /// <summary>
        /// Obtiene las sucursales hermanas que son secundarias
        /// </summary>
        /// <param name="id">Id de la sucursal principal, hija de la oficina principal</param>
        /// <returns>IENUMERABLE</returns>
        public async Task<IEnumerable<DentalBranch>> GetAllSecondBranches(Guid id)
        {
            var branch = await GetById(id);
            if (branch == null) return null;
            if (!branch.IsPrincipal) return null;
            return await GetAll().Where(x => x.PrincipalOfficeId == branch.PrincipalOfficeId).ToListAsync();
        }

        public async Task<bool> SoftDelete(Guid param)
        {
            var model = await _dbContext.DentalBranch.FirstOrDefaultAsync();
            model.State = DatabaseLayer.Enums.State.Removed;
            model.UpdateAt = DateTime.Now;
            _dbContext.Update(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
