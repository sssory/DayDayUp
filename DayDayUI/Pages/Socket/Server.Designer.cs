namespace DayDayWinForm.Pages.Socket
{
    partial class Server
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
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.MaskedTextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_send_msg = new System.Windows.Forms.Button();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.btn_send_file = new System.Windows.Forms.Button();
            this.cb_sendAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_online = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(437, 33);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(100, 21);
            this.txt_ip.TabIndex = 1;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(543, 33);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(38, 21);
            this.txt_port.TabIndex = 2;
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_open.ForeColor = System.Drawing.Color.LimeGreen;
            this.btn_open.Location = new System.Drawing.Point(437, 70);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(144, 43);
            this.btn_open.TabIndex = 3;
            this.btn_open.Text = "开启服务";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "在线列表";
            // 
            // btn_send_msg
            // 
            this.btn_send_msg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_send_msg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_send_msg.Location = new System.Drawing.Point(437, 130);
            this.btn_send_msg.Name = "btn_send_msg";
            this.btn_send_msg.Size = new System.Drawing.Size(144, 29);
            this.btn_send_msg.TabIndex = 8;
            this.btn_send_msg.Text = "消息发送";
            this.btn_send_msg.UseVisualStyleBackColor = true;
            this.btn_send_msg.Click += new System.EventHandler(this.btn_send_msg_Click);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(236, 33);
            this.txt_send.Multiline = true;
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(178, 352);
            this.txt_send.TabIndex = 9;
            // 
            // btn_send_file
            // 
            this.btn_send_file.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_send_file.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_send_file.Location = new System.Drawing.Point(437, 176);
            this.btn_send_file.Name = "btn_send_file";
            this.btn_send_file.Size = new System.Drawing.Size(144, 29);
            this.btn_send_file.TabIndex = 10;
            this.btn_send_file.Text = "文件发送";
            this.btn_send_file.UseVisualStyleBackColor = true;
            this.btn_send_file.Click += new System.EventHandler(this.btn_send_file_Click);
            // 
            // cb_sendAll
            // 
            this.cb_sendAll.AutoSize = true;
            this.cb_sendAll.Checked = true;
            this.cb_sendAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_sendAll.Location = new System.Drawing.Point(293, 14);
            this.cb_sendAll.Name = "cb_sendAll";
            this.cb_sendAll.Size = new System.Drawing.Size(48, 16);
            this.cb_sendAll.TabIndex = 11;
            this.cb_sendAll.Text = "群发";
            this.cb_sendAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "消息发送";
            // 
            // lb_online
            // 
            this.lb_online.FormattingEnabled = true;
            this.lb_online.ItemHeight = 12;
            this.lb_online.Location = new System.Drawing.Point(36, 33);
            this.lb_online.Name = "lb_online";
            this.lb_online.Size = new System.Drawing.Size(178, 352);
            this.lb_online.TabIndex = 13;
            // 
            // SocketServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_online);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_sendAll);
            this.Controls.Add(this.btn_send_file);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.btn_send_msg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Name = "SocketServerControl";
            this.Size = new System.Drawing.Size(1100, 454);
            this.Load += new System.EventHandler(this.SocketServerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.MaskedTextBox txt_port;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_send_msg;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.Button btn_send_file;
        private System.Windows.Forms.CheckBox cb_sendAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_online;
    }
}
