using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOT;

namespace DataLayer
{
    public class TaiKhoanDAl
    {
        //KIểm tra tồn tại tài khoản
        public bool CheckAccountExistsDAL(string username)
        {
            string query = "SELECT * FROM TaiKhoan WHERE Ten_Dang_Nhap = @username";

            SqlParameter[] parameters =
                {
            new SqlParameter("@username", username)
        };

            DataTable dt = DBProviderDAL.GetDataTable(query, parameters);
            return dt.Rows.Count > 0;
        }

        //Lấy email của tài khoản
        public string GetAccountEmailDAL(string username, int accountType)
        {
            string query = "";

            if (accountType == 1)
            {
                query = @"
                SELECT Email 
                FROM SinhVien 
                WHERE SinhVien.MSSV = @username";
            }
            else
            {
                query = @"
                SELECT Email 
                FROM GiaoVien 
                WHERE GiaoVien.MSGV = @username";
            }

            SqlParameter[] parameters =
                {
            new SqlParameter("@username", username)
        };
            DataTable dt = DBProviderDAL.GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0]["Email"].ToString() : "";
        }

        // Kiêm tra đăng nhập


        public TaiKhoan ValidateLoginDAL(TaiKhoan account)
        {
            try
            {
                string query = "SELECT * FROM TaiKhoan WHERE Ten_dang_nhap = @username AND Mat_khau = @password";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@username", account.TenDangNhap),
                    new SqlParameter("@password", account.MatKhau)
                };

                DataTable dt = DBProviderDAL.GetDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return new TaiKhoan
                    {
                        TenDangNhap = dt.Rows[0]["Ten_Dang_Nhap"].ToString(),
                        MatKhau = dt.Rows[0]["Mat_Khau"].ToString(),
                        LoaiTaiKhoan = Convert.ToInt32(dt.Rows[0]["Loai_Tai_Khoan"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while validating login: " + ex.Message);
            }

            return null;
        }

        //Đổi mât khẩu
        public bool ChangePasswordDAL(string username, string password)
        {
            string query = "UPDATE TaiKhoan SET Mat_Khau = @password WHERE Ten_Dang_Nhap = @username";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@username", username),
        new SqlParameter("@password", password)
            };
            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

    }
}
