using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Settings
{
    public class AppSetting
    {
        public bool IsDevelopment { get; set; }
        public string[] DefaultPermissions { get; set; }
        public UserApp User { get; set; }
    }

    /// <summary>
    /// Alone for Use in AppSetting class
    /// </summary>
    public class UserApp
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Names { get => UserName; }
        public string LastName { get => UserName; }
    }
}
