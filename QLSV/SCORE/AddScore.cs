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

namespace QLSV.SCORE
{
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }

        SCORE Score = new SCORE();
        QLSV.COURSE.COURSE Course = new QLSV.COURSE.COURSE();
        STUDENT Student = new STUDENT();
        private void idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddScore_Load(object sender, EventArgs e)
        {
            
            courseidComboBox.DataSource = Course.getAllCourse("");
            courseidComboBox.DisplayMember = "label";
            courseidComboBox.SelectedItem = null;
            courseidComboBox.ValueMember = "Id";
            SqlCommand command = new SqlCommand("select Id,fname,lname from std");
            dataGridView.DataSource = Student.getStudent(command);
        }
        private void load()
        {
            courseidComboBox.DataSource = Course.getAllCourse("");
            courseidComboBox.DisplayMember = "label";
            courseidComboBox.SelectedItem = null;
            courseidComboBox.ValueMember = "Id";
            SqlCommand command = new SqlCommand("select Id,fname,lname from std");
            dataGridView.DataSource = Student.getStudent(command);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                int stdID = int.Parse(stdidTextBox.Text);
                int courseID = Convert.ToInt32(courseidComboBox.SelectedValue.ToString());
                float score = float.Parse(scoreTextBox.Text.Trim());
                string des = descriptionTextBox.Text;
                if (check())
                {
                    if (Score.checkScoreName(stdID, courseID))
                    {
                        if (Score.InsertScore(stdID, courseID, score, des))
                        {
                            MessageBox.Show("New Course Inserted", "Add Scose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Course Not Inserted", "Add Scose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Score Already Exits", "Add Scose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool check()
        {
            int id;
            if (!int.TryParse(stdidTextBox.Text, out id))
            {
                MessageBox.Show("Please check Student ID", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (float.Parse(scoreTextBox.Text) < 0|| float.Parse(scoreTextBox.Text) > 10)
            {
                MessageBox.Show("The period must between 0 and 10", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            stdidTextBox.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
