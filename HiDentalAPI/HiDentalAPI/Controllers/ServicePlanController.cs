using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicePlanController : ControllerBase
    {
        private readonly IUnitOfWork _services;
        public ServicePlanController(IUnitOfWork services) => _services = services;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _services.ServicePlanService.GetList());

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id.IsEmpty()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Id invalido" });
            var result = await _services.ServicePlanService.GetById(id);
            if (result == null) return BadRequest(new ResponseBase { Code = CodeResponse.NotFound , Message = "No encontrado" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicePlan model)
        {
            if (model.PlanId.IsEmpty() && model.ServiceOfPattientId.IsEmpty()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams , Message = "PlanId y ServiceOfPattientId son requeridos" });
            var result = await _services.ServicePlanService.Add(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError , Message = "Intente nuevamente" });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServicePlan model)
        {
            if (model.PlanId.IsEmpty() && model.ServiceOfPattientId.IsEmpty()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "PlanId y ServiceOfPattientId son requeridos" });
            var result = await _services.ServicePlanService.Update(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Intente nuevamente" });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (id.IsEmpty()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Id invalido" });
            var exist = await _services.ServicePlanService.GetById(id);
            if (exist == null) return BadRequest(new ResponseBase { Code = CodeResponse.NotFound, Message = "No encontrado" });
            var result = await _services.ServicePlanService.Remove(exist);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Intente de nuevo mas tarde" });
            return Ok(result);
        }

    }
}