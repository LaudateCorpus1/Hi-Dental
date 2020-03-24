using DataBaseLayer.Models.Commons;
using DataBaseLayer.Models.Offices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Models
{
    public class PrincipalOffice : CommonsProperty
    {
        public string Description { get; set; }
        public string Address { get; set; }
        [Required]
        public string Title { get; set; }
        [Phone(ErrorMessage = "{0} Invalido")]
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<DentalBranch> DentalBranches { get; set; }
    }
}
