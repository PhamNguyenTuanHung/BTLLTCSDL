﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using DOT;

namespace DataLayer
{
    public class SinhVienDAL : TaiKhoanDAl
    {
        //Lấy thoog tin sinh viên
        public DataTable GetStudentInfoTableDAL(string mssv)
        {
            try
            {
                string query = "SELECT SinhVien.*, Khoa.Ten_Khoa FROM SinhVien, Lop, Khoa " +
                                   "WHERE SinhVien.MSSV = @mssv " +
                                   "AND SinhVien.ma_lop = Lop.ma_lop " +
                                   "AND Lop.Ma_Khoa = Khoa.Ma_Khoa";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mssv",mssv)
                };
                return  DBConnectDAL.GetDataTable(query,parameters);
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
                using (SqlConnection conn =DBConnectDAL.Connect())
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

        //Lấy điểm của sinh viên
        public DataTable GetStudentGradesDAL(string mssv)
        {
            try
            {
                string query = "SELECT Ten_Mon_Hoc, Diem_Qua_Trinh, Diem_Thi, Diem_Tong_Ket " +
                               "FROM Diem, MonHoc WHERE Diem.Ma_Mon_Hoc = MonHoc.Ma_Mon_Hoc " +
                               "AND Diem.MSSV = @mssv";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mssv",mssv)
                };
                return DBConnectDAL.GetDataTable(query,parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy điểm sinh viên: " + ex.Message);
            }
        }

        //Lấy thời khóa biểu
        public DataTable GetStudentScheduleDAL(string mssv)
        {
            try
            {
                string query = "SELECT ThoiKhoaBieu.Ma_Lop_Mon_Hoc,Ten_Mon_Hoc,Ten_Day_Du," +
                    "\r\nNgay_Hoc,Gio_Bat_Dau,Gio_Ket_Thuc,Phong_Hoc" +
                    "\r\nFROM DangKy,LopMonHoc,ThoiKhoaBieu,GiaoVien,MonHoc\r\n" +
                    "WHERE 'SV003'= DangKy.MSSV AND " +
                    "\r\nDangKy.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc\r\n" +
                    " AND ThoiKhoaBieu.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc\r\n" +
                    "AND LopMonHoc.MSGV=GiaoVien.MSGV\r\n" +
                    "AND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mssv",mssv)
                };
                return DBConnectDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Đăng kí môn
        public bool RegisterCourseDAL(string mssv, string malopmonhoc, DateTime date)
        {
            try
            {
                string query = "INSERT INTO DangKy (MSSV, Ma_Lop_Mon_Hoc, Ngay_Dang_Ky) VALUES (@MSSV, @MaLop, @NgayDK)";
                date = DateTime.Today;
                SqlParameter[] parameters = {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@MaLop", malopmonhoc),
                    new SqlParameter("@NgayDK", date)
                    };
                return DBConnectDAL.ExecuteNonQuery(query,parameters) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Hủy đăng kí môn
        public bool UnregisterCourseDAL(string mssv,string malopmonhoc)
        {
            try
            {
                string query = "DELETE FROM DangKy " +
                    " WHERE @MSSV=mssv AND @malopmonhoc = Ma_Lop_Mon_Hoc";
                SqlParameter[] parameters = {
                    new SqlParameter("@MSSV", mssv),
                    new SqlParameter("@malopmonhoc",malopmonhoc)
                    };
                return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Danh sách mônn đã đăng kí của sinh viên
        public DataTable GetRegisteredCoursesDAL(string mssv)
        {
            try
            {
                string query = "SELECT DangKy.Ma_Lop_Mon_Hoc,Ten_Mon_Hoc,Ngay_Dang_Ky,So_Tin_Chi " +
                    "\r\nFROM DangKy,LopMo,LopMonHoc,MonHoc" +
                    "\r\nWHERE DangKy.Ma_Lop_Mon_Hoc=LopMo.Ma_Lop_Mon_Hoc " +
                    "\r\nAND MSSV=@mssv AND DangKy.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc" +
                    "\r\nAND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc ";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mssv",mssv)
                };
                return DBConnectDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng ký môn học: " + ex.Message);
            }
        }

        //Danh sách môn học có thể đăng kí
        public DataTable GetAvailableCoursesDAL()
        {
            try
            {
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
                 return DBConnectDAL.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách môn học đăng ký: " + ex.Message);
            }
        }

        //ịch thi
        public DataTable GetExamScheduleDAL(string mssv)
        {
            try
            {
                string query = "SELECT DangKy.Ma_Lop_Mon_Hoc, Ten_Mon_Hoc,Ngay_Thi,Gio_Bat_Dau,Gio_Ket_Thuc,Phong_Thi " +
                    "FROM LichThi,DangKy ,MonHoc,LopMonHoc" +
                    "\r\nWHERE DangKy.Ma_Lop_Mon_Hoc=LichThi.Ma_Lop_Mon_Hoc AND DangKy.MSSV=@mssv " +
                    "\r\nAND LopMonHoc.Ma_Lop_Mon_Hoc=DangKy.Ma_Lop_Mon_Hoc AND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc";
                SqlParameter[] parameters = new SqlParameter[]
                                {
                    new SqlParameter("@mssv",mssv)
                                };
                return DBConnectDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách môn học đăng ký: " + ex.Message);
            }
        }
    }
}
