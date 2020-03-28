using System.Threading.Tasks;
using Auth.Interfaces;
using BussinesLayer.Contracts;

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
        IPrincipalOfficeService PrincipalOfficeService { get; }
        IDentalBranchService DentalBranchService { get; }
        IServiceOfPattientService ServiceOfPattientService { get; }

        Task Commit();
    }
}