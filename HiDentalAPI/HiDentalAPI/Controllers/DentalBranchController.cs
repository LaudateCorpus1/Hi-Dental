using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.ViewModels.DentalBranch;
using DataBaseLayer.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DentalBranchController : ControllerBase
    {
        private readonly IUnitOfWork _sevices;
        public DentalBranchController(IUnitOfWork unitOfWork) => _sevices = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterDentalBranchViewModel filter)
        {
            var result = await _sevices.DentalBranchService.GetAllWithPaginateAsync(filter);
            if (result == null) return BadRequest(new ResponseBase { Code = CodeResponse.NotFound, Message = "esta oficina no tiene subsucursales" });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _sevices.DentalBranchService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByPrincipalOfficeId(Guid id)
        {
            var result = await _sevices.DentalBranchService.GetAllByPrincipalOfficeId(id);
            if (result == null) return NotFound(new ResponseBase { Code = CodeResponse.NotFound, Message = "Esta sucursal no existe" });
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Filter(string title)
        {
            if (title.IsNull()) return BadRequest(new ResponseBase { Code = CodeResponse.InvalidParams, Message = "parametros invalidos" });
            var result = await _sevices.DentalBranchService.FilterAsync(x => x.Title.Contains(title));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DentalBranch model)
        {
            var result = await _sevices.DentalBranchService.Add(model);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.DbError, Message = "Intente de nuevo" });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DentalBranch model)
        {
            var result = await _sevices.DentalBranchService.Update(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var exist = await _sevices.DentalBranchService.GetById(id);
            if (exist == null) return NotFound();
            var result = await _sevices.DentalBranchService.SoftDelete(id);
            if (!result) return BadRequest(new ResponseBase { Code = CodeResponse.Unknown, Message = "Intente de nuevo" });
            return Ok(result);
        }
    }
}