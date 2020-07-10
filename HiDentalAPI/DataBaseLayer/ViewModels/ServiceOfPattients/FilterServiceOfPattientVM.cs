using DataBaseLayer.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.ServiceOfPattients
{
    public class FilterServiceOfPattientVM : FilterCommon
    {
        public Guid DentalBranchId { get; set; }
    }
}
