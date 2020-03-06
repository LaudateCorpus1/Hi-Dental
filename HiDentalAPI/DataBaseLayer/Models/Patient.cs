using DataBaseLayer.Models.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class Patient : CommonsProperty
    {
        [Required(ErrorMessage = "EL CAMPO {0} ES REQUERIDO")]
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }
        [Required]
        public string Identification_card { get; set; }
        [Required]
        public string Address { get; set; }
        public string Address_Office { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Referred_to_by{ get; set; }
        [Required]
        public string Cellphone_number{ get; set; }
        public string PhoneNumber_Office { get; set; }
        [Required]
        public string BirthDate { get; set; }

        public virtual IEnumerable<Appointment> Appointments { get; set; }
        public virtual IEnumerable<Consultation> Consultations { get; set; }

    
    }
    
}
