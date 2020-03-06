using DataBaseLayer.Models.Commons;
using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models
{
    public class PaymentPlan : CommonsProperty
    {
        

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public virtual ICollection<ChargePaymentPlan> ChargesPayment_Plan { get; set; }

    }
}
