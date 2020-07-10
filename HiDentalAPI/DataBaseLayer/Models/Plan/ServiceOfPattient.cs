using DataBaseLayer.Enums.Appointment;
using DataBaseLayer.Models.Commons;
using DataBaseLayer.Models.Offices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Models.Plan
{
    public class ServiceOfPattient : CommonsProperty
    {
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DentalBranchId { get; set; }
        public virtual DentalBranch DentalBranch { get; set; }
    }
}
