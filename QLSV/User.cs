using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    class User
    {
        My_DB Mydb = new My_DB();


        public bool UsernameExist(string username,string operation,int userid = 0)
        {
            string query="";
            SqlCommand command;
            if (operation == "Register")
            {
                query = "select * from hr where username=@username";
                command = new SqlCommand(query, Mydb.getConnection);
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            }
            else
            {
                query = "select * from hr where username=@username and id<>@id";
                command = new SqlCommand(query, Mydb.getConnection);
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@id", SqlDbType.Int).Value = userid;
            }
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }
        public bool AddUser(string fname, string lname,string username, string password, MemoryStream fig)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO hr(fname,lname,username,password,fig)" +
                "VALUES (@fname,@lname,@username,@password,@fig)", Mydb.getConnection);
                command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                command.Parameters.Add("@fig", SqlDbType.Image).Value = fig.ToArray();
                Mydb.openConnection();

                if ((command.ExecuteNonQuery() == 1))
                {
                    Mydb.closeConnection();
                    return true;
                }
                else
                {
                    Mydb.closeConnection();
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public DataTable getUserByID(int id)
        {
            SqlCommand command = new SqlCommand("select username,fig from hr where id=@id");
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }

        public bool DeleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM user WHERE id=@id", Mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            Mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Mydb.closeConnection();
                return true;
            }
            else
            {
                Mydb.closeConnection();
                return false;
            }
        }

        public bool UpdateStd(int ID, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE std SET fname=@fname,lname=@lname," +
                    "bdate=@bdate,gender=@gender,phone=@phone,address=@address,picture=@picture" +
                " WHERE id=@id", Mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@bdate", SqlDbType.DateTime).Value = bdate;
                command.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();
                Mydb.openConnection();

                if ((command.ExecuteNonQuery() == 1))
                {
                    Mydb.closeConnection();
                    return true;
                }
                else
                {
                    Mydb.closeConnection();
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
