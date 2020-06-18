using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.CulturedFormating
{
    /// <summary>
    /// Parses strings, and converts to string using the formats defined in class FormatingInfo.
    /// </summary>
    public static class Parser {

        static public string ToString(double val) {
            return val.ToString(FormatingInfo.NumberFormatString, FormatingInfo.CultureInfo);
        }

        static public string ToString(float val) {
            return val.ToString(FormatingInfo.NumberFormatString, FormatingInfo.CultureInfo);
        }

        static public string ToString(DateTime val) {
            return val.ToString(FormatingInfo.DateFormatString, FormatingInfo.CultureInfo);
        }

        static public double ToDouble(string s) {
            return double.Parse(s, FormatingInfo.CultureInfo);
        }

        static public float ToFloat(string s) {
            return float.Parse(s, FormatingInfo.CultureInfo);
        }

        static public DateTime ToDate(string s) {
            return DateTime.ParseExact(s, FormatingInfo.DateFormatString, FormatingInfo.CultureInfo);
        }

    }
}
