using System.Threading.Tasks;
using Auth.Interfaces;
using BussinesLayer.Contracts;
using BussinesLayer.Contracts.Appointments;
using BussinesLayer.Contracts.Plans;

namespace BussinesLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthService AuthService { get; }
        IPatientService PatientService { get; }
        IUserService UserService { get; }
        IPermissionService PermissionService { get; }
        IUserTypeService UserTypeService { get; }
        IUserDetailService UserDetailService { get; }
        IDentalBranchService DentalBranchService { get; }
        IServiceOfPattientService ServiceOfPattientService { get; }
        IPlanService PlanService { get; }
        IServicePlanService ServicePlanService { get; }

        IAppointmentService AppointmentService { get; }

        Task Commit();
    }
}