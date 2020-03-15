using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IPrincipalOfficeService : IBaseRepository<PrincipalOffice> , IHelperServiceStructure<Guid>
    {
        Task<PrincipalOffice> GetWithChildrenBranchsAsync(Guid id);
    }
}
