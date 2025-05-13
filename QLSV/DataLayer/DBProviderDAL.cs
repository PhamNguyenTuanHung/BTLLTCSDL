using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DBProviderDAL
    {
        private static readonly string connectionString =
            @"Data Source=BLUE\BLUE;Initial Catalog=DB_QLSV;Integrated Security=True;";

        // Phương thức kết nối cơ bản
        public static SqlConnection Connect()
        {
            try
            {
                var sqlCon = new SqlConnection(connectionString);
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
                using (var connect = Connect())
                {
                    connect.Open();
                    using (var cmd = new SqlCommand(query, connect))
                    {
                        if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi truy vấn: " + query + " - " + ex.Message);
            }
        }

        // Phương thức thực thi truy vấn không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public static int MyExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connect = Connect())
                {
                    connect.Open();
                    using (var cmd = new SqlCommand(query, connect))
                    {
                        if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteNonQuery(); // Thực thi truy vấn và trả về số hàng bị ảnh hưởng
                    }
                }
            }

            catch (Exception ex) // Bắt lỗi khác
            {
                throw new Exception($"Lỗi: {ex.Message}", ex);
            }
        }
    }
}