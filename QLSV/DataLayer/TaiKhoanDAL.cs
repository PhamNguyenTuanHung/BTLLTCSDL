using System;
using System.Data.SqlClient;
using DOT;

namespace DataLayer
{
    public class TaiKhoanDAl
    {
        //KIểm tra tồn tại tài khoản
        public bool CheckAccountExistsDAL(string username, int accountType)
        {
            var query = "";
            if (accountType == 1)
                query = "SELECT * FROM SinhVien WHERE MSSV = @username";
            else
                query = "SELECT * FROM GiangVien WHERE MSGV = @username";

            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username)
            };

            var dt = DBProviderDAL.GetDataTable(query, parameters);
            return dt.Rows.Count > 0;
        }

        //Lấy email của tài khoản
        public string GetAccountEmailDAL(string username, int accountType)
        {
            var query = "";

            if (accountType == 1)
                query = @"
                SELECT Email 
                FROM SinhVien 
                WHERE SinhVien.MSSV = @username";
            else
                query = @"
                SELECT Email 
                FROM GiangVien 
                WHERE GiangVien.MSGV = @username";

            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username)
            };
            var dt = DBProviderDAL.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0]["Email"].ToString() : "";
        }

        // Kiêm tra đăng nhập


        public TaiKhoan ValidateLoginDAL(TaiKhoan account)
        {
            try
            {
                var query = "SELECT * FROM TaiKhoan WHERE Ten_dang_nhap = @username AND Mat_khau = @password";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@username", account.TenDangNhap),
                    new SqlParameter("@password", account.MatKhau)
                };

                var dt = DBProviderDAL.GetDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                    return new TaiKhoan
                    {
                        TenDangNhap = dt.Rows[0]["Ten_Dang_Nhap"].ToString(),
                        MatKhau = dt.Rows[0]["Mat_Khau"].ToString(),
                        LoaiTaiKhoan = Convert.ToInt32(dt.Rows[0]["Loai_Tai_Khoan"]),
                        TrangThai = Convert.ToInt32(dt.Rows[0]["Trang_Thai"])
                    };
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng nhập: " + ex.Message);
            }

            return null;
        }

        //Đổi mât khẩu
        public bool ChangePasswordDAL(string username, string password)
        {
            var query = "UPDATE TaiKhoan SET Mat_Khau = @password WHERE Ten_Dang_Nhap = @username";
            var parameters = new[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
    }
}