using BussinesLayer.Repository.Contracts;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.ServiceOfPattients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts
{
    public interface IServiceOfPattientService : IBaseRepository<ServiceOfPatient> , IPaginationService<ServiceOfPatient,FilterServiceOfPattientVM>
    {
    }
}
