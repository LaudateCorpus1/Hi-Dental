using DatabaseLayer.Models.Patients;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Commons;
using DataBaseLayer.Models.Offices;
using System;

namespace DatabaseLayer.Models.Appointments
{
    public class Appointment : CommonsProperty
    {
        public string Objective { get; set; }
        public string Note { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        /// <summary>
        /// CREATED BY
        /// </summary>
        public string UserId { get; set; }
        public User User { get; set; }

        public Guid DentalBranchId { get; set; }
        public DentalBranch DentalBranch { get; set; }

    }
}
