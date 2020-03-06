using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace DataBaseLayer.Models
{
    public class UserPermission : IdentityUserRole<string>
    {
        public Permission Role { get; set; }
        public User User { get; set; }
    } 
}
