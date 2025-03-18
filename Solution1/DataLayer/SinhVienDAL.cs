using System;
using System.Data;
using System.Data.SqlClient;
using DOT;

namespace DataLayer
{
    public class SinhVien_DAL
    {
        public SinhVien ThongTinSVDAL(string mssv)
        {
            try
            {
                SinhVien sv = null;
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    string query = "SELECT SinhVien.*, Khoa.Ten_Khoa FROM SinhVien, Lop, Khoa " +
                                   "WHERE SinhVien.MSSV = @mssv AND SinhVien.ma_lop = Lop.ma_lop " +
                                   "AND Lop.Ma_Khoa = Khoa.Ma_Khoa";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sv = new SinhVien()
                            {
                                MSSV = reader["MSSV"].ToString(),
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
                    }
                }
                return sv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin sinh viên: " + ex.Message);
            }
        }

        public DataTable DiemSVDAL(string mssv)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT Ten_Mon_Hoc, Diem_Qua_Trinh, Diem_Thi, Diem_Tong_Ket " +
                               "FROM Diem, MonHoc WHERE Diem.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc " +
                               "AND Diem.MSSV = @mssv";

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
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy điểm sinh viên: " + ex.Message);
            }
        }

        public DataTable TKBSinhVienDAL(string mssv)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT Ten_Mon_Hoc, Gio_Bat_Dau, Gio_Ket_Thuc, Ngay_Hoc " +
                               "FROM LopHocPhan, DangKy, MonHoc " +
                               "WHERE DangKy.MSSV = @mssv " +
                               "AND LopHocPhan.Ma_Mon_Hoc = DangKy.Ma_Mon_Hoc " +
                               "AND MonHoc.Ma_Mon_Hoc = DangKy.Ma_Mon_Hoc " +
                               "AND LopHocPhan.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc";

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
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thời khóa biểu sinh viên: " + ex.Message);
            }
        }

        public bool DangKyMonHocDAL(string mssv, string mamonhoc, DateTime date)
        {
            try
            {
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    date = DateTime.Today;
                    conn.Open();
                    string query = "INSERT INTO DangKy VALUES (@mssv, @mamonhoc, @date)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@mamonhoc", mamonhoc);
                    cmd.Parameters.AddWithValue("@date", date);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng ký môn học: " + ex.Message);
            }
        }

        public DataTable DanhSachMonHocDangKiDAL(string mssv)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT MonDangKi.*, Ten_Mon_Hoc, So_Tin_Chi " +
                               "FROM MonDangKi, MonHoc " +
                               "WHERE MonHoc.Ma_Mon_Hoc = MonDangKi.Ma_Mon_Hoc";

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
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách môn học đăng ký: " + ex.Message);
            }
        }

        public bool DoiMatKhauDAL(string mssv, string pass)
        {
            try
            {
                string query = "UPDATE TaiKhoan " +
                               "SET Mat_Khau = @pass " +
                               "WHERE Ten_Dang_Nhap = @mssv";

                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }
    }
}
