using BussinesLayer.Contracts.Plans;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Enums;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.Pagination;
using DataBaseLayer.ViewModels.Plan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Plans
{
    public class PlanService : BaseRepository<Plan>, IPlanService
    {
        private readonly ApplicationDbContext _dbContext;
        public PlanService(ApplicationDbContext dbContext) : base(dbContext)
         => _dbContext = dbContext;


        public async Task<PaginationViewModel<Plan>> GetAllWithPaginateAsync(FilterPlanViewModel filterEntity)
        {
            var results = GetAll();
            if(!string.IsNullOrEmpty(filterEntity.Title)) results = results.Where(x => x.Title.Contains(filterEntity.Title));
            var count = results.Count();
            var pages = count / filterEntity.QuantityByPage;

            return new PaginationViewModel<Plan>
            {
                ActualPage = filterEntity.Page,
                Pages = pages,
                Total = count,
                Entities = await results.Skip((filterEntity.Page - 1) * filterEntity.QuantityByPage)
                .Take(filterEntity.QuantityByPage)
                .ToListAsync()
            };

        }

        public async Task<bool> SoftDelete(Guid param)
        {
            var result = await GetById(param);
            if (result == null) return false;
            result.State = State.Removed;
            return await Update(result);
        }

        public async Task<bool> AddServiceToPlan(ServicePlan model)
        {
            _dbContext.PlanService.Add(model);
            return await CommitAsync();
        }
    }
}
