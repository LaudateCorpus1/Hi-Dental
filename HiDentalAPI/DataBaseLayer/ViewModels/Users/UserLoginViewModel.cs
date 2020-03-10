using DataBaseLayer.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseLayer.Users.ViewModels
{
    public class UserLoginViewModel
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
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public TypeOfCreation TypeOfCreation { get; set; } = TypeOfCreation.ByUser;
    }
}
