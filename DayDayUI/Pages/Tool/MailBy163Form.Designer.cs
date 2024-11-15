namespace DayDayWinForm.Pages.Tool
{
    partial class MailBy163Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_addressee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_content = new System.Windows.Forms.TextBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "收件地址";
            // 
            // txt_addressee
            // 
            this.txt_addressee.Location = new System.Drawing.Point(85, 48);
            this.txt_addressee.Name = "txt_addressee";
            this.txt_addressee.Size = new System.Drawing.Size(378, 21);
            this.txt_addressee.TabIndex = 12;
            this.txt_addressee.Text = "maybelleschoesfcw@gmail.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "正文内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "标题";
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.LightGreen;
            this.btn_send.Location = new System.Drawing.Point(482, 335);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(129, 43);
            this.btn_send.TabIndex = 9;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_content
            // 
            this.txt_content.Location = new System.Drawing.Point(85, 170);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(378, 208);
            this.txt_content.TabIndex = 8;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(85, 113);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(378, 21);
            this.txt_title.TabIndex = 7;
            // 
            // MailBy163Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_addressee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.txt_title);
            this.Name = "MailBy163Form";
            this.Text = "MailBy163Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_addressee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.TextBox txt_title;
    }
}