using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }
        CONTACT Contact = new CONTACT();
        GROUP Group = new GROUP();
        User User = new User();

        private void LoadGroup()
        {
            groupComboBox.DataSource = Group.GetAllGroup();
            groupComboBox.DisplayMember = "name";
            groupComboBox.ValueMember = "id";
            groupComboBox.SelectedItem = null;
        }

        private bool checkField()
        {
            if(idTextBox.Text.Trim()=="")
            {
                MessageBox.Show("Please Fill ID Contact");
                return false;
            }
            if (Contact.idContactExist(idTextBox.Text))
            {
                MessageBox.Show("ID Contact Already Exist");
                return false;
            }
            if (fnameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill First Name");
                return false;
            }
            if (lnameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Last Name");
                return false;
            }
            if (groupComboBox.SelectedItem==null)
            {
                MessageBox.Show("Please Choose Group");
                return false;
            }
            if (phoneTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Phone Number");
                return false;
            }
            if (emailTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Email");
                return false;
            }
            if (addressTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Address");
                return false;
            }
            return true;
        }
        private void AddContactForm_Load(object sender, EventArgs e)
        {
            LoadGroup();
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (checkField())
            {
                MemoryStream image = new MemoryStream();
                stdImagePictureBox.Image.Save(image, stdImagePictureBox.Image.RawFormat);
                if(Contact.AddContact(idTextBox.Text,fnameTextBox.Text,lnameTextBox.Text,Convert.ToInt32(groupComboBox.SelectedValue),
                    phoneTextBox.Text, emailTextBox.Text, addressTextBox.Text, image, GlobalUserID.GlobalUserId))
                {
                    MessageBox.Show("Contact Inserted", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Contact Not Inserted", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
