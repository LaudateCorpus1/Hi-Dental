using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Commons;
using System;

namespace DatabaseLayer.Models
{
    public class PlanTreatmentPatient : CommonsProperty
    {

        public Guid PlanTratamientoID { get; set; }
        public Treatment_plan Treatment_plan { get; set; }

        public Guid ConsultationID { get; set; }
        public Consultation Consultation { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }


    }
}
