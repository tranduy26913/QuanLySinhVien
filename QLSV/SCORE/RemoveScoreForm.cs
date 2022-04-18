using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.SCORE
{
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }
        QLSV.COURSE.COURSE Course = new QLSV.COURSE.COURSE();
        SCORE Score = new SCORE();
       
        private void load()
        {
            dataGridView.DataSource = Score.getAllScore("");

        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int stdID = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                int courseID = Convert.ToInt32(dataGridView.CurrentRow.Cells[3].Value);
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

        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Score.getAllScore("");
        }
    }
}
