using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOT;

namespace DataLayer
{
    public class TaiKhoanDl
    {
        public TaiKhoan CheckLoginDL(TaiKhoan taikhoan)
        {
            using (SqlConnection conn = DBConnectDL.Connect())
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
                return null;
            }
        }
    }
}
