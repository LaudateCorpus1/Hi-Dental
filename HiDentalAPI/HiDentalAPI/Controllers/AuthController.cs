using AutoMapper;
using BussinesLayer.UnitOfWork;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DataBaseLayer.Enums;
using DataBaseLayer.MappingProfiles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;

        public AuthController(IUnitOfWork service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> SigIn(UserLoginViewModel model)
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
            {   //define the type of creation
                if (string.IsNullOrEmpty(model.CreatedBy)) model.TypeOfCreation = TypeOfCreation.ByApp;
                var result = await _service.AuthService.Register(model);
                if (result) return Ok(await _service.AuthService.BuildToken(new UserLoginViewModel { UserName = model.UserName, Password = model.Password }));
            }
            return BadRequest(model);
        }
    }
}