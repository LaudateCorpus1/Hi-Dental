using AutoMapper;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Users.ViewModels;
using DatabaseLayer.ViewModels.Users;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Users;
using DataBaseLayer.ViewModels.Users;

namespace DataBaseLayer.MappingProfiles
{
    public class SharedMap : Profile
    {
        public SharedMap()
        {
            CreateMap<User, CreateUserViewModel> ().ReverseMap();
            CreateMap<Permission, PermissionViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserLoginViewModel>().ReverseMap();
            CreateMap<UserDetail, UserDetailViewModel>().ReverseMap();
            CreateMap<UserType, UserTypeViewModel>().ReverseMap();
            CreateMap<Permission, PermissionViewModel>().ReverseMap();

        }
    }
}
