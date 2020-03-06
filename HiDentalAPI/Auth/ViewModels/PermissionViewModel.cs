using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.ViewModels
{
    public class PermissionViewModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string MenuName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool IsChecked { get; set; }
        public bool HasChild { get; set; }
        public bool IsExpanded { get; set; }
        public string ParentId { get; set; }
    }
}
