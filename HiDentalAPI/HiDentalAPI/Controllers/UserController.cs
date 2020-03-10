using AutoMapper;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Users;
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
        public UserController(IUnitOfWork service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError(nameof(id), "Es requerido");
                return BadRequest(ModelState);
            }
            return Ok(_mapper.Map<UserViewModel>(await _service.UserService.GetUserById(id)));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError(nameof(id), "Es requerido");
                return BadRequest(ModelState);
            }
            var result = await _service.UserService.SoftDelete(id);
            if (!result)
            {
                ModelState.AddModelError(nameof(User), "No se ha podido agregar, intente de nuevo");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            if (!ModelState.IsValid) return BadRequest(user);
            var result = await _service.UserService.UpdateAsync(user);
            if (!result)
            {
                ModelState.AddModelError(nameof(user), "No se ha podido actualizar , intente de nuevo");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetail(UserDetail model)
        {
            if (!ModelState.IsValid) return BadRequest(model);
            var result = await _service.UserService.UpdateDetailAsync(model);
            if (!result)
            {
                ModelState.AddModelError(nameof(UserDetail), "No se ha podido actualizar , intente de nuevo");
                return BadRequest(ModelState);
            }
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
                ModelState.AddModelError(nameof(FilterUserViewModel), "Los parametros del filtro estan vacios");
                return BadRequest(ModelState);
            }
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _service.UserService.FilterAsync(filters)));
        }

    }
}