using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.UnitOfWork;
using Common.ExtensionsMethods;
using DataBaseLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DentalBranchController : ControllerBase
    {
        private readonly IUnitOfWork _sevices;
        public DentalBranchController(IUnitOfWork unitOfWork) => _sevices = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var result = (await _sevices.DentalBranchService.GetAllByPrincipalOfficeId(id));
            if (result == null) return BadRequest("esta oficina no tiene subsucursales");
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
        public async Task<IActionResult> GetAllSecondBranches(Guid id)
        {
            var result = await _sevices.DentalBranchService.GetAllSecondBranches(id);
            if (result == null) return BadRequest("Esta sucursal no tiene subs sucursales");
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Filter(string title)
        {
            if (title.IsNull()) return BadRequest("parametros invalidos");
            var result = await _sevices.DentalBranchService.FilterAsync(x => x.Title.Contains(title));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DentalBranch model)
        {
            var result = await _sevices.DentalBranchService.Add(model);
            if (!result) return BadRequest("Intente de nuevo");
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
            if (!result) return BadRequest("Intente de nuevo");
            return Ok(result);
        }
    }
}