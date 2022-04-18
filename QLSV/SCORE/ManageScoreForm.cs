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
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }

        public ManageScoreForm(string idContact)
        {
            InitializeComponent();
            this.idContact = idContact;
        }
        SCORE Score = new SCORE();
        QLSV.COURSE.COURSE Course = new QLSV.COURSE.COURSE();
        STUDENT Student = new STUDENT();
        string idContact = "";
        private void load()
        {
            courseidComboBox.DataSource = Course.getAllCourse(idContact);
            courseidComboBox.DisplayMember = "label";
            courseidComboBox.SelectedItem = null;
            courseidComboBox.ValueMember = "Id";
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                int stdID = int.Parse(stdidTextBox.Text);
                int courseID = Convert.ToInt32(courseidComboBox.SelectedValue.ToString());
                float score = float.Parse(scoreTextBox.Text);
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
            catch
            {
                MessageBox.Show("Course Not Inserted", "Add Scose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (float.Parse(scoreTextBox.Text) < 0 || float.Parse(scoreTextBox.Text) > 10)
            {
                MessageBox.Show("The period must between 0 and 10", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            courseidComboBox.DataSource = Course.getAllCourse(idContact);
            courseidComboBox.DisplayMember = "label";
            courseidComboBox.SelectedItem = null;
            courseidComboBox.ValueMember = "Id";
            dataGridView.DataSource = Score.getAllScore(idContact);
            dataGridView.Tag = "Score";
        }

        private void avgScoreButton_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = Score.avgScore();
            dataGridView.Tag = "avg";
        }

        private void showStdButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(courseidComboBox.SelectedValue);
                SqlCommand command;
                if (this.idContact == "")
                {
                    command = new SqlCommand("select student_id as [Student ID],fname as [First Name]" +
                                        ",lname as [Last Name],bdate as [Birth Day] from" +
                                        " std inner join score on std.Id=score.student_id" +
                                        " where score.Course_id=@id");
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                }
                else
                {
                    command = new SqlCommand("select student_id as [Student ID],fname as [First Name]" +
                                          ",lname as [Last Name],bdate as [Birth Day] from" +
                                          " std inner join score on std.Id=score.student_id" +
                                          " inner join course on score.course_id=course.id " +
                                          "where score.Course_id=@id and course.contact_id=@contact_id");
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@contact_id", SqlDbType.VarChar).Value = idContact;
                }
                dataGridView.DataSource = Student.getStudent(command);
                dataGridView.Tag = "std";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showScoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = Score.getAllScoreByContactid(this.idContact);
                dataGridView.Tag = "Score";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int stdID = int.Parse(stdidTextBox.Text);
                int courseID = Convert.ToInt32(courseidComboBox.SelectedValue.ToString());
                if (Score.DeleteScore(stdID, courseID))
                {
                    MessageBox.Show("Score Deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    load();
                }
                else
                {
                    MessageBox.Show("Score Not Deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Score Not Deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Tag == "Score")
            {
                int id = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                DataTable data = Score.getAllScoreByID(id);
                this.stdidTextBox.Text = data.Rows[0][0].ToString();
                this.courseidComboBox.SelectedValue = dataGridView.CurrentRow.Cells[3].Value;
                scoreTextBox.Text = data.Rows[0][3].ToString();
                descriptionTextBox.Text = data.Rows[0][4].ToString();
            }
            else if (dataGridView.Tag == "std")
            {
                this.stdidTextBox.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                int stdID = int.Parse(stdidTextBox.Text);
                int courseID = Convert.ToInt32(courseidComboBox.SelectedValue.ToString());
                float score = float.Parse(scoreTextBox.Text);
                string des = descriptionTextBox.Text;
                if (check())
                {

                    if (Score.EditScore(stdID, courseID, score, des))
                    {
                        MessageBox.Show("Score Updated", "Edit Scose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Score Not Updated", "Edit Scose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Score Not Updated", "Edit Scose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showScoreByCourseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (courseidComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please Choose Course");
                    return;
                }
                dataGridView.DataSource = Score.getStudentByCourseID(int.Parse(courseidComboBox.SelectedValue.ToString()),idContact);
                dataGridView.Tag = "Score";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
