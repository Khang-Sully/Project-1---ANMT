using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            // Alert when there is an empty information box 
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
                //
                string salt = "19127443";
                tempAcc.Password = SHA256.Hash(Encoding.Unicode.GetBytes(pw), salt);

                // More details about User
                tempAcc.Phone = t_phone.Text.ToString();
                tempAcc.Fullname = t_fullname.Text.ToString();
                tempAcc.dob = t_dob.Text.ToString();
                tempAcc.Address = t_address.Text.ToString();

                // Generate RSA Keys for User
                RSA rsa = new RSA();
                string PublicKeyFileName = "../../../Key/" + tempAcc.Email + "_rsa_publicKey.txt";
                string PrivateKeyFileName = "../../../Key/" + tempAcc.Email + "_rsa_privateKey.txt";
                rsa.generateKeys(@PublicKeyFileName, @PrivateKeyFileName);


                //temp
                string PK= File.ReadAllText(PublicKeyFileName);
                string PPk = File.ReadAllText(PrivateKeyFileName);

                // Encrypt Private Key by Passphase
                AES aes = new AES(tempAcc.Password);
                string privateKeyunCrepted = System.IO.File.ReadAllText(@PrivateKeyFileName);
                byte[] tempPrivateKeyEncrypted = aes.Encrypt(Encoding.Unicode.GetBytes(privateKeyunCrepted));
                
                System.IO.File.WriteAllBytes(@PrivateKeyFileName, tempPrivateKeyEncrypted);
               
                // Add Account into Database
                string isPassed = DAO_Account.get_Instance().AddAccount(tempAcc, @PublicKeyFileName, @PrivateKeyFileName);

                // Check all information correctly
                if (isPassed.Equals("1"))
                {
                    MessageBox.Show("Sign up Successfully!");
                    Login l = new Login();
                    this.Hide();
                    l.ShowDialog();
                }
                // Use 1 email for only 1 account
                else
                {
                    MessageBox.Show("Email already exists!");
                }
            }
            // Signup unsuccessfully (wrong password, wrong email, lack information)
            catch (Exception ex)
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
