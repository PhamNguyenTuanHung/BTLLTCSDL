using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataLayer
{
    public class DBProviderDAL
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
                throw new Exception("Lỗi khi thực thi truy vấn: " + query + " - " + ex.Message);
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
           /* catch (SqlException ex)
            {
                *//*switch (ex.Number)
                {
                    case 2627: // Vi phạm PRIMARY KEY hoặc UNIQUE
                        throw new Exception("Lỗi: Trùng khóa chính. Dữ liệu đã tồn tại!");

                   // case 547: // Vi phạm ràng buộc FOREIGN KEY hoặc CHECK constraint
                     //   throw new Exception("Lỗi: Không thể thực hiện do dữ liệu bị ràng buộc!");

                    case 208: // Bảng hoặc cột không tồn tại
                        throw new Exception("Lỗi: Bảng hoặc cột không tồn tại!");

                    case 4060: // Database không tồn tại hoặc bị khóa
                        throw new Exception("Lỗi: Không thể kết nối đến cơ sở dữ liệu!");

                    case 18456: // Sai tài khoản đăng nhập SQL Server
                        throw new Exception("Lỗi: Sai tên đăng nhập hoặc mật khẩu!");

                    case 233: // SQL Server không phản hồi
                        throw new Exception("Lỗi: Máy chủ SQL không phản hồi. Kiểm tra kết nối!");

                    case 53: // Không thể kết nối đến SQL Server
                        throw new Exception("Lỗi: Không thể kết nối đến máy chủ SQL. Kiểm tra mạng hoặc firewall!");

                    case 8152: // Dữ liệu nhập vào quá dài
                        throw new Exception("Lỗi: Giá trị nhập vào quá dài!");

                    case 245: // Kiểu dữ liệu sai (Data type mismatch)
                        throw new Exception("Lỗi: Dữ liệu không đúng định dạng!");

                    case 2601: // Vi phạm UNIQUE Constraint khi UPDATE
                        throw new Exception("Lỗi: Dữ liệu bị ràng buộc bởi một UNIQUE constraint!");

                    case 2628: // Dữ liệu bị cắt ngắn khi INSERT hoặc UPDATE
                        throw new Exception("Lỗi: Dữ liệu nhập vào quá lớn!");

                    default:*//*
                        throw new Exception("Lỗi SQL: " + ex.Message);
                }
            
            }*/

            catch (Exception ex) // Bắt lỗi khác
            {
                throw new Exception($"Lỗi: {ex.Message}", ex);
            }
        }

    }
}
