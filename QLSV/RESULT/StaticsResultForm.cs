using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.RESULT
{
    public partial class StaticsResultForm : Form
    {
        public StaticsResultForm()
        {
            InitializeComponent();
        }
        QLSV.SCORE.SCORE Score = new QLSV.SCORE.SCORE();
        private void StaticsResultForm_Load(object sender, EventArgs e)
        {
            DataTable data = Score.getStatic();
            dataGridView1.DataSource = data;
            chart1.DataSource= Score.getStatic();
            for(int i = 0; i < data.Rows.Count; i++)
            {
                string percent = data.Rows[i][2].ToString();
                percent = percent.Substring(0, percent.Length - 1);
                chart1.Series["Pass"].Points.AddXY(data.Rows[i][0].ToString(), percent.Trim());
                percent = data.Rows[i][3].ToString();
                percent = percent.Substring(0, percent.Length - 1);
                chart1.Series["Fail"].Points.AddXY(data.Rows[i][0].ToString(), percent.Trim());
            }
            
        }
    }
}
