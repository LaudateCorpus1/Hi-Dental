using Auth.ViewModels;
using System;
using System.Collections.Generic;

namespace Auth.Models
{
    public class AuthResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Expire { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }
        public string UserName { get; set; }
    }
}
