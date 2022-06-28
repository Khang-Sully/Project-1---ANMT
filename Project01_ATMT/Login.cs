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
    public partial class Login : Form
    {

        private static bool isLogged = false;
        public Login()
        {
            InitializeComponent();
        }
        
        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = t_Email.Text.ToString();
            string password = t_Password.Text.ToString();

            object[] hash = new object[2] { email, SHA256.Hash(Encoding.ASCII.GetBytes(password)) };
            //try
            //{
            DataProvider dp = new DataProvider();
            DataTable dt = dp.ExecuteQuery("EXEC SP_LOG_IN @Email , @Password", hash);
            String isPassed = dt.Rows[0][0].ToString();
                
            if (isPassed.Equals("1")) {
                if (Login.isLogged == false)
                {
                    MessageBox.Show("Logged in successfully!");
                    Login.isLogged = true;
                    Menu m = new Menu(email);
                    this.Hide();
                    m.ShowDialog();
                }
                else { 
                    MessageBox.Show("The previous account is not logged out!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Username or password incorrect!");
            }
            //}
/*            catch (Exception login)
            {
                MessageBox.Show("Error ~ Username or password incorrect!");
            }*/
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            Signup s = new Signup();
            this.Hide();
            s.ShowDialog();
        }
    }
}
