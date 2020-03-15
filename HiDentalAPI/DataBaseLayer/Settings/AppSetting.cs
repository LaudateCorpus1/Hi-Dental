using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Settings
{
    public class AppSetting
    {
        public string AppName { get; set; }
        public string RouteDev { get; set; }
        public string RouteProd { get; set; }
        public string DefautlUserType { get; set; }
        public string Route { get => IsDevelopment ? RouteDev : RouteProd; set { } }
        public bool IsDevelopment { get; set; }
        public string[] DefaultPermissions { get; set; }
        public UserApp User { get; set; }
        public Email Email { get; set; }
        public Office Office { get; set; }
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

    public class Email
    {
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string BaseEmail { get; set; }
        public string Password { get; set; }
        public string ChangePasswordEndPoint { get; set; }

    }

    public class Office
    {
        public string Name { get; set; }
    }
}
