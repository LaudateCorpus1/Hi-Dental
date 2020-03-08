using Auth.Models;
using DatabaseLayer.Users.ViewModels;
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
