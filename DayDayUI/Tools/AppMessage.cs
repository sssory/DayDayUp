using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayUI.Tools
{
    internal class AppMessage
    {
        internal static void Logmsg(string text)
        {

            DayDayForm app = (DayDayForm)Application.OpenForms["DayDayForm"];
            app.Logmsg(text);
        }
    }
}
