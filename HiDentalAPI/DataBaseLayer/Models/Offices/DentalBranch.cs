using DataBaseLayer.Models.Commons;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DatabaseLayer.Models.Appointments;
using DatabaseLayer.Models.Patients;

namespace DataBaseLayer.Models.Offices
{
    public class DentalBranch : CommonsProperty
    {

        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Phone(ErrorMessage = "{0} Numero invalido")]
        public string PhoneNumber { get; set; }
        public bool IsPrincipal
        {
            get { return IsPrincipal; }
            set { IsPrincipal = PrincipalOfficeId.HasValue ? false : true; }
        }
        /// <summary>
        /// ID DE LA DENTALBRANCH PRINCIPAL
        /// </summary>
        public Guid? PrincipalOfficeId { get; set; }

        public virtual ICollection<Appointment> Appoiments { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
