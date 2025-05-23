﻿using System;
using System.Data;
using System.Data.SqlClient;
using DOT;

namespace DataLayer
{
    public class SinhVienDAL : TaiKhoanDAl
    {
        //Lấy thông tin sinh viên
        public DataTable GetStudentInfoTableDAL(string mssv)
        {
            try
            {
                var query = "SELECT SinhVien.*, Khoa.Ten_Khoa FROM SinhVien, Lop, Khoa " +
                            "WHERE SinhVien.MSSV = @mssv " +
                            "AND SinhVien.ma_lop = Lop.ma_lop " +
                            "AND Lop.Ma_Khoa = Khoa.Ma_Khoa";
                var parameters = new[]
                {
                    new SqlParameter("@mssv", mssv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex) // Lỗi khác
            {
                throw ex; // Ném lỗi lên BUS
            }
        }

        public SinhVien GetStudentDetailsDAL(string mssv)
        {
            try
            {
                SinhVien sv = null;
                using (var conn = DBProviderDAL.Connect())
                {
                    var query = "SELECT SinhVien.*,Lop.Ma_Lop FROM SinhVien, Lop, Khoa " +
                                "WHERE SinhVien.MSSV = @mssv AND SinhVien.ma_lop = Lop.ma_lop ";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            sv = new SinhVien
                            {
                                MSSV = reader["MSSV"].ToString(),
                                HoTen = reader["Ho_Ten"].ToString(),
                                GioiTinh = reader["Gioi_Tinh"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["Ngay_Sinh"]),
                                Email = reader["Email"].ToString(),
                                DiaChi = reader["Dia_Chi"].ToString(),
                                KhoaHoc = reader["Khoa_Hoc"].ToString(),
                                DiemRenLuyen = Convert.ToDouble(reader["Diem_Ren_Luyen"]),
                                MaLop = reader["Ma_Lop"].ToString()
                            };
                    }
                }

                return sv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Lấy điểm của sinh viên
        public DataTable GetStudentGradesDAL(string mssv)
        {
            try
            {
                var query = "SELECT Ten_Mon_Hoc, Diem_Qua_Trinh, Diem_Thi, Diem_Tong_Ket,Ma_Hoc_Ky " +
                            "\r\nFROM Diem, MonHoc WHERE Diem.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc" +
                            "\r\nAND Diem.MSSV = @mssv ";
                var parameters = new[]
                {
                    new SqlParameter("@mssv", mssv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy điểm sinh viên: " + ex.Message);
            }
        }

        //Lấy thời khóa biểu
        public DataTable GetStudentScheduleDAL(string mssv)
        {
            var query = "SELECT \r\n    " +
                "SinhVien.MSSV,\r\n   " +
                " LopMonHoc.Ma_Lop_Mon_Hoc,\r\n   " +
                " STRING_AGG" +
                "(\r\n        CONVERT(NVARCHAR, ThoiKhoaBieu.Ngay_Hoc, 103) +" +
                " ' (' + \r\n        CONVERT(NVARCHAR, ThoiKhoaBieu.Gio_Bat_Dau, 108) +" +
                " ' - ' + \r\n        CONVERT(NVARCHAR, ThoiKhoaBieu.Gio_Ket_Thuc, 108) + ')', \r\n        ', ')" +
                " AS Lich_Hoc\r\n" +
                "FROM \r\n    ThoiKhoaBieu\r\nJOIN \r\n " +
                "   LopMonHoc ON ThoiKhoaBieu.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc\r\n" +
                "JOIN \r\n    DangKy ON DangKy.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc \r\n" +
                "JOIN \r\n    SinhVien ON SinhVien.MSSV = DangKy.MSSV\r\n" +
                "GROUP BY \r\n    SinhVien.MSSV, LopMonHoc.Ma_Lop_Mon_Hoc\r\n" +
                "ORDER BY \r\n    SinhVien.MSSV, LopMonHoc.Ma_Lop_Mon_Hoc;";
            var parameters = new[]
            {
                new SqlParameter("@mssv", mssv)
            };
            return DBProviderDAL.GetDataTable(query, parameters);
        }

        //Đăng kí môn
        public bool RegisterCourseDAL(string mssv, string malopmonhoc, DateTime date)
        {
            var query = "INSERT INTO DangKy (MSSV, Ma_Lop_Mon_Hoc, Ngay_Dang_Ky) VALUES (@MSSV, @MaLop, @NgayDK)";
            date = DateTime.Today;
            SqlParameter[] parameters =
            {
                new SqlParameter("@MSSV", mssv),
                new SqlParameter("@MaLop", malopmonhoc),
                new SqlParameter("@NgayDK", date)
            };
            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        //Hủy đăng kí môn
        public bool UnregisterCourseDAL(string mssv, string malopmonhoc)
        {
            try
            {
                var query = "DELETE FROM DangKy " +
                            " WHERE @MSSV=mssv AND @malopmonhoc = Ma_Lop_Mon_Hoc";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@malopmonhoc", malopmonhoc)
                };
                return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Danh sách môn đã đăng kí của sinh viên
        public DataTable GetRegisteredCoursesDAL(string mssv)
        {
            try
            {
                var query = "SELECT DangKy.Ma_Lop_Mon_Hoc,Ten_Mon_Hoc,Ngay_Dang_Ky,So_Tin_Chi " +
                            "\r\nFROM DangKy,MonMoDangKy,LopMonHoc,MonHoc" +
                            "\r\nWHERE DangKy.Ma_Lop_Mon_Hoc=MonMoDangKy.Ma_Lop_Mon_Hoc " +
                            "\r\nAND MSSV=@mssv AND DangKy.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc" +
                            "\r\nAND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc ";
                var parameters = new[]
                {
                    new SqlParameter("@mssv", mssv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng ký môn học: " + ex.Message);
            }
        }

        //Danh sách môn học có thể đăng kí
        public DataTable GetAvailableCoursesDAL(string maHocKy)
        {
            try
            {
                var query = "SELECT\n    " +
                    "LopMonHoc.Ma_Lop_Mon_Hoc,MonHoc.Ma_Mon_Hoc,MonHoc.Ten_Mon_Hoc,\n " +
                    "   STRING_AGG(ThoiKhoaBieu.Ngay_Hoc + ' (' + CONVERT(VARCHAR, ThoiKhoaBieu.Gio_Bat_Dau, 8) " +
                    "+ ' - ' + CONVERT(VARCHAR, ThoiKhoaBieu.Gio_Ket_Thuc, 8) + ')', '; ') AS Lich_Hoc," +
                    "\n    MAX(ThoiKhoaBieu.Phong_Hoc) AS Phong_Hoc,\n  " +
                    "  MAX(MonHoc.So_Tin_Chi) AS So_Tin_Chi,\n" +
                    "    MAX(LopMonHoc.So_Luong_Dang_Ky_Toi_Da) AS So_Luong_Dang_Ky_Toi_Da,\n   " +
                    " (SELECT COUNT(*) \n" +
                    "     FROM DangKy\n    " +
                    " WHERE DangKy.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc) AS So_Luong_Da_Dang_Ky\n" +
                    "FROM\n" +
                    "    MonMoDangKy, LopMonHoc, MonHoc, ThoiKhoaBieu\n" +
                    "WHERE\n  " +
                    "  LopMonHoc.Ma_Hoc_Ky = @MaHocKy\n  " +
                    "  AND MonMoDangKy.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc\n   " +
                    " AND LopMonHoc.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc\n " +
                    "   AND ThoiKhoaBieu.Ma_Lop_Mon_Hoc = MonMoDangKy.Ma_Lop_Mon_Hoc\n" +
                    "GROUP BY\n  " +
                    "  LopMonHoc.Ma_Lop_Mon_Hoc, MonHoc.Ma_Mon_Hoc, MonHoc.Ten_Mon_Hoc\n" +
                    "ORDER BY\n    LopMonHoc.Ma_Lop_Mon_Hoc;";
                var sqlParameter = new[]
                {
                    new SqlParameter("@MaHocKy", maHocKy)
                };
                return DBProviderDAL.GetDataTable(query, sqlParameter);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách môn học đăng ký: " + ex.Message);
            }
        }

        //Lịch thi
        public DataTable GetExamScheduleDAL(string mssv)
        {
            try
            {
                var query = "SELECT DangKy.Ma_Lop_Mon_Hoc, Ten_Mon_Hoc,Ngay_Thi,Gio_Bat_Dau,Gio_Ket_Thuc,Phong_Thi " +
                            "FROM LichThi,DangKy ,MonHoc,LopMonHoc" +
                            "\r\nWHERE DangKy.Ma_Lop_Mon_Hoc=LichThi.Ma_Lop_Mon_Hoc AND DangKy.MSSV=@mssv " +
                            "\r\nAND LopMonHoc.Ma_Lop_Mon_Hoc=DangKy.Ma_Lop_Mon_Hoc AND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc";
                var parameters = new[]
                {
                    new SqlParameter("@mssv", mssv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách môn học đăng ký: " + ex.Message);
            }
        }

        //Lấy thông tin học kì

        public DataTable GetSemesterDAL()
        {
            try
            {
                var query = "select Ma_Hoc_Ky,Ten_Hoc_Ky from HocKy";
                return DBProviderDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách học kì: " + ex.Message);
            }
        }


        //Lưu ảnh

        public bool ChangeImageDAL(byte[] anh, string mssv)
        {
            var query = "UPDATE SinhVien SET Anh = @Anh WHERE MSSV = @MSSV";
            var parameters = new[]
            {
                new SqlParameter("@MSSV", mssv),
                new SqlParameter("@Anh", anh)
            };
            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
    }
}