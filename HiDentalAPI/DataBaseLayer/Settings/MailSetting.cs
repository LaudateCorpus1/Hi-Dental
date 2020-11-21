using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Settings
{
    public class MailSetting
    {
        public string SmtpClient { get; set; }
        public string From { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
