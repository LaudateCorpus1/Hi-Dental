using AutoMapper;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DatabaseLayer.ViewModels.Users;
using DataBaseLayer.Models;

namespace DataBaseLayer.MappingProfiles
{
    public class SharedMap : Profile
    {
        public SharedMap()
        {
            CreateMap<CreateUserViewModel, User>().ReverseMap();
            CreateMap<UserPermission, PermissionViewModel>().ReverseMap();
        }
    }
}
