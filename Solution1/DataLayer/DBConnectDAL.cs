using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

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
        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connect = Connect())
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
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
                Console.WriteLine("Lỗi khi thực thi truy vấn: " + query + " - " + ex.Message);
                return null; // Trả về null thay vì ném exception
            }
        }

        // Phương thức thực thi truy vấn không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connect = Connect())
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery(); // Thực thi truy vấn và trả về số hàng bị ảnh hưởng
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi truy vấn: " + query + " - " + ex.Message, ex);
            }
        }
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connect = Connect())
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar(); // Trả về giá trị duy nhất từ truy vấn
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
