using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ExtensionsMethods
{
    public static class SharedExtension
    {
        public static bool IsEmpty(this Guid param) => param == Guid.Empty;
    }
}
