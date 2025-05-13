using System;
using System.Data;
using System.Data.SqlClient;
using DOT;

namespace DataLayer
{
    public class GiangVienDAL : TaiKhoanDAl
    {
        public GiangVien GetLecturerInfoDAL(string msgv)
        {
            {
                GiangVien gv = null;
                using (var conn = DBProviderDAL.Connect())
                {
                    var query = "SELECT GiangVien.* FROM GiangVien" +
                                " WHERE GiangVien.MSGV=@msgv ";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@msgv", msgv);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            gv = new GiangVien
                            {
                                MSGV = reader["MSGV"].ToString(),
                                HoTen = reader["Ho_Ten"].ToString(),
                                GioiTinh = reader["Gioi_Tinh"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["Ngay_Sinh"]),
                                Email = reader["Email"].ToString(),
                                DiaChi = reader["Dia_Chi"].ToString(),
                                MaKhoa = reader["Ma_Khoa"].ToString()
                            };
                    }
                }

                return gv;
            }
        }

        public DataTable GetLecturerInfoTableDAL(string msgv)
        {
            try
            {
                var query = "SELECT GiangVien.*,Lop.Ma_Lop FROM GiangVien,Lop" +
                                " WHERE GiangVien.MSGV=@msgv and GiangVien.MSGV=Lop.MSGVCN";
                var parameters = new[]
                {
                    new SqlParameter("@msgv", msgv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong ThongTinGVDAL: " + ex.Message, ex);
            }
        }

        public DataTable GetClassListDAl(string msgv)
        {
            try
            {
                var query = "SELECT Ma_Lop_Mon_Hoc,Ten_Mon_Hoc FROM LopMonHoc,MonHoc" +
                            "\r\nWHERE MSGV=@msgv AND LopMonHoc.Ma_Mon_Hoc= MonHoc.Ma_Mon_Hoc";
                var parameters = new[]
                {
                    new SqlParameter("@msgv", msgv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DanhSachLopHocDAL: " + ex.Message, ex);
            }
        }

        public DataTable GetLecturerScheduleDAL(string msgv)
        {
            try
            {
                var query = "\tSELECT \n    " +
                    "GiangVien.MSGV,\n   " +
                    " LopMonHoc.Ma_Lop_Mon_Hoc,\n   " +
                    " STRING_AGG(\nCONVERT(NVARCHAR, ThoiKhoaBieu.Ngay_Hoc, 103) +" +
                    " ' (' + \nCONVERT(NVARCHAR, ThoiKhoaBieu.Gio_Bat_Dau, 108) +" +
                    " ' - ' + \nCONVERT(NVARCHAR, ThoiKhoaBieu.Gio_Ket_Thuc, 108) + ')', \n  ', ') " +
                    "AS Lich_Hoc\n" +
                    "FROM  ThoiKhoaBieu\n" +
                    "JOIN LopMonHoc ON ThoiKhoaBieu.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc\n" +
                    "JOIN GiangVien ON GiangVien.MSGV = LopMonHoc.MSGV\n " +
                    "AND GiangVien.MSGV=@msgv " +
                    "GROUP BY GiangVien.MSGV, LopMonHoc.Ma_Lop_Mon_Hoc\n" +
                    "ORDER BY GiangVien.MSGV, LopMonHoc.Ma_Lop_Mon_Hoc;";
                var parameters = new[]
                {
                    new SqlParameter("@msgv", msgv)
                };
                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong TKBGiangVienDAL: " + ex.Message, ex);
            }
        }

        public DataTable GetStudentGradesDAL(string msgv, string malopmonhoc)
        {
            try
            {
                var query =
                    "SELECT Diem.MSSV, SinhVien.Ho_Ten, Diem_Qua_Trinh, Diem_Thi, Diem_Tong_Ket, Lan_Thi, Diem.Ma_Hoc_Ky, Diem.Ma_Mon_Hoc" +
                    "\r\nFROM SinhVien, Diem, LopMonHoc, DangKy, MonHoc" +
                    "\r\nWHERE SinhVien.MSSV = Diem.MSSV" +
                    "\r\nAND DangKy.MSSV = SinhVien.MSSV" +
                    "\r\nAND DangKy.Ma_Lop_Mon_Hoc = LopMonHoc.Ma_Lop_Mon_Hoc" +
                    "\r\nAND Diem.MSSV = DangKy.MSSV\r\nAND Diem.Ma_Mon_Hoc = LopMonHoc.Ma_Mon_Hoc" +
                    "\r\nAND LopMonHoc.MSGV = @msgv\r\nAND LopMonHoc.Ma_Lop_Mon_Hoc =@malopmonhoc " +
                    "\r\nAND MonHoc.Ma_Mon_Hoc = LopMonHoc.Ma_Mon_Hoc;";
                var parameters = new[]
                {
                    new SqlParameter("@msgv", msgv),
                    new SqlParameter("@malopmonhoc", malopmonhoc)
                };

                return DBProviderDAL.GetDataTable(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DanhSachDiemSVDAL: " + ex.Message, ex);
            }
        }

/*        public bool DoiMatKhauDAl(string msgv, string pass)
        {
            try
            {
                string query = "UPDATE TaiKhoan SET Mat_Khau=@pass WHERE Ten_Dang_Nhap=@msgv";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@pass",pass),
                    new SqlParameter("@msgv",msgv)
                };
                return DBConnect_DAL.ExecuteNonQuery(query, parameters)>0;

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DoiMatKhauDAl: " + ex.Message, ex);
            }
        }*/

        public bool UpdateStudentGradesDAL(string mssv, string malopmonhoc, double diemQT, double diemThi,
            double diemTK)
        {
            try
            {
                var query = "UPDATE Diem SET Diem_Qua_Trinh=@diemQT, Diem_Thi=@diemThi, Diem_Tong_Ket=@diemTK " +
                            "WHERE MSSV=@mssv " +
                            "AND Ma_Mon_Hoc = (SELECT Ma_Mon_Hoc FROM LopMonHoc WHERE Ma_Lop_Mon_Hoc = @malopmonhoc)";
                var parameters = new[]
                {
                    new SqlParameter("@mssv", mssv),
                    new SqlParameter("@malopmonhoc", malopmonhoc),
                    new SqlParameter("@diemQT", diemQT),
                    new SqlParameter("@diemThi", diemThi),
                    new SqlParameter("@diemTK", diemTK)
                };

                return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong SuaDiemSVDAL: " + ex.Message, ex);
            }
        }

        public bool ChangeImageDAL(byte[] anh, string msgv)
        {
            var query = "UPDATE GiangVien SET Anh = @Anh WHERE MSGV = @MSGV";
            var parameters = new[]
            {
                new SqlParameter("@MSGV", msgv),
                new SqlParameter("@Anh", anh)
            };
            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
    }
}