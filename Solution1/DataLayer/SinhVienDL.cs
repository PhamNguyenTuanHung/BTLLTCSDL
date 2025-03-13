using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOT;
namespace DataLayer
{
    public class SinhVienDL
    {
        public SinhVien ThongTinSVDL(string mssv)
        {
            SinhVien sv = null;
            using (SqlConnection conn = DBConnectDL.Connect())
            {
                string query = "SELECT SinhVien.*,Khoa.Ten_Khoa FROM SinhVien,Lop,Khoa WHERE SinhVien.MSSV=@mssv and SinhVien.ma_lop=Lop.ma_lop and Lop.Ma_Khoa=Khoa.Ma_Khoa ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sv = new SinhVien()
                    {
                        MSSV= reader["MSSV"].ToString(),
                        HoTenSV = reader["Ten_Day_Du"].ToString(),
                        GioiTinh = reader["Gioi_Tinh"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["Ngay_Sinh"]),
                        Email = reader["Email"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        DiaChi = reader["Dia_Chi"].ToString(),
                        KhoaHoc = reader["Khoa_Hoc"].ToString(),
                        DRL = Convert.ToDouble(reader["Diem_Ren_Luyen"]),
                        MaLop = reader["Ma_Lop"].ToString(),
                        TenKhoa = reader["Ten_Khoa"].ToString()
                    };
                }
                reader.Close();
            }
            return sv;
        }

        public  DataTable DiemSVDL(string mssv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Ten_Mon_Hoc,Diem_Qua_Trinh,Diem_Thi,Diem_Tong_Ket FROM Diem," +
                "MonHoc WHERE Diem.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc AND Diem.MSSV=@mssv ";
            using (SqlConnection conn = DBConnectDL.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
            }
            return dt;
        }

        public DataTable TKBSinhVienDL(string mssv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Ten_Mon_Hoc,Gio_Bat_Dau,Gio_Ket_Thuc,Ngay_Hoc " +
                "FROM LopMonHoc, DangKy, MonHoc " +
                "WHERE DangKy.MSSV = @mssv and LopMonHoc.Ma_Mon_Hoc = DangKy.Ma_Mon_Hoc " +
                "and MonHoc.Ma_Mon_Hoc = DangKy.Ma_Mon_Hoc " +
                "and LopMonHoc.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc";
            using (SqlConnection conn = DBConnectDL.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
            }
            return dt;
        }
    }
}
