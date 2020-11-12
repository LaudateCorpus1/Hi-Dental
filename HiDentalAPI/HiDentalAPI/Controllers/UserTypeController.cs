using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUnitOfWork _services;
        public UserTypeController(IUnitOfWork unitOfWork) => _services = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _services.UserTypeService.GetList());

        [HttpPost]
        public async Task<IActionResult> Create(UserType model)
        {
            var exist = await _services.UserTypeService.Filter(x => x.Name == model.Name).ToListAsync();
            if (exist.Any()) return BadRequest("Ya existe este tipo de usuario , intente con otro nombre");
            var result = await _services.UserTypeService.Add(model);
            if (!result) return BadRequest("Intente nuevamente");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _services.UserTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Filter(string name)
        {
            if (name.IsNull()) return BadRequest("Parametro requerido");
            var model = await _services.UserTypeService.Filter(name);
            if (model == null) return NoContent();
            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _services.UserTypeService.GetById(id);
            if (result == null) return NotFound();
            var response = await _services.UserTypeService.SoftDelete(id);
            if (!response) return BadRequest("Occurrió un error intente de nuevo");
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserType model)
        {
            var existId = await _services.UserTypeService.Filter(x => x.Id == model.Id).AnyAsync();
            if (!existId) return BadRequest("No existe este tipo de usuario");
            var existName = await _services.UserTypeService.Filter(x => x.Name == model.Name).ToListAsync();
            if (existName.Any()) return BadRequest("Ya existe este tipo de usuario , intente con otro nombre");
            var result = await _services.UserTypeService.Update(model);
            if (!result) return BadRequest("ocurrio un error intente de nuevo");
            return Ok(result);
        }
    }
}