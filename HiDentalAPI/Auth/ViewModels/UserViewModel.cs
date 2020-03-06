using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6,ErrorMessage = "La contraseña debe ser mayor a 6")]
        public string Password { get; set; }
    }

    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe ser mayor a 6")]
        public string Password { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }
    }
}
