using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Models
{
    public class DentalBranch : CommonsProperty
    {
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Phone(ErrorMessage = "Numero invalido")]
        public string PhoneNumber { get; set; }
        [Required]
        public Guid PrincipalOfficeId { get; set; }
        public virtual PrincipalOffice PrincipalOffice { get; set; }
        public bool IsPrincipal { get; set; } = false;
    }
}
