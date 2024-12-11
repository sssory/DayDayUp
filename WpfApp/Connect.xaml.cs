using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DayDayBackup.Resources
{
    /// <summary>
    /// Connect.xaml 的交互逻辑
    /// </summary>
    public partial class Connect : Window
    {
        private MainWindow parent;
        public Connect(MainWindow _parent)
        {
            InitializeComponent();
            parent = _parent;
            this.Owner = _parent;

            txtIP.Text = _parent.serverIp;
            txtPort.Text = _parent.serverPort;
            txtUser.Text = _parent.serverUser;
            txtPassword.Password= _parent.serverPassword;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GetDataBase())
            {
                this.DialogResult = true;
            }

        }
        public bool GetDataBase()
        {
            // MySQL 连接字符串（请根据你的配置更改）
            string connectionString = "Server=" + txtIP.Text.Trim() + ";Port=" + txtPort.Text.Trim() + ";User ID=" + txtUser.Text.Trim() + ";Password=" + txtPassword.Password.Trim() + ";";

            parent.serverDatabase.Clear();
            // 创建连接对象
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // 打开连接
                    connection.Open();

                    // 获取所有数据库
                    using (MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", connection))
                    {
                        // 执行查询并获取结果
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // 读取并打印所有数据库名称
                            while (reader.Read())
                            {
                                string temp = reader.GetString(0);
                                if (temp == "scadadata")
                                {
                                    parent.serverDatabase.Add("程序数据库(scadadata)");
                                }
                                else if (temp == "scadacurcevalue")
                                {
                                    parent.serverDatabase.Add("历史数据库(scadacurcevalue)");
                                }
                            }
                        }
                    }

                    // 获取mysqldump
                    using (MySqlCommand cmd = new MySqlCommand("SELECT @@basedir AS basePath FROM DUAL", connection))
                    {
                        // 执行查询并获取结果
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // 读取并打印所有数据库名称
                            while (reader.Read())
                            {
                                string temp = reader.GetString(0);
                                parent.servermysqldump = reader[0].ToString() + "bin";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                    return false;
                }
            }
            parent.serverDatabase.Sort();
            parent.serverIp = txtIP.Text.Trim();
            parent.serverPort = txtPort.Text.Trim();
            parent.serverUser = txtUser.Text.Trim();
            parent.serverPassword = txtPassword.Password.Trim();
            return true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Button_Click(null, null);
            }
            
        }
    }
}
