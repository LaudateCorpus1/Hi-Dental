using DatabaseLayer.Enums;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models.Users
{
    public class User : IdentityUser
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public int Gender { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public State State { get; set; } = State.Active;
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Consultation> Consults { get; set; }
        public virtual ICollection<UserPermission> UserRoles { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
