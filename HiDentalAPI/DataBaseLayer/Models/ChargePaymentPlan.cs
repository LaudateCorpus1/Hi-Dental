using DataBaseLayer.Models.Commons;
using System;

namespace DatabaseLayer.Models
{
    public class ChargePaymentPlan : CommonsProperty
    {
       
        public double Charge { get; set; }
        public bool StateCharge { get; set; } //Pagado o Pendiente

        public Guid PaymentPlanID { get; set; }
        public PaymentPlan Payment_plan { get; set; }


    }
}
