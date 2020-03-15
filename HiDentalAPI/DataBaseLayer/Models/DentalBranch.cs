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
        public string Address { get; set; }
        public string Title { get; set; }
        [Phone(ErrorMessage = "Numero invalido")]
        public string PhoneNumber { get; set; }
        public Guid PrincipalOfficeId { get; set; }
        public PrincipalOffice PrincipalOffice { get; set; }
    }
}
