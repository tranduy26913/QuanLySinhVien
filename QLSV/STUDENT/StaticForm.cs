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
    public partial class StaticForm : Form
    {
        public StaticForm()
        {
            InitializeComponent();
        }
        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;

        private void StaticForm_Load(object sender, EventArgs e)
        {
            panTotalColor = panTotal.BackColor;
            panMaleColor = panMale.BackColor;
            panFemaleColor = panFemale.BackColor;
            STUDENT std = new STUDENT();
            double total = Convert.ToDouble(std.totalStudent());
            double male = Convert.ToDouble(std.maleStudent());
            double female = total - male;
            double malepercent = 100 * male / total;
            double femalepercent = 100 - malepercent;
            lbTotal.Text = "Total student:"+total.ToString();
            lbMale.Text = "Male:" + malepercent.ToString("0.00") + "%";
            lbFemale.Text = "FeMale:"+femalepercent.ToString("0.00")+"%";
        }

        private void lbTotal_MouseEnter(object sender, EventArgs e)
        {
            lbTotal.ForeColor = panTotalColor;
            panTotal.BackColor = Color.White;
        }

        private void lbMale_MouseEnter(object sender, EventArgs e)
        {
            lbMale.ForeColor = panMaleColor;
            panMale.BackColor = Color.White;
        }

        private void panTotal_MouseLeave(object sender, EventArgs e)
        {
            lbTotal.ForeColor = Color.White;
            panTotal.BackColor = panTotalColor;
        }

        private void panMale_MouseLeave(object sender, EventArgs e)
        {
            lbMale.ForeColor = Color.White;
            panMale.BackColor = panMaleColor;
        }

        private void panFemale_MouseEnter(object sender, EventArgs e)
        {
            lbFemale.ForeColor = panFemaleColor;
            panFemale.BackColor = Color.White;
        }

        private void panFemale_MouseLeave(object sender, EventArgs e)
        {
            lbFemale.ForeColor = Color.White;
            panFemale.BackColor = panFemaleColor;
        }
    }
}
