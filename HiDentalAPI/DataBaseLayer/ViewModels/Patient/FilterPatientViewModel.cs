using DataBaseLayer.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.ViewModels.Patient
{
    public class FilterPatientViewModel : FilterCommon
    {
        [Required]
        public Guid DentalBranchId { get; set; }
        public string Name { get; set; }
        public string LastNames { get; set; }
        public string IdentityCard { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }    
    }
}
