using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models.Plan
{
    public class PlanService : CommonsProperty
    {
        public Guid PlanId { get; set; }
        public Plan Plan { get; set; }
        public Guid ServiceOfPattientId { get; set; }
        public ServiceOfPattient ServiceOfPattient { get; set; }
    }
}
