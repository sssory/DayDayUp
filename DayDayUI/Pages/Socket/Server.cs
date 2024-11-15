using DayDayWinForm.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.Socket
{
    public partial class Server : UserControl
    {
        public Server()
        {
            InitializeComponent();
        }
        private void SocketServerControl_Load(object sender, EventArgs e)
        {

            txt_ip.Text = AppConfig.SocketIP;
            txt_port.Text = AppConfig.SocketPort;

            OnlineChange = onlinechange;
            SaveFile = savefile;
        }


        public System.Net.Sockets.Socket socket = null;

        public Dictionary<string, System.Net.Sockets.Socket> clients = new Dictionary<string, System.Net.Sockets.Socket>();

        private delegate void OnlineChangeDelegate(string user, System.Net.Sockets.Socket accept, bool isUp);
        private delegate void SaveFileDelegate(byte[] bytes, int length,string user);

        private OnlineChangeDelegate OnlineChange;
        private SaveFileDelegate SaveFile;

        private void savefile(byte[] bytes, int length,string user)
        {
            try
            { 
                string logPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                
                logPath = Path.Combine(logPath, "ServerFiles");

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                if (!logPath.EndsWith(@"\"))
                {
                    logPath += @"\";
                }

                string fileName= DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                logPath += fileName;

                using (FileStream fs = new FileStream(logPath, FileMode.Create))
                {
                    fs.Write(bytes, 1, length - 1);
                    App.LogMessage($"Server：收到客户端{user}的文件，{fileName}");
                }

            }
            catch (Exception ex)
            {
                App.LogMessage($"Server：保存时发生错误，" + ex.Message);
            }
        }
        private void onlinechange(string user, System.Net.Sockets.Socket accept, bool isUp)
        {
            if (lb_online.InvokeRequired)
            {
                lb_online.Invoke(OnlineChange,user,accept,isUp);
            }
            else
            {
                if (isUp)
                {
                    clients.Add(user, accept);
                    lb_online.Items.Add(user);
                }
                else
                {
                    clients.Remove(user);
                    lb_online.Items.Remove(user);
                }
            }

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            btn_open.Enabled = false;

            //创建负责监听的套接字
            socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //根据ip和port创建IPE对象
            IPAddress address = IPAddress.Parse(txt_ip.Text.Trim());
            IPEndPoint IPE = new IPEndPoint(address, int.Parse(txt_port.Text.Trim()));

            try
            {
                socket.Bind(IPE);


                //参数 10 指定了挂起连接队列的最大长度，也叫做监听队列的最大长度。
                //这表示最多有多少个等待连接的客户端可以排队等待服务器的接受（即调用 Accept()）处理。
                socket.Listen(10);

                App.LogMessage("Server：socket服务已开启");
                
            }
            catch (Exception ex)
            {
                App.LogMessage("Server：socket服务开启失败，" + ex.Message);
                btn_open.Enabled = true;
                return;
            }


            //开启后台线程监听
            Thread thread = new Thread(ListeningClient);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ListeningClient()
        {
            while (true)
            {
                //一旦监听到客户端连接 便会创建一个套接字
                System.Net.Sockets.Socket accept = socket.Accept();//这里会阻塞  直到收到连接

                string client = accept.RemoteEndPoint.ToString();

                App.LogMessage($"Server：客户端{client}上线");
                OnlineChange(client, accept, true);

                //开启接受线程
                Thread thread = new Thread(ReceiveMsg);
                thread.IsBackground = true;
                thread.Start(accept);
            }
        }

        private void ReceiveMsg(object acceptObj)
        {
            System.Net.Sockets.Socket accept = acceptObj as System.Net.Sockets.Socket;
            string user = accept.RemoteEndPoint.ToString();

            while (true)
            {
                //定义一个10M 缓冲区
                byte[] bytes = new byte[1024 * 10242 * 10];

                int length = -1;

                try
                {
                    length = accept.Receive(bytes);
                }
                catch (Exception)
                {
                    App.LogMessage($"Server：客户端{user}下线");
                    OnlineChange(user, accept, false);
                    break;
                }

                if (length == 0)
                {
                    App.LogMessage($"Server：客户端{user}下线：");
                    OnlineChange(user, accept, false);
                    break;
                }

                

                //约定第一位  0：文本消息  1：文件
                if (bytes[0]==0)
                {
                    //消息
                    string msg = Encoding.UTF8.GetString(bytes,1, bytes.Length - 1);
                    App.LogMessage($"Server：收到客户端{user}的消息，" + msg);

                }
                else
                {
                    //文件
                    this.Invoke( SaveFile,bytes, length, user);
                }

            }

        }

        private void btn_send_msg_Click(object sender, EventArgs e)
        {
            string msg = txt_send.Text.Trim();
            
            if (socket==null)
            {
                MessageBox.Show("服务未启动", "DayDayUp");
                return;
            }
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("请填写消息内容", "DayDayUp");
                return;
            }
            if (lb_online.Items.Count == 0)
            {
                MessageBox.Show("没有可发送对象", "DayDayUp");
                return;
            }
            if (lb_online.SelectedItems.Count == 0 && !cb_sendAll.Checked)
            {
                MessageBox.Show("请选择发送对象", "DayDayUp");
                return;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            byte[] newBytes = new byte[bytes.Length + 1];
            newBytes[0] = 0;
            Array.Copy(bytes, 0, newBytes, 1, bytes.Length);
            SendToClient(newBytes, msg);
            txt_send.Text = "";
        }

        private void btn_send_file_Click(object sender, EventArgs e)
        {
            if (socket == null)
            {
                MessageBox.Show("服务未启动", "DayDayUp");
                return;
            }
            if (lb_online.Items.Count == 0)
            {
                MessageBox.Show("没有可发送对象", "DayDayUp");
                return;
            }
            if (lb_online.SelectedItems.Count == 0 && !cb_sendAll.Checked)
            {
                MessageBox.Show("请选择发送对象", "DayDayUp");
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
                int filelength = fs.Read(bytes, 1, bytes.Length-1);
                SendToClient(bytes, fileD.FileName);

            }

        }

        private void SendToClient(byte[] bytes,string LogMessage="")
        {
            if (!cb_sendAll.Checked)
            {
                //发送选中
                foreach (var item in lb_online.SelectedItems)
                {
                    System.Net.Sockets.Socket value = null;
                    clients.TryGetValue(item.ToString(), out value);
                    if (value != null) value.Send(bytes);
                }
            }
            else
            {
                //群发
                foreach (string item in clients.Keys)
                {
                    var value = clients[item];
                    value.Send(bytes);
                }
            }
        }

    }
}
