using DataBase;
using DataBase.MySql;
using DayDayWinForm.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayWinForm.Tools
{
    public static class App
    {
        public static DayDayWindow MainForm = Application.OpenForms["DayDayForm"] as DayDayWindow;

        public static users User = null;

        public static string SpecialChar = @"~!@#$%^&*()-_=+[]{}|;:'"",.<>?/`";
        
        /// <summary>
        /// 主页面消息
        /// </summary>
        public static void LogMessage(string msg)
        {
            MainForm.LogMessage(msg);
        }
        /// <summary>
        /// 验证用户输入是否包含特殊字符
        /// </summary>
        // 验证用户输入是否包含特殊字符
        public static bool ContainSpecialChar(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // 正则表达式，匹配任意一个特殊字符
            string pattern = "[" + Regex.Escape(SpecialChar) + "]";

            // 如果匹配则返回 true
            return Regex.IsMatch(input, pattern);
        }


    }
}
