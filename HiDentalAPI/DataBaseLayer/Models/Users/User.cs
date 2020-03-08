using DatabaseLayer.Enums;
using DataBaseLayer.Enums;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models.Users
{
    public class User : IdentityUser
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public State State { get; set; } = State.Active;
        public string CreatedBy { get; set; } = nameof(TypeOfCreation.ByApp);
        /// <summary>
         /// Define the type of user creation
        /// if it's for the app, the property createdBy is ByApp otherwise it will have the creator id
        /// </summary>
        public TypeOfCreation CreationType { get; set; } = TypeOfCreation.ByUser;
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Consultation> Consults { get; set; }
        public virtual ICollection<UserPermission> UserRoles { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
