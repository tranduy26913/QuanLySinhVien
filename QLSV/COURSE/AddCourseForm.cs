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
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }
        DataProvider dp = new DataProvider();

        COURSE Course = new COURSE();
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    int id = int.Parse(idTextBox.Text);
                    string label = labelTextBox.Text;
                    int period = Convert.ToInt32(periodNumericUD.Value);
                    string des = descriptionTextBox.Text;
                    int sem = int.Parse(semesterComboBox.SelectedValue.ToString());
                    string contact_id = cbContact.SelectedItem.ToString();
                    if (Course.checkCourseName(label))
                    {
                        if (Course.AddCourse(id, label, period, contact_id,des,sem))
                        {
                            MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("This Course Name Already Exits", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool check()
        {
            int id;
            if(!int.TryParse(idTextBox.Text,out id))
            {
                MessageBox.Show("Please check Course ID", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (labelTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Add a Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(periodNumericUD.Value)< 10)
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

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
            string query = "select distinct semester from course";
            semesterComboBox.DataSource = dp.ExecuteQuery(query);
            semesterComboBox.DisplayMember = "semester";
            semesterComboBox.ValueMember = "semester";
            semesterComboBox.SelectedItem = null;
            query = "select distinct id from contact";
            DataTable dt = dp.ExecuteQuery(query);
            foreach(DataRow item in dt.Rows)
            {
                cbContact.Items.Add(item[0].ToString());
            }
            cbContact.SelectedItem = null;
        }
    }
}
