using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace DataBaseLayer.Models
{
    public class UserPermission : IdentityUserRole<string>
    {
        public virtual Permission Role { get; set; }
        public virtual User User { get; set; }
    } 
}
