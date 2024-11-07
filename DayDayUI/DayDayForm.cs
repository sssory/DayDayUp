
using DayDayUI.Model;
using DayDayUI.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DayDayUI
{
    public partial class DayDayForm : Form
    {
        public DayDayForm()
        {
            InitializeComponent();
        }

        private void DayDayForm_Load(object sender, EventArgs e)
        {
           
            Logmsg = LogMessage;
            AddClickEventToMenuItems(menu_head.Items);
            LoadState();
        }

        #region 头部菜单
        private void AddClickEventToMenuItems(ToolStripItemCollection menuItems)
        {
            foreach (ToolStripItem item in menuItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    // 添加点击事件
                    menuItem.Click += MenuItem_Click; ;

                    // 如果有子菜单项，递归调用
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        AddClickEventToMenuItems(menuItem.DropDownItems);
                    }
                }
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem menu = sender as ToolStripMenuItem;

            string[] arr = menu.Name.Split('_');

            if (arr.Length < 2)
            {
                return;
            }

            if (arr[arr.Length - 1] == "C")
            {

                if (tab_body.TabPages.ContainsKey(menu.Name))
                {
                    foreach (TabPage page in tab_body.TabPages)
                        if (page.Name == menu.Name)
                            tab_body.SelectedIndex = tab_body.TabPages.IndexOf(page);

                    return;
                }
                 
                var newPage=ControlHelper.CreatePage(menu.Name, menu.Text);

                if (newPage != null)
                {
                    tab_body.TabPages.Add(newPage);
             
                    tab_body.SelectedIndex = tab_body.TabPages.Count - 1;
                }
            }
            
        }

        #endregion
        
        #region 消息
        public delegate void LogMessageDelegate(string msg);

        public LogMessageDelegate Logmsg;
        private void LogMessage(string msg)
        {
            if (txt_msg.InvokeRequired)
            {
                this.Invoke(Logmsg,msg);
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_msg.Text))
                {
                    txt_msg.AppendText("\r\n");
                }

                txt_msg.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg);

                LogModel logModel = new LogModel();
                logModel.LogMessage = msg;
                logModel.LogDate = DateTime.Now;
                //Sugar.MySql.Insertable(logModel).ExecuteCommand();
            }
            
        }
        #endregion

        #region API服务
        private void LoadState()
        {
            status_foot_service.Text = "API服务:" + APIService.Service.sercives.Status.ToString();
            
            if (APIService.Service.sercives.Status == APIService.Service.APIStatus.Open)
            {
                status_foot_service.ForeColor = Color.Green;
                LogMessage("API服务已开启");
            }
            else
            {
                status_foot_service.ForeColor = Color.Red;
                LogMessage("API服务已关闭");
            }
        }

        private void m_api_open_Click(object sender, EventArgs e)
        {
            APIService.Service.sercives.Start();
            LoadState();
        }

        private void m_api_close_Click(object sender, EventArgs e)
        {
            APIService.Service.sercives.Stop();
            LoadState();
        }
        #endregion

        private void tab_body_MouseDown(object sender, MouseEventArgs e)
        {


            try
            {
                if (e.Button == MouseButtons.Right)
                {
                   
                    TabPage selectedTab = null;
                    foreach (TabPage tab in tab_body.TabPages)
                    {
                        Rectangle rect = tab_body.GetTabRect(tab_body.TabPages.IndexOf(tab));
                        if (rect.Contains(e.Location))
                        {
                            selectedTab = tab;
                            break;
                        }
                    }

                    if (selectedTab != null)
                    {
                        tab_body.SelectedIndex = tab_body.TabPages.IndexOf(selectedTab); 
                    }

                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
                throw;
            }

        }


        private void contextMenuStrip1_Click_1(object sender, EventArgs e)
        {
            try
            {
                TabControl tabControl = (TabControl)(((ContextMenuStrip)sender).SourceControl);
                TabPage tabPage = tabControl.SelectedTab;
                tab_body.TabPages.Remove(tabPage);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
             
                throw;
            }
          
        }

        private void m_clear_Click(object sender, EventArgs e)
        {
            txt_msg.Text = string.Empty;
        }

    }
}
