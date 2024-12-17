using DayDayBackup.Resources;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace DayDayBackup
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {   
        
    

        public MainWindow()
        {
            InitializeComponent();
  
        }

            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Connect connect = new Connect(this);
            if (connect.GetDataBase())
            {
                if (serverDatabase.Count == 0)
                {
                    serverDatabase.Add("无数据");
                }
                //加载数据库结构
                lbDatabase.ItemsSource = null;
                lbDatabase.ItemsSource = serverDatabase;

                btnReConnect.Content = "已连接";
                btnReConnect.Background = new SolidColorBrush(Color.FromRgb(144, 238, 144));

                if (File.Exists(servermysqldump+ "\\mysqldump.exe"))
                {
                    btnGetDump.Background = new SolidColorBrush(Color.FromRgb(144, 238, 144));
                }
                
            }
        }
        public string serverIp = "localhost";
        public string serverPort = "3306";
        public string serverUser = "root";
        public string serverPassword = "uce2010";
        public string servermysqldump = "";
        public bool checkall = false;
        public string dbName = "";
        Dictionary<string,bool> tables = new Dictionary<string, bool>();
        public List<string> serverDatabase = new List<string>();

        private void btnReConnect_Click(object sender, RoutedEventArgs e)
        {
            ShowConnect();
        }
        public void ShowConnect()
        {
            Connect connect = new Connect(this);
            connect.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bool? result = connect.ShowDialog();
            if (result.Value)
            {
                if (serverDatabase.Count == 0)
                {
                    serverDatabase.Add("无数据");
                }
                //加载数据库结构
                lbDatabase.ItemsSource = null;
                lbDatabase.ItemsSource = serverDatabase;

                btnReConnect.Content = "已连接";
                btnReConnect.Background = new SolidColorBrush(Color.FromRgb(144, 238, 144));
                if (File.Exists(servermysqldump + "\\mysqldump.exe"))
                {
                    btnGetDump.Background = new SolidColorBrush(Color.FromRgb(144, 238, 144));
                }
            }
        }
        private void lbDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = Convert.ToString(lbDatabase.SelectedItem);
            if (name.IndexOf("无数据") != -1 || string.IsNullOrEmpty(name))
            {
                wpTable.Children.Clear();
            }
            else
            {
                dbName = name;
                GetTable();
                ShowTable();
            }
        }
        private void GetTable()
        {
            tables.Clear();

            // MySQL 连接字符串（请根据你的配置更改）
            string connectionString = "Server=" + serverIp + ";Port=" + serverPort + ";User ID=" + serverUser + ";Password=" + serverPassword + ";Database=" + dbName + ";";

            // 创建连接对象
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // 打开连接
                    connection.Open();

                    // 执行 SQL 查询：获取所有数据库
                    string query = $"SELECT table_name FROM information_schema.tables WHERE table_schema = '{dbName}' AND table_type = 'BASE TABLE'";

                    // 创建命令对象
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // 执行查询并获取结果
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // 读取并打印所有数据库名称
                            while (reader.Read())
                            {
                                string temp = reader.GetString(0);

                                if (!string.IsNullOrEmpty(txtKey.Text.Trim()))
                                    if (!temp.Contains(txtKey.Text.Trim()))
                                        continue;

                                tables.Add(temp, true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }
            }
        }
        private void ShowTable()
        {
            wpTable.Children.Clear();
            if (tables.Count == 0)
            {
                Label label = new Label();
                label.Content = "无数据";
                wpTable.Children.Add(label);
                return;
            }
            foreach (var item in tables)
            {
                CheckBox cb = new CheckBox()
                {
                    Width = 200,
                    Content = item.Key,
                    IsChecked = item.Value
                };

                cb.Checked += Cb_Checked; ;
                cb.Unchecked += Cb_Unchecked; ;
                wpTable.Children.Add(cb);
            }
        }
        private void Cb_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (tables.ContainsKey(Convert.ToString(check.Content)))
            {
                tables[Convert.ToString(check.Content)] = false;
            }
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (tables.ContainsKey(Convert.ToString(check.Content)))
            {
                tables[Convert.ToString(check.Content)] = true;
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (checkall)
            {
                foreach (var item in tables.Keys.ToArray())
                {
                    tables[item] = true;
                }
                checkall = false;
            }
            else
            {
                foreach (var item in tables.Keys.ToArray())
                {
                    tables[item] = false;
                }
                checkall = true;
            }
            ShowTable();
        }

        private void btnGetDump_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "请选择 mysqldump.exe 文件";
            openFile.Multiselect = false;
            openFile.InitialDirectory = servermysqldump;
            openFile.Filter = "mysqldump.exe|mysqldump.exe";
            bool? result = openFile.ShowDialog();
            if (result.Value)
            {
                servermysqldump = System.IO.Path.GetDirectoryName(openFile.FileName);
                MessageBox.Show("成功更改mysqldump", "提示");
            }

        }

        private async void btnBackup_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnReConnect.Content.ToString() != "已连接")
            {
                MessageBox.Show("请连接数据库");
                return;
            }
            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show("请选择数据库");
                return;
            }
            if (!tables.ContainsValue(true))
            {
                MessageBox.Show("请选择数据表");
                return;
            }

            string backpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // 创建文件夹选择对话框
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog
            {
                // 设置对话框描述
                Description = "请选择导出路径",

                // 设置默认路径
                SelectedPath = backpath,

                // 是否允许新建文件夹
                ShowNewFolderButton = true
            };
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pbLoading.Visibility = Visibility.Visible;
                string message = "";
                await Task.Run(() =>
                {
                    string checktab = "";

                    foreach (var item in tables.Keys.ToArray())
                        if (tables[item])
                            checktab += $" {item}";

                    backpath = folderDialog.SelectedPath + $"\\{dbName}{DateTime.Now.ToString("yyyyMMddHHmmss")}.sql";
                    string cmd = $"mysqldump --host={serverIp} --default-character-set=utf8 --single-transaction  --port={serverPort} --user={serverUser} --password={serverPassword} --quick --hex-blob  --databases {dbName} --tables {checktab} > {backpath}";
                    
                    try
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.WorkingDirectory = servermysqldump;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        //输入命令
                        p.StandardInput.WriteLine(cmd);
                        p.StandardInput.Close();
                        // 等待进程完成
                        p.WaitForExit();

                        // 获取输出信息（可选）
                        string output = p.StandardOutput.ReadToEnd();
                        string error = p.StandardError.ReadToEnd();

                        p.Close();
                        p.Dispose();

                        if (error.ToUpper().Contains("ERROR")) message = error;
                        else message = "备份成功";

                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                    }
                });

                MessageBox.Show(message);
                pbLoading.Visibility = Visibility.Hidden;
            }
        }

        private async void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (btnReConnect.Content.ToString() != "已连接")
            {
                MessageBox.Show("请连接数据库");
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "数据还原";
            openFile.Multiselect = false;
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Filter = "*.sql|*.sql";
            bool? result = openFile.ShowDialog();
            if (result.Value)
            {
                string tempdbName = "";
                if (openFile.FileName.IndexOf("scadadata") != -1) tempdbName = "scadadata";
                else if (openFile.FileName.IndexOf("scadacurcevalue") != -1) tempdbName = "scadacurcevalue";


                if (string.IsNullOrEmpty(tempdbName))
                {
                    MessageBox.Show("文件名不规范", "提示");
                    return;
                }

                pbLoading.Visibility = Visibility.Visible;
                string message = "";

                await Task.Run(() =>
                {
                    try
                    {
                        CreateDatabase(tempdbName);

                        // 构建命令
                        string cmd = $"mysql -h {serverIp} -P {serverPort} -u {serverUser} -p{serverPassword} {tempdbName} < \"{openFile.FileName}\"";
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.WorkingDirectory = servermysqldump;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        //输入命令
                        p.StandardInput.WriteLine(cmd);
                        p.StandardInput.Close();

                        // 等待进程完成
                        p.WaitForExit();

                        // 获取输出信息（可选）
                        string output = p.StandardOutput.ReadToEnd();
                        string error = p.StandardError.ReadToEnd();

                        p.Close();
                        p.Dispose();

                        if (error.ToUpper().Contains("ERROR")) message = error;
                        else message = "还原成功";

                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                    }

                });

                MessageBox.Show(message);
                pbLoading.Visibility = Visibility.Hidden;

                Connect connect = new Connect(this);
                connect.GetDataBase();
                //加载数据库结构
                lbDatabase.ItemsSource = null;
                lbDatabase.ItemsSource = serverDatabase;
            }
        }

        private void CreateDatabase(string dn)
        {
            // MySQL 连接字符串（请根据你的配置更改）
            string connectionString = "Server=" + serverIp + ";Port=" + serverPort + ";User ID=" + serverUser + ";Password=" + serverPassword + ";";

            // 创建连接对象
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS " + dn, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }
            }
        }
        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                GetTable();
                ShowTable();
            }
        }

    

        private void OpenSqlFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQL文件|*.sql",
                Title = "选择一个SQL文件"
            };


            // 显示对话框并检查是否选择了文件
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // 读取SQL文件内容
                    string sqlScript = File.ReadAllText(filePath, Encoding.UTF8);

                    // 连接到数据库（请根据实际情况修改连接字符串）
                    string connectionString = "Server=" + serverIp + ";Port=" + serverPort + ";User ID=" + serverUser + ";Password=" + serverPassword + ";";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // 使用SqlCommand执行SQL脚本
                        using (MySqlCommand command = new MySqlCommand(sqlScript, connection))
                        {
                            command.ExecuteNonQuery();
                            StatusTextBlock.Text = "SQL文件执行成功！";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 捕获并显示异常信息
                    MessageBox.Show($"执行SQL文件时出错: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    StatusTextBlock.Text = "SQL文件执行失败！";
                }
            }
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                btnRestore.Visibility = Visibility.Visible;
                OpenSqlFileButton.Visibility = Visibility.Visible;
                // 创建一个打开文件对话框
            }
        }
    }

}
