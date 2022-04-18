using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    class GROUP
    {
        My_DB Mydb = new My_DB();
        public DataTable GetAllGroup()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from group_contact";
                SqlCommand command = new SqlCommand(query, Mydb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }

        }
        public bool nameGroupExist(string nameGroup, int id = 0)
        {
            string query = "";
            SqlCommand command;
            if (id == 0)
            {
                query = "select * from group_contact where name=@name";
                command = new SqlCommand(query, Mydb.getConnection);
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = nameGroup;
            }
            else
            {
                query = "select * from group_contact where name=@name and id<>@id";
                command = new SqlCommand(query, Mydb.getConnection);
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = nameGroup;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }
        public bool AddGroup(string nameGroup)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO group_contact(name)" +
                "VALUES (@name)", Mydb.getConnection);
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = nameGroup;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool EditGroup(string nameGroup, int id)
        {
            try
            {
                SqlCommand command = new SqlCommand("update group_contact set name=@name where id=@id", Mydb.getConnection);
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = nameGroup;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool RemoveGroup(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand("delete from group_contact where id=@id", Mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
