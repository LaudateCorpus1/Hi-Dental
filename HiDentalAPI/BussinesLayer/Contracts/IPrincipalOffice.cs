using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.ViewModels.PrincipalOffice;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IPrincipalOfficeService : IBaseRepository<PrincipalOffice>, IHelperServiceStructure<Guid>, IPaginationService<PrincipalOffice, FilterOfficeViewModel>
    {
        Task<PrincipalOffice> GetWithChildrenBranchsAsync(Guid id);
        Task<IEnumerable<DentalBranch>> DentalBranches(Guid id);
    }
}
