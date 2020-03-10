using Auth.Models;
using DatabaseLayer.Users.ViewModels;
using System.Threading.Tasks;

namespace Auth.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignIn(UserLoginViewModel model);
        Task<bool> Register(CreateUserViewModel model);
        Task<AuthResult> BuildToken(UserLoginViewModel model);
    }
}
