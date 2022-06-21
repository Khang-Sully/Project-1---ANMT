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
        public Menu()
        {
            InitializeComponent();
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
    }
}
