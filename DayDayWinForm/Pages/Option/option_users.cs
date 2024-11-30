using DataBase;
using DataBase.MySql;
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
    public partial class option_users : UserControl
    {
        public option_users()
        {
            InitializeComponent();
        }

        public void BindList()
        {
            List<users> us = Sugar.MySql.Queryable<users>().ToList();
            BindingList<users> bindList = new BindingList<users>(us);
            gvList.DataSource = bindList;
        }

        private void option_users_Load(object sender, EventArgs e)
        {
            BindList();
        }
    }
}
