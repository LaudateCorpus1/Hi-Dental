using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.ViewModels.DentalBranch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IDentalBranchService : IBaseRepository<DentalBranch>, IHelperServiceStructure<Guid>, IPaginationService<DentalBranch, FilterDentalBranchViewModel>
    {
        /// <summary>
        /// Obtiene las sucursales dependientes de otras sucursales
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<DentalBranch>> GetAllByPrincipalOfficeId(Guid id);
    }
}
