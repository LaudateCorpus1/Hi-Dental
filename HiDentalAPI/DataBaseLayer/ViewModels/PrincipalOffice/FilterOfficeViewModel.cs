using DataBaseLayer.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.PrincipalOffice
{
    public class FilterOfficeViewModel : FilterCommon
    {
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
    }
}
