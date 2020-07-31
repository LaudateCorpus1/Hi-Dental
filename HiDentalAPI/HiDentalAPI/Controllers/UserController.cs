using AutoMapper;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DataBaseLayer.Enums;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Email;
using DataBaseLayer.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Es requerido");
            return Ok(_mapper.Map<UserViewModel>(await _service.UserService.GetUserById(id)));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Es requerido");
            var result = await _service.UserService.SoftDelete(id);
            if (!result) return BadRequest("No se ha podido agregar, intente de nuevo");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            if (!ModelState.IsValid) return BadRequest(user);
            var result = await _service.UserService.UpdateAsync(user);
            if (!result) return BadRequest("No se ha podido actualizar , intente de nuevo");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetail(UserDetail model)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            var result = await _service.UserService.UpdateDetailAsync(model);
            if (!result) return BadRequest("No se ha podido actualizar , intente de nuevo");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterUserViewModel filter)
        {
            if (filter.CreatedBy.IsNull() && filter.DentalBranchId == Guid.Empty) return BadRequest("Parametros invalidos");
            return Ok(await _service.UserService.GetAllWithPaginateAsync(filter));
        }

        [HttpPost]
        public async Task<IActionResult> Filter([FromQuery]FilterUserViewModel filters)
        {
            if (filters.Names.IsNull() && filters.LastNames.IsNull() && filters.IndentityDocument.IsNull())
            {
                return BadRequest("Los parametros del filtro estan vacios");
            }
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _service.UserService.FilterAsync(filters)));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordEmail(EmailViewModel email)
        {
            var result = await _service.UserService.SendEmailChangePasswordAsync(email);
            if (!result) return NoContent();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel model)
        {
            if(!await _service.UserService.ValidateKeyOfChangePassword(model.Key)) return BadRequest("Key invalida");
            var result = await _service.UserService.ChangePasswordAsync(model);
            if (!result) return NoContent();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserToRoleViewModel model)
        {
            var isInRole = await _service.UserService.UserIsInRoleAsync(model);
            if (isInRole) return BadRequest("El usuario ya tiene este rol asignado");
            var result = await _service.UserService.AddUserToRoleAsync(model);
            if (!result) return BadRequest("El usuario o rol no existe");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(UserToRoleViewModel model)
        {
            var isInRole = await _service.UserService.UserIsInRoleAsync(model);
            if (!isInRole) return BadRequest("El usuario no pertenece a este rol o permiso");
            var result = await _service.UserService.RemoveUserFromRoleAsync(model);
            if (!result) return BadRequest("El usuario o rol no existe");
            return Ok(result);
        }
       
        [HttpPost]
        public async Task<IActionResult> AddDetail(UserDetail model)
        {
            var existUser = await _service.UserService.GetUserById(model.UserId);
            if (existUser == null) return BadRequest("No existe este usuario");
            var haveDetail = await _service.UserDetailService.FilterAsync(x => x.UserId == model.UserId);
            if (haveDetail.Any()) return BadRequest("Este usuario ya tiene un detalle");
            var result = await _service.UserDetailService.Add(model);
            if (!result) return BadRequest("Ocurrio un error, intente de nuevo");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllGender()
        {
            return Ok(Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateType(UserToTypeViewModel model)
        {
            var result = await _service.UserService.UpdateUserToTypeAsync(model);
            if (!result) return BadRequest("Lo sentimos , puede que este usuario no exista o el typo");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDentalBranch(UserToDentalBranchViewModel model)
        {
            var result = await _service.UserService.UpdateDentalBranchAsync(model);
            if (!result) return BadRequest("Lo sentimos , ha ocurrido un error. Puede que el usuario o sucursal no exista");
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> FindByUserName(string userName)
        {
            var result = _mapper.Map<UserViewModel>(await _service.UserService.GetByUserName(userName));
            if (result == null) return NoContent();
            return Ok(result);
        }
    }
}