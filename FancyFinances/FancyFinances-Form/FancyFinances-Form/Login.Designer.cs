namespace FancyFinances_Form
{
    partial class frmLogin
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
            label1 = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label3 = new Label();
            llbForgotPass = new LinkLabel();
            btnCreateAcc = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 9);
            label1.Name = "label1";
            label1.Size = new Size(235, 30);
            label1.TabIndex = 0;
            label1.Text = "Login to your Account";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(23, 181);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(277, 32);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(93, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(207, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(93, 58);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(207, 23);
            txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 66);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 108);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // llbForgotPass
            // 
            llbForgotPass.AutoSize = true;
            llbForgotPass.Location = new Point(23, 146);
            llbForgotPass.Name = "llbForgotPass";
            llbForgotPass.Size = new Size(100, 15);
            llbForgotPass.TabIndex = 7;
            llbForgotPass.TabStop = true;
            llbForgotPass.Text = "Forgot Password?";
            llbForgotPass.LinkClicked += llbForgotPass_LinkClicked;
            // 
            // btnCreateAcc
            // 
            btnCreateAcc.Location = new Point(23, 219);
            btnCreateAcc.Name = "btnCreateAcc";
            btnCreateAcc.Size = new Size(277, 32);
            btnCreateAcc.TabIndex = 8;
            btnCreateAcc.Text = "Create Account";
            btnCreateAcc.UseVisualStyleBackColor = true;
            btnCreateAcc.Click += btnCreateAcc_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(340, 251);
            Controls.Add(btnCreateAcc);
            Controls.Add(llbForgotPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private Label label3;
        private LinkLabel llbForgotPass;
        private Button btnCreateAcc;
    }
}