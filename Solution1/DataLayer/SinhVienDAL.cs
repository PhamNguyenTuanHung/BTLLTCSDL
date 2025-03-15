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
    public class SinhVien_DAL
    {
        public SinhVien ThongTinSVDAL(string mssv)
        {
            SinhVien sv = null;
            using (SqlConnection conn = DBConnect_DAL.Connect())
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

        public DataTable DiemSVDAL(string mssv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Ten_Mon_Hoc,Diem_Qua_Trinh,Diem_Thi,Diem_Tong_Ket FROM Diem," +
                "MonHoc WHERE Diem.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc AND Diem.MSSV=@mssv ";
            using (SqlConnection conn = DBConnect_DAL.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
            }
            return dt;
        }

        public DataTable TKBSinhVienDAL(string mssv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Ten_Mon_Hoc,Gio_Bat_Dau,Gio_Ket_Thuc,Ngay_Hoc " +
                "FROM LopMonHoc, DangKy, MonHoc " +
                "WHERE DangKy.MSSV = @mssv and LopMonHoc.Ma_Mon_Hoc = DangKy.Ma_Mon_Hoc " +
                "and MonHoc.Ma_Mon_Hoc = DangKy.Ma_Mon_Hoc " +
                "and LopMonHoc.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc";
            using (SqlConnection conn = DBConnect_DAL.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
            }
            return dt;
        }

        public bool DangKyMonHocDAL(string mssv, string mamonhoc, DateTime date)
        {
            using (SqlConnection conn = DBConnect_DAL.Connect())
            {
                date = DateTime.Today;
                conn.Open();
                string query = "INSERT INTO DangKy VALUES (@mssv, @mamonhoc,@date)";
                SqlCommand cmd= new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                cmd.Parameters.AddWithValue("@mamonhoc", mamonhoc);
                cmd.Parameters.AddWithValue("@date", date);
                return cmd.ExecuteNonQuery() >0;
            }    
        }

        public DataTable DanhSachMonHocDangKiDAL(string mssv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT MonDangKi.*,Ten_Mon_Hoc,So_Tin_Chi" +
                "\r\nFROM MonDangKi, MonHoc" +
                "\r\nWHERE MonHoc.Ma_Mon_Hoc= MonDangKi.Ma_Mon_Hoc";
            using (SqlConnection conn = DBConnect_DAL.Connect())
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
