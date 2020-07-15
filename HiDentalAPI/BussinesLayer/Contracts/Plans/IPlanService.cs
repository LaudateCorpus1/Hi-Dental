using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.Plan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts.Plans
{
    public interface IPlanService : IBaseRepository<Plan>, IPaginationService<Plan, FilterPlanViewModel> , IHelperServiceStructure<Guid>
    {
        /// <summary>
        /// Agrega un servicio a un plan
        /// </summary>
        /// <returns>boolean</returns>
        Task<bool> AddServiceToPlan(ServicePlan model);
    }
}
