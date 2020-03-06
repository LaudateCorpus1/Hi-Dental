using System.Threading.Tasks;
using Auth.Interfaces;
using BussinesLayer.Contracts;

namespace BussinesLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthService AuthService { get; }
        IPatientService PatientService { get; }
        Task Commit();
    }
}