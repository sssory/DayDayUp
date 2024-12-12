using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DayDayWinForm.Pages.Tool
{
    public partial class SugarHelper : UserControl
    {
        public SugarHelper()
        {
            InitializeComponent();
        }

        private void SugarModelControl_Load(object sender, EventArgs e)
        {
            txt_folder.Text= Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            string tableName = txt_table.Text.Trim();
            string nameSpace = txt_namespace.Text.Trim();
            string folder = txt_folder.Text.Trim();

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
                DataBase.Sugar.MySql.DbFirst.Where(it => it == tableName).IsCreateAttribute().IsCreateDefaultValue().CreateClassFile(folder, nameSpace);
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
