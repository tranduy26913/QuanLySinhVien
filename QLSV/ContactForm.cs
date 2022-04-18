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
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        User User = new User();
        GROUP Group = new GROUP();
        CONTACT Contact = new CONTACT();
        private void LoadImageAndUser()
        {
            DataTable dt = User.getUserByID(GlobalUserID.GlobalUserId);
            if (dt.Rows.Count > 0)
            {
                byte[] pic = (byte[])dt.Rows[0]["fig"];
                MemoryStream picture = new MemoryStream(pic);
                userPictureBox.Image = Image.FromStream(picture);
                usernameLabel.Text = "Welcome back ( " + dt.Rows[0][0].ToString().Trim() + " )";
            }
        }

        private void LoadGroup()
        {
            groupComboBox.DataSource = Group.GetAllGroup();
            groupComboBox.DisplayMember = "name";
            groupComboBox.ValueMember = "id";
            groupComboBox.SelectedItem = null;
            removeGroupComboBox.DataSource = groupComboBox.DataSource;
            removeGroupComboBox.DisplayMember = "name";
            removeGroupComboBox.ValueMember = "id";
            removeGroupComboBox.SelectedItem = null;
        }
        private void ContactForm_Load(object sender, EventArgs e)
        {
            LoadGroup();
            LoadImageAndUser();
        }

        private void addGroupButton_Click(object sender, EventArgs e)
        {
            if (Group.nameGroupExist(addGroupTextBox.Text))
            {
                if (Group.AddGroup(addGroupTextBox.Text))
                {
                    MessageBox.Show("Group Inserted", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGroup();
                }
                else
                    MessageBox.Show("Group Not Inserted ", "Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("Group Name Already Exist", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void editGroupButton_Click(object sender, EventArgs e)
        {
            if (groupComboBox.SelectedItem != null)
            {
                if (Group.nameGroupExist(editGroupTextBox.Text, Convert.ToInt32(groupComboBox.SelectedValue)))
                {
                    if (Group.EditGroup(editGroupTextBox.Text, Convert.ToInt32(groupComboBox.SelectedValue)))
                    {
                        MessageBox.Show("Group Updated", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGroup();
                    }
                    else
                        MessageBox.Show("Group Not Updated", "Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Group Name Already Exist", "Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Please Choose Group", "Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void removeGroupButton_Click(object sender, EventArgs e)
        {
            if (removeGroupComboBox.SelectedItem != null)
            {
                if (Group.RemoveGroup(Convert.ToInt32(removeGroupComboBox.SelectedValue)))
                {
                    MessageBox.Show("Group Deleted", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGroup();
                }

                else
                    MessageBox.Show("Group Not Deleted", "Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Please Choose Group", "Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form AddContact = new AddContactForm();
            AddContact.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (removeContactTextBox.Text.Trim() != "")
            {
                if (Contact.DeleteContact(removeContactTextBox.Text.Trim()))
                {
                    MessageBox.Show("Contact Deleted", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Contact Not Deleted", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please Fill Contact ID", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void showListButton_Click(object sender, EventArgs e)
        {
            Form showList = new ShowContactForm();
            showList.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Form showList = new EditContactForm();
            showList.ShowDialog();
        }
    }
}
