namespace DayDayUI.Controls
{
    partial class ServiceYDControl
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
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_json = new System.Windows.Forms.TextBox();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(673, 22);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(88, 21);
            this.btn_Send.TabIndex = 0;
            this.btn_Send.Text = "下配方";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_json
            // 
            this.txt_json.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_json.Location = new System.Drawing.Point(0, 0);
            this.txt_json.Multiline = true;
            this.txt_json.Name = "txt_json";
            this.txt_json.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_json.Size = new System.Drawing.Size(323, 750);
            this.txt_json.TabIndex = 1;
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(341, 23);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(326, 21);
            this.txt_url.TabIndex = 2;
            this.txt_url.Text = "http://192.168.59.203:8026/api/EllingTon/Downrecipe";
            // 
            // ServiceYDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.txt_json);
            this.Controls.Add(this.btn_Send);
            this.Name = "ServiceYDControl";
            this.Size = new System.Drawing.Size(1100, 750);
            this.Load += new System.EventHandler(this.ServiceYDControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_json;
        private System.Windows.Forms.TextBox txt_url;
    }
}
