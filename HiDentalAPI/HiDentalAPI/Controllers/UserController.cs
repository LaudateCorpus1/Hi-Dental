﻿using AutoMapper;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Email;
using DataBaseLayer.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetUserDetail(string id)
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
        public async Task<IActionResult> GetAll(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("id es requerido");
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _service.UserService.GetAllByUserAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Filter(FilterUserViewModel filters)
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
            if(!await _service.UserService.ValidateKeyOfChangePassword(model.key)) return BadRequest("Key invalida");
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
    }
}