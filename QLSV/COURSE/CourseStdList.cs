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
    public partial class CourseStdList : Form
    {
        public CourseStdList()
        {
            InitializeComponent();
        }
        COURSE Course = new COURSE();
        private void CourseStdList_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV() 
        {
            try
            {
                int CourseID = int.Parse(this.courseIDTextBox.Text);
                dataGridView.DataSource = Course.getStdByID(CourseID);
                this.semesterLabel.Text = "Semester: " +(Course.getSemesterByID(CourseID)).Rows[0][0].ToString();
                for (int i = 1; i <dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i - 1].Cells[0].Value = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
