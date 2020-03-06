using Auth.Models;
using Auth.ViewModels;
using DatabaseLayer.Models;
using System.Threading.Tasks;

namespace Auth.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignIn(UserViewModel model);
        Task<bool> Register(CreateUserViewModel model);
        Task<AuthResult> BuildToken(UserViewModel model);
    }
}
