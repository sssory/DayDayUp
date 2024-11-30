using System;
using DayDayWinForm.Tools;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Reflection;
using DayDayWinForm.Pages.Common;

namespace DayDayWinForm.Pages.Socket
{
    public partial class McEthernet : UserControl
    {
        public McEthernet()
        {
            InitializeComponent();
        }

        private void McEthernetClientControl_Load(object sender, EventArgs e)
        {
            txt_ip.Text = AppConfig.SocketIP;
            txt_port.Text = AppConfig.SocketPort;
            SaveFile = savefile;
            this.cbmodel.SelectedIndex = 1;
        }
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
        private System.Net.Sockets.Socket socket = null;
        #region 消息
        private void LogMessage(string msg)
        {
            App.LogMessage(msg);
        }
        #endregion
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


                if (bytes[0] == 0)
                {
                    //消息
                    string msg = Encoding.UTF8.GetString(bytes, 1, bytes.Length - 1);
                    LogMessage("Server消息：" + msg);
                }
                else
                {
                    string msg = "";
                    if (this.rbascill.Checked)
                    {
                        msg = Encoding.UTF8.GetString(bytes).Substring(0, length);
                        LogMessage("接收报文:" + msg);
                    }
                    else {
                        // 将byte数组转换为十六进制字符串  
                        string hexString = BitConverter.ToString(bytes).Replace("-", "").ToUpper().Substring(0, length*2); ;
            
                        LogMessage("接收报文:" + hexString);
                    }

                }


            }
        }
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
                LogMessage("socket服务连接失败，" + ex.Message.Replace("\r", "").Replace("\n", ""));
                return;
            }

            Thread thread = new Thread(ReceiveMsg);
            thread.IsBackground = true;
            thread.Start();
        }
        #region 转换方法
        public static string AsciiToBinaryFour(string ascii)
        {
            string binary = string.Empty;
            if (ascii.Length == 4)
            {
                binary = ascii.Substring(2, 2) + ascii.Substring(0, 2);
            }
            return binary.ToUpper();
        }
        public static bool IsNumeric(string str)
        {
            bool ok = false;
            if (str != null && System.Text.RegularExpressions.Regex.IsMatch(str, @"^\d+$"))
                ok = true;
            return ok;
        }
        public static string ConvertString(string value, int fromBase, int toBase)
        {
            try
            {

                int intValue = Convert.ToInt32(value, fromBase);
                return Convert.ToString(intValue, toBase);
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        public static string AsciiToBinarySix(string ascii)
        {
            string binary = string.Empty;
            if (ascii.Length == 6)
            {
                if (IsNumeric(ascii))
                {
                    int mcaddress = Convert.ToInt32(ascii);
                    ascii = ConvertString(mcaddress.ToString(), 10, 16).PadLeft(6, '0');
                    binary = ascii.Substring(4, 2) + ascii.Substring(2, 2) + ascii.Substring(0, 2);
                }
                else
                {
                    //当寄存器为B，X，Y 16进制的时候处理
                    binary = ascii.Substring(4, 2) + ascii.Substring(2, 2) + ascii.Substring(0, 2);
                }

            }
            return binary.ToUpper();
        }
        #endregion
        #region 组成报文
        /// <summary>
        /// 命令副头部 表示发起指令
        /// </summary>
        public string Subheader = "5000";
        /// <summary>
        /// 网络编号 默认00
        /// </summary>
        public string NetNo = "00";
        /// <summary>
        /// PLC编号 默认FF
        /// </summary>
        public string PcNo = "FF";
        /// <summary>
        /// 请求访问IO模块信号
        /// </summary>
        public string RmIoNo = "03FF";
        /// <summary>
        /// 请求目标模块站编号
        /// </summary>
        public string RmSNo = "00";
        /// <summary>
        /// 请求数据长度
        /// </summary>
        public string RDataLength = "0018";
        /// <summary>
        /// CPU监视定时器
        /// </summary>
        public string CpuMtime = "0010";
        /// <summary>
        /// 批量读命令 0401代表批量读取 1401 代表批量写入 ******
        /// </summary>
        public string McRcomand = "0401";//二进制
        public string McWcomand = "0401";//ASCill

        /// <summary>
        /// 字命令 0代表按字读取 1 代表按位读取 ********
        /// </summary>
        public string McRsubcomand = "0001";//二进制
        public string McWsubcomand = "0001";//ASCill
        /// <summary>
        /// 首地址
        /// </summary>
        public string HeaderDe = "000000";

        /// <summary>
        /// 软元件 读取区域 ******** 网上查找具体的读取区域对应的软元件值 下面只列举了D区和L区
        /// </summary>
        public string BinaryDeCode = "A8";//二进制
        public string DeCode = "D*";//ASCill
        /// <summary>
        /// 读取长度
        /// </summary>
        public string DepointNo = "0001";
        /// <summary>
        /// 发送数据
        /// </summary>
        public string WriteData = "";
        #endregion 

        /// <summary>
        /// 二进制报文
        /// </summary>
        public string BinaryMcWriteAll
        {
            set { BinaryMcWriteAll = value; }
            get
            {
                return Subheader + NetNo + PcNo + AsciiToBinaryFour(RmIoNo) + RmSNo + RDataLength +
               AsciiToBinaryFour(CpuMtime) + AsciiToBinaryFour(McRcomand) + AsciiToBinaryFour(McRsubcomand) + AsciiToBinarySix(HeaderDe) + BinaryDeCode +
               AsciiToBinaryFour(DepointNo) + WriteData;
            }
        }
        public string BinaryMcWritedPart
        {
            get
            {
                return AsciiToBinaryFour(CpuMtime) + AsciiToBinaryFour(McRcomand) + AsciiToBinaryFour(McRsubcomand) + AsciiToBinarySix(HeaderDe) + BinaryDeCode +
                      AsciiToBinaryFour(DepointNo) + this.WriteData;
            }
        }
        public string AsciiMcWriteAll
        {
            set { AsciiMcWriteAll = value; }
            get
            {
                return Subheader + NetNo + PcNo + RmIoNo + RmSNo + RDataLength +
                    CpuMtime + McWcomand + McWsubcomand + DeCode + HeaderDe +
                       DepointNo + this.WriteData;
            }
        }
        public string AsciiMcWritedPart
        {
            get
            {
                return CpuMtime +McWcomand +McWsubcomand +DeCode +HeaderDe +
                      DepointNo + this.WriteData;
            }
        }
        public void BinaryDeCodeCount(string model) {
            switch (model)
            {
                case "SM"://特殊继电器
                    BinaryDeCode = "91";
                    DeCode = "SM";
                    break;
                case "SD"://特殊寄存器
                    BinaryDeCode = "A9";
                    DeCode = "SD";
                    break;
                case "X"://输入
                    BinaryDeCode = "9C";
                    DeCode = "X*";
                    break;
                case "Y"://输出
                    BinaryDeCode = "9D";
                    DeCode = "Y*";
                    break;
                case "M"://内部继电器
                    BinaryDeCode = "90";
                    DeCode = "M*";
                    break;
                case "L"://锁存继电器
                    BinaryDeCode = "92";
                    DeCode = "L*";
                    break;
                case "F"://报警器
                    BinaryDeCode = "93";
                    DeCode = "F*";
                    break;
                case "V"://变址继电器
                    BinaryDeCode = "94";
                    DeCode = "V*";
                    break;
                case "B"://链接继电器
                    BinaryDeCode = "A0";
                    DeCode = "B*";
                    break;
                case "D"://数据寄存器
                    BinaryDeCode = "A8";
                    DeCode = "D*";
                    break;
                case "W"://链接寄存器
                    BinaryDeCode = "B4";
                    DeCode = "W*";
                    break;
                    //定时器*3
                case "TS": //触点
                    BinaryDeCode = "C1";
                    DeCode = "TS";
                    break;
                case "TC"://线圈
                    BinaryDeCode = "C0";
                    DeCode = "TC";
                    break;
                case "TN"://当前值
                    BinaryDeCode = "C2";
                    DeCode = "TN";
                    break;
                    //累计定时器*3
                case "SS"://触点
                    BinaryDeCode = "C7";
                    DeCode = "SS";
                    break;
                case "SC"://线圈
                    BinaryDeCode = "C6";
                    DeCode = "SC";
                    break;
                case "SN"://当前值
                    BinaryDeCode = "C8";
                    DeCode = "SN";
                    break;
                    //计数器*3
                case "CS"://触点
                    BinaryDeCode = "C4";
                    DeCode = "CS";
                    break;
                case "CC"://线圈
                    BinaryDeCode = "C3";
                    DeCode = "CC";
                    break;
                case "CN"://当前值
                    BinaryDeCode = "C5";
                    DeCode = "CN";
                    break;
                case "SB"://链接特殊继电器
                    BinaryDeCode = "A1";
                    DeCode = "SB";
                    break;
                case "SW"://链接特殊寄存器
                    BinaryDeCode = "B5";
                    DeCode = "SW";
                    break;
                case "S"://步进继电器*2
                    BinaryDeCode = "98";
                    DeCode = "S*";
                    break;
                case "DX"://直接输入
                    BinaryDeCode = "A2";
                    DeCode = "DX";
                    break;
                case "DY"://直接输出
                    BinaryDeCode = "A3";
                    DeCode = "DY";
                    break;
                case "Z"://变址寄存器
                    BinaryDeCode = "CC";
                    DeCode = "Z*";
                    break;
                case "R"://文件寄存器*4
                    BinaryDeCode = "AF";
                    DeCode = "R*";
                    break;
                case "ZR"://文件寄存器*6
                    BinaryDeCode = "B0";
                    DeCode = "ZR";
                    break;
                default:
                    break;
            }


        }
        public void Bindtxt_Send(string writeData) {
            try
            {
                McRcomand = McWcomand = this.txtMccomand.Text;
                McWsubcomand = McRsubcomand = this.txtMcsubcomand.Text;
                HeaderDe = this.txtregister.Text;
                BinaryDeCodeCount(this.cbmodel.Text);
                DepointNo = this.txtDepointNo.Text;
                WriteData = writeData;

                if (rbascill.Checked)
                {
                    int lengthstring = AsciiMcWritedPart.Length ;
                    string rDataLength = ConvertString(lengthstring.ToString(), 10, 16).PadLeft(4, '0').ToUpper();
                   
                    RDataLength = rDataLength;
                    this.txt_send.Text = AsciiMcWriteAll;
                }
                else
                {
                    int lengthstring = BinaryMcWritedPart.Length / 2;
                    string rDataLength = ConvertString(lengthstring.ToString(), 10, 16).PadLeft(4, '0').ToUpper();
                    rDataLength = rDataLength.Substring(2, 2) + rDataLength.Substring(0, 2);
                    RDataLength = rDataLength;
                    this.txt_send.Text = BinaryMcWriteAll;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bindtxt_Send(this.txtdata.Text);
        }
        public static byte[] GetComandByte(string commandStr)
        {
            byte[] bData = { 0 };
            Int32 dataLength = commandStr.Length / 2;
            bData = new byte[dataLength];
            try
            {
                for (int i = 0; i < dataLength; i++)
                {
                    bData[i] = byte.Parse(ConvertString(commandStr.ToString().Substring(i * 2, 2), 16, 10));
                }
            }
            catch (Exception ex)
            {

            }
            return bData;
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
            byte[] comBytes = Encoding.UTF8.GetBytes(msg);
            if (rbbinary.Checked)
            {
            comBytes = GetComandByte(msg);
			}
            socket.Send(comBytes);
            LogMessage("发送报文:" + txt_send.Text);
            txt_send.Text = "";
        }
        public string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = Path.Combine(appPath, "Resources\\Img\\三菱 MC 三帧指令说明.jpg");
                ShowImgForm mcEthernetShow = new ShowImgForm(filepath);
                mcEthernetShow.ShowDialog();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(appPath, "Resources\\Img\\三菱 MC 三帧软元件说明.jpg");
            ShowImgForm mcEthernetShow = new ShowImgForm(filepath);
            mcEthernetShow.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bindtxt_Send("");

        }
       
        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = Path.Combine(appPath, "Resources\\Img\\三菱 MC 三帧报文详情说明.jpg");
                ShowImgForm mcEthernetShow = new ShowImgForm(filepath);
                mcEthernetShow.ShowDialog();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtMccomand.Text = "0401";
            this.txtMcsubcomand.Text = "0000";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.txtMccomand.Text = "1401";
            this.txtMcsubcomand.Text = "0000";
        }
    }

}
