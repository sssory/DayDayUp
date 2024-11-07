using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DayDayUI.Tools
{
    internal static class ControlHelper
    {
        #region 选项卡
        internal static TabPage CreatePage(string Name, string Text)
        {

            try
            {
                string[] arr = Name.Split('_');

                string ControlName = $"{arr[arr.Length - 2]}Control";
                // 获取当前程序集
                Assembly currentAssembly = Assembly.GetExecutingAssembly();

                // 创建用户控件实例
                var userControl = (UserControl)currentAssembly.CreateInstance($"DayDayUI.Controls.{ControlName}");
                
                // 创建 TabPage 并将用户控件添加进去
                TabPage tabPage = new TabPage(Text)
                {
                    // 设置 TabPage 的内容为用户控件
                    Name = Name,
                    Controls = { userControl }
                };
                tabPage.ContextMenuStrip = new ContextMenuStrip();
                tabPage.ContextMenuStrip.Items.Add("关闭");
                userControl.Dock = DockStyle.Fill; // 设置用户控件填充整个 TabPage

                return tabPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the control: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
