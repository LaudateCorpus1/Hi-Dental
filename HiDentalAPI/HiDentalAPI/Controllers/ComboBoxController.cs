using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinesLayer.UnitOfWork;
using DatabaseLayer.Enums;
using DataBaseLayer.ViewModels.ComboBox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiDentalAPI.Controllers
{
    /// <summary>
    /// This concept is suggested by Lony Mejia.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComboBoxController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ComboBoxController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> UserTypes() => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid,State>>>(await _unitOfWork.UserTypeService.GetList()));

        [HttpGet]
        public async Task<IActionResult> PrincipalOffices()
            => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, string>>>(await _unitOfWork.PrincipalOfficeService.GetList()));

        [HttpGet]
        public async Task<IActionResult> DentalBranchs()
            => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, Guid>>>(await _unitOfWork.DentalBranchService.GetList()));
    
    }
}