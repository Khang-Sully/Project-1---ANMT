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
    public partial class Menu : Form
    {
        public Menu(string LoginEmail)
        {
            InitializeComponent();
            loadInfor(LoginEmail);
            SetAllTextBoxToReadOnly();
        }
        public void SetAllTextBoxToReadOnly()
        {
            t_Email.ReadOnly = true;
            t_Password.ReadOnly = true;
            t_Phone.ReadOnly = true;
            t_FullName.ReadOnly = true;
            t_dob.ReadOnly = true;
            t_Address.ReadOnly = true;
        }
        public void EnableEditAllTextBox()
        {
            t_Email.ReadOnly = false;
            t_Password.ReadOnly = false;
            t_Phone.ReadOnly = false;
            t_FullName.ReadOnly = false;
            t_dob.ReadOnly = false;
            t_Address.ReadOnly = false;
        }
        public void ClearAllTextBox()
        {
            t_Email.Clear();
            t_Password.Clear();
            t_Phone.Clear();
            t_FullName.Clear();
            t_dob.Clear();
            t_Address.Clear();
        }

        public void loadInfor(string loginEmail)
        {
            DataProvider dp = new DataProvider();
            object[] email = new object[1] { loginEmail };
            DataTable data = dp.ExecuteQuery("EXEC SP_SEL_ACCOUNT @EMAIL ", email);
            this.EnableEditAllTextBox();
            this.t_Email.Text = data.Rows[0][0].ToString();
            this.t_Password.Text = "Hidden";
            this.t_Phone.Text = data.Rows[0][2].ToString();
            this.t_FullName.Text = data.Rows[0][3].ToString();
            this.t_dob.Text = data.Rows[0][4].ToString();
            this.t_Address.Text = data.Rows[0][5].ToString();
            SetAllTextBoxToReadOnly();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            EnableEditAllTextBox();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(t_Email.Text) || String.IsNullOrEmpty(t_Password.Text) || String.IsNullOrEmpty(t_Phone.Text) || String.IsNullOrEmpty(t_FullName.Text) || String.IsNullOrEmpty(t_dob.Text) || String.IsNullOrEmpty(t_Address.Text))
            {
                MessageBox.Show("Text box cannot be left blank");
                return;
            }
            DataProvider dp = new DataProvider();
            object[] editedInfo = new object[6] { t_Email.Text, SHA256.Hash(Encoding.ASCII.GetBytes(t_Password.Text)), t_Phone.Text, t_FullName.Text, t_dob.Text, t_Address.Text };
            dp.ExecuteQuery("EXEC SP_UPDATE_ACCOUNT @EMAIL, @PASSWORD, @PHONE, @FULLNAME, @DOB, @ADDRESS ", editedInfo);
            MessageBox.Show("Successfully edited information!");
            this.t_Password.Text = "Hidden*";

            SetAllTextBoxToReadOnly();
        }
    }
}
