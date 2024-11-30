namespace DayDayWinForm.Pages.Common
{
    partial class LoginForm
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
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbleye = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUserNumber.Location = new System.Drawing.Point(89, 37);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(191, 21);
            this.txtUserNumber.TabIndex = 0;
            this.txtUserNumber.Text = "admin";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUserPassword.Location = new System.Drawing.Point(89, 78);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '●';
            this.txtUserPassword.Size = new System.Drawing.Size(191, 21);
            this.txtUserPassword.TabIndex = 1;
            this.txtUserPassword.Text = "111";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // lbleye
            // 
            this.lbleye.AutoSize = true;
            this.lbleye.Font = new System.Drawing.Font("宋体", 16F);
            this.lbleye.Location = new System.Drawing.Point(285, 77);
            this.lbleye.Name = "lbleye";
            this.lbleye.Size = new System.Drawing.Size(32, 22);
            this.lbleye.TabIndex = 4;
            this.lbleye.Text = "👁";
            this.lbleye.Click += new System.EventHandler(this.lbleye_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(329, 146);
            this.Controls.Add(this.lbleye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUserNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbleye;
    }
}