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
    public partial class EditContactForm : Form
    {
        public EditContactForm()
        {
            InitializeComponent();
        }
        public EditContactForm(string id)
        {
            InitializeComponent();
            this.id = id;
            LoadInfo();

        }
        private string id = "";
        GROUP Group = new GROUP();
        CONTACT Contact = new CONTACT();
        private void LoadGroup()
        {
            groupComboBox.DataSource = Group.GetAllGroup();
            groupComboBox.DisplayMember = "name";
            groupComboBox.ValueMember = "id";
            groupComboBox.SelectedItem = null;
        }

        private void cleanFill()
        {
            fnameTextBox.Text = "";
            lnameTextBox.Text = "";
            phoneTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            groupComboBox.SelectedItem = null;
        }
        private bool checkField()
        {
            if (idTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill ID Contact");
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
            if (groupComboBox.SelectedItem == null)
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
        private void EditContactForm_Load(object sender, EventArgs e)
        {
            LoadGroup();
        }

        private void LoadInfo()
        {
            LoadGroup();
            DataTable dt = Contact.getContactByID(this.id);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Contact", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cleanFill();
                return;
            }
            for (int i = 0; i < groupComboBox.Items.Count; i++)
            {
                groupComboBox.SelectedIndex = i;
                if (dt.Rows[0]["group_id"].ToString() == groupComboBox.SelectedValue.ToString())
                {
                    break;
                }
            }
            idTextBox.Text = this.id;
            fnameTextBox.Text = dt.Rows[0]["fname"].ToString();
            lnameTextBox.Text = dt.Rows[0]["lname"].ToString();
            phoneTextBox.Text = dt.Rows[0]["phone"].ToString();
            emailTextBox.Text = dt.Rows[0]["email"].ToString();
            addressTextBox.Text = dt.Rows[0]["address"].ToString();
            byte[] pic = (byte[])dt.Rows[0]["pic"];
            MemoryStream picture = new MemoryStream(pic);
            stdImagePictureBox.Image = Image.FromStream(picture);
        }

        private void selectCButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text.Trim() != "")
            {
                this.id = idTextBox.Text.Trim();
                LoadInfo();
            }
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

        private void editButton_Click(object sender, EventArgs e)
        {
            if (checkField())
            {
                MemoryStream image = new MemoryStream();
                stdImagePictureBox.Image.Save(image, stdImagePictureBox.Image.RawFormat);
                if (Contact.UpdateContact(idTextBox.Text, fnameTextBox.Text, lnameTextBox.Text, Convert.ToInt32(groupComboBox.SelectedValue),
                    phoneTextBox.Text, emailTextBox.Text, addressTextBox.Text, image, GlobalUserID.GlobalUserId))
                {
                    MessageBox.Show("Contact Updated", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Contact Not Updated", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
