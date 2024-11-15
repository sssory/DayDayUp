using System.Configuration;

namespace DayDayWPF.Tools
{
    internal static class AppConfig
    {
        public static string DefaultConnection { get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); } }
    }
}
