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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string user = usernameTextBox.Text;
            if (CheckUser() && pwTextBox.Text!="")
            {
                if (checkBox1.Checked == false)
                {
                    errorProvider1.SetError(checkBox1, "Please check");
                }
                else
                {
                    My_DB Mydb = new My_DB();
                    SqlCommand command = new SqlCommand("SELECT MAX(id) FROM log_in", Mydb.getConnection);
                    Mydb.openConnection();
                    SqlDataReader Dr = command.ExecuteReader();
                    int id=0;
                    while(Dr.Read())
                        id = int.Parse(Dr[0].ToString());
                    Dr.Close();
                     command = new SqlCommand("INSERT INTO log_in(id,username,password)" +
                         "VALUES (@id,@user,@pw)", Mydb.getConnection);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id + 1;
                    command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    command.Parameters.Add("@pw", SqlDbType.VarChar).Value = pwTextBox.Text;
                   
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Đăng ký thành công!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Đăng ký thất bại!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Mydb.closeConnection();
                }

            }
            else
            {
                MessageBox.Show("Please check your Username or Password!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckUser()
        {
            My_DB db = new My_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM log_in WHERE username = @User", db.getConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = usernameTextBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        private void cfTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cfTextBox.Text != pwTextBox.Text)
                errorProvider3.SetError(cfTextBox, "Please check your password");
            else
                errorProvider3.Clear();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!CheckUser())
                errorProvider1.SetError(usernameTextBox, "Please check your username");
            else
                errorProvider1.Clear();
        }

        private void pwTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pwTextBox.Text == "")
                errorProvider2.SetError(usernameTextBox, "Please fill password");
            else
                errorProvider2.Clear();
        }

        private void pwTextBox_Validated(object sender, EventArgs e)
        {
            if (pwTextBox.Text == "")
                errorProvider2.SetError(usernameTextBox, "Please fill password");
            else
                errorProvider2.Clear();
        }
    }
}
