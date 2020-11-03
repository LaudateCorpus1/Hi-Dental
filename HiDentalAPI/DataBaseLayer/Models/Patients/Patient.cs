using Common.Helpers;
using DatabaseLayer.Models.Appointments;
using DataBaseLayer.Enums;
using DataBaseLayer.Enums.Pattient;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Commons;
using DataBaseLayer.Models.Offices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseLayer.Models.Patients
{
    public class Patient : CommonsProperty
    {
        [Required(ErrorMessage = "EL CAMPO {0} ES REQUERIDO")]
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }
        public string IdentificationCard { get; set; }
        [Required]
        public string Address { get; set; }
        public string AddressOffice { get; set; }
        public string Photo { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string ReferredBy { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Phone]
        public string WorkPhoneNumber { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public bool MedicalAlert { get; set; }

        [Required]
        public Guid DentalBranchId { get; set; }
        public DentalBranch DentalBranch { get; set; }
        public string Note { get; set; }

        [JsonIgnore]
        public string Code { get; set; } = StringsHelper.GenerateRandomString(6);

        public virtual ICollection<Appointment> Appointment { get; set; }

        public StepForm StepForm { get; set; }

    }
}
