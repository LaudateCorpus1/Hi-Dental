using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Settings
{
    public class AuthSetting
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string SecretKey { get; set; }
    }
}
