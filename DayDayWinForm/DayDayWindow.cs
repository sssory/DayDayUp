using Common;
using DataBase;
using DataBase.MySql;
using DayDayWinForm.Pages.Common;
using DayDayWinForm.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DayDayWinForm
{
    public partial class DayDayWindow : Form
    {
        public DayDayWindow()
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
            try
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
                    logModel.UserId = App.User == null ? 0 : App.User.Id;
                    TableCommand.logs_insert(logModel);
                }
            }
            catch (Exception ex)
            {
                LogError.Write(ex);
            }
            
        }
        #endregion

        #region 状态栏
        public void LoadServiceStatus()
        {
            status_foot_service.Visible = true;
            status_foot_service.Text = "Service:" + APIService.Service.sercives.Status.ToString();
            
            if (APIService.Service.sercives.Status == APIService.Service.APIStatus.Open)
            {
                status_foot_service.ForeColor = Color.Green;
                App.LogMessage("API服务已开启！");
            }
            else
            {
                status_foot_service.ForeColor = Color.Red;
                App.LogMessage("API服务已关闭！");
            }
        }
        public void LoadUser(string name="")
        {
            status_foot_user.Visible = !string.IsNullOrEmpty(name);
            status_foot_user.Text = "当前用户:" + name;
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
        List<DataBase.MySql.menus> list = new List<menus>();
        private void LoadMenus()
        {
            menu_head.Items.Clear();

            //账号
            menu_head.Items.Add(loginmenu());

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

        private ToolStripMenuItem loginmenu()
        {
            ToolStripMenuItem Account = new ToolStripMenuItem("Account");
            Account.Name = "Account";

            var login = new ToolStripMenuItem()
            {
                Name = "Login",
                Text = "Login"
            };
            login.Click += (s, e) => { LoginForm form = new LoginForm();form.ShowDialog(); };
            var logout = new ToolStripMenuItem()
            {
                Name = "Logout",
                Text = "Logout"
            };
            logout.Click += (s, e) => {
                if (App.User != null)
                {
                    if (MessageBox.Show("确定要登出吗？", "DayDayUp", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        App.LogMessage($"您已登出。青山不改，绿水长流，后会有期！");
                        App.User = null;
                        App.MainForm.LoadUser();
                    }
                }
            };
            var pay = new ToolStripMenuItem()
            {
                Name = "Pay",
                Text = "Pay"
            };
            pay.Click += (s, e) => { App.LogMessage("充值功能开发中。。。"); };
            Account.DropDownItems.Add(login);
            Account.DropDownItems.Add(logout);
            Account.DropDownItems.Add(pay);

            return Account;
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

        private void DayDayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ControlHelper.OpenForm(tab_body, "Option_MainOption", "Option");
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
                default:
                    if (menu.ParentId != 0 && !isok) App.LogMessage("请配置菜单功能...");
                    break;
            }


        }


        #endregion

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                DateTime dt = DateTime.Parse(txtTime.Text);
                SetSystemDateTime.SetLocalTime(dt);
            }
        }
        private void txtTime_Enter(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {

        }

    }

    #region 系统时间
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMiliseconds;
    }
    public class SetSystemDateTime
    {
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime sysTime);

        public static bool SetLocalTime(DateTime dt)
        {
            bool flag = false;
            try
            {
                SystemTime sysTime = new SystemTime();
                sysTime.wYear = Convert.ToUInt16(dt.Year);
                sysTime.wMonth = Convert.ToUInt16(dt.Month);
                sysTime.wDay = Convert.ToUInt16(dt.Day);
                sysTime.wHour = Convert.ToUInt16(dt.Hour);
                sysTime.wMinute = Convert.ToUInt16(dt.Minute);
                sysTime.wSecond = Convert.ToUInt16(dt.Second);
                flag = SetSystemDateTime.SetLocalTime(ref sysTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("SetSystemDateTime函数执行异常" + e.Message);
            }
            return flag;
        }
    }

    #endregion
}
