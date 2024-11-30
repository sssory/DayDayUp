using DataBase.MySql;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Common;

namespace DayDayWinForm.Tools
{
    internal static class ControlHelper
    {
        #region 选项卡

        // 获取当前程序集
        static Assembly currentAssembly = Assembly.GetExecutingAssembly();
        /// <summary>
        /// 打开窗体或控件
        /// </summary>
        /// <returns></returns>
        internal static bool OpenForm(TabControl tab_body, menus menu)
        {
            try
            {
                if (menu.ShowType=="control")
                {
                    OpenForm(tab_body, menu.Code, menu.Name);
                }
                else if (menu.ShowType == "form")
                {
                    // 创建用户控件实例
                    var form = (Form)currentAssembly.CreateInstance($"DayDayWinForm.Pages.{menu.Code.Replace("_", ".")}Form");
                    form.Width = (int)(App.MainForm.Width * 0.7);
                    form.Height = (int)(App.MainForm.Height * 0.7);
                    form.FormBorderStyle = FormBorderStyle.Fixed3D;

                    // 设置新窗口的位置和大小
                    int x = Math.Max(App.MainForm.Left, Math.Min(App.MainForm.Right - form.Width, App.MainForm.Left + (App.MainForm.Width - form.Width) / 2));
                    int y = Math.Max(App.MainForm.Top, Math.Min(App.MainForm.Bottom - form.Height, App.MainForm.Top + (App.MainForm.Height - form.Height) / 2));
                    form.StartPosition = FormStartPosition.CenterParent;
               
                    form.ShowDialog();
                }

                return true;
            }
            catch(Exception ex)
            {
                LogError.Write(ex);
                return false;
            }
        }


        internal static bool OpenForm(TabControl tab_body,string Code,string Text)
        {
            try
            { 
                foreach (TabPage page in tab_body.TabPages)
                {
                    if (page.Name == Code)
                    {
                        tab_body.SelectedIndex = tab_body.TabPages.IndexOf(page);
                        return true;
                    }
                }

                // 创建用户控件实例
                var userControl = (UserControl)currentAssembly.CreateInstance($"DayDayWinForm.Pages.{Code.Replace("_", ".")}");

                // 创建 TabPage 并将用户控件添加进去
                TabPage tabPage = new TabPage(Text)
                {
                    // 设置 TabPage 的内容为用户控件
                    Name = Code,
                    Controls = { userControl }
                };
                userControl.Dock = DockStyle.Fill; // 设置用户控件填充整个 TabPage
                tab_body.TabPages.Add(tabPage);
                tab_body.SelectedIndex = tab_body.TabPages.Count - 1;

                return true;
            }
            catch (Exception ex)
            {
                LogError.Write(ex);
                return false;
            }
        }

        #endregion

        internal static List<string> GetColumns(this DataTable dataTable)
        {
            List<string> strings = new List<string>();

            if (dataTable == null)
            {
                return strings;
            }

            foreach (DataColumn item in dataTable.Columns)
            {
                strings.Add(item.ColumnName);
            }

            return strings;
        }
    }
}
