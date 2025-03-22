using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DBConnect_DAL
    {
        private static readonly string connectionString = @"Data Source=BLUE\BLUE;Initial Catalog=DB_QLSV;Integrated Security=True;";

        // Phương thức kết nối cơ bản
        public static SqlConnection Connect()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(connectionString);
                return sqlCon;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kết nối đến CSDL: " + ex.Message, ex);
            }
        }

        // Phương thức thực thi truy vấn và trả về DataTable
        public static DataTable GetData(string query)
        {
            try
            {
                using (SqlConnection connect = Connect())
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi truy vấn: " + query + " - " + ex.Message, ex);
            }
        }

        // Phương thức thực thi truy vấn không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public static int ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connect = Connect())
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi truy vấn: " + query + " - " + ex.Message, ex);
            }
        }
    }
}
