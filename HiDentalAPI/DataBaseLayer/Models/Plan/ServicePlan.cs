using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Models.Plan
{
    public class ServicePlan : CommonsProperty
    {
        [Required]
        public Guid PlanId { get; set; }
        public Plan Plan { get; set; }
        [Required]
        public Guid ServiceOfPattientId { get; set; }
        public ServiceOfPatient ServiceOfPattient { get; set; }
    }
}
