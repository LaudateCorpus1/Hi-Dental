using DatabaseLayer.Models.Patients;
using DataBaseLayer.Enums.Appointment;
using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Models.Plan
{
    public class Plan : CommonsProperty
    {
        [Required]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public TypeOfPlan TypeOfPlan { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }
        public virtual ICollection<ServicePlan> ServiceOfPattients { get; set; }

    }
}
