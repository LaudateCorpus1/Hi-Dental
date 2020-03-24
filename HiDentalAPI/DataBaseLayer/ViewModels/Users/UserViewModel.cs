using DatabaseLayer.Enums;
using DataBaseLayer.Enums;
using DataBaseLayer.Models.Commons;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataBaseLayer.ViewModels.Users
{

    /// <summary>
    /// Modelo para mapear el modelo User
    /// </summary>
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string UserName { get; set; }
        public DateTime CreateAt { get; set; } 
        public DateTime UpdateAt { get; set; } 
        public State State { get; set; }
        public string CreatedBy { get; set; }
        public TypeOfCreation CreationType { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserDetailViewModel UserDetail { get; set; }
        public Guid DentalBranchId { get; set; }
        public Models.Offices.DentalBranch DentalBranch { get; set; }
    }

    /// <summary>
    /// VM para agregar un usuario a un rol
    /// </summary>
    public class UserToRoleViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }

    /// <summary>
    /// VM para agregar un usuario a un tipo
    /// </summary>
    public class UserToTypeViewModel
    {
        [Required]
        public Guid UserDetailId { get; set; }

        [Required]
        public Guid TypeId { get; set; }
    }

    /// <summary>
    /// VM para agregar un usuario a una sucursal
    /// </summary>
    public class UserToDentalBranchViewModel
    {
        [Required]
        public Guid DentalBranchId { get; set; }

        [Required]
        public string UserId { get; set; }
    }

    /// <summary>
    /// VM para mapear el userDetail to UserDetailViewModel
    /// </summary>
    public class UserDetailViewModel : CommonsProperty
    {
        public string Description { get; set; }
        public string IdentityDocument { get; set; }
        public string Gender { get; set; }
        public Guid UserTypeId { get; set; }
        public UserTypeViewModel UserType { get; set; }
        public string UserId { get; set; }
    }
    /// <summary>
    /// VM para mapear el userType al userTypeViewModel
    /// </summary>
    public class UserTypeViewModel : CommonsProperty
    {
        public string Name { get; set; }
    }
}
