using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Math
{
    /// <summary>
    /// Contains information about the number formats used by all the classes in this namespace.
    /// </summary>
    public static class FormatingInfo
    {
        private static NumberFormatInfo outFormat = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
        
        /// <summary>
        /// The classes inside the  TiegrisUtil.Math namespace, use this format, to covert double values to string.
        /// </summary>
        public static NumberFormatInfo OutNumberFormat {
            get => outFormat;
            set => outFormat = value;
        }
    }
}
