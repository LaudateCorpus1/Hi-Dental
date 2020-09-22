using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.Commons
{
    public class FilterCommon
    {
        public int Page { get; set; } = 1;
        public int QuantityByPage { get; set; } = 10;
    }
}
