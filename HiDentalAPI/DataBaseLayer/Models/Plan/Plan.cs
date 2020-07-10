using DatabaseLayer.Models.Patients;
using DataBaseLayer.Enums.Appointment;
using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models.Plan
{
    public class Plan : CommonsProperty
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid ServiceOfPattientId { get; set; }
        public TypeOfPlan TypeOfPlan { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }
        public virtual ICollection<PlanService> ServiceOfPattient { get; set; }

    }
}
