using System;
using System.Data;
using System.Data.SqlClient;
using DOT;

namespace DataLayer
{
    public class SinhVien_DAL
    {
        public DataTable ThongTinSVDAL(string mssv)
        {
            try
            {
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    DataTable dt = new DataTable();
                    string query = "SELECT SinhVien.*, Khoa.Ten_Khoa FROM SinhVien, Lop, Khoa " +
                                   "WHERE SinhVien.MSSV = @mssv " +
                                   "AND SinhVien.ma_lop = Lop.ma_lop " +
                                   "AND Lop.Ma_Khoa = Khoa.Ma_Khoa";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);

                    conn.Open();
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                    sqlAdapter.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException ex) // Lỗi SQL
            {
                throw ex; // Ném lỗi lên BUS
            }
            catch (Exception ex) // Lỗi khác
            {
                throw ex; // Ném lỗi lên BUS
            }
        }



        public SinhVien ThongTinSinhVienDAL(string mssv)
        {
            try
            {
                SinhVien sv = null;
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    string query = "SELECT SinhVien.*,Lop.Ma_Lop FROM SinhVien, Lop, Khoa " +
                                   "WHERE SinhVien.MSSV = @mssv AND SinhVien.ma_lop = Lop.ma_lop ";
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
                                DiaChi = reader["Dia_Chi"].ToString(),
                                KhoaHoc = reader["Khoa_Hoc"].ToString(),
                                DRL = Convert.ToDouble(reader["Diem_Ren_Luyen"]),
                                MaLop = reader["Ma_Lop"].ToString(),
                            };
                        }
                    }
                }
                return sv;
            }
            catch (Exception ex)
            {
                throw ex;
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
                string query = "SELECT ThoiKhoaBieu.Ma_Lop_Mon_Hoc,Ngay_Hoc,Gio_Bat_Dau,Gio_Ket_Thuc,Phong_Hoc" +
                    "\r\nFROM DangKy,LopMonHoc,ThoiKhoaBieu" +
                    "\r\nWHERE @mssv= DangKy.MSSV and DangKy.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc" +
                    "\r\nAND ThoiKhoaBieu.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc";

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
                throw ex;
            }
        }

        public bool DangKyMonHoc(string mssv, string malopmonhoc)
        {
            try
            {
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    conn.Open();
                    // Kiểm tra số lượng đăng ký tối đa
                    string checkSoLuongQuery = "SELECT COUNT(*) AS So_Luong_Da_DK, " +
                                              "(SELECT So_Luong_DK_Toi_Da FROM LopMonHoc WHERE Ma_Lop_Mon_Hoc = @malopmonhoc) AS So_Luong_Toi_Da " +
                                              "FROM DangKy WHERE Ma_Lop_Mon_Hoc = @malopmonhoc";
                    using (SqlCommand checkSoLuongCmd = new SqlCommand(checkSoLuongQuery, conn))
                    {
                        checkSoLuongCmd.Parameters.AddWithValue("@malopmonhoc", malopmonhoc);
                        using (SqlDataReader reader = checkSoLuongCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int soLuongDaDK = reader.GetInt32(0);
                                int soLuongToiDa = reader.GetInt32(1);
                                if (soLuongDaDK >= soLuongToiDa)
                                {
                                    throw new Exception("Lớp đã đầy, không thể đăng ký thêm!");
                                }
                            }
                        }
                    }

                    // Thực hiện đăng ký
                    string insertQuery = "INSERT INTO DangKy (MSSV, Ma_Lop_Mon_Hoc, Ngay_Dang_Ky) " +
                                        "VALUES (@mssv, @malopmonhoc, @date)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@mssv", mssv);
                        cmd.Parameters.AddWithValue("@malopmonhoc", malopmonhoc);
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng ký môn học: " + ex.Message);
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
                    string query = "INSERT INTO DangKy VALUES (@mssv, @malopmonhoc, @date)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@malopmonhoc", mamonhoc);
                    cmd.Parameters.AddWithValue("@date", date);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng ký môn học: " + ex.Message);
            }


        }

        public DataTable DanhSachMonHocDangKiDAL()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT LopMonHoc.Ma_Lop_Mon_Hoc,MonHoc.Ma_Mon_Hoc,MonHoc.Ten_Mon_Hoc," +
                    "\r\nThoiKhoaBieu.Ngay_Hoc,ThoiKhoaBieu.Gio_Bat_Dau,ThoiKhoaBieu.Gio_Ket_Thuc," +
                    "\r\nThoiKhoaBieu.Phong_Hoc,MonHoc.So_Tin_Chi,LopMo.So_Luong_Toi_Da," +
                    "\r\n    (SELECT COUNT(*) \r\n     " +
                    "FROM DangKy \r\n     " +
                    "WHERE DangKy.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc) AS So_Luong_Da_DK" +
                    "\r\nFROM LopMo, LopMonHoc, MonHoc, ThoiKhoaBieu" +
                    "\r\nWHERE LopMonHoc.Ma_Hoc_Ky = 'HK3_24_25' " +
                    "\r\n    AND LopMo.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc" +
                    "\r\n    AND LopMonHoc.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc " +
                    "\r\n    AND ThoiKhoaBieu.Ma_Lop_Mon_Hoc = LopMo.Ma_Lop_Mon_Hoc;";

                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
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

        public DataTable LichThiDAL(string mssv)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT DangKy.Ma_Lop_Mon_Hoc, Ten_Mon_Hoc,Ngay_Thi,Gio_Bat_Dau,Gio_Ket_Thuc,Phong_Thi " +
                    "FROM LichThi,DangKy ,MonHoc,LopMonHoc" +
                    "\r\nWHERE DangKy.Ma_Lop_Mon_Hoc=LichThi.Ma_Lop_Mon_Hoc AND DangKy.MSSV=@mssv " +
                    "\r\nAND LopMonHoc.Ma_Lop_Mon_Hoc=DangKy.Ma_Lop_Mon_Hoc AND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc";
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
