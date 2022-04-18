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
    public partial class AddCourseForm_stdcs : Form
    {
        public AddCourseForm_stdcs()
        {
            InitializeComponent();
        }
        DataProvider dp = new DataProvider();
        DataTable data = new DataTable();
        List<int> dataChoose = new List<int>();

        private void AddCourseForm_stdcs_Load(object sender, EventArgs e)
        {
            string query = "select distinct semester from course";
            semesterComboBox.DataSource = dp.ExecuteQuery(query);
            semesterComboBox.DisplayMember = "semester";
            semesterComboBox.ValueMember = "semester";
            semesterComboBox.SelectedItem = null;
        }

        private void loadListCourse()
        {
            string query = "select * from course where semester= @semester";
            if (this.semesterComboBox.SelectedValue != null)
            {
                int semester;
                if (int.TryParse(this.semesterComboBox.SelectedValue.ToString(), out semester))
                {
                    data = dp.ExecuteQuery(query, new object[] { semester });

                }

            }
        }
        private void showAvailableListBox()
        {
            if (data.Rows.Count != 0)
            {
                availableListBox.DataSource = data;
                availableListBox.DisplayMember = "label";
                availableListBox.ValueMember = "id";
                availableListBox.SelectedIndex = 0;
            }

        }

        private void semesterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadListCourse();
                showAvailableListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (availableListBox.Items.Count > 0)
            {
                chooseCourseListBox.Items.Add(availableListBox.SelectedItem);
                dataChoose.Add(Convert.ToInt32(data.Rows[availableListBox.SelectedIndex][0]));
                chooseCourseListBox.DisplayMember = "label";
                chooseCourseListBox.ValueMember = "id";
                chooseCourseListBox.SelectedIndex = 0;
                data.Rows.RemoveAt(availableListBox.SelectedIndex);
                showAvailableListBox();
            }
            else
            {
                MessageBox.Show("Môn học đã hết!");
            }



        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO score(student_id,course_id,student_score,description)" +
                "VALUES( @stdID , @courseID , @score , @description )";

            int stdID = int.Parse(this.stdIDTextBox.Text);
            int courseID;
            for(int i = 0; i < dataChoose.Count; i++)
            {
                try
                {
                    courseID = dataChoose[i];
                    dp.ExecuteNonQuery(query, new object[] { stdID, courseID, 0f, courseID.ToString() });
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}
