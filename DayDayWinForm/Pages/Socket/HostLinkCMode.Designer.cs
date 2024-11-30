
namespace DayDayWinForm.Pages.Socket
{
    partial class HostLinkCMode
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDeCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDepointNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtMccomand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtdata = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtregister = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDeCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDepointNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnRead);
            this.groupBox1.Controls.Add(this.txtMccomand);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.txtdata);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtregister);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(26, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 290);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "C_mode数据区";
            // 
            // txtDeCode
            // 
            this.txtDeCode.Location = new System.Drawing.Point(85, 112);
            this.txtDeCode.Name = "txtDeCode";
            this.txtDeCode.Size = new System.Drawing.Size(144, 21);
            this.txtDeCode.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "存储区代号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(83, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "注:FCS默认Ascii异或验证";
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
            this.label9.Location = new System.Drawing.Point(8, 162);
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
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(179, 245);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(95, 29);
            this.btnRead.TabIndex = 26;
            this.btnRead.Text = "生成读取报文";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtMccomand
            // 
            this.txtMccomand.Location = new System.Drawing.Point(85, 71);
            this.txtMccomand.Name = "txtMccomand";
            this.txtMccomand.Size = new System.Drawing.Size(144, 21);
            this.txtMccomand.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "发送指令:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(35, 245);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 29);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "生成发送报文";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtdata
            // 
            this.txtdata.Location = new System.Drawing.Point(85, 198);
            this.txtdata.Name = "txtdata";
            this.txtdata.Size = new System.Drawing.Size(144, 21);
            this.txtdata.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "发送数据:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "生成报文";
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(93, 362);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(409, 21);
            this.txt_send.TabIndex = 34;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(426, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 29);
            this.button5.TabIndex = 37;
            this.button5.Text = "查看报文详情说明";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 29);
            this.button1.TabIndex = 38;
            this.button1.Text = "查看返回报文详情说明";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 29);
            this.button2.TabIndex = 39;
            this.button2.Text = "存储区代号说明";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HostLinkCmodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.groupBox1);
            this.Name = "HostLinkCmodeControl";
            this.Size = new System.Drawing.Size(785, 415);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDepointNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtdata;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtregister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMccomand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
