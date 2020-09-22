using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DatabaseLayer.Models.Appointments;
using DataBaseLayer.ViewModels.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _services;
        public AppointmentController(IUnitOfWork services)
            => _services = services;


        [HttpGet("{dentalBranchId}")]
        public async Task<IActionResult> GetAll(Guid dentalBranchId)
        {
            if (dentalBranchId.IsEmpty()) return NotFound(new ResponseBase { Code = CodeResponse.NotExist, Message = "El id de la oficina es requerido" });
            return Ok(await _services.AppointmentService.GetList(x => x.DentalBranchId == dentalBranchId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _services.AppointmentService.GetById(id);
            if (result == null) return NotFound(new ResponseBase { Code = CodeResponse.NotExist, Message = "No encontrado" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment model)
        {
            var result = await _services.AppointmentService.Add(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.NotExist, Message = "Lo sentimos, intente de nuevo mas tarde" });
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Appointment model)
        {
            var result = await _services.AppointmentService.Update(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.NotExist, Message = "Lo sentimos, intente de nuevo mas tarde" });
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _services.AppointmentService.Remove(new Appointment { Id = id });
            if(!result) return BadRequest(new ResponseBase { Code = CodeResponse.NotExist, Message = "Lo sentimos, intente de nuevo mas tarde" });
            return Ok(result);
        }
    }
}