using AutoMapper;
using DatabaseLayer.Enums;
using DatabaseLayer.Models.Patients;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Settings;
using DataBaseLayer.ViewModels.ComboBox;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.MappingProfiles
{
    public class ComboMap : Profile
    {
        public ComboMap()
        {
            CreateMap<UserType, ComboBoxViewModel<Guid, State>>()
                .ForMember(x => x.Code, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Title, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.Group, y => y.MapFrom(s => s.State))
                .ReverseMap();

            CreateMap<DentalBranch, ComboBoxViewModel<Guid, Guid?>>()
                .ForMember(x => x.Code, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Group, y => y.MapFrom(s => s.PrincipalOfficeId))
                .ReverseMap();

            CreateMap<Patient, ComboBoxViewModel<Guid, Guid?>>()
               .ForMember(x => x.Code, y => y.MapFrom(s => s.Id))
               .ForMember(x => x.Title, y => y.MapFrom(s => s.FullName))
               .ForMember(x => x.Group, y => y.MapFrom(s => s.DentalBranchId))
               .ReverseMap();

            CreateMap<User, ComboBoxViewModel<Guid, Guid?>>()
               .ForMember(x => x.Code, y => y.MapFrom(s => s.Id))
               .ForMember(x => x.Title, y => y.MapFrom(s => s.FullName))
               .ForMember(x => x.Group, y => y.MapFrom(s => s.DentalBranchId))
               .ReverseMap();
        }
    }
}
