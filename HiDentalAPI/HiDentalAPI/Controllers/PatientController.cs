using BussinesLayer.UnitOfWork;
using DatabaseLayer.Models.Patients;
using DataBaseLayer.ViewModels.Patient;
using Microsoft.AspNetCore.Mvc;
using System;
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
            if (result == null) return BadRequest("DentalBranchId invalido");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _services.PatientService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient model)
        {
            var result = await _services.PatientService.Add(model);
            if (!result) return BadRequest("Lo sentimos ocurrio un error, intente de nuevo");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Patient model)
        {
            var exist = await _services.PatientService.GetById(model.Id);
            if (exist == null) return NotFound();
            var result = await _services.PatientService.Update(model);
            if (!result) return BadRequest("Ocurrio un error intente de nuevo");
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
