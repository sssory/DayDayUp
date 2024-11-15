using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.Tool
{
    public partial class MailBy163Form : Form
    {
        public MailBy163Form()
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

            Mail mail = new Mail(txt_title.Text.Trim(), txt_content.Text.Trim(), txt_addressee.Text.Trim());
            var result = mail.SendMail();
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
