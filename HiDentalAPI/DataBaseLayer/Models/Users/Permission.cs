using DatabaseLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataBaseLayer.Models.Users
{
    public class Permission : IdentityRole
    {
        public string MenuName { get; set; }
        public State State { get; set; } = State.Active;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool IsChecked { get; set; }
        public bool HasChild { get; set; }
        public bool IsExpanded { get; set; }
        public string ParentId { get; set; }
        [JsonIgnore]
        public ICollection<UserPermission> Users { get; set; }

    }
}
