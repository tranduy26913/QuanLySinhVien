using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class ShowContactForm : Form
    {
        public ShowContactForm()
        {
            InitializeComponent();
        }
        GROUP Group = new GROUP();
        CONTACT Contact = new CONTACT();
        private void LoadGroupListBox()
        {
            groupListBox.DataSource = Group.GetAllGroup();
            groupListBox.ValueMember = "id";
            groupListBox.DisplayMember = "name";
            groupListBox.SelectedItem = null;
        }
        private void LoadContact(int id = 0)
        {
            dgvContact.DataSource = Contact.GetContactByIDGroup(id);
            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dgvContact.Columns["pic"];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void ShowContactForm_Load(object sender, EventArgs e)
        {
            LoadGroupListBox();
            LoadContact();
        }

        private void groupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupListBox.SelectedValue != null)
            {
                int id = 0;
                if (int.TryParse(groupListBox.SelectedValue.ToString(), out id))
                    LoadContact(id);
            }

        }

        private void dvgContact_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idContact = dgvContact.CurrentRow.Cells[0].Value.ToString();
                SCORE.ManageScoreForm scoref = new SCORE.ManageScoreForm(idContact);
                scoref.ShowDialog();
            }
            catch { }
        }
    }
}
