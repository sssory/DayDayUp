namespace DayDayWinForm.Pages.Tool
{
    partial class SqlBackUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgwork = new System.ComponentModel.BackgroundWorker();
            this.PGBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14F);
            this.label9.Location = new System.Drawing.Point(236, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 19);
            this.label9.TabIndex = 69;
            this.label9.Text = "备份至:";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("宋体", 14F);
            this.lblPath.Location = new System.Drawing.Point(309, 253);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 19);
            this.lblPath.TabIndex = 70;
            this.lblPath.Click += new System.EventHandler(this.LblPath_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(501, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 68;
            this.label8.Text = "注:日志数据日期";
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestore.Font = new System.Drawing.Font("宋体", 14F);
            this.btnRestore.Location = new System.Drawing.Point(313, 341);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(182, 30);
            this.btnRestore.TabIndex = 67;
            this.btnRestore.Text = "数据还原";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnExec
            // 
            this.btnExec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExec.Font = new System.Drawing.Font("宋体", 14F);
            this.btnExec.Location = new System.Drawing.Point(313, 289);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(182, 30);
            this.btnExec.TabIndex = 66;
            this.btnExec.Text = "开始备份";
            this.btnExec.UseVisualStyleBackColor = false;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // txtTime
            // 
            this.txtTime.CalendarFont = new System.Drawing.Font("宋体", 14F);
            this.txtTime.CustomFormat = "yyyy-MM";
            this.txtTime.Font = new System.Drawing.Font("宋体", 14F);
            this.txtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTime.Location = new System.Drawing.Point(313, 205);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(182, 29);
            this.txtTime.TabIndex = 64;
            this.txtTime.Value = new System.DateTime(2024, 6, 18, 10, 34, 48, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(235, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 65;
            this.label3.Text = "日  期:";
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 14F);
            this.txtPwd.Location = new System.Drawing.Point(313, 153);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(182, 29);
            this.txtPwd.TabIndex = 63;
            this.txtPwd.Text = "uce2010";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.Location = new System.Drawing.Point(235, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 62;
            this.label6.Text = "密  码:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 12);
            this.label7.TabIndex = 61;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("宋体", 14F);
            this.txtUser.Location = new System.Drawing.Point(313, 95);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(182, 29);
            this.txtUser.TabIndex = 60;
            this.txtUser.Text = "root";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(235, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 59;
            this.label4.Text = "用户名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 58;
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("宋体", 14F);
            this.txtPort.Location = new System.Drawing.Point(501, 39);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(53, 29);
            this.txtPort.TabIndex = 57;
            this.txtPort.Text = "3306";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("宋体", 14F);
            this.txtIP.Location = new System.Drawing.Point(313, 39);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(182, 29);
            this.txtIP.TabIndex = 56;
            this.txtIP.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(235, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 55;
            this.label2.Text = "服务器:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 54;
            // 
            // bgwork
            // 
            this.bgwork.WorkerReportsProgress = true;
            this.bgwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwork_DoWork);
            this.bgwork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwork_ProgressChanged);
            // 
            // PGBar
            // 
            this.PGBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PGBar.Location = new System.Drawing.Point(0, 440);
            this.PGBar.Name = "PGBar";
            this.PGBar.Size = new System.Drawing.Size(800, 10);
            this.PGBar.TabIndex = 71;
            this.PGBar.Visible = false;
            // 
            // SqlBackUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PGBar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SqlBackUpForm";
            this.Text = "SqlBackUpForm";
            this.Load += new System.EventHandler(this.MySqlBackUpControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.DateTimePicker txtTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgwork;
        private System.Windows.Forms.ProgressBar PGBar;
    }
}