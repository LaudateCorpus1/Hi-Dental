using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.ComboBox
{
    public class ComboBoxViewModel<TCode,TGroup>
    {
        public TCode Code { get; set; }
        public string Title { get; set; }
        public TGroup Group { get; set; }
    }
}
