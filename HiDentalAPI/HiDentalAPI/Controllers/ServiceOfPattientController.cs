using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.UnitOfWork;
using DataBaseLayer.Models.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceOfPattientController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public ServiceOfPattientController(IUnitOfWork service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid dentalBranchId) => Ok(await _service.ServiceOfPattientService.GetListByDentalBrach(dentalBranchId));

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.ServiceOfPattientService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceOfPattient model)
        {
            var result = await _service.ServiceOfPattientService.Add(model);
            if (!result) return BadRequest("Error intente de nuevo");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServiceOfPattient model)
        {
            var exist = await _service.ServiceOfPattientService.GetById(model.Id);
            if (exist == null) return NotFound();
            return Ok(await _service.ServiceOfPattientService.Update(model));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var exist = await _service.ServiceOfPattientService.GetById(id);
            if (exist == null) return NotFound();
            return Ok(await _service.ServiceOfPattientService.Remove(exist));
        }
        
    }
}