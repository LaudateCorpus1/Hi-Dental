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
    }
}
