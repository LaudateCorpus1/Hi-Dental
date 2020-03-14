using DatabaseLayer.Models.Users;
using DataBaseLayer.Enums;
using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataBaseLayer.Models.Users
{
    public class UserDetail 
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string IdentityDocument { get; set; }
        public string Gender { get; set; }
        [Required]
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

    }
    /// <summary>
    /// Define the TypeUsers
    /// </summary>
    public class UserType : CommonsProperty
    {
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
