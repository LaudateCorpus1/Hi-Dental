using DataBaseLayer.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.ViewModels.Users
{
    public class FilterUserViewModel : FilterCommon
    {
        /// <summary>
        /// CreatedBy 
        /// </summary>
        public string CreatedBy { get; set; }
        public Guid DentalBranchId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string IndentityDocument { get; set; }
    }
}
