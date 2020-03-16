using Auth.Interfaces;
using Auth.Services;
using AutoMapper;
using BussinesLayer.Contracts;
using BussinesLayer.Services;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BussinesLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<AppSetting> _appSettings;
        private readonly IMapper _mapper;

        #region for user
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Permission> _roleManager;
        private readonly IOptions<AuthSetting> _settings;
        #endregion

        #region services
        private AuthService _authService;
        private PatientService _patientService;
        private UserService _userService;
        private PermissionService _permissionService;
        private UserTypeService _userTypeService;
        private UserDetailService _userDetailService;
        private PrincipalOfficeService _principalOfficeService;
        private DentalBranchService _dentalBranchService;
        #endregion


        public UnitOfWork(ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Permission> roleManager,
            IOptions<AuthSetting> settings,
            IOptions<AppSetting> appSetting,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _settings = settings;
            _appSettings = appSetting;
            _mapper = mapper;
        }
        public IPatientService PatientService => _patientService ?? (_patientService = new PatientService(_context));

        public IAuthService AuthService => _authService ?? (_authService = new AuthService(_userManager, _signInManager, _settings, _context , _appSettings));

        public IUserService UserService => _userService ?? (_userService = new UserService(_context, _userManager, _appSettings , _mapper));

        public IPermissionService PermissionService => _permissionService ?? (_permissionService = new PermissionService(_context, _roleManager));

        public IUserTypeService UserTypeService => _userTypeService ?? (_userTypeService = new UserTypeService(_context));

        public IUserDetailService UserDetailService => _userDetailService ?? (_userDetailService = new UserDetailService(_context));

        public IPrincipalOfficeService PrincipalOfficeService => _principalOfficeService ?? (_principalOfficeService = new PrincipalOfficeService(_context));

        public IDentalBranchService DentalBranchService => _dentalBranchService ?? (_dentalBranchService = new DentalBranchService(_context));
        async Task IUnitOfWork.Commit() => await _context.SaveChangesAsync();
    }
}
