using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOT;

namespace DataLayer
{
    public class TaiKhoan_DAl
    {
        public TaiKhoan CheckLoginDAL(TaiKhoan taikhoan)
        {
            try
            {
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    conn.Open();
                    string query = "SELECT * FROM TaiKhoan WHERE Ten_dang_nhap = @username AND Mat_khau = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", taikhoan.User_name);
                        cmd.Parameters.AddWithValue("@password", taikhoan.Pass_word);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string username = reader["Ten_Dang_Nhap"].ToString();
                                string password = reader["Mat_Khau"].ToString();
                                int type = Convert.ToInt32(reader["Loai_Tai_Khoan"]);

                                return new TaiKhoan(username, password, type);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý theo cách phù hợp (ví dụ: ghi log, hiển thị thông báo)
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }

            return null;
        }
    }
}
