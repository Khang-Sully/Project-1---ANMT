namespace Project01_ATMT
{
    partial class Menu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.t_Address = new System.Windows.Forms.TextBox();
            this.t_Phone = new System.Windows.Forms.TextBox();
            this.t_dob = new System.Windows.Forms.TextBox();
            this.t_Password = new System.Windows.Forms.TextBox();
            this.t_FullName = new System.Windows.Forms.TextBox();
            this.t_Email = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_userlist = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_sign = new System.Windows.Forms.RadioButton();
            this.rb_encrypt = new System.Windows.Forms.RadioButton();
            this.rb_decrypt = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.t_saveasPath = new System.Windows.Forms.TextBox();
            this.btn_Saveas = new System.Windows.Forms.Button();
            this.t_filepath = new System.Windows.Forms.TextBox();
            this.btn_upload = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv_notification = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userlist)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_notification)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.t_Address);
            this.groupBox1.Controls.Add(this.t_Phone);
            this.groupBox1.Controls.Add(this.t_dob);
            this.groupBox1.Controls.Add(this.t_Password);
            this.groupBox1.Controls.Add(this.t_FullName);
            this.groupBox1.Controls.Add(this.t_Email);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(466, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(298, 155);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 22);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(128, 155);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 22);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Date of birth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "FullName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // t_Address
            // 
            this.t_Address.Location = new System.Drawing.Point(298, 119);
            this.t_Address.Margin = new System.Windows.Forms.Padding(2);
            this.t_Address.Name = "t_Address";
            this.t_Address.Size = new System.Drawing.Size(146, 20);
            this.t_Address.TabIndex = 0;
            // 
            // t_Phone
            // 
            this.t_Phone.Location = new System.Drawing.Point(58, 119);
            this.t_Phone.Margin = new System.Windows.Forms.Padding(2);
            this.t_Phone.Name = "t_Phone";
            this.t_Phone.Size = new System.Drawing.Size(146, 20);
            this.t_Phone.TabIndex = 0;
            // 
            // t_dob
            // 
            this.t_dob.Location = new System.Drawing.Point(298, 72);
            this.t_dob.Margin = new System.Windows.Forms.Padding(2);
            this.t_dob.Name = "t_dob";
            this.t_dob.Size = new System.Drawing.Size(146, 20);
            this.t_dob.TabIndex = 0;
            // 
            // t_Password
            // 
            this.t_Password.Location = new System.Drawing.Point(58, 72);
            this.t_Password.Margin = new System.Windows.Forms.Padding(2);
            this.t_Password.Name = "t_Password";
            this.t_Password.PasswordChar = '*';
            this.t_Password.Size = new System.Drawing.Size(146, 20);
            this.t_Password.TabIndex = 0;
            // 
            // t_FullName
            // 
            this.t_FullName.Location = new System.Drawing.Point(298, 24);
            this.t_FullName.Margin = new System.Windows.Forms.Padding(2);
            this.t_FullName.Name = "t_FullName";
            this.t_FullName.Size = new System.Drawing.Size(146, 20);
            this.t_FullName.TabIndex = 0;
            // 
            // t_Email
            // 
            this.t_Email.Location = new System.Drawing.Point(58, 24);
            this.t_Email.Margin = new System.Windows.Forms.Padding(2);
            this.t_Email.Name = "t_Email";
            this.t_Email.Size = new System.Drawing.Size(146, 20);
            this.t_Email.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_userlist);
            this.groupBox2.Location = new System.Drawing.Point(9, 197);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(466, 255);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User List";
            // 
            // dgv_userlist
            // 
            this.dgv_userlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userlist.Cursor = System.Windows.Forms.Cursors.No;
            this.dgv_userlist.Location = new System.Drawing.Point(4, 17);
            this.dgv_userlist.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_userlist.Name = "dgv_userlist";
            this.dgv_userlist.RowHeadersWidth = 51;
            this.dgv_userlist.RowTemplate.Height = 24;
            this.dgv_userlist.Size = new System.Drawing.Size(457, 250);
            this.dgv_userlist.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_sign);
            this.groupBox3.Controls.Add(this.rb_encrypt);
            this.groupBox3.Controls.Add(this.rb_decrypt);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.t_saveasPath);
            this.groupBox3.Controls.Add(this.btn_Saveas);
            this.groupBox3.Controls.Add(this.t_filepath);
            this.groupBox3.Controls.Add(this.btn_upload);
            this.groupBox3.Location = new System.Drawing.Point(479, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(272, 234);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Do";
            // 
            // rb_sign
            // 
            this.rb_sign.AutoSize = true;
            this.rb_sign.Location = new System.Drawing.Point(207, 124);
            this.rb_sign.Margin = new System.Windows.Forms.Padding(2);
            this.rb_sign.Name = "rb_sign";
            this.rb_sign.Size = new System.Drawing.Size(46, 17);
            this.rb_sign.TabIndex = 5;
            this.rb_sign.TabStop = true;
            this.rb_sign.Text = "Sign";
            this.rb_sign.UseVisualStyleBackColor = true;
            // 
            // rb_encrypt
            // 
            this.rb_encrypt.AutoSize = true;
            this.rb_encrypt.Location = new System.Drawing.Point(24, 124);
            this.rb_encrypt.Margin = new System.Windows.Forms.Padding(2);
            this.rb_encrypt.Name = "rb_encrypt";
            this.rb_encrypt.Size = new System.Drawing.Size(61, 17);
            this.rb_encrypt.TabIndex = 5;
            this.rb_encrypt.TabStop = true;
            this.rb_encrypt.Text = "Encrypt";
            this.rb_encrypt.UseVisualStyleBackColor = true;
            // 
            // rb_decrypt
            // 
            this.rb_decrypt.AutoSize = true;
            this.rb_decrypt.Location = new System.Drawing.Point(116, 124);
            this.rb_decrypt.Margin = new System.Windows.Forms.Padding(2);
            this.rb_decrypt.Name = "rb_decrypt";
            this.rb_decrypt.Size = new System.Drawing.Size(62, 17);
            this.rb_decrypt.TabIndex = 5;
            this.rb_decrypt.TabStop = true;
            this.rb_decrypt.Text = "Decrypt";
            this.rb_decrypt.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Send to";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 20);
            this.textBox1.TabIndex = 3;
            // 
            // t_saveasPath
            // 
            this.t_saveasPath.Location = new System.Drawing.Point(96, 187);
            this.t_saveasPath.Margin = new System.Windows.Forms.Padding(2);
            this.t_saveasPath.Name = "t_saveasPath";
            this.t_saveasPath.Size = new System.Drawing.Size(153, 20);
            this.t_saveasPath.TabIndex = 2;
            // 
            // btn_Saveas
            // 
            this.btn_Saveas.Location = new System.Drawing.Point(22, 187);
            this.btn_Saveas.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Saveas.Name = "btn_Saveas";
            this.btn_Saveas.Size = new System.Drawing.Size(56, 19);
            this.btn_Saveas.TabIndex = 1;
            this.btn_Saveas.Text = "Save as";
            this.btn_Saveas.UseVisualStyleBackColor = true;
            // 
            // t_filepath
            // 
            this.t_filepath.Location = new System.Drawing.Point(96, 35);
            this.t_filepath.Margin = new System.Windows.Forms.Padding(2);
            this.t_filepath.Name = "t_filepath";
            this.t_filepath.Size = new System.Drawing.Size(153, 20);
            this.t_filepath.TabIndex = 0;
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(22, 35);
            this.btn_upload.Margin = new System.Windows.Forms.Padding(2);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(56, 19);
            this.btn_upload.TabIndex = 0;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv_notification);
            this.groupBox4.Location = new System.Drawing.Point(479, 249);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(271, 202);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Notification";
            // 
            // dgv_notification
            // 
            this.dgv_notification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_notification.Location = new System.Drawing.Point(0, 17);
            this.dgv_notification.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_notification.Name = "dgv_notification";
            this.dgv_notification.RowHeadersWidth = 51;
            this.dgv_notification.Size = new System.Drawing.Size(266, 180);
            this.dgv_notification.TabIndex = 0;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 462);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userlist)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_notification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_Address;
        private System.Windows.Forms.TextBox t_Phone;
        private System.Windows.Forms.TextBox t_dob;
        private System.Windows.Forms.TextBox t_Password;
        private System.Windows.Forms.TextBox t_FullName;
        private System.Windows.Forms.TextBox t_Email;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_userlist;
        private System.Windows.Forms.RadioButton rb_sign;
        private System.Windows.Forms.RadioButton rb_encrypt;
        private System.Windows.Forms.RadioButton rb_decrypt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox t_saveasPath;
        private System.Windows.Forms.Button btn_Saveas;
        private System.Windows.Forms.TextBox t_filepath;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_notification;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_edit;
    }
}