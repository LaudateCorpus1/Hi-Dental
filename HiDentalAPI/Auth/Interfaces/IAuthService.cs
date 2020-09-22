using Auth.Models;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using System.Threading.Tasks;

namespace Auth.Interfaces
{
    public interface IAuthService
    {
        Task<User> SignIn(UserLoginViewModel model);
        Task<bool> Register(CreateUserViewModel model);
        Task<AuthResult> BuildToken(UserLoginViewModel model);
    }
}
