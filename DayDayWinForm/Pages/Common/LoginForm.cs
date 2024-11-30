using DataBase.MySql;
using DataBase;
using DayDayWinForm.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace DayDayWinForm.Pages.Common
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
         

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtUserNumber.Text.Trim()))
                {
                    MessageBox.Show("请输入账号");
                    return;
                }
                if (string.IsNullOrEmpty(txtUserPassword.Text.Trim()))
                {
                    MessageBox.Show("请输入密码");
                    return;
                }
                var msg = string.Empty;
                if (!Login(txtUserNumber.Text.Trim(), txtUserPassword.Text.Trim(), out msg))
                {
                    MessageBox.Show(msg);
                    return;
                }

                this.Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUserPassword.PasswordChar = '●';
        }

        private void lbleye_Click(object sender, EventArgs e)
        {
            if (txtUserPassword.PasswordChar == '0')
            {
                txtUserPassword.PasswordChar = '●';
            }
            else
            {
                txtUserPassword.PasswordChar = '0';
            }
        }

        internal static bool Login(string name, string pwd, out string msg)
        {
            try
            {
                msg = "";
                var user = Sugar.MySql.Queryable<users>().First(u => u.UserNumber == name);
                if (user == null)
                {
                    msg = "账号或密码错误";
                    return false;
                }
                if (!MD5Helper.VerifyMd5Hash(pwd, user.UserPassword))
                {
                    msg = "账号或密码错误";
                    return false;
                }

                App.User = user;
                App.MainForm.LoadUser(user.UserName);
                App.LogMessage($"欢迎您登录“{user.UserName}”,享受高端服务请点击左上角充值入口。");
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                LogError.Write(ex);
                return false;
            }
        }
    }
}
