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

namespace DayDayWinForm.Pages.Common
{
    public partial class ShowImgForm : Form
    {
        string FileName = "";
        public ShowImgForm(string fileName)
        {
            FileName = fileName;
            InitializeComponent();
        }
     

        private void McEthernetShow_Load(object sender, EventArgs e)
        {
            Stream stream = File.OpenRead(FileName);
            Image image = Image.FromStream(stream, false, false);
            if (image.Width + 10>1920&& image.Height + 50>1080)
            {
                MessageBox.Show("图片太大,请联系管理员处理");
                return;
            }
            this.Size = new Size(image.Width+10, image.Height+50);
            pictureBox1.Size = new Size(image.Width , image.Height);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Load(FileName);
        }
    }
}
