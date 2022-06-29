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

namespace Project01_ATMT
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        public void EnableEditAllTextBox()
        {
            t_email.ReadOnly    = false;
            t_password.ReadOnly = false;
            t_phone.ReadOnly    = false;
            t_fullname.ReadOnly = false;
            t_dob.ReadOnly      = false;
            t_address.ReadOnly  = false;
        }
        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(t_email.Text) || String.IsNullOrEmpty(t_password.Text) || String.IsNullOrEmpty(t_phone.Text) || String.IsNullOrEmpty(t_fullname.Text) || String.IsNullOrEmpty(t_dob.Text) || String.IsNullOrEmpty(t_address.Text))
            {
                MessageBox.Show("Text box cannot be left blank");
                return;
            }
            try
            {
                EnableEditAllTextBox();
                DTO_Account tempAcc = new DTO_Account();

                tempAcc.Email = t_email.Text.ToString();
                String pw = t_password.Text.ToString();
                tempAcc.Password = SHA256.Hash(Encoding.ASCII.GetBytes(pw));

                tempAcc.Phone = t_phone.Text.ToString();
                tempAcc.Fullname = t_fullname.Text.ToString();
                tempAcc.dob = t_dob.Text.ToString();
                tempAcc.Address = t_address.Text.ToString();

                RSA rsa = new RSA();
                string PublicKeyFileName = "../../../Key/" + tempAcc.Email + "_rsa_publicKey.txt";
                string PrivateKeyFileName = "../../../Key/" + tempAcc.Email + "_rsa_privateKey.txt";
                rsa.generateKeys(@PublicKeyFileName, @PrivateKeyFileName);
                
                AES aes = new AES(tempAcc.Password);
                string privateKeyunCrepted = System.IO.File.ReadAllText(@PrivateKeyFileName);
                byte[] tempPrivateKeyEncrypted = aes.Encrypt(Encoding.Unicode.GetBytes(privateKeyunCrepted));
                string PrivateKeyEncrypted = BitConverter.ToString(tempPrivateKeyEncrypted);

                StreamWriter sr = new System.IO.StreamWriter(@PrivateKeyFileName);
                sr.Write(PrivateKeyEncrypted);
                sr.Close();

                string isPassed = DAO_Account.get_Instance().AddAccount(tempAcc, @PublicKeyFileName, @PrivateKeyFileName);
               
                if (isPassed.Equals("1"))
                {
                    MessageBox.Show("Sign up Successfully!");
                    Login l = new Login();
                    this.Hide();
                    l.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Email already exists!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to sign up new account!");
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }
    }
}
