using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.Responses
{
    public class BadViewModel 
    {
        public string Message { get; set; }
        public IEnumerable<object> Params { get; set; }
    }
}
