using DayDayWinForm.Pages.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.Socket
{
    public partial class HostLinkCMode : UserControl
    {
        public HostLinkCMode()
        {
            InitializeComponent();
        }
        
        public string startcode = "@";
        public string PcNo = "00";
        public string headcode = "FA";
        public string awaittime = "0";
        public string SID = "00";
        public string SA2 = "00";
        public string DA2 = "00";
        public string ICF = "00";
            public string Rcommand = "0101";
        /// <summary>
        /// 首地址
        /// </summary>
        public string HeaderDe = "000000";
        public string DeCode = "30";
        /// <summary>
        /// 读取长度
        /// </summary>
        public string DepointNo = "0001";
        /// <summary>
        /// 发送数据
        /// </summary>
        public string WriteData = "";
        public string HostLinkWriteAll
        {
            set { HostLinkWriteAll = value; }
            get
            {
                return startcode + PcNo + headcode+ awaittime+SID+SA2+DA2+ICF+Rcommand+HeaderDe+DeCode+DepointNo+WriteData;


            }
        }
        public string message(string HeaderDe1,string DeCode1,string DepointNo1,string WriteData1,string Rcommand1) {
            try
            {
                HeaderDe = HeaderDe1;
                DepointNo = DepointNo1;
                DeCode = DeCode1;
                WriteData = WriteData1;
                Rcommand = Rcommand1;
                char[] car = HostLinkWriteAll.ToCharArray();
                int sum = 0;
                foreach (var item in car)
                {

                    int a = Convert.ToInt32(item);
                    sum ^= a;
                }
                if (sum >= 0 && sum <= 9)
                {

                    return HostLinkWriteAll + "0" + sum.ToString("X2");
                }
                else
                {
                    return HostLinkWriteAll + sum.ToString("X2");
                }
            }
            catch (Exception ex) 
            {

                throw;
            }
          
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.txt_send.Text = message(this.txtregister.Text, this.txtDeCode.Text, this.txtDepointNo.Text, this.txtdata.Text, this.txtMccomand.Text) + "*\\CR";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            this.txt_send.Text = message(this.txtregister.Text, this.txtDeCode.Text, this.txtDepointNo.Text, "", this.txtMccomand.Text)+"*\\CR";
        }
        public string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = Path.Combine(appPath, "Resources\\Img\\欧姆龙HostLink报文详情说明.png");
                ShowImgForm mcEthernetShow = new ShowImgForm(filepath);
                mcEthernetShow.ShowDialog();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = Path.Combine(appPath, "Resources\\Img\\欧姆龙HostLink 返回报文详情说明.jpg");
                ShowImgForm mcEthernetShow = new ShowImgForm(filepath);
                mcEthernetShow.ShowDialog();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = Path.Combine(appPath, "Resources\\Img\\欧姆龙HostLink存储区说明.jpg");
                ShowImgForm mcEthernetShow = new ShowImgForm(filepath);
                mcEthernetShow.ShowDialog();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
