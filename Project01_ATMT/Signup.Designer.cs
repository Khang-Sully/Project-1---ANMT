namespace Project01_ATMT
{
    partial class Signup
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
            this.t_email = new System.Windows.Forms.TextBox();
            this.t_password = new System.Windows.Forms.TextBox();
            this.t_phone = new System.Windows.Forms.TextBox();
            this.t_fullname = new System.Windows.Forms.TextBox();
            this.t_dob = new System.Windows.Forms.TextBox();
            this.t_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_signup = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // t_email
            // 
            this.t_email.Location = new System.Drawing.Point(78, 56);
            this.t_email.Name = "t_email";
            this.t_email.Size = new System.Drawing.Size(157, 22);
            this.t_email.TabIndex = 0;
            // 
            // t_password
            // 
            this.t_password.Location = new System.Drawing.Point(78, 125);
            this.t_password.Name = "t_password";
            this.t_password.PasswordChar = '*';
            this.t_password.Size = new System.Drawing.Size(157, 22);
            this.t_password.TabIndex = 0;
            // 
            // t_phone
            // 
            this.t_phone.Location = new System.Drawing.Point(78, 194);
            this.t_phone.Name = "t_phone";
            this.t_phone.Size = new System.Drawing.Size(157, 22);
            this.t_phone.TabIndex = 0;
            // 
            // t_fullname
            // 
            this.t_fullname.Location = new System.Drawing.Point(372, 56);
            this.t_fullname.Name = "t_fullname";
            this.t_fullname.Size = new System.Drawing.Size(157, 22);
            this.t_fullname.TabIndex = 0;
            // 
            // t_dob
            // 
            this.t_dob.Location = new System.Drawing.Point(372, 125);
            this.t_dob.Name = "t_dob";
            this.t_dob.Size = new System.Drawing.Size(157, 22);
            this.t_dob.TabIndex = 0;
            // 
            // t_address
            // 
            this.t_address.Location = new System.Drawing.Point(372, 194);
            this.t_address.Name = "t_address";
            this.t_address.Size = new System.Drawing.Size(157, 22);
            this.t_address.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "FullName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Date of birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Address";
            // 
            // btn_signup
            // 
            this.btn_signup.Location = new System.Drawing.Point(123, 259);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(111, 28);
            this.btn_signup.TabIndex = 2;
            this.btn_signup.Text = "Signup";
            this.btn_signup.UseVisualStyleBackColor = true;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(334, 259);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(111, 28);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 336);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_address);
            this.Controls.Add(this.t_phone);
            this.Controls.Add(this.t_dob);
            this.Controls.Add(this.t_fullname);
            this.Controls.Add(this.t_password);
            this.Controls.Add(this.t_email);
            this.Name = "Signup";
            this.Text = "Signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t_email;
        private System.Windows.Forms.TextBox t_password;
        private System.Windows.Forms.TextBox t_phone;
        private System.Windows.Forms.TextBox t_fullname;
        private System.Windows.Forms.TextBox t_dob;
        private System.Windows.Forms.TextBox t_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_signup;
        private System.Windows.Forms.Button btn_login;
    }
}