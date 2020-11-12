using BussinesLayer.UnitOfWork;
using DatabaseLayer.Models.Patients;
using DataBaseLayer.ViewModels.Patient;
using DataBaseLayer.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _services;
        public PatientController(IUnitOfWork unitOfWork) => _services = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]FilterPatientViewModel model)
        {
            var result = await _services.PatientService.GetAllWithPaginateAsync(model);
            if (result == null) return BadRequest(new ResponseBase { Code = CodeResponse.NotExist, Message = "No hay pacientes para dicha sucursal" });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _services.PatientService.GetById(id);
            if (result == null) return NotFound(new ResponseBase { Code = CodeResponse.NotExist, Message = "Paciente no encontrado" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient model)
        {
            var result = await _services.PatientService.Add(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Lo sentimos ocurrio un error, intente de nuevo" });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Patient model)
        {
            var exist = _services.PatientService.GetAll().Any(x => x.Id == model.Id);
            if (!exist) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "Paciente No encontrado" });
            var result = await _services.PatientService.Update(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Ocurrio un error intente de nuevo" });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var exist = await _services.PatientService.GetById(id);
            if (exist == null) return NotFound();
            return Ok(await _services.PatientService.SoftDelete(id));
        }
    }
}
