namespace DayDayWinForm
{
    partial class DayDayWindow
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayDayWindow));
            this.menu_head = new System.Windows.Forms.MenuStrip();
            this.status_foot = new System.Windows.Forms.StatusStrip();
            this.status_foot_service = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_foot_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.tab_body = new System.Windows.Forms.TabControl();
            this.tab_body_main = new System.Windows.Forms.TabPage();
            this.btnDefault = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.status_foot.SuspendLayout();
            this.tab_body.SuspendLayout();
            this.tab_body_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_head
            // 
            this.menu_head.Location = new System.Drawing.Point(0, 0);
            this.menu_head.Name = "menu_head";
            this.menu_head.Size = new System.Drawing.Size(1184, 24);
            this.menu_head.TabIndex = 0;
            this.menu_head.Text = "menuStrip1";
            // 
            // status_foot
            // 
            this.status_foot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_foot_service,
            this.status_foot_user});
            this.status_foot.Location = new System.Drawing.Point(0, 717);
            this.status_foot.Name = "status_foot";
            this.status_foot.Size = new System.Drawing.Size(1184, 22);
            this.status_foot.TabIndex = 1;
            this.status_foot.Text = "statusStrip1";
            // 
            // status_foot_service
            // 
            this.status_foot_service.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_foot_service.Name = "status_foot_service";
            this.status_foot_service.Size = new System.Drawing.Size(65, 21);
            this.status_foot_service.Text = "Service：";
            this.status_foot_service.Visible = false;
            // 
            // status_foot_user
            // 
            this.status_foot_user.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.status_foot_user.Name = "status_foot_user";
            this.status_foot_user.Size = new System.Drawing.Size(72, 21);
            this.status_foot_user.Text = "当前用户：";
            this.status_foot_user.Visible = false;
            // 
            // txt_msg
            // 
            this.txt_msg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_msg.Location = new System.Drawing.Point(0, 556);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ReadOnly = true;
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_msg.Size = new System.Drawing.Size(1184, 161);
            this.txt_msg.TabIndex = 2;
            // 
            // tab_body
            // 
            this.tab_body.Controls.Add(this.tab_body_main);
            this.tab_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_body.Location = new System.Drawing.Point(0, 24);
            this.tab_body.Name = "tab_body";
            this.tab_body.SelectedIndex = 0;
            this.tab_body.Size = new System.Drawing.Size(1184, 532);
            this.tab_body.TabIndex = 4;
            this.tab_body.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tab_body_MouseUp);
            // 
            // tab_body_main
            // 
            this.tab_body_main.Controls.Add(this.btnDefault);
            this.tab_body_main.Controls.Add(this.txtTime);
            this.tab_body_main.Controls.Add(this.label1);
            this.tab_body_main.Location = new System.Drawing.Point(4, 22);
            this.tab_body_main.Name = "tab_body_main";
            this.tab_body_main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_body_main.Size = new System.Drawing.Size(1176, 506);
            this.tab_body_main.TabIndex = 1;
            this.tab_body_main.Text = "welcome";
            this.tab_body_main.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(12, 124);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(153, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "button";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(12, 74);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(153, 21);
            this.txtTime.TabIndex = 1;
            this.txtTime.Enter += new System.EventHandler(this.txtTime_Enter);
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 40F);
            this.label1.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Day Day Up";
            // 
            // DayDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.tab_body);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.status_foot);
            this.Controls.Add(this.menu_head);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu_head;
            this.Name = "DayDayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DayDayUp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DayDayForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayDayForm_KeyDown);
            this.status_foot.ResumeLayout(false);
            this.status_foot.PerformLayout();
            this.tab_body.ResumeLayout(false);
            this.tab_body_main.ResumeLayout(false);
            this.tab_body_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_head;
        private System.Windows.Forms.StatusStrip status_foot;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.ToolStripStatusLabel status_foot_service;
        private System.Windows.Forms.TabControl tab_body;
        private System.Windows.Forms.TabPage tab_body_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel status_foot_user;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnDefault;
    }
}

