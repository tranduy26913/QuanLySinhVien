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
    class CONTACT
    {
        My_DB Mydb = new My_DB();


        public DataTable GetContactByIDGroup(int id=0)
        {
            DataTable data = new DataTable();
            try
            {
                SqlCommand command;
                if(id==0)
                    command=new SqlCommand("select contact.id as id,fname,lname,name as group_name,phone,email,address,pic from contact inner join " +
                    "group_contact on contact.group_id=group_contact.id", Mydb.getConnection);
                else
                {
                    command = new SqlCommand("select contact.id as id,fname,lname,name as group_name,phone,email,address,pic from contact inner join " +
                    "group_contact on contact.group_id=group_contact.id where group_contact.id=@id", Mydb.getConnection);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                }
                Mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                adapter.Fill(data);
                Mydb.closeConnection();
                return data;

            }
            catch
            {
                return data;
            }
        }
        
        public bool AddContact(string id, string fname, string lname, int group_id, string phone, string email, string address, MemoryStream picture, int userid)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO contact(id,fname,lname,group_id,phone,email,address,pic,userid)" +
                "VALUES (@id,@fname,@lname,@group_id,@phone,@email,@address,@pic,@userid)", Mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@group_id", SqlDbType.Int).Value = group_id;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
                command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
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

        public DataTable getAllContact()
        {
            SqlCommand command = new SqlCommand("select * from contact", Mydb.getConnection);
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }
        public DataTable getContactByID(string id)
        {
            SqlCommand command = new SqlCommand("select * from contact where id=@id", Mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Connection = Mydb.getConnection;
            Mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Mydb.closeConnection();
            return data;
        }


        public bool DeleteContact(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM contact WHERE id=@id", Mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
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

        public bool UpdateContact(string ID, string fname, string lname, int group_id, string phone, string email, string address, MemoryStream picture, int userid)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE contact SET fname=@fname,lname=@lname," +
                    "group_id=@group_id,phone=@phone,email=@email,address=@address,pic=@pic,userid=@userid" +
                " WHERE id=@id", Mydb.getConnection);
                command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@group_id", SqlDbType.Int).Value = group_id;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
                command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = ID;


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

        public bool idContactExist(string id)
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from contact where id=@id", Mydb.getConnection);
                command.Connection = Mydb.getConnection;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                Mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);
                Mydb.closeConnection();
                if (data.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }

}
