using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// GUI Signup Screen
namespace Project01_ATMT
{
    public partial class Signup : Form // Signup Function
    {
        public Signup()
        {
            InitializeComponent();
        }

        // Set Edit to Signup Information
        public void EnableEditAllTextBox()
        {
            t_email.ReadOnly    = false;
            t_password.ReadOnly = false;
            t_phone.ReadOnly    = false;
            t_fullname.ReadOnly = false;
            t_dob.ReadOnly      = false;
            t_address.ReadOnly  = false;
        }

        // Signup Button
        private void btn_signup_Click(object sender, EventArgs e)
        {
            // Alerts when there is an empty information box
            if (String.IsNullOrEmpty(t_email.Text) || String.IsNullOrEmpty(t_password.Text) || String.IsNullOrEmpty(t_phone.Text) || String.IsNullOrEmpty(t_fullname.Text) || String.IsNullOrEmpty(t_dob.Text) || String.IsNullOrEmpty(t_address.Text))
            {
                MessageBox.Show("Text box cannot be left blank");
                return;
            } 
            try
            {
                EnableEditAllTextBox();
                DTO_Account tempAcc = new DTO_Account();

                // Important Information for User to Login
                tempAcc.Email = t_email.Text.ToString();
                String pw = t_password.Text.ToString();
                tempAcc.Password = SHA256.Hash(Encoding.ASCII.GetBytes(pw));

                // More details about User
                tempAcc.Phone = t_phone.Text.ToString();
                tempAcc.Fullname = t_fullname.Text.ToString();
                tempAcc.dob = t_dob.Text.ToString();
                tempAcc.Address = t_address.Text.ToString();

                // Encryption User Password
                AES aes = new AES(tempAcc.Password); // Encrypt with AES to protect data
                RSA rsa = new RSA(aes); // Encrypt with RSA to transmit data
                DTO_rsakey tempRsaKEy = new DTO_rsakey();
                tempRsaKEy.Email = t_email.Text.ToString();
                
                // Add Account into Database
                string isPassed = DAO_Account.get_Instance().AddAccount(tempAcc);

                // Check all the information correctly
                if (isPassed.Equals("1"))
                {
                    MessageBox.Show("Sign up Successfully!");
                    Login l = new Login();
                    this.Hide();
                    l.ShowDialog();
                }
                // Use 1 Email for only 1 Account
                else
                {
                    MessageBox.Show("Email already exists!");
                }
            }
            // Signup unsuccessfully (wrong password, wrong email, lack information)
            catch(Exception ex)
            {
                MessageBox.Show("Failed to sign up new account!");
            }

        }

        // Send Login Button for User already has an account
        private void btn_login_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }
    }
}
