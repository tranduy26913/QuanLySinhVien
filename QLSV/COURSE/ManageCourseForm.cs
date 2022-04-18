using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.COURSE
{
    public partial class ManageCourseForm : Form
    {
        public ManageCourseForm()
        {
            InitializeComponent();
        }
        COURSE Course = new COURSE();
        DataProvider dp = new DataProvider();
        int index = 0;
        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            LoadData();
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
        
        private void LoadData()
        {
            listBox.DataSource = Course.getAllCourse("");
            listBox.DisplayMember = "label";
            listBox.ValueMember = "id";
            listBox.SelectedIndex = 0;
            index = listBox.Items.Count-1;
            ShowData(index);
            totalCourseLabel.Text = "Total Course:"+(index+1).ToString();

        }

      
        private void resetButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            labelTextBox.Text = "";
            periodNumericUD.Value = 1;
            descriptionTextBox.Text = "";
            //LoadData();
        }

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
                            MessageBox.Show("New Course Inserted", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                            MessageBox.Show("Course Not Inserted", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("This Course Name Already Exits", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!int.TryParse(idTextBox.Text, out id))
            {
                MessageBox.Show("Please check Course ID", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (labelTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Add a Course Name", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(periodNumericUD.Value) < 10)
            {
                MessageBox.Show("The period must than 10", "Manage Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData(listBox.SelectedIndex);
        }

        private void ShowData(int index)
        {
            listBox.SelectedIndex = index;
            DataRowView dr = (DataRowView)listBox.SelectedItem;          
            idTextBox.Text = dr.Row.ItemArray[0].ToString();
            labelTextBox.Text = dr.Row.ItemArray[1].ToString();
            periodNumericUD.Value = Convert.ToDecimal(dr.Row.ItemArray[2].ToString());
            string contact= dr.Row.ItemArray[3].ToString();
            for (int i = 0; i < cbContact.Items.Count; i++)
            {
                if (cbContact.Items[i].ToString().Equals(contact))
                {
                    cbContact.SelectedIndex = i;
                    break;
                }
            }
            descriptionTextBox.Text = dr.Row.ItemArray[4].ToString();
            string sem = dr.Row.ItemArray[5].ToString();
            for (int i = 0; i < semesterComboBox.Items.Count; i++)
            {
                if (semesterComboBox.Items[i].ToString().Equals(sem))
                {
                    semesterComboBox.SelectedIndex = i;
                    break;
                }
            }
            index = listBox.SelectedIndex;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (index < listBox.Items.Count - 1)
            {
                index++;
                ShowData(index);
                preButton.Enabled = true;
                firstButton.Enabled = true;
                if (index == listBox.Items.Count - 1)
                {
                    nextButton.Enabled = false;
                    
                    lastButton.Enabled = false;
                    
                }
                    
            }
        }

        private void preButton_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                ShowData(index);
                nextButton.Enabled = true;
                lastButton.Enabled = true;
                if (index == 0)
                {                  
                    preButton.Enabled = false;
                    
                    firstButton.Enabled = false;
                }
            }
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            index = listBox.Items.Count-1;
            ShowData(index);
            nextButton.Enabled = false;
            preButton.Enabled = true;
            lastButton.Enabled = false;
            firstButton.Enabled = true;
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            index = 0;
            ShowData(index);
            nextButton.Enabled = true;
            preButton.Enabled = false;
            lastButton.Enabled = true;
            firstButton.Enabled = false;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check())
                {
                    return;
                }
                int id = int.Parse(idTextBox.Text);
                string label = labelTextBox.Text;
                int period = Convert.ToInt32(periodNumericUD.Value);
                string des = descriptionTextBox.Text;
                int sem = int.Parse(semesterComboBox.SelectedValue.ToString());
                string contact_id = cbContact.SelectedItem.ToString();
                if (Course.checkCourseName(label, id))
                {

                    if (Course.UpdateCourse(id, label, period, contact_id, des, sem))
                    {
                        MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void removeEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idTextBox.Text);
                if (Course.DeleteCourse(id))
                {
                    MessageBox.Show("Course Deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course Not Deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CourseStdList stdList =new CourseStdList();
                stdList.courseIDTextBox.Text = listBox.SelectedValue.ToString();
                stdList.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
