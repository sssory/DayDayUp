using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.Option
{
    public partial class MainOption : UserControl
    {
        public MainOption()
        {
            InitializeComponent();
        }

        private void option_menu_Click(object sender, EventArgs e)
        {
            option_munes option_ = new option_munes();
            SelectMenu(option_);
        }

        private void option_user_Click(object sender, EventArgs e)
        {
            option_users option_ = new option_users();
            SelectMenu(option_);
        }

        private void SelectMenu(UserControl user)
        {
            MainPan.Controls.Clear();
            user.Dock = DockStyle.Fill;
            MainPan.Controls.Add(user);
            
        }

        private void MainOption_Load(object sender, EventArgs e)
        {
            option_menu_Click(null, null);
        }
    }
}
