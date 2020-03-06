using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBaseLayer.Models.Users
{
    public class UserDetail 
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

    public class UserType : CommonsProperty
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
