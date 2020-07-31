using DatabaseLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.ViewModels.Users
{
    public class PermissionViewModel : IdentityRole
    {
        public string MenuName { get; set; }
        public State State { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool IsChecked { get; set; }
        public bool HasChild { get; set; }
        public bool IsExpanded { get; set; }
        public string ParentId { get; set; }
    }

    public class PermissionAddViewModel
    {
        [Required]
        public string Name { get; set; }
        public string MenuName { get; set; }
        public bool IsChecked { get; set; } = false;
        public bool HasChild { get; set; } = false;
        public bool IsExpanded { get; set; } = false;
        public string ParentId { get; set; }

    }
}
