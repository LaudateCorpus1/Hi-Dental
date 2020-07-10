using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.Pagination;
using DataBaseLayer.ViewModels.ServiceOfPattients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ServiceOfPattientService : BaseRepository<ServiceOfPattient>, IServiceOfPattientService
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceOfPattientService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationViewModel<ServiceOfPattient>> GetAllWithPaginateAsync(FilterServiceOfPattientVM filterEntity)
        {
            var result = GetAll();

            if (filterEntity.DentalBranchId != Guid.Empty) result = result.Where(x => x.DentalBranchId == filterEntity.DentalBranchId); 

            var total = result.Count();
            var pages = total / filterEntity.QuantityByPage;

            return new PaginationViewModel<ServiceOfPattient>
            {
                ActualPage = filterEntity.Page,
                Pages = pages,
                Total = total,
                Entities = await result.Skip((filterEntity.Page - 1) * filterEntity.QuantityByPage).Take(filterEntity.QuantityByPage)
                .OrderByDescending(x => x.CreateAt).ToListAsync()
            };
        }
    }
}
