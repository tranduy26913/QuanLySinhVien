using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.COURSE
{
    class COURSE
    {
        My_DB Mydb = new My_DB();

        public bool AddCourse(int ID, string label, int period,string contact_id, string description,int sem)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Course(Id,label,period,contact_id,description,semester)" +
                "VALUES (@id,@label,@period,@contact_id,@description,@semester)", Mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@label", SqlDbType.NVarChar).Value = label;
                command.Parameters.Add("@period", SqlDbType.Int).Value = period;
                command.Parameters.Add("@contact_id", SqlDbType.NVarChar).Value = contact_id;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
                command.Parameters.Add("@semester", SqlDbType.Int).Value = sem;
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

        public DataTable getAllCourse(string contact_id)
        {
            SqlCommand command;
            if (contact_id == "")
            {
                command = new SqlCommand("select * from Course");
            }
            else
            {
                command = new SqlCommand("select * from Course where contact_id=@contact_id");
                command.Parameters.Add("@contact_id", SqlDbType.VarChar).Value = contact_id;
            }
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }

        public DataTable getCourseByID(int ID)
        {
            SqlCommand command = new SqlCommand("select * from Course where Id=@id");
            command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }

        public DataTable getStdByID(int ID)
        {
            SqlCommand command = new SqlCommand("select Score.student_id as student_id, fname,lname from std inner join Score on std.Id=Score.student_id where Score.course_id=@id");
            command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }

        public DataTable getSemesterByID(int ID)
        {
            SqlCommand command = new SqlCommand("select semester from Course where Id=@id");
            command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }
        public bool DeleteCourse(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id=@id", Mydb.getConnection);
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

        public bool UpdateCourse(int ID, string label, int period,string contact_id, string description,int sem)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Course SET label=@label,period=@period,contact_id=@contact_id,description=@description,semester=@semester WHERE id=@id", Mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                command.Parameters.Add("@label", SqlDbType.NVarChar).Value = label;
                command.Parameters.Add("@period", SqlDbType.Int).Value = period;
                command.Parameters.Add("@contact_id", SqlDbType.NVarChar).Value = contact_id;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
                command.Parameters.Add("@semester", SqlDbType.Int).Value = sem;
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

        public int totalCourse()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT count(*) FROM Course", Mydb.getConnection);
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
        
        public bool checkCourseName(string name,int id = 0)
        {
            SqlCommand command = new SqlCommand("select * from Course where label=@label and Id<>@id");
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@label", SqlDbType.NVarChar).Value = name;
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            if (data.Rows.Count > 0)
            {
                Mydb.closeConnection();
                return false;
            }
            Mydb.closeConnection();
            return true;
        }
    }
}
