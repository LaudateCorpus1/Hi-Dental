using DatabaseLayer.Models.Users;
using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models
{
    public class PatientOfService : CommonsProperty
    {
    

        public Guid ServiceID { get; set; }
        public Service Service { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Guid PacienteId { get; set; }
        public Patient Paciente { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
