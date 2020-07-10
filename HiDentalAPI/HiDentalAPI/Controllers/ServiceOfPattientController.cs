using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.UnitOfWork;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.Responses;
using DataBaseLayer.ViewModels.ServiceOfPattients;
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
        public async Task<IActionResult> GetAll([FromQuery] FilterServiceOfPattientVM filter)
            => Ok(await _service.ServiceOfPattientService.GetAllWithPaginateAsync(filter));

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.ServiceOfPattientService.GetById(id);
            if (result == null) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "El servicio no existe" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceOfPattient model)
        {
            var result = await _service.ServiceOfPattientService.Add(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Error intente de nuevo" });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServiceOfPattient model)
        {
            var exist = await _service.ServiceOfPattientService.GetById(model.Id);
            if (exist == null) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "El servicio no existe" });
            return Ok(await _service.ServiceOfPattientService.Update(model));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var exist = await _service.ServiceOfPattientService.GetById(id);
            if (exist == null) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "El servicio no existe" });
            return Ok(await _service.ServiceOfPattientService.Remove(exist));
        }

    }
}