namespace DayDayUI.Pages.Tool
{
    partial class MailBy163
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
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_content = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_addressee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(41, 119);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(378, 21);
            this.txt_title.TabIndex = 0;
            // 
            // txt_content
            // 
            this.txt_content.Location = new System.Drawing.Point(41, 176);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(378, 208);
            this.txt_content.TabIndex = 1;
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.LightGreen;
            this.btn_send.Location = new System.Drawing.Point(438, 341);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(129, 43);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "正文内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "收件地址";
            // 
            // txt_addressee
            // 
            this.txt_addressee.Location = new System.Drawing.Point(41, 54);
            this.txt_addressee.Name = "txt_addressee";
            this.txt_addressee.Size = new System.Drawing.Size(378, 21);
            this.txt_addressee.TabIndex = 5;
            this.txt_addressee.Text = "maybelleschoesfcw@gmail.com";
            // 
            // MailDemoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_addressee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.txt_title);
            this.Name = "MailDemoControl";
            this.Size = new System.Drawing.Size(1100, 454);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_addressee;
    }
}
