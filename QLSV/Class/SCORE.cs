using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.SCORE
{
    class SCORE
    {
        My_DB Mydb = new My_DB();

        public bool InsertScore(int stdID, int courseID, float score, string description)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO score(student_id,course_id,student_score,description)" +
                "VALUES (@stdID,@courseID,@score,@description)", Mydb.getConnection);
                command.Parameters.Add("@stdID", SqlDbType.Int).Value = stdID;
                command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
                command.Parameters.Add("@score", SqlDbType.Float).Value = score;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
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

        public bool EditScore(int stdID, int courseID, float score, string description)
        {
            try
            {
                SqlCommand command = new SqlCommand("update score set student_score=@score, description=@description where student_id=@student_id" +
                    " and course_id=@course_id", Mydb.getConnection);
                command.Parameters.Add("@student_id", SqlDbType.Int).Value = stdID;
                command.Parameters.Add("@course_id", SqlDbType.Int).Value = courseID;
                command.Parameters.Add("@score", SqlDbType.Float).Value = score;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
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

        public DataTable getAllScoreByContactid(string contact_id)
        {
            SqlCommand command;
            if (contact_id == "")
            {
                command = new SqlCommand("select student_id as [Student ID],fname as [First Name]" +
                ",lname as [Last Name],course_id as [Course ID], Course.label as [Label],ROUND(student_score,2) as [Score]" +
                " from std inner join Score on std.Id = Score.student_id inner join Course" +
                " on Score.course_id = Course.Id");
            }
            else
            {
                command = new SqlCommand("select student_id as [Student ID],fname as [First Name]" +
                ",lname as [Last Name],course_id as [Course ID], Course.label as [Label],ROUND(student_score,2) as [Score]" +
                " from std inner join Score on std.Id = Score.student_id inner join Course" +
                " on Score.course_id = Course.Id where Course.contact_id=@contact_id");
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

        public DataTable getAllScore(string id)
        {
            SqlCommand command = new SqlCommand("select * from course");
            command.Connection = Mydb.getConnection;
             Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            string s = "";
            for(int i=0;i<data.Rows.Count;i++)
            {
                string courseid = data.Rows[i][0].ToString();
                string name = data.Rows[i][1].ToString();
                s = s + "max(case when s.course_id =" + courseid + " then ROUND(student_score,2) else 0 end) as [" + name+"],";
            }
            command = new SqlCommand("SELECT std.Id as [Student ID], std.fname as [First Name],std.lname as [Last name]," +
                s + "ROUND(avg(student_score),2) as AvgScore " +
                "from std left join score as s on std.Id = s.student_id " +
                " where CONCAT(student_id,fname) LIKE'%" + id + "%'" +
                " group by std.Id,std.fname,std.lname" );
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            DataTable data2 = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(data2);
            Mydb.closeConnection();
            return data2;
        }
        public DataTable getAllScoreByID(int id)
        {
            SqlCommand command = new SqlCommand("SELECT std.Id, std.fname,std.lname," +
                "max(case when s.course_id = 2 then ROUND(student_score,2) else 0 end) as C#," +
                "max(case when s.course_id = 3 then ROUND(student_score,2) else 0 end) as Java," +
                "max(case when s.course_id = 4 then ROUND(student_score,2) else 0 end) as [Cloud Computing]," +
                "max(case when s.course_id = 5 then ROUND(student_score,2) else 0 end) as ML," +
                "avg(student_score) as AvgScore " +
                "from std left join score as s on std.Id = s.student_id " +
                " where std.Id=@id " +
                "group by std.Id,std.fname,std.lname");
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }
        public DataTable getStatic()
        {
            SqlCommand command = new SqlCommand("select Course.label as [Label],ROUND(AVG(student_score),2) as [Avg]" +
                ",STR(count(case when student_score>=5 then 1 else null end)*100/count(student_id))+'%' as pass" +
                ",STR(count(case when student_score<5 then 1 else null end)*100/count(student_id))+'%' as fail" +
                " from std inner join Score on std.Id = Score.student_id inner join Course" +
                " on Score.course_id = Course.Id" +
                " group by Course.Id,Course.label");
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }
        public DataTable getStudentByCourseID(int ID,string contact_id)
        {
            SqlCommand command;
            if (contact_id == "")
            {
                command = new SqlCommand("select student_id as [Student ID],fname as [First Name]" +
                ",lname as [Last Name],course_id as [Course ID], Course.label as [Label],ROUND(student_score,2) as [Score]" +
                " from std inner join Score on std.Id = Score.student_id inner join Course" +
                " on Score.course_id = Course.Id where course_id=@id");
                command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            }
            else
            {
                command = new SqlCommand("select student_id as [Student ID],fname as [First Name]" +
                ",lname as [Last Name],course_id as [Course ID], Course.label as [Label],ROUND(student_score,2) as [Score]" +
                " from std inner join Score on std.Id = Score.student_id inner join Course" +
                " on Score.course_id = Course.Id where course_id=@id and Course.contact_id=@contact_id");
                command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
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

        public bool DeleteScore(int stdID,int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM score WHERE student_id=@stdID and course_id=@courseID", Mydb.getConnection);
            command.Parameters.Add("@stdID", SqlDbType.Int).Value = stdID;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
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

        public DataTable avgScore()
        {
            DataTable data = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("select label as [Name Course],AVG from(select course_id, ROUND(AVG(student_score),2)" +
                    " as AVG from score group by course_id) as AVG_SCORE " +
                    "inner join Course on AVG_SCORE.course_id = Course.Id", Mydb.getConnection);
                Mydb.openConnection();
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                Mydb.closeConnection();
                return data;
            }
            catch (Exception ex)
            {
                return data;
            }


        }

        public bool checkScoreName(int stdID, int courseID)
        {
            SqlCommand command = new SqlCommand("select * from score where student_id=@stdID and course_id=@courseID");
            command.Parameters.Add("@stdID", SqlDbType.Int).Value = stdID;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
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
