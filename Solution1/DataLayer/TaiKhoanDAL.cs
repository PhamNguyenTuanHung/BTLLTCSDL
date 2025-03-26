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
    public class TaiKhoan_DAl
    {
        public bool KiemTraTonTaiTaiKhoanDAl(string tenTaiKhoan)
        {
            string query = "SELECT * FROM TaiKhoan WHERE Ten_Dang_Nhap = @tenTaiKhoan";

            SqlParameter[] parameters =
                {
                    new SqlParameter("@tenTaiKhoan", tenTaiKhoan)
                };

            DataTable dt = DBConnect_DAL.GetDataTable(query, parameters);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }


        public string LayEmailCuaTaiKhoanDAL(string taiKhoan, int loaiTaiKhoan)
        {
            string query = "";

            if (loaiTaiKhoan == 1)
            {
                query = @"
                        SELECT Email 
                        FROM  SinhVien 
                        WHERE SinhVien.MSSV = @taikhoan";
            }
            else
            {
                query = @"
                        SELECT Email 
                        FROM  GiaoVien 
                        WHERE GiaoVien.MSGV  = @taikhoan";
            }


            SqlParameter[] parameters = 
                {
                    new SqlParameter("@taikhoan", taiKhoan)
                };
            DataTable dt = DBConnect_DAL.GetDataTable(query, parameters);
            if (dt.Rows.Count > 0) 
                return dt.Rows[0]["Email"].ToString();
            return "";
        }
        public TaiKhoan KiemTraDangNhapDAL(TaiKhoan taikhoan)
        {
            try
            {

                string query = "SELECT * FROM TaiKhoan WHERE Ten_dang_nhap = @username AND Mat_khau = @password";


                SqlParameter[] parameters =
                {
                    new SqlParameter( "@username", taikhoan.User_name),
                    new SqlParameter( "@password", taikhoan.Pass_word)
                };

                DataTable dt = DBConnect_DAL.GetDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return new TaiKhoan
                    {
                        User_name = dt.Rows[0]["TenTaiKhoan"].ToString(),
                        Pass_word = dt.Rows[0]["Mat_Khau"].ToString(),
                        Type = Convert.ToInt32(dt.Rows[0]["LoaiTaiKhoan"])
                    };
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý theo cách phù hợp (ví dụ: ghi log, hiển thị thông báo)
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }

            return null;
        }

        public bool DoiMatKhauDAL(string taiKhoan,string matKhau)
        {
            string query = "UPDATE TaiKhoan SET Mat_Khau =@matKhau WHERE Ten_Dang_Nhap = @taiKhoan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@taiKhoan",taiKhoan),
                new SqlParameter("@matKhau",matKhau)
            };
            return DBConnect_DAL.ExecuteNonQuery(query,parameters)>0;
        }    
    }
}
