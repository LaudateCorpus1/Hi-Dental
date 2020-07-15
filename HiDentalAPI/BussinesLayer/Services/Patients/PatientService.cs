using BussinesLayer.Contracts;
using BussinesLayer.Repository.Contracts;
using BussinesLayer.Repository.Services;
using Common.ExtensionsMethods;
using DatabaseLayer.Enums;
using DatabaseLayer.Models.Patients;
using DatabaseLayer.Persistence;
using DataBaseLayer.ViewModels.Pagination;
using DataBaseLayer.ViewModels.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class PatientService : BaseRepository<Patient>, IPatientService
    {
        private readonly ApplicationDbContext _dbContext;
        public PatientService(ApplicationDbContext dbContext) : base(dbContext) => _dbContext = dbContext;


        public async Task<PaginationViewModel<Patient>> GetAllWithPaginateAsync(FilterPatientViewModel filterEntity)
        {
            var result = GetAll().Where(x => x.DentalBranchId == filterEntity.DentalBranchId);
            if (!result.Any()) return null;
            if (!filterEntity.IdentityCard.IsNull()) result = result.Where(x => x.IdentificationCard.Contains(filterEntity.IdentityCard));
            if (!filterEntity.Code.IsNull()) result = result.Where(x => x.Code == filterEntity.Code);
            if (!filterEntity.Name.IsNull()) result = result.Where(x => x.Names.Contains(filterEntity.Name));
            if (!filterEntity.LastNames.IsNull()) result = result.Where(x => x.LastNames.Contains(filterEntity.LastNames));
            if (!filterEntity.Email.IsNull()) result = result.Where(x => x.Email.Contains(filterEntity.Email));


            var total = result.Count();
            var pages = total / filterEntity.QuantityByPage;

            return new PaginationViewModel<Patient>
            {
                ActualPage = filterEntity.Page,
                Pages = pages,
                Total = total,
                Entities = await result.Skip((filterEntity.Page - 1) * filterEntity.QuantityByPage).Take(filterEntity.QuantityByPage)
                .OrderByDescending(x => x.CreateAt).ToListAsync()
            };
        }

        public async Task<bool> SoftDelete(Guid param)
        {
            var model = await GetById(param);
            model.State = State.Removed;
            _dbContext.Update(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
