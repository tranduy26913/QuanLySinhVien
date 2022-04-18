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
    class DataProvider
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        public DataTable ExecuteQuery(string query, object[] paramater = null)
        {
            DataTable data = new DataTable();

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                string[] arr = query.Split(' ');
                if (paramater != null)
                {
                    int i = 0;
                    foreach (string str in arr)
                    {
                        if (str.Contains("@"))
                        {
                            command.Parameters.Add(str, paramater[i]);

                            i++;
                        }

                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DataProvider", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int result = 0;

            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);

                string[] arr = query.Split(' ');
                if (paramater != null)
                {
                    int i = 0;
                    foreach (string str in arr)
                    {
                        if (str.Contains("@"))
                        {
                            command.Parameters.AddWithValue(str, paramater[i]);
                            i++;
                        }
                    }
                }
                result = command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DataProvider", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object result = 0;

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                string[] arr = query.Split(' ');
                if (paramater != null)
                {
                    int i = 0;
                    foreach (string str in arr)
                    {
                        if (str.Contains("@"))
                        {
                            command.Parameters.AddWithValue(str, paramater[i]);
                            i++;
                        }

                    }
                }
                result = command.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DataProvider", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
