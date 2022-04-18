using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.COURSE
{
    public partial class EditCourseForm : Form
    {
        public EditCourseForm()
        {
            InitializeComponent();
        }
        COURSE Course = new COURSE();
        DataProvider dp = new DataProvider();
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            idComboBox.DataSource = Course.getAllCourse("");
            idComboBox.DisplayMember = "Id";
            idComboBox.ValueMember = "Id";
            idComboBox.SelectedItem = null;
            string query = "select distinct semester from course";
            DataTable dt = dp.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                semesterComboBox.Items.Add(item[0].ToString());
            }
            semesterComboBox.SelectedItem = null;
            query = "select distinct id from contact";
            dt = dp.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                cbContact.Items.Add(item[0].ToString());
            }
            cbContact.SelectedItem = null;
        }

        private void fillCombo(int id)
        {
            idComboBox.DataSource = Course.getAllCourse("");
            idComboBox.DisplayMember = "Id";
            idComboBox.ValueMember = "Id";
            idComboBox.SelectedIndex = id;
        }
        private void idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idComboBox.SelectedValue);
                DataTable data = new DataTable();
                data = Course.getCourseByID(id);
                labelTextBox.Text = data.Rows[0][1].ToString();
                periodNumericUD.Value = Convert.ToDecimal(data.Rows[0][2].ToString());
                string contact = data.Rows[0][3].ToString();
                for(int i = 0; i < cbContact.Items.Count; i++)
                {
                    if (cbContact.Items[i].ToString().Equals(contact))
                    {
                        cbContact.SelectedIndex = i;
                        break;
                    }
                }
                descriptionTextBox.Text = data.Rows[0][4].ToString();
                string sem = data.Rows[0][5].ToString();
                for (int i = 0; i < semesterComboBox.Items.Count; i++)
                {
                    if (semesterComboBox.Items[i].ToString().Equals(sem))
                    {
                        semesterComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch
            {

            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check())
                {
                    return;
                }
                int id = int.Parse(idComboBox.SelectedValue.ToString());
                string label = labelTextBox.Text;
                int period = Convert.ToInt32(periodNumericUD.Value);
                string des = descriptionTextBox.Text;
                int sem = int.Parse(semesterComboBox.SelectedValue.ToString());
                string contact_id = cbContact.SelectedItem.ToString();
                if (Course.checkCourseName(label, id))
                {

                    if (Course.UpdateCourse(id, label, period, contact_id,des, sem))
                    {
                        MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        fillCombo(id);
                    }
                }
                else
                {
                    MessageBox.Show("This Course Name Already Exits", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }
            catch
            {

            }
        }


        private bool check()
        {
            int id;
            if (!int.TryParse(idComboBox.SelectedValue.ToString(), out id))
            {
                MessageBox.Show("Please check Course ID", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (labelTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Add a Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(periodNumericUD.Value) < 10)
            {
                MessageBox.Show("The period must than 10", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (semesterComboBox.SelectedItem == null)
            {
                MessageBox.Show("Choose a semester", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbContact.SelectedItem == null)
            {
                MessageBox.Show("Choose a contact", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}
