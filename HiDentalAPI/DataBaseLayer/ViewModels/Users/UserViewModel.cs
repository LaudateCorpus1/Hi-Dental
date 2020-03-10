using DatabaseLayer.Enums;
using DataBaseLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.Users
{
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
    }

    public class UserDetailViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string IdentityDocument { get; set; }
        public string Gender { get; set; }
        public Guid UserTypeId { get; set; }
        public string UserId { get; set; }
    }

}
