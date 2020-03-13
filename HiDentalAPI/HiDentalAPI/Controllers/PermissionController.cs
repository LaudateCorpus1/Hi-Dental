using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DatabaseLayer.ViewModels.Users;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _services;
        private readonly IMapper _mapper;

        public PermissionController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _services = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _services.PermissionService.GetList());

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            if (id.IsNull()) {
                ModelState.AddModelError(nameof(id), "Requerido");
                return BadRequest(ModelState);
            } 
            var result = _mapper.Map<PermissionViewModel>(await _services.PermissionService.GetByIdentifier(id));           
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByName(string name)
        {
            if (name.IsNull())
            {
                ModelState.AddModelError(nameof(name), "Requerido");
                return BadRequest(ModelState);
            }
            var result = _mapper.Map<IEnumerable<PermissionViewModel>>(await _services.PermissionService.FilterAsync(x => x.Name.Contains(name)));
            if (result == null) return NoContent();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PermissionAddViewModel permission)
        {
            if (!permission.ParentId.IsNull())
            {
                var result = await _services.PermissionService.GetByIdentifier(permission.ParentId);
                if(result == null)
                {
                    ModelState.AddModelError(nameof(permission.ParentId), "El parentId no existe");
                    return BadRequest(ModelState);
                }
            }
            var resultRole = await _services.PermissionService.Create(new Permission { Name = permission.Name });
            if (!resultRole)
            {
                ModelState.AddModelError(nameof(permission.Name), "Ya existe un permiso con ese nombre");
                return BadRequest(ModelState);
            }
            return Ok(resultRole);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (id.IsNull())
            {
                ModelState.AddModelError(nameof(id), "Requerido");
                return BadRequest(ModelState);
            }
            var result = await _services.PermissionService.GetByIdentifier(id);
            if (result == null) return NotFound();
            return Ok(await _services.PermissionService.Remove(result));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PermissionViewModel permission)
        {
            if (permission == null)
            {
                ModelState.AddModelError(nameof(permission), "Requerido");
                return BadRequest(ModelState);
            }
            var map = _mapper.Map<Permission>(permission);
            var result = await _services.PermissionService.UpdateByProperties(map);
            if (!result) return NotFound();
            return Ok(result);
        }



    }
}