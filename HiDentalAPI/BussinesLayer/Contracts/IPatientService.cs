using BussinesLayer.Repository.Contracts;
using DatabaseLayer.Models;
using DatabaseLayer.Models.Patients;
using DataBaseLayer.ViewModels.Patient;
using System;

namespace BussinesLayer.Contracts
{
    public interface IPatientService : IBaseRepository<Patient>, IHelperServiceStructure<Guid> , IPaginationService<Patient , FilterPatientViewModel>
    {
      
    }
}
