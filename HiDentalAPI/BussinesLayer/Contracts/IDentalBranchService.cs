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
        Task<IEnumerable<DentalBranch>> GetAllByPrincipalOfficeId(Guid id);
        Task<IEnumerable<DentalBranch>> GetAllSecondBranches(Guid id);
    }
}
