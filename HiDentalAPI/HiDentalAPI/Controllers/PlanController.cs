using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.Services.Plans;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.ViewModels.Plan;
using DataBaseLayer.ViewModels.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IUnitOfWork _services;
        public PlanController(IUnitOfWork services) => _services = services;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterPlanViewModel filter) => Ok(await _services.PlanService.GetAllWithPaginateAsync(filter));

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id.IsEmpty()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Parametro id invalido" });
            var result = await _services.PlanService.GetById(id);
            if (result == null) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "Lo sentimos, no encontrado" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Plan model)
        {
            var result = await _services.PlanService.Add(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Ha ocurrido un error, intente de nuevo mas tarde" });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Plan model)
        {
            if (model.Id.IsEmpty()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "Parametro id requerido" });
            var result = await _services.PlanService.Update(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Ha ocurrido un error, intente de nuevo" });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _services.PlanService.SoftDelete(id);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Ha ocurrido un error, intente de nuevo mas tarde" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlanService(ServicePlan model)
        {
            var result = await _services.PlanService.AddServiceToPlan(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Ha ocurrido un error, intente de nuevo" });
            return Ok(result);
        }
    }
}