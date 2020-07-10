using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using Common.ExtensionsMethods;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.ViewModels.DentalBranch;
using DataBaseLayer.ViewModels.Pagination;
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
        {
            var branch = await GetById(id);
            if (branch == null) return null;
            if (!branch.IsPrincipal) return null;
            return await GetAll().Where(x => x.PrincipalOfficeId == id).ToListAsync();
        }

        public async Task<PaginationViewModel<DentalBranch>> GetAllWithPaginateAsync(FilterDentalBranchViewModel filterEntity)
        {
            var branch = GetAll();
            if (filterEntity.IsPrincipal) branch = branch.Where(x => x.IsPrincipal == filterEntity.IsPrincipal);
            if(filterEntity.PrincipalOfficeId.HasValue) branch = branch.Where(x => x.PrincipalOfficeId == filterEntity.PrincipalOfficeId);
            if (!filterEntity.Title.IsNull()) branch = branch.Where(x => x.Title.Contains(filterEntity.Title));
            if (!filterEntity.PhoneNumber.IsNull()) branch = branch.Where(x => x.Title.Contains(filterEntity.PhoneNumber));
            var total = branch.Count();
            var pages = total / filterEntity.QuantityByPage;
            return new PaginationViewModel<DentalBranch>
            {
                ActualPage = filterEntity.Page,
                Pages = pages,
                Total = total,
                Entities = await branch.Skip((filterEntity.Page - 1) * filterEntity.QuantityByPage)
                .Take(filterEntity.QuantityByPage).OrderByDescending(x => x.CreateAt).ToListAsync()
            };
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
