using DayDayDB;
using DayDayWinForm.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.Tool
{
    public partial class SugarForm : Form
    {
        public SugarForm()
        {
            InitializeComponent();
        }

        private void lblPath_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择路径";

            var res = folder.ShowDialog();
            if (res == DialogResult.OK)
            {
                lblPath.Text = folder.SelectedPath;
            }
        }


        private void SugarForm_Load(object sender, EventArgs e)
        {

            lblPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            List<string> tables = Sugar.MySql.Ado.SqlQuery<string>($"SELECT table_name FROM information_schema.tables WHERE table_schema = '{AppConfig.Get("MySqlDBName")}'");

            tables.Insert(0, "");
            cbTable.DataSource = tables;
        }


        private void btn_create_Click(object sender, EventArgs e)
        {
            string tableName = cbTable.SelectedItem.ToString().Trim();
            string nameSpace = txt_namespace.Text.Trim();
            string folder = lblPath.Text.Trim();

            //1 验证输入
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("不存在路径");
                return;
            }

            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("请输入表名");
                return;
            }

            if (string.IsNullOrEmpty(nameSpace))
            {
                MessageBox.Show("请输入命名空间");
                return;
            }

            //2 创建文件
            try
            {
                DayDayDB.Sugar.MySql.DbFirst.Where(it => it == tableName).IsCreateAttribute().IsCreateDefaultValue().CreateClassFile(folder, nameSpace);
                MessageBox.Show("成功");


                //OpenFileDialog openFile = new OpenFileDialog();
                //openFile.InitialDirectory = folder;
                //openFile.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误" + ex.Message);
            }
        }

    }
}
