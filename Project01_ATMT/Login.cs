using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// GUI Login Screen
namespace Project01_ATMT
{
    public partial class Login : Form // Login Function
    {

        private static bool isLogged = false;
        public Login()
        {
            InitializeComponent();
        }
        
        // Send Login Button
        private void btn_login_Click(object sender, EventArgs e)
        {
            // Store Information from User
            string email = t_Email.Text.ToString();
            string password = t_Password.Text.ToString();

            // Hashing Data for Security storing
            object[] hash = new object[2] { email, SHA256.Hash(Encoding.ASCII.GetBytes(password)) };
            
            // Provide User's Information from Database
            DataProvider dp = new DataProvider();
            DataTable dt = dp.ExecuteQuery("EXEC SP_LOG_IN @Email , @Password", hash);
            String isPassed = dt.Rows[0][0].ToString();
            
            // Is the Password correct?
            if (isPassed.Equals("1")) {
                if (Login.isLogged == false)
                {
                    MessageBox.Show("Logged in successfully!");
                    Login.isLogged = true;
                    Menu m = new Menu(email);
                    this.Hide();
                    m.ShowDialog();
                }
                // Caution!!! Logout the previous account before login
                else { 
                    MessageBox.Show("The previous account is not logged out!");
                    this.Close();
                }
            }
            else
            {
                // Incorrect Password message
                MessageBox.Show("Username or password incorrect!");
            }
        }

        // Send Signup Button for User doesn't have any accounts
        private void btn_signup_Click(object sender, EventArgs e)
        {
            Signup s = new Signup();
            this.Hide();
            s.ShowDialog();
        }
    }
}