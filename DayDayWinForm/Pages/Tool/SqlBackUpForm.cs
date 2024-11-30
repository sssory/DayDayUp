using MySql.Data.MySqlClient;
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
    public partial class SqlBackUpForm : Form
    {
        public SqlBackUpForm()
        {
            InitializeComponent();
        }

        private void MySqlBackUpControl_Load(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("yyyy-MM");
            lblPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            lblPath.Click += LblPath_Click;
        }

        private void LblPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择路径";
            //folder.ShowNewFolderButton = true;

            var res = folder.ShowDialog();
            if (res == DialogResult.OK)
            {
                lblPath.Text = folder.SelectedPath;
            }

        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            bgwork.RunWorkerAsync();
        }
        private string RunCmd(string mysqldumPath, string strCmd)
        {
            try
            {
                string msg = "";

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = mysqldumPath;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                //输入命令
                p.StandardInput.WriteLine(strCmd);
                p.Close();
                p = null;
                return msg;
            }
            catch (Exception ex)
            {

                return "error:" + ex.Message;
            }
        }
        private void bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwork.ReportProgress(0);

            //选择桌面地址
            string scadadataPath = lblPath.Text + $"\\scadadata-{Convert.ToDateTime(txtTime.Text).ToString("yyyyMM")}.sql";
            string scadacurcevaluePath = lblPath.Text + $"\\scadacurcevalue-{Convert.ToDateTime(txtTime.Text).ToString("yyyyMM")}.sql";

            string mysqlDump = "";

            string scadadataTables = "";
            string scadacurcevalueTables = "";

            //连接数据库
            string connectionString = $"server={txtIP.Text.Trim()};user id={txtUser.Text.Trim()};password={txtPwd.Text.Trim()};database=scadadata;persistsecurityinfo=False;port={txtPort.Text.Trim()};Pooling=true;Allow Zero Datetime=true;Charset=utf8;";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    // 获取执行路径
                    using (MySqlCommand command = new MySqlCommand("SELECT @@basedir AS basePath FROM DUAL", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mysqlDump = reader[0].ToString() + "bin";
                            }
                        }
                    }

                    using (MySqlCommand command = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'scadadata'", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scadadataTables += $" {reader[0]}";
                            }
                        }
                    }

                    using (MySqlCommand command = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'scadacurcevalue' and TABLE_NAME like '%" + Convert.ToDateTime(txtTime.Text.Trim()).ToString("yyyyMM") + "'", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scadacurcevalueTables += $" {reader[0]}";
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库连接异常:{ex.Message}");
                return;
            }


            bgwork.ReportProgress(20);

            if (scadadataTables != "")
            {

                string scadadatacmd = $"mysqldump --host={txtIP.Text.Trim()} --default-character-set=utf8 --lock-tables   --port={txtPort.Text.Trim()} --user={txtUser.Text.Trim()} --password={txtPwd.Text.Trim()} --quick --databases scadadata --tables {scadadataTables} > {scadadataPath}";
                RunCmd(mysqlDump, scadadatacmd);
            }

            bgwork.ReportProgress(60);

            if (scadacurcevalueTables != "")
            {
                string scadacurcevaluecmd = $"mysqldump --host={txtIP.Text.Trim()} --default-character-set=utf8 --lock-tables   --port={txtPort.Text.Trim()} --user={txtUser.Text.Trim()} --password={txtPwd.Text.Trim()} --quick --databases scadacurcevalue --tables {scadacurcevalueTables} > {scadacurcevaluePath}";
                RunCmd(mysqlDump, scadacurcevaluecmd);
            }

            bgwork.ReportProgress(100);

            if (scadacurcevalueTables == "" && scadadataTables == "")
            {
                MessageBox.Show("生成失败");
            }
            else
            {
                MessageBox.Show("已生到指定路径");
            }
        }
        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                PGBar.Visible = true;
            }

            PGBar.Value = e.ProgressPercentage;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string mysqlDump = "";

            //连接数据库
            string connectionString = $"server={txtIP.Text.Trim()};user id={txtUser.Text.Trim()};password={txtPwd.Text.Trim()};persistsecurityinfo=False;port={txtPort.Text.Trim()};Pooling=true;Allow Zero Datetime=true;Charset=utf8;";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT @@basedir AS basePath FROM DUAL", connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // 处理每一行数据
                                mysqlDump = reader[0].ToString() + "bin";
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接到数据库");
                return;
            }


            OpenFileDialog open = new OpenFileDialog();

            var result = open.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = open.FileName;
                string databaseName = "";

                if (path.IndexOf("scadacurcevalue") != -1)
                {
                    databaseName = "scadacurcevalue";
                }
                else
                {
                    databaseName = "scadadata";
                }


            }

        }
    }
}
