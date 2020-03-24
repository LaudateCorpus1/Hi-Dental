using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using Common.ExtensionsMethods;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.ViewModels.Pagination;
using DataBaseLayer.ViewModels.PrincipalOffice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<DentalBranch>> DentalBranches(Guid id) 
            => await _dbContext.DentalBranch.Where(x => x.PrincipalOfficeId == id).ToListAsync();

        public async Task<PaginationViewModel<PrincipalOffice>> GetAllWithPaginateAsync(FilterOfficeViewModel filterEntity)
        {
            var offices = GetAll();
            if (!filterEntity.Title.IsNull()) offices = offices.Where(x => x.Title.Contains(filterEntity.Title));
            if (!filterEntity.PhoneNumber.IsNull()) offices = offices.Where(x => x.PhoneNumber.Contains(filterEntity.PhoneNumber));
            var total = offices.Count();
            var pages = total / filterEntity.QuantityByPage;
            return new PaginationViewModel<PrincipalOffice>
            {
                ActualPage = filterEntity.Page,
                Total = total,
                Pages = pages,
                Entities = await offices.Skip((filterEntity.Page - 1) * filterEntity.QuantityByPage)
                .Take(filterEntity.QuantityByPage).OrderByDescending(x => x.CreateAt).ToListAsync()           
            };
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
