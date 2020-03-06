using Auth.ViewModels;
using BussinesLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public AuthController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> SigIn(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AuthService.SignIn(model);
                if (result) return Ok(await _service.AuthService.BuildToken(model));
            }
            return BadRequest(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AuthService.Register(model);
                if (result) return Ok(await _service.AuthService.BuildToken(new UserViewModel { UserName = model.UserName, Password = model.Password }));
            }
            return BadRequest(model);
        }
    }
}