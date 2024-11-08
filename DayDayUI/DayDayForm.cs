using DayDayDB;
using DayDayDB.MySql;
using DayDayUI.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            LogMessage = logmsg;
            LoadMenus();
            
        }

        
        #region 消息
        public delegate void LogMessageDelegate(string msg);

        public LogMessageDelegate LogMessage;
        private void logmsg(string msg)
        {
            if (txt_msg.InvokeRequired)
            {
                this.Invoke(LogMessage, msg);
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_msg.Text))
                {
                    txt_msg.AppendText("\r\n");
                }

                txt_msg.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg);

                logs logModel = new logs();
                logModel.LogMessage = msg;
                logModel.LogDate = DateTime.Now;
                Sugar.MySql.Insertable(logModel).ExecuteCommand();
            }
        }
        #endregion

        #region API服务
        public void LoadServiceStatus()
        {
            status_foot_service.Visible = true;
            status_foot_service.Text = "Service:" + APIService.Service.sercives.Status.ToString();
            
            if (APIService.Service.sercives.Status == APIService.Service.APIStatus.Open)
            {
                status_foot_service.ForeColor = Color.Green;
                App.MainForm.LogMessage("API服务已开启！");
            }
            else
            {
                status_foot_service.ForeColor = Color.Red;
                App.MainForm.LogMessage("API服务已关闭！");
            }
        }

        #endregion

        #region 右键关闭
        private ContextMenuStrip contextMenu; // 定义上下文菜单
        private int selectedTabIndex = -1;    // 存储被右键点击的选项卡索引
        private void InitializeContextMenu()
        {
            // 创建上下文菜单并添加“关闭”项
            contextMenu = new ContextMenuStrip();
            ToolStripMenuItem closeItem = new ToolStripMenuItem("close");
            ToolStripMenuItem closeOther = new ToolStripMenuItem("close other");
            closeItem.Click += CloseItem_Click; // 添加关闭事件
            closeOther.Click += CloseItem_Click; // 添加关闭事件
            contextMenu.Items.Add(closeItem);
            contextMenu.Items.Add(closeOther);
        }
        private void CloseItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem thisMenu = sender as ToolStripMenuItem;
            // 检查索引有效性，然后关闭对应选项卡

            if (thisMenu.Text == "close")
            {
                if (selectedTabIndex >= 0 && selectedTabIndex < tab_body.TabCount)
                {
                    tab_body.TabPages.RemoveAt(selectedTabIndex);
                    selectedTabIndex = -1; // 重置索引
                }
            }
            else
            {
                foreach (TabPage item in tab_body.TabPages)
                {
                    int index = tab_body.TabPages.IndexOf(item);
                    if (index != selectedTabIndex)
                    {
                        tab_body.TabPages.RemoveAt(index);
                        selectedTabIndex--;
                    }
                }
            }

        }

        private void tab_body_MouseUp(object sender, MouseEventArgs e)
        {
            // 检查是否为右键单击
            if (e.Button == MouseButtons.Right)
            {
                // 获取鼠标点击的选项卡索引
                for (int i = 0; i < tab_body.TabCount; i++)
                {
                    if (tab_body.GetTabRect(i).Contains(e.Location))
                    {
                        // 找到右键单击的选项卡，触发事件
                        contextMenu.Show(tab_body, e.Location);
                        selectedTabIndex = i;
                        break;
                    }
                }
            }
        }

        #endregion

        #region 头部菜单
        List<menus> list = new List<menus>();
        private void LoadMenus()
        {
            menu_head.Items.Clear();
            list = Sugar.MySql.Queryable<menus>().ToList();
            foreach (var item in list.Where(m => m.ParentId == 0).OrderBy(m => m.Sort))
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem(item.Name);
                newItem.Name = item.Code;
                newItem.Tag = item.Id.ToString();
                newItem.Click += (send, e) => NewItem_Click(send, e, item);
                LoadMenusChild(newItem);
                menu_head.Items.Add(newItem);
            }

            InitializeContextMenu();

        }
        private void LoadMenusChild(ToolStripMenuItem parent)
        {
            var child = list.Where(c => c.ParentId == int.Parse(parent.Tag.ToString())).OrderBy(c => c.Sort);
            foreach (var item in child)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem(item.Name);
                newItem.Name = item.Code;
                newItem.Tag = item.Id.ToString();
                newItem.Click += (send, e) => NewItem_Click(send, e, item);
                LoadMenusChild(newItem);
                parent.DropDownItems.Add(newItem);

                if (item.AutoStart == 1)
                {
                    NewItem_Click(null, null, item);
                }
            }
        }

        public void NewItem_Click(object sender, EventArgs e, menus menu)
        {
            bool isok = false;
            if (!string.IsNullOrEmpty(menu.ShowType)) isok = ControlHelper.OpenForm(this.tab_body,menu);

            switch (menu.Code)
            {
                case "Base_OpenService":
                    APIService.Service.sercives.Start();
                    LoadServiceStatus();
                    break;
                case "Base_CloseService":
                    APIService.Service.sercives.Stop();
                    LoadServiceStatus();
                    break;
                case "Base_ClearMessage":
                    txt_msg.Text = string.Empty;
                    break;
                case "Base_ReloadDayDayUp":
                    App.MainForm.LogMessage("功能开发中...");
                    break;
                default:
                    if (menu.ParentId != 0 && !isok) App.MainForm.LogMessage("请配置菜单功能...");
                    break;
            }


        }
        #endregion

    }
}
