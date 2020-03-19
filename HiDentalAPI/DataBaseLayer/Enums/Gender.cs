using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Enums
{
    public enum Gender
    {
        [Display(Name = nameof(M))]
        M,
        [Display(Name = nameof(F))]
        F,
        [Display(Name = nameof(Other))]
        Other
    }
}
