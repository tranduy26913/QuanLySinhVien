using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSV
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }
        STUDENT Student = new STUDENT();
        private void fineIDButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.idTextBox.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE id=" + id);
            DataTable data = Student.getStudent(command);
            if (data.Rows.Count > 0)
            {
                this.fnameTextBox.Text = (data.Rows[0]["fname"].ToString());
                this.lnameTextBox.Text = data.Rows[0]["lname"].ToString();
                this.dateTimePicker1.Value = (DateTime)data.Rows[0]["bdate"];
                if (data.Rows[0]["gender"].ToString() == "Female")
                {
                    this.FemaleRadioButton.Checked = true;
                }
                else
                {
                    this.maleRadioButton.Checked = true;
                }
                this.phoneTextBox.Text = data.Rows[0]["phone"].ToString();
                this.AddressTextBox.Text = data.Rows[0]["address"].ToString();

                byte[] pic = (byte[])data.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                this.pictureBox1.Image = Image.FromStream(picture);
            }
            else
                MessageBox.Show("Not Found!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void findFnButton_Click(object sender, EventArgs e)
        {
            string fname = this.fnameTextBox.Text;
            string query = "SELECT * FROM std WHERE fname LIKE '%" + fname + "%'";
            SqlCommand command = new SqlCommand(query);
            DataTable Data=Student.getStudent(command);
            if (Data.Rows.Count > 0)
            {
                Form stdListFrm = new StudentsListForm(Data);
                stdListFrm.ShowDialog();
            }
            else
                MessageBox.Show("Not Found!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void findPhoneButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE phone=@phone");
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = this.phoneTextBox.Text;
            DataTable data = Student.getStudent(command);
            if (data.Rows.Count > 0)
            {
                this.idTextBox.Text = data.Rows[0]["id"].ToString();
                this.fnameTextBox.Text = data.Rows[0]["fname"].ToString();
                this.lnameTextBox.Text = data.Rows[0]["lname"].ToString();
                this.dateTimePicker1.Value = (DateTime)data.Rows[0]["bdate"];
                if (data.Rows[0]["gender"].ToString() == "Female")
                {
                    this.FemaleRadioButton.Checked = true;
                }
                else
                {
                    this.maleRadioButton.Checked = true;
                }
                this.phoneTextBox.Text = data.Rows[0]["phone"].ToString();
                this.AddressTextBox.Text = data.Rows[0]["address"].ToString();

                byte[] pic = (byte[])data.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                this.pictureBox1.Image = Image.FromStream(picture);
            }
            else
                MessageBox.Show("Not Found!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.Message,"Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(!int.TryParse(idTextBox.Text,out id))
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

        private void button1_Click(object sender, EventArgs e)
        {
            AddCourseForm_stdcs AddCoursestd = new AddCourseForm_stdcs();
            AddCoursestd.stdIDTextBox.Text = this.idTextBox.Text;
            AddCoursestd.ShowDialog();
        }
    }
}
