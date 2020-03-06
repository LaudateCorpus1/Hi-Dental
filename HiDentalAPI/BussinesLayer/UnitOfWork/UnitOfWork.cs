using Auth.Interfaces;
using Auth.Services;
using BussinesLayer.Contracts;
using BussinesLayer.Services;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BussinesLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        #region for user
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptions<AuthSetting> _settings;
        #endregion
        private AuthService _authService;
        private PatientService _patientService;

        public UnitOfWork(ApplicationDbContext context, 
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<AuthSetting> settings)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _settings = settings;
        }
        public IPatientService PatientService => _patientService ?? (_patientService = new PatientService(_context));

        public IAuthService AuthService => _authService ?? (_authService = new AuthService(_userManager, _signInManager, _settings, _context));

        async Task IUnitOfWork.Commit() => await _context.SaveChangesAsync();
    }
}
