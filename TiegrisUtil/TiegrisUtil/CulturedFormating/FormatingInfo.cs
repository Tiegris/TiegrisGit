using System.Globalization;

namespace TiegrisUtil.CulturedFormating
{
    /// <summary>
    /// Contains information about the number and date formats.
    /// </summary>
    public static class FormatingInfo
    {
        private static string outNumberFormatString = "0.####";
        private static CultureInfo cultureInfo = CultureInfo.GetCultureInfo("hu-hu");
        private static string dateFormatString = "yyyy.MM.dd. H:mm:ss";
        public static string NumberFormatString 
            { get => outNumberFormatString; set => outNumberFormatString = value; }
        public static string DateFormatString 
            { get => dateFormatString; set => dateFormatString = value; }
        public static CultureInfo CultureInfo 
            { get => cultureInfo; set => cultureInfo = value; }
    }
}
