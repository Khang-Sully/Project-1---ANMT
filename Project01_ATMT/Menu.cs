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

// GUI Menu Screen
namespace Project01_ATMT
{
    public partial class Menu : Form
    { 
        public List<DTO_Account> listOfUser;
        public bool Edited = false;
        public static string _email;
        public byte[] _password;
        public Menu(string LoginEmail, byte[] password)
        {
            InitializeComponent();
            _email = LoginEmail;
            _password = password;
            LoadListData();
            loadInfor(LoginEmail);
        }

        // Set to ReadOnly Mode
        public void SetAllTextBoxToReadOnly()
        {
            t_Email.ReadOnly = true;
            t_Password.ReadOnly = true;
            t_Phone.ReadOnly = true;
            t_FullName.ReadOnly = true;
            t_dob.ReadOnly = true;
            t_Address.ReadOnly = true;
        }

        // Set to Edit Mode
        public void EnableEditAllTextBox()
        {
            t_Password.ReadOnly = false;
            t_Phone.ReadOnly = false;
            t_FullName.ReadOnly = false;
            t_dob.ReadOnly = false;
            t_Address.ReadOnly = false;
        }

        // Loading Information from Database
        public void loadInfor(string loginEmail)
        {
            DataTable data = DAO_Account.get_Instance().getUserInfo(loginEmail);
            this.EnableEditAllTextBox();
            this.t_Email.Text = data.Rows[0][0].ToString();
            //this.t_Password.Text = "Hidden";
            this.t_Password.Text = data.Rows[0][1].ToString();
            this.t_Phone.Text = data.Rows[0][2].ToString();
            this.t_FullName.Text = data.Rows[0][3].ToString();
            this.t_dob.Text = data.Rows[0][4].ToString();
            this.t_Address.Text = data.Rows[0][5].ToString();
            SetAllTextBoxToReadOnly();


        }

        // Send Edit Button
        private void btn_edit_Click(object sender, EventArgs e)
        {
            EnableEditAllTextBox();
            Edited = true;
        }

        // Send Save Button
        private void btn_save_Click(object sender, EventArgs e)
        {
            // Cannot save when there is any Textbox left Blank
            if (String.IsNullOrEmpty(t_Email.Text) || String.IsNullOrEmpty(t_Password.Text) || String.IsNullOrEmpty(t_Phone.Text) || String.IsNullOrEmpty(t_FullName.Text) || String.IsNullOrEmpty(t_dob.Text) || String.IsNullOrEmpty(t_Address.Text))
            {
                MessageBox.Show("Text box cannot be left blank");
                return;
            }

            // 
            DTO_Account acc = new DTO_Account();
            acc.Email = t_Email.Text.ToString();

            string salt = "19127443";
            acc.Password = SHA256.Hash(Encoding.ASCII.GetBytes(t_Password.Text), salt);
            acc.Phone = t_Phone.Text.ToString();
            acc.Fullname = t_FullName.Text.ToString();
            acc.dob = t_dob.Text.ToString();
            acc.Address = t_Address.Text.ToString();

            DAO_Account.get_Instance().EditAccount(acc);
            MessageBox.Show("Successfully edited information!");
            //this.t_Password.Text = "Hidden*";
            reloadListDataTable();
            SetAllTextBoxToReadOnly();
        }
        private DataTable ListToDataTable(List<String> col, List<DTO_Account> listOfUser) { 
            DataTable dt = new DataTable();
            foreach(String s in col)
            {
                dt.Columns.Add(s);
            }

            if (listOfUser.Count == 0)
            {
                return dt;
            }
            foreach (DTO_Account acc in listOfUser)
            {
                dt.Rows.Add(new object[] { acc.Email, acc.Phone, acc.Fullname });
            }

            return dt;
        }
        public void LoadListData()
        {
            listOfUser = DAO_Account.get_Instance().LoadUserList();
            DataTable dt =  ListToDataTable(new List<String>() { "Email", "Phone", "Fullname" }, listOfUser);

            this.dgv_userlist.DataSource = dt;
            this.dgv_userlist.Update();
            this.dgv_userlist.Refresh();
            //TextBox Event Full Row Selected Click
        }
        public void reloadListDataTable() {
            this.dgv_userlist.DataSource = null;
            LoadListData();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileAttach = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                fileAttach.Multiselect = false;

                if (fileAttach.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fileAttach.FileName;
                    //var readFile = File.ReadAllText(fileName);
                    this.t_filepath.Text = fileName;
                    this.t_filepath.ReadOnly = true;
                }
            }
        }

        private void btn_Saveas_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderBrowserDialog.Description = "Select a folder to send to:";
                    string folderName = folderBrowserDialog.SelectedPath;
                    folderBrowserDialog.ShowNewFolderButton = true;
                    //var readFile = File.ReadAllText(fileName);
                    this.t_saveasPath.Text = folderName;
                    this.t_saveasPath.ReadOnly = true;
                }
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rb_encrypt.Checked == true)
                {
                    if (String.IsNullOrEmpty(t_filepath.Text))
                    {
                        MessageBox.Show("File has not yet been uploaded.");
                        return;
                    }
                    if (String.IsNullOrEmpty(t_sendTo.Text))
                    {
                        MessageBox.Show("Enter the recipient's email address.");
                        return;
                    }
                    if (String.IsNullOrEmpty(t_saveasPath.Text))
                    {
                        MessageBox.Show("Choose a location for the file to be saved.");
                        return;
                    }

                    byte[] data = File.ReadAllBytes(t_filepath.Text);
                    
                    string encryptedFileName = t_filepath.Text.ToString().Split('\\').Last() + "Encrypted";
                    string encryptedFilePath = t_saveasPath.Text.ToString() + "\\" + encryptedFileName;
                   
                    RSA rsa = new RSA();
                    string KpublicFilePath = DAO_Account.get_Instance().GetPublickey(t_sendTo.Text.ToString());

                    byte[] sessionkey = AES.genSessionKey();
                    AES aes = new AES(sessionkey);

                    byte[] encryptedData = aes.Encrypt(data);

                    using (var stream = File.Create(@encryptedFilePath))
                        stream.Write(encryptedData, 0, encryptedData.Length);

                    string SessionkeyEncrypt = rsa.Encrypt(Encoding.Default.GetString(sessionkey), KpublicFilePath);

                    DAO_Account.get_Instance().AddMFile(_email, t_sendTo.Text.ToString(), SessionkeyEncrypt, encryptedFileName);

                    //MessageBox.Show("File Send Successfully");
                }
                else if (this.rb_decrypt.Checked == true)
                {
                    if (String.IsNullOrEmpty(t_filepath.Text))
                    {
                        MessageBox.Show("File has not yet been uploaded.");
                        return;
                    }

                    if (String.IsNullOrEmpty(t_saveasPath.Text))
                    {
                        MessageBox.Show("Choose a location for the file to be saved.");
                        return;
                    }
                    byte[] dataEncrypted = File.ReadAllBytes(t_filepath.Text);

                    string encryptedFileName = t_filepath.Text.ToString().Split('\\').Last();
                    string decryptedFileName = encryptedFileName.Replace("Encrypted", "");
                    string decryptedFilePath = t_saveasPath.Text.ToString() + "\\" + decryptedFileName;

                    String sessionkey_Encrypted = DAO_Account.get_Instance().GetSessionKey(_email, encryptedFileName);
                    string PrivatekeyFilePath = DAO_Account.get_Instance().GetPrivateKey(_email);

                    byte[] privatekeyEncrypted = File.ReadAllBytes(PrivatekeyFilePath);
                    AES aesDecryptPrivateKey = new AES(_password);
                    byte[] privateKey = aesDecryptPrivateKey.Decrypt(privatekeyEncrypted);

                    RSA rsa = new RSA();
                    string sessionkey = rsa.Decrypt(sessionkey_Encrypted, Encoding.Unicode.GetString(privateKey));

                    AES aes = new AES(System.Text.Encoding.Unicode.GetBytes(sessionkey));
                    byte[] data = aes.Decrypt(dataEncrypted);

                    File.WriteAllBytes(decryptedFilePath, data);

                    //MessageBox.Show("Decrypt file Successfully");
                }
                else
                {
                    MessageBox.Show("Choose Encrypt or Decrypt!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error");
                return;
            }
        }

        private void sendNotification(String sendTo, int level, string content) 
        {
            return;
        }
    }
}


