using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinesLayer.UnitOfWork;
using DatabaseLayer.Enums;
using DataBaseLayer.Settings;
using DataBaseLayer.ViewModels.ComboBox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        private readonly AppSetting _appSetting;
        public ComboBoxController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSetting> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSetting = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> UserTypes()
            => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, State>>>(await _unitOfWork.UserTypeService.GetList(x => x.Name != _appSetting.DefautlUserType)));

        [HttpGet]
        public async Task<IActionResult> DentalBranchs()
            => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, Guid?>>>(await _unitOfWork.DentalBranchService.GetList(x => x.IsPrincipal == true)));

        [HttpGet]
        public async Task<IActionResult> DentalBranchsNotPrincipal(Guid principalId)
           => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, Guid?>>>(await _unitOfWork.DentalBranchService.GetList(x => x.IsPrincipal == false && x.PrincipalOfficeId == principalId)));

        [HttpGet("{dentalBranchId}")]
        public async Task<IActionResult> Patients(Guid dentalBranchId)
            => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, Guid?>>>(await _unitOfWork.PatientService.GetList(x => x.DentalBranchId == dentalBranchId)));
    
        [HttpGet("{dentalBranchId}")]
        public async Task<IActionResult> Profesionals(Guid dentalBranchId)
            => Ok(_mapper.Map<IEnumerable<ComboBoxViewModel<Guid, Guid?>>>(await _unitOfWork.UserService.GetAllDoctors(dentalBranchId)));

    }
}