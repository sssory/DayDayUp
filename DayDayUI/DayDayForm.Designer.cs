namespace DayDayUI
{
    partial class DayDayForm
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
            this.menu_head = new System.Windows.Forms.MenuStrip();
            this.Menus = new System.Windows.Forms.ToolStripMenuItem();
            this.Base_ApiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.Base_ApiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.Base_ClearMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.Base_ReloadForm = new System.Windows.Forms.ToolStripMenuItem();
            this.status_foot = new System.Windows.Forms.StatusStrip();
            this.status_foot_service = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.tab_body = new System.Windows.Forms.TabControl();
            this.tab_body_main = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.menu_head.SuspendLayout();
            this.status_foot.SuspendLayout();
            this.tab_body.SuspendLayout();
            this.tab_body_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_head
            // 
            this.menu_head.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menus});
            this.menu_head.Location = new System.Drawing.Point(0, 0);
            this.menu_head.Name = "menu_head";
            this.menu_head.Size = new System.Drawing.Size(1184, 25);
            this.menu_head.TabIndex = 0;
            this.menu_head.Text = "menuStrip1";
            // 
            // Menus
            // 
            this.Menus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Base_ApiOpen,
            this.Base_ApiClose,
            this.Base_ClearMessage,
            this.Base_ReloadForm});
            this.Menus.Name = "Menus";
            this.Menus.Size = new System.Drawing.Size(59, 21);
            this.Menus.Text = "Menus";
            // 
            // Base_ApiOpen
            // 
            this.Base_ApiOpen.Name = "Base_ApiOpen";
            this.Base_ApiOpen.Size = new System.Drawing.Size(124, 22);
            this.Base_ApiOpen.Text = "启动API";
            // 
            // Base_ApiClose
            // 
            this.Base_ApiClose.Name = "Base_ApiClose";
            this.Base_ApiClose.Size = new System.Drawing.Size(124, 22);
            this.Base_ApiClose.Text = "关闭API";
            // 
            // Base_ClearMessage
            // 
            this.Base_ClearMessage.Name = "Base_ClearMessage";
            this.Base_ClearMessage.Size = new System.Drawing.Size(124, 22);
            this.Base_ClearMessage.Text = "清除信息";
            // 
            // Base_ReloadForm
            // 
            this.Base_ReloadForm.Name = "Base_ReloadForm";
            this.Base_ReloadForm.Size = new System.Drawing.Size(124, 22);
            this.Base_ReloadForm.Text = "重新加载";
            // 
            // status_foot
            // 
            this.status_foot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_foot_service});
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
            this.status_foot_service.Size = new System.Drawing.Size(4, 17);
            this.status_foot_service.Visible = false;
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
            this.tab_body.Location = new System.Drawing.Point(0, 25);
            this.tab_body.Name = "tab_body";
            this.tab_body.SelectedIndex = 0;
            this.tab_body.Size = new System.Drawing.Size(1184, 531);
            this.tab_body.TabIndex = 4;
            this.tab_body.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tab_body_MouseUp);
            // 
            // tab_body_main
            // 
            this.tab_body_main.Controls.Add(this.label1);
            this.tab_body_main.Location = new System.Drawing.Point(4, 22);
            this.tab_body_main.Name = "tab_body_main";
            this.tab_body_main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_body_main.Size = new System.Drawing.Size(1176, 505);
            this.tab_body_main.TabIndex = 1;
            this.tab_body_main.Text = "welcome";
            this.tab_body_main.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 40F);
            this.label1.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label1.Location = new System.Drawing.Point(6, 3);
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
            this.MainMenuStrip = this.menu_head;
            this.Name = "DayDayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DayDayUp";
            this.Load += new System.EventHandler(this.DayDayForm_Load);
            this.menu_head.ResumeLayout(false);
            this.menu_head.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem Menus;
        private System.Windows.Forms.TabControl tab_body;
        private System.Windows.Forms.TabPage tab_body_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem Base_ClearMessage;
        private System.Windows.Forms.ToolStripMenuItem Base_ReloadForm;
        private System.Windows.Forms.ToolStripMenuItem Base_ApiOpen;
        private System.Windows.Forms.ToolStripMenuItem Base_ApiClose;
    }
}

