using DataBaseLayer.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.ViewModels.DentalBranch
{
    public class FilterDentalBranchViewModel : FilterCommon
    {
        public Guid? PrincipalOfficeId { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public bool  IsPrincipal { get; set; }
    }
}
