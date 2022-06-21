using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void Sign_up()
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

            DAO_Account.get_Instance().addAccount(tempAcc);
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
                Sign_up();
                MessageBox.Show("Sign up Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to sign up new account!");
            }
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
        }
    }
}
