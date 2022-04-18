using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLSV
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            STUDENT Std = new STUDENT();
            string fname = fnameTextBox.Text;
            string lname = lnameTextBox.Text;
            string phone = phoneTextBox.Text;
            string address = addressTextBox.Text;
            DateTime bdate = dateTimePicker1.Value;
            string gender = "Male";
            if (femaleRB.Checked)
                gender = "Female";

            int age = DateTime.Now.Year-bdate.Year;
            MemoryStream image = new MemoryStream();
            stdImagePictureBox.Image.Save(image, stdImagePictureBox.Image.RawFormat);
            if (age < 10 || age > 120)
                MessageBox.Show("The student age must be between 10 and 120 year", "Invalid birth date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (check())
                {
                    try
                    {
                        int id = int.Parse(idTextBox.Text);
                        if (Std.AddStd(id, fname, lname, bdate, gender, phone, address, image))
                            MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        public bool check()
        {
            if (idTextBox.Text.Trim() == "" || fnameTextBox.Text.Trim() == ""
                || lnameTextBox.Text.Trim() == "" || addressTextBox.Text.Trim() == ""
                || phoneTextBox.Text.Trim() == "" ||stdImagePictureBox.Image==null)
                return false;
            return true;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Filter = "Select Image(*jpg;*png;*bmp;*gif)|*jpg;*png;*bmp;*gif";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                stdImagePictureBox.Image = Image.FromFile(openf.FileName);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
