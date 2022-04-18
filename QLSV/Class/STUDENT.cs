using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLSV
{
    class STUDENT
    {
        My_DB Mydb = new My_DB();

        public bool AddStd(int ID, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO std(id,fname,lname,bdate,gender,phone,address,picture)" +
                "VALUES (@id,@fname,@lname,@bdate,@gender,@phone,@address,@picture)", Mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
                command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
                command.Parameters.Add("@bdate", SqlDbType.DateTime).Value = bdate;
                command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
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

        public DataTable getStudent(SqlCommand command)
        {
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }

        public bool DeleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM std WHERE id=@id", Mydb.getConnection);
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
                command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
                command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
                command.Parameters.Add("@bdate", SqlDbType.DateTime).Value = bdate;
                command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
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

        public int totalStudent()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT count(*) FROM std", Mydb.getConnection);
                Mydb.openConnection();
                int result = (int)command.ExecuteScalar();
                Mydb.closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
        public int maleStudent()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT count(*) FROM std WHERE gender=@gender", Mydb.getConnection);
                command.Parameters.Add("@gender", SqlDbType.VarChar).Value = "Male";
                Mydb.openConnection();
                int result = (int)command.ExecuteScalar();
                Mydb.closeConnection();
                return result;
            }
            catch
            {
                return 0;
            }


        }
    }
}
