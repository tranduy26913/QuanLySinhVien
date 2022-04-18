using QLSV.COURSE;
using QLSV.SCORE;
using QLSV.RESULT;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AddStdForm = new AddStudentForm();
            AddStdForm.ShowDialog(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form StdListLoadFrm = new StudentsListForm();
            StdListLoadFrm.Show();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UDstdFrm = new UpdateDeleteStudentForm();
            UDstdFrm.ShowDialog();
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form StaticFrm = new StaticForm();
            StaticFrm.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form printFrm = new PrintSaveForm();
            printFrm.ShowDialog();
        }

        private void manegeStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form msFrm = new ManageStudentForm();
            msFrm.ShowDialog();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AddCourseFrm = new AddCourseForm();
            AddCourseFrm.ShowDialog();
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form EditCourseFrm = new EditCourseForm();
            EditCourseFrm.ShowDialog();
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form RemoveCourseFrm = new RemoveCourseForm();
            RemoveCourseFrm.ShowDialog();
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ManageCourseFrm = new ManageCourseForm();
            ManageCourseFrm.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScore addScoreFrm = new AddScore();
            addScoreFrm.ShowDialog();
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm removeCourseFrm = new RemoveScoreForm();
            removeCourseFrm.ShowDialog();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form manageFrm = new ManageScoreForm();
            manageFrm.ShowDialog();
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form avgFrm = new AvgScoreForm();
            avgFrm.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form printCourseFrm = new PrintForm();
            printCourseFrm.ShowDialog();
        }

        private void staticsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form StaticFrm = new StaticsResultForm();
            StaticFrm.ShowDialog();
        }

        private void aVGResuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form avgFrm = new AvgResultForm();
            avgFrm.ShowDialog();
        }
    }
}
