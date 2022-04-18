using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
        }
        User User = new User();
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string user = usernameTextBox.Text;
            if (User.UsernameExist(user,"Register") && pwTextBox.Text != "")
            {
                if (checkBox1.Checked == false)
                {
                    errorProvider1.SetError(checkBox1, "Please check");
                }
                else
                {

                    MemoryStream image = new MemoryStream();
                    stdImagePictureBox.Image.Save(image, stdImagePictureBox.Image.RawFormat);
                    if (User.AddUser(fnameTextBox.Text,lnameTextBox.Text,usernameTextBox.Text,pwTextBox.Text,image))
                    {
                        MessageBox.Show("Đăng ký thành công!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Đăng ký thất bại!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please check your Username or Password!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   

        private void cfTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cfTextBox.Text != pwTextBox.Text)
                errorProvider3.SetError(cfTextBox, "Please check your password");
            else
                errorProvider3.Clear();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!User.UsernameExist(usernameTextBox.Text,"Register"))
                errorProvider1.SetError(usernameTextBox, "Please check your username");
            else
                errorProvider1.Clear();
        }

        private void pwTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pwTextBox.Text == "")
                errorProvider2.SetError(usernameTextBox, "Please fill password");
            else
                errorProvider2.Clear();
        }

        private void pwTextBox_Validated(object sender, EventArgs e)
        {
            if (pwTextBox.Text == "")
                errorProvider2.SetError(usernameTextBox, "Please fill password");
            else
                errorProvider2.Clear();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Filter = "Select Image(*jpg;*png;*bmp;*gif)|*jpg;*png;*bmp;*gif";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                stdImagePictureBox.Image = Image.FromFile(openf.FileName);
            }
        }
    }
}
