using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class StudentsListForm : Form
    {
        public StudentsListForm()
        {
            InitializeComponent();
            this.Load += StudentsListForm_Load;
        }
        public StudentsListForm(DataTable Data)
        {
            InitializeComponent();
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 100;
            dataGridView.DataSource = Data;
            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dataGridView.Columns[7];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        STUDENT Student = new STUDENT();
        private void StudentsListForm_Load(object sender, EventArgs e)
        {
            String query = "SELECT id as [Student ID],fname as [First Name],lname as [Last Name]," +
                "bdate as [Birth Day],gender as [Gender],phone as [Phone],address as [Address],picture as [Picture] FROM std";
            SqlCommand command = new SqlCommand(query);
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 100;
            dataGridView.DataSource = Student.getStudent(command);
            
            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dataGridView.Columns[7];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }


        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteStudentForm UDstdFrm = new UpdateDeleteStudentForm();
            UDstdFrm.idTextBox.Text =dataGridView.CurrentRow.Cells[0].Value.ToString();
            UDstdFrm.fnameTextBox.Text= dataGridView.CurrentRow.Cells[1].Value.ToString();
            UDstdFrm.lnameTextBox.Text= dataGridView.CurrentRow.Cells[2].Value.ToString();
            UDstdFrm.dateTimePicker1.Value=(DateTime)dataGridView.CurrentRow.Cells[3].Value;
            if (dataGridView.CurrentRow.Cells[4].Value.ToString() == "Female")
                UDstdFrm.FemaleRadioButton.Checked=true;
            UDstdFrm.phoneTextBox.Text= dataGridView.CurrentRow.Cells[5].Value.ToString();
            UDstdFrm.AddressTextBox.Text= dataGridView.CurrentRow.Cells[6].Value.ToString();

            byte[] pic = (byte[])dataGridView.CurrentRow.Cells[7].Value;
            MemoryStream picture =new MemoryStream(pic);
            UDstdFrm.pictureBox1.Image = Image.FromStream(picture);
            
            UDstdFrm.ShowDialog();
            

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            String query = "SELECT id as [Student ID],fname as [First Name],lname as [Last Name]," +
                "bdate as [Birth Day],gender as [Gender],phone as [Phone],address as [Address],picture as [Picture] FROM std";
            SqlCommand command = new SqlCommand(query);
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 100;
            dataGridView.DataSource = Student.getStudent(command);

            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dataGridView.Columns[7];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
