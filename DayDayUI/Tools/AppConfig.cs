using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayDayWinForm.Tools
{
    internal class AppConfig
    {
        internal static string Get(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                return value;
            }
            catch (Exception)
            {
                return "";
            }
        }

        internal static string ServiceIP { get { return Get("ServiceIP"); } }
        internal static string ServicePort { get { return Get("ServicePort"); } }
        internal static string SocketIP { get { return Get("SocketIP"); } }
        internal static string SocketPort { get { return Get("SocketPort"); } }

    }
}
