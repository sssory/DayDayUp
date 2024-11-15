using DayDayWinForm.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.Socket
{
    public partial class Client : UserControl
    {
        public Client()
        {
            InitializeComponent();
        }

        private void SocketClientControl_Load(object sender, EventArgs e)
        {
            txt_ip.Text = AppConfig.SocketIP;
            txt_port.Text = AppConfig.SocketPort;
            SaveFile = savefile;
        }
        #region 消息
        private void LogMessage(string msg)
        {
            this.Invoke(new Action(() => {

                if (!string.IsNullOrEmpty(txt_receive.Text))
                {
                    txt_receive.AppendText("\r\n");
                }

                txt_receive.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg);
            }));
        }
        #endregion

        #region 文件
        private delegate void SaveFileDelegate(byte[] bytes, int length);

        private SaveFileDelegate SaveFile;

        private void savefile(byte[] bytes, int length)
        {
            try
            {
                string logPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                logPath = Path.Combine(logPath, "ClientFiles");

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                if (!logPath.EndsWith(@"\"))
                {
                    logPath += @"\";
                }

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                logPath += fileName;

                using (FileStream fs = new FileStream(logPath, FileMode.Create))
                {
                    fs.Write(bytes, 1, length - 1);

                    LogMessage("Server文件：" + fileName);
                }

            }
            catch (Exception ex)
            {
                LogMessage($"保存时发生错误，" + ex.Message);
            }
        }
        #endregion

        private System.Net.Sockets.Socket socket = null;
        private void btn_open_Click(object sender, EventArgs e)
        {
            btn_open.Enabled = false;
            socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(txt_ip.Text.Trim());
            IPEndPoint IPE = new IPEndPoint(address, int.Parse(txt_port.Text.Trim()));
            
            try
            {
                socket.Connect(IPE);
                LogMessage("socket服务已连接");
            }
            catch (Exception ex)
            {
                btn_open.Enabled = true;
                LogMessage("socket服务连接失败，" + ex.Message.Replace("\r","").Replace("\n", ""));
                return;
            }

            Thread thread = new Thread(ReceiveMsg);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ReceiveMsg()
        {
            while (true)
            {
                byte[] bytes = new byte[1024 * 1024 * 10];

                int length = -1;
                try
                {
                    length = socket.Receive(bytes);
                }
                catch (Exception)
                {
                    LogMessage($"连接已断线");
                    break;
                }

                if (length == 0)
                {
                    LogMessage($"连接已断线");
                    break;
                }


                if (bytes[0]==0)
                {
                    //消息
                    string msg = Encoding.UTF8.GetString(bytes, 1, bytes.Length - 1);
                    LogMessage("Server消息："+msg);
                }
                else
                {
                    //文件
                    this.Invoke(SaveFile, bytes, length);
                }


            }
        }

        private void btn_send_msg_Click(object sender, EventArgs e)
        {
            string msg = txt_send.Text.Trim();

            if (socket == null)
            {
                MessageBox.Show("未连接服务", "DayDayUp");
                return;
            }
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("请填写消息内容", "DayDayUp");
                return;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            byte[] newBytes = new byte[bytes.Length + 1];
            newBytes[0] = 0;
            Array.Copy(bytes, 0, newBytes, 1, bytes.Length);
            socket.Send(newBytes);
            txt_send.Text = "";
        }

        private void btn_send_file_Click(object sender, EventArgs e)
        {
            if (socket == null)
            {
                MessageBox.Show("未连接服务", "DayDayUp");
                return;
            }
            

            OpenFileDialog fileD = new OpenFileDialog();

            // 设置对话框的属性
            fileD.InitialDirectory = "c:\\"; // 设置初始目录
            fileD.Filter = "文本文件(*.txt)|*.txt"; // 设置文件过滤器
            fileD.FilterIndex = 1;
            fileD.RestoreDirectory = true;

            if (fileD.ShowDialog() != DialogResult.OK) // 显示对话框
            {
                return;
            }

            // 获取选中的文件路径
            string filePath = fileD.FileName;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {

                byte[] bytes = new byte[fs.Length + 1];
                bytes[0] = 1;
                int filelength = fs.Read(bytes, 1, bytes.Length - 1);
                socket.Send(bytes);

            }
        }
    }
}
