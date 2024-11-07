using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DayDayUI.Tools;
namespace DayDayUI.Controls
{
    public partial class MailDemoControl : UserControl
    {
        public MailDemoControl()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_title.Text.Trim()) || string.IsNullOrEmpty(txt_content.Text.Trim()) || string.IsNullOrEmpty(txt_addressee.Text.Trim()))
            {
                MessageBox.Show("请填写相关内容");
                return;
            }

            DayDayUI.Tools.Mail mail = new Tools.Mail(txt_title.Text.Trim(), txt_content.Text.Trim(), txt_addressee.Text.Trim());
            var result=mail.SendMail();
            if (result)
            {
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }
    }
}
