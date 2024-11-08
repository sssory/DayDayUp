using DayDayDB.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DayDayUI.Tools
{
    internal static class ControlHelper
    {
        #region 选项卡
        /// <summary>
        /// 打开窗体或控件
        /// </summary>
        /// <returns></returns>
        internal static bool OpenForm(TabControl tab_body, menus menu)
        {

            try
            {
                // 获取当前程序集
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                if (menu.ShowType=="control")
                {
                    foreach (TabPage page in tab_body.TabPages)
                    {
                        if (page.Name == menu.Code)
                        {
                            tab_body.SelectedIndex = tab_body.TabPages.IndexOf(page);
                            return true;
                        }
                    }

                    // 创建用户控件实例
                    var userControl = (UserControl)currentAssembly.CreateInstance($"DayDayUI.Pages.{menu.Code.Replace("_",".")}");

                    // 创建 TabPage 并将用户控件添加进去
                    TabPage tabPage = new TabPage(menu.Name)
                    {
                        // 设置 TabPage 的内容为用户控件
                        Name = menu.Code,
                        Controls = { userControl }
                    };
                    userControl.Dock = DockStyle.Fill; // 设置用户控件填充整个 TabPage
                    tab_body.TabPages.Add(tabPage);
                    tab_body.SelectedIndex = tab_body.TabPages.Count - 1;
                }
                else if (menu.ShowType == "form")
                {
                    // 创建用户控件实例
                    var form = (Form)currentAssembly.CreateInstance($"DayDayUI.Pages.{menu.Code.Replace("_", ".")}Form");
                    form.Show();
                }


                return true;
            }
            catch
            {
                return false;
            }




        }
        internal static void InitPage<T>(TabControl tabBody, object sender) where T : UserControl, new()
        {
            if (sender == null)
            {
                return;
            }

            ToolStripMenuItem item = sender as ToolStripMenuItem;

            //创建选项卡
            TabPage tabPage = new TabPage();
            tabPage.Text = item.Text;
            tabPage.Name = item.Name;

            if (!tabBody.TabPages.ContainsKey(tabPage.Name))
            {
                tabBody.TabPages.Add(tabPage);
                tabBody.SelectedIndex = tabBody.TabPages.IndexOf(tabPage);
                T control = new T();
                tabPage.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            }
            else
            {
                foreach (TabPage page in tabBody.TabPages)
                {
                    if (page.Name == tabPage.Name)
                    {
                        tabBody.SelectedIndex = tabBody.TabPages.IndexOf(page);
                    }
                }
            }
        }

        #endregion
    }
}
