using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.ViewModels.Users
{
    public class FilterUserViewModel
    {
        /// <summary>
        /// CreatedBy 
        /// </summary>
        public string Id { get; set; }
        public Guid DentalBranchId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string IndentityDocument { get; set; }
        public int Page { get; set; } = 1;
        public int QuantityByPage { get; set; } = 10;
    }
}
