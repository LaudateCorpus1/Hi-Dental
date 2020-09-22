using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DatabaseLayer.ViewModels.Users;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Responses;
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

        public PermissionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _services = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _services.PermissionService.GetList());

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            if (id.IsNull()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Parametro id es Requerido" });
            var result = _mapper.Map<PermissionViewModel>(await _services.PermissionService.GetByIdentifier(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByName(string name)
        {
            if (name.IsNull()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "parametro name Requerido" });
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
                if (result == null) return BadRequest(new ResponseBase { Code = CodeResponse.NotExist, Message = "El parentId no existe" });
            }
            var resultRole = await _services.PermissionService.Create(new Permission { Name = permission.Name });
            if (!resultRole) return BadRequest(new ResponseBase { Code = CodeResponse.Exist, Message = "Ya existe un permiso con ese nombre" });
            return Ok(resultRole);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            if (id.IsNull()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "id es requerido" });

            var result = await _services.PermissionService.GetByIdentifier(id);
            if (result == null) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "El permiso no existe" });
            return Ok(await _services.PermissionService.Remove(result));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PermissionViewModel permission)
        {

            if (permission == null) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Algunos parametros son requeridos" });
            var map = _mapper.Map<Permission>(permission);
            var result = await _services.PermissionService.UpdateByProperties(map);
            if (!result) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "Permiso no encontrado" });
            return Ok(result);
        }



    }
}