using DatabaseLayer.Models.Patients;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Enums.Appointment;
using DataBaseLayer.Models.Commons;
using DataBaseLayer.Models.Offices;
using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models.Appointments
{
    public class Appointment : CommonsProperty
    {
        public string Subject { get; set; }
        public string Note { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        /// <summary>
        /// CREATED BY
        /// </summary>
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Guid DentalBranchId { get; set; }
        public DentalBranch DentalBranch { get; set; }


        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public AppointmentState AppointmentState { get; set; }

    }
}
