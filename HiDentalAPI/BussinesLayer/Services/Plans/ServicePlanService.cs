using BussinesLayer.Contracts.Plans;
using BussinesLayer.Repository.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Services.Plans
{
    public class ServicePlanService : BaseRepository<ServicePlan>, IServicePlanService
    {
        public ServicePlanService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
