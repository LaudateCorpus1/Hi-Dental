using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IDentalBranchService : IBaseRepository<DentalBranch> , IHelperServiceStructure<Guid>
    {
        Task<IEnumerable<DentalBranch>> GetAllByPrincipalOfficeId(Guid id);
        Task<IEnumerable<DentalBranch>> GetAllSecondBranches(Guid id);
    }
}
