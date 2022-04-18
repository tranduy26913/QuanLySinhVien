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
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }
        STUDENT Student = new STUDENT();
        

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Filter = "Select Image(*jpg;*png;*bmp;*gif)|*jpg;*png;*bmp;*gif";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openf.FileName);
            }
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            STUDENT Std = new STUDENT();
            string fname = fnameTextBox.Text;
            string lname = lnameTextBox.Text;
            string phone = phoneTextBox.Text;
            string address = AddressTextBox.Text;
            DateTime bdate = dateTimePicker1.Value;
            string gender = "Male";
            if (FemaleRadioButton.Checked)
                gender = "Female";

            int age = DateTime.Now.Year - bdate.Year;
            MemoryStream image = new MemoryStream();
            pictureBox1.Image.Save(image, pictureBox1.Image.RawFormat);
            if (age < 10 || age > 120)
                MessageBox.Show("The student age must be between 10 and 120 year", "Invalid birth date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (check())
                {
                    try
                    {
                        int id = int.Parse(idTextBox.Text);
                        if (Std.UpdateStd(id, fname, lname, bdate, gender, phone, address, image))
                            MessageBox.Show("Student Infomation Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool check()
        {
            if (idTextBox.Text.Trim() == "" || fnameTextBox.Text.Trim() == ""
                || lnameTextBox.Text.Trim() == "" || AddressTextBox.Text.Trim() == ""
                || phoneTextBox.Text.Trim() == "" || pictureBox1.Image == null)
                return false;
            return true;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(idTextBox.Text, out id))
            {
                MessageBox.Show("Lỗi ID!");
            }
            else
            {
                if (MessageBox.Show("Are You Sure", "Delele Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    STUDENT Student = new STUDENT();
                    if (Student.DeleteStudent(id))
                    {
                        MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        idTextBox.Text = "";
                        fnameTextBox.Text = "";
                        lnameTextBox.Text = "";
                        maleRadioButton.Checked = true;
                        dateTimePicker1.Value = DateTime.Now;
                        phoneTextBox.Text = "";
                        AddressTextBox.Text = "";
                        pictureBox1.Image = pictureBox1.InitialImage;
                    }
                    else
                    {
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            LoadDataGrid(Student.getStudent(command));
        }
        private void LoadDataGrid(DataTable data)
        {
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 100;
            dataGridView.DataSource = data;
            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dataGridView.Columns[7];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
            this.totalStudentLabel.Text = "Total Student:" + dataGridView.Rows.Count.ToString();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idTextBox.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            this.fnameTextBox.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            this.lnameTextBox.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            this.dateTimePicker1.Value = (DateTime)dataGridView.CurrentRow.Cells[3].Value;
            if (dataGridView.CurrentRow.Cells[4].Value.ToString() == "Female")
                this.FemaleRadioButton.Checked = true;
            this.phoneTextBox.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            this.AddressTextBox.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();

            byte[] pic = (byte[])dataGridView.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            this.pictureBox1.Image = Image.FromStream(picture);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string fname = fnameTextBox.Text;
            string lname = lnameTextBox.Text;
            string phone = phoneTextBox.Text;
            string address = AddressTextBox.Text;
            DateTime bdate = dateTimePicker1.Value;
            string gender = "Male";
            if (FemaleRadioButton.Checked)
                gender = "Female";

            int age = DateTime.Now.Year - bdate.Year;
            MemoryStream image = new MemoryStream();
            pictureBox1.Image.Save(image, pictureBox1.Image.RawFormat);
            if (age < 10 || age > 120)
                MessageBox.Show("The student age must be between 10 and 120 year", "Invalid birth date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (check())
                {
                    try
                    {
                        int id = int.Parse(idTextBox.Text);
                        if (Student.AddStd(id, fname, lname, bdate, gender, phone, address, image))
                            MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            fnameTextBox.Text = "";
            lnameTextBox.Text = "";
            maleRadioButton.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            AddressTextBox.Text = "";
            phoneTextBox.Text = "";
            searchTextBox.Text = "";
            pictureBox1.Image = pictureBox1.InitialImage;
            string query = "SELECT * FROM std";
            SqlCommand command = new SqlCommand(query);
            LoadDataGrid(Student.getStudent(command));

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string textSearch = this.searchTextBox.Text;
            string query = "SELECT * FROM std WHERE CONCAT(fname,lname,address) LIKE '%" + textSearch + "%'";
            SqlCommand command = new SqlCommand(query);
            DataTable Data = Student.getStudent(command);
            if (Data.Rows.Count > 0)
            {
                LoadDataGrid(Data);
            }
            else
                MessageBox.Show("Not Found!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.jpg";
            savefile.Filter = "JPEG Files|*.jpg|PNG Files|*.png";
            savefile.FileName = "Student_"+this.idTextBox.Text;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No Image In PictureBox!");
            }
            else if (savefile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(savefile.FileName);
            }
        }
    }
}
