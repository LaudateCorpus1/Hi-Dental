using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Models.Plan
{
    public class Payment : CommonsProperty
    {
        [Required]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
    }
}
