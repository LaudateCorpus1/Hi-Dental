using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Plan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IServiceOfPattientService : IBaseRepository<ServiceOfPattient>
    {
        Task<IEnumerable<ServiceOfPattient>> GetListByDentalBrach(Guid id);
    }
}
