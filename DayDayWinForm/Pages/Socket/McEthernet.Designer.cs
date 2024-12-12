
namespace DayDayWinForm.Pages.Socket
{
    partial class McEthernet
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_send_msg = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.MaskedTextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.rbascill = new System.Windows.Forms.RadioButton();
            this.rbbinary = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDepointNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMcsubcomand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMccomand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbmodel = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtdata = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtregister = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_send_msg
            // 
            this.btn_send_msg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_send_msg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_send_msg.Location = new System.Drawing.Point(510, 313);
            this.btn_send_msg.Name = "btn_send_msg";
            this.btn_send_msg.Size = new System.Drawing.Size(144, 29);
            this.btn_send_msg.TabIndex = 28;
            this.btn_send_msg.Text = "消息发送";
            this.btn_send_msg.UseVisualStyleBackColor = true;
            this.btn_send_msg.Click += new System.EventHandler(this.btn_send_msg_Click);
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_open.ForeColor = System.Drawing.Color.LimeGreen;
            this.btn_open.Location = new System.Drawing.Point(27, 80);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(144, 43);
            this.btn_open.TabIndex = 27;
            this.btn_open.Text = "连接服务";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(133, 43);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(38, 21);
            this.txt_port.TabIndex = 26;
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(27, 43);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(100, 21);
            this.txt_ip.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "消息发送";
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(82, 316);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(409, 21);
            this.txt_send.TabIndex = 23;
            // 
            // rbascill
            // 
            this.rbascill.AutoSize = true;
            this.rbascill.Checked = true;
            this.rbascill.Location = new System.Drawing.Point(205, 3);
            this.rbascill.Name = "rbascill";
            this.rbascill.Size = new System.Drawing.Size(59, 16);
            this.rbascill.TabIndex = 34;
            this.rbascill.TabStop = true;
            this.rbascill.Text = "Ascill";
            this.rbascill.UseVisualStyleBackColor = true;
            // 
            // rbbinary
            // 
            this.rbbinary.AutoSize = true;
            this.rbbinary.Location = new System.Drawing.Point(273, 3);
            this.rbbinary.Name = "rbbinary";
            this.rbbinary.Size = new System.Drawing.Size(59, 16);
            this.rbbinary.TabIndex = 33;
            this.rbbinary.Text = "二进制";
            this.rbbinary.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.txtDepointNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtMcsubcomand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMccomand);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbmodel);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtdata);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtregister);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(195, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 278);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "三帧数据区";
            // 
            // txtDepointNo
            // 
            this.txtDepointNo.Location = new System.Drawing.Point(85, 157);
            this.txtDepointNo.Name = "txtDepointNo";
            this.txtDepointNo.Size = new System.Drawing.Size(144, 21);
            this.txtDepointNo.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "读取长度:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "完整的六位寄存器地址";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 26;
            this.button1.Text = "生成读取报文";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMcsubcomand
            // 
            this.txtMcsubcomand.Location = new System.Drawing.Point(85, 121);
            this.txtMcsubcomand.Name = "txtMcsubcomand";
            this.txtMcsubcomand.Size = new System.Drawing.Size(144, 21);
            this.txtMcsubcomand.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "发送字指令:";
            // 
            // txtMccomand
            // 
            this.txtMccomand.Location = new System.Drawing.Point(85, 88);
            this.txtMccomand.Name = "txtMccomand";
            this.txtMccomand.Size = new System.Drawing.Size(144, 21);
            this.txtMccomand.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "发送指令:";
            // 
            // cbmodel
            // 
            this.cbmodel.FormattingEnabled = true;
            this.cbmodel.Items.AddRange(new object[] {
            "SM",
            "SD",
            "X",
            "Y",
            "M",
            "L",
            "F",
            "V",
            "B",
            "D",
            "W",
            "TS",
            "TC",
            "TN",
            "SS",
            "SC",
            "SN",
            "CS",
            "CC",
            "CN",
            "SB",
            "SW",
            "S",
            "DX",
            "DY",
            "Z",
            "R",
            "ZR",
            ""});
            this.cbmodel.Location = new System.Drawing.Point(85, 57);
            this.cbmodel.Name = "cbmodel";
            this.cbmodel.Size = new System.Drawing.Size(144, 20);
            this.cbmodel.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(42, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 29);
            this.button2.TabIndex = 16;
            this.button2.Text = "生成发送报文";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtdata
            // 
            this.txtdata.Location = new System.Drawing.Point(85, 192);
            this.txtdata.Name = "txtdata";
            this.txtdata.Size = new System.Drawing.Size(144, 21);
            this.txtdata.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "发送数据:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "寄存器型号:";
            // 
            // txtregister
            // 
            this.txtregister.Location = new System.Drawing.Point(85, 23);
            this.txtregister.Name = "txtregister";
            this.txtregister.Size = new System.Drawing.Size(144, 21);
            this.txtregister.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "寄存器地址:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(580, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "MC说明:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(582, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 29);
            this.button3.TabIndex = 27;
            this.button3.Text = "查看指令详情";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(582, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 29);
            this.button4.TabIndex = 35;
            this.button4.Text = "查看寄存器详情";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(582, 112);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 29);
            this.button5.TabIndex = 36;
            this.button5.Text = "查看报文详情说明";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(246, 57);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 29);
            this.button6.TabIndex = 30;
            this.button6.Text = "配置读取";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(246, 92);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 29);
            this.button7.TabIndex = 31;
            this.button7.Text = "配置写入";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // McEthernetClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rbascill);
            this.Controls.Add(this.rbbinary);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_send_msg);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_send);
            this.Name = "McEthernetClientControl";
            this.Size = new System.Drawing.Size(1068, 382);
            this.Load += new System.EventHandler(this.McEthernetClientControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_send_msg;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.MaskedTextBox txt_port;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.RadioButton rbascill;
        private System.Windows.Forms.RadioButton rbbinary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtdata;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtregister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbmodel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMcsubcomand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMccomand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDepointNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
    }
}
