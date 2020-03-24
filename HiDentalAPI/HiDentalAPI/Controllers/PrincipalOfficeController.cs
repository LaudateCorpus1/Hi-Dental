using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.UnitOfWork;
using DataBaseLayer.Models;
using DataBaseLayer.ViewModels.PrincipalOffice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrincipalOfficeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrincipalOfficeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]FilterOfficeViewModel filter) 
            => Ok(await _unitOfWork.PrincipalOfficeService.GetAllWithPaginateAsync(filter));

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _unitOfWork.PrincipalOfficeService.GetWithChildrenBranchsAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrincipalOffice model)
        {
            var result = await _unitOfWork.PrincipalOfficeService.Add(model);
            if (!result) return BadRequest("Intente de nuevo");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDentalBranches(Guid id)
        {
            var exist = await _unitOfWork.PrincipalOfficeService.GetById(id);
            if (exist == null) return BadRequest("La oficina principal no existe , intente nuevamente ");
            return Ok(await _unitOfWork.PrincipalOfficeService.DentalBranches(exist.Id));
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string title)
            => Ok(await _unitOfWork.PrincipalOfficeService.FilterAsync(x => x.Title.Contains(title)));

        [HttpPut]
        public async Task<IActionResult> Update(PrincipalOffice model)
        {
            var result = await _unitOfWork.PrincipalOfficeService.Update(model);
            if (!result) return BadRequest("Ocurrio un error intente de nuevo");
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _unitOfWork.PrincipalOfficeService.SoftDelete(id);
            if (!result) return BadRequest("Lo sentimos, intente de nuevo");
            return Ok(result);
        }
    }
}