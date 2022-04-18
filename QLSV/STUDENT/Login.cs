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

namespace QLSV
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userTextBox.Focus();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            My_DB db = new My_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            string query = "SELECT * FROM log_in WHERE username = @User AND password=@Pass";
            SqlCommand command = new SqlCommand(query, db.getConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = userTextBox.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = passTextBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (rbStudent.Checked == true)
            {
                if (table.Rows.Count > 0)
                {
                    Form frmMain = new MainForm();
                    this.Hide();
                    frmMain.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                query = "SELECT * FROM hr WHERE username = @User AND password=@Pass";
                command = new SqlCommand(query, db.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = userTextBox.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = passTextBox.Text;
                if (table.Rows.Count > 0)
                {
                    GlobalUserID.SetGlobalUserId(int.Parse(table.Rows[0][0].ToString()));
                    Form contact = new ContactForm();
                    this.Hide();
                    contact.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (rbStudent.Checked)
            {
                Form Register = new RegisterForm();
                Register.ShowDialog();
            }
            else
            {
                Form Register = new RegisterUserForm();
                Register.ShowDialog();
            }

        }

        private void userTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(ConsoleKey.Enter))
            {
                passTextBox.Focus();
            }
        }

        private void passTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(ConsoleKey.Enter))
            {
                loginButton.Focus();
            }
        }
    }
}
