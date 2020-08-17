using AutoMapper;
using BussinesLayer.UnitOfWork;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DataBaseLayer.Enums;
using DataBaseLayer.MappingProfiles;
using DataBaseLayer.ViewModels.Responses;
using DataBaseLayer.ViewModels.Users;
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

        public AuthController(IUnitOfWork service, IMapper mapper)
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
                if (result == null) return BadRequest(new ResponseBase { Code = CodeResponse.NotExist, Message = "El usuario no existe" });
                return Ok(await _service.AuthService.BuildToken(new UserLoginViewModel
                {
                    UserName = result.UserName,
                    Password = string.Empty,
                    DentalBranchId = result.DentalBranchId,
                    Id = result.Id
                }));
            }
            return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Parametros invalidos", ObjError = model });
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {   //define the type of creation
                if (string.IsNullOrEmpty(model.CreatedBy)) model.TypeOfCreation = TypeOfCreation.ByApp;
                var result = await _service.AuthService.Register(model);
                if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Ocurrio un error intente de nuevo" });
                return Created(nameof(UserController.FindByUserName), new
                {
                    User = _mapper.Map<UserViewModel>(await _service.UserService.GetByUserName(model.UserName))
                });
            }
            return BadRequest(ModelState);
        }
    }
}