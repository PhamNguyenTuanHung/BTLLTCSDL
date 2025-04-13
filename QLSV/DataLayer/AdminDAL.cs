using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using DOT;
namespace DataLayer
{
    public class AdminDAL
    {
        //Lấy dữ liệu

        //Lấy danh sach bảng
        public List<string> GetTableNameDAL()
        {
            List<string> tableNames = new List<string>();

            string query = "SELECT TABLE_NAME " +
                "\r\nFROM INFORMATION_SCHEMA.TABLES " +
                "\r\nWHERE TABLE_TYPE = 'BASE TABLE';";

            using (SqlConnection conn = DBConnectDAL.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0)); // Lấy tên cột khóa chính
                        }
                    }
                }
            }
            return tableNames;
        }

        //Lấy khóa chính của các bảng
        public List<string> GetPrimaryKeysDAL(string tableName)
        {
            List<string> primaryKeys = new List<string>();

            string query = "SELECT kcu.COLUMN_NAME" +
                "\r\nFROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc" +
                "\r\nJOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu " +
                "\r\n    ON tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME" +
                "\r\nWHERE tc.TABLE_NAME = @tableName" +
                "\r\nAND tc.CONSTRAINT_TYPE = 'PRIMARY KEY';";

            using (SqlConnection conn = DBConnectDAL.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            primaryKeys.Add(reader.GetString(0)); // Lấy tên cột khóa chính
                        }
                    }
                }
            }
            return primaryKeys;
        }

        public List<string> GetForiegnKeysDAL(string tableName)
        {
            List<string> foreignKeys = new List<string>();
            string query = "SELECT kcu.COLUMN_NAME" +
                "\r\nFROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc" +
                "\r\nJOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu" +
                "\r\n    ON tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME" +
                "\r\nWHERE tc.TABLE_NAME = @tableName AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'";


            using (SqlConnection conn = DBConnectDAL.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số tableName vào câu truy vấn
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    conn.Open();

                    // Thực thi câu lệnh SQL động
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Đọc kết quả trả về
                        while (reader.Read())
                        {
                           foreignKeys.Add(reader.GetString(0)); // Lấy tên cột khóa ngoại  
                        }
                    }
                }
                
            }
            // Trả về danh sách các khóa ngoại
            return foreignKeys;
        }

        public List<string> GetForeignKeyValuesDAL(List<string> foreignKeys,string tableName)
        {
            List<string> foreignKeysData = new List<string>();
            using (SqlConnection conn = DBConnectDAL.Connect())
            {
                conn.Open();
                foreach (string col in foreignKeys)
                {
                    string colQuery = $"SELECT DISTINCT [{col}] FROM {tableName} WHERE [{col}] IS NOT NULL";
                    using (SqlCommand colCmd = new SqlCommand(colQuery, conn))
                    {
                        using (SqlDataReader colReader = colCmd.ExecuteReader())
                        {
                            while (colReader.Read())
                            {
                                // Làm gì đó với giá trị của cột khóa ngoại
                                string value = colReader[0].ToString();
                                foreignKeysData.Add(value);
                            }
                        }
                    }
                }

            }
            
            return foreignKeysData;
        }
        public DataTable GetLecturersListDAL()
        {

            string query = "SELECT * FROM GiangVien ";
            return DBConnectDAL.GetDataTable(query);

        }

        public DataTable GetStudentsListDAL()
        {

            string query = "SELECT * FROM SinhVien ";
            return DBConnectDAL.GetDataTable(query);

        }

        public DataTable GetSubjectsListDAL()
        {

            string query = "SELECT * FROM MonHoc ";
            return DBConnectDAL.GetDataTable(query);

        }

        public DataTable GetClassListDAL()
        {

            string query = "SELECT * FROM LopMonHoc ";
            return DBConnectDAL.GetDataTable(query);

        }

        public DataTable GetExamScheduleDAL()
        {

            string query = "SELECT * FROM LichThi ";
            return DBConnectDAL.GetDataTable(query);

        }

        public DataTable GetStudentGradesDAL()
        {

            string query = "SELECT * FROM Diem ";
            return DBConnectDAL.GetDataTable(query);


        }

        public DataTable GetScheduleDAL()
        {

            string query = "SELECT * FROM ThoiKhoaBieu";
            return DBConnectDAL.GetDataTable(query);

        }

        public DataTable GetAccountListsDAL()
        {
            string query = "SELECT * FROM TaiKhoan";
            return DBConnectDAL.GetDataTable(query);
        }

        //Các hàm thêm dữ liệu
        public bool InsertStudentDAL(SinhVien sv)
        {

            string query = "INSERT INTO SinhVien (MSSV, Ten_Day_Du, Gioi_Tinh, Ngay_Sinh, Email, Dia_Chi, Khoa_Hoc, Diem_Ren_Luyen, Ma_Lop) " +
                           "VALUES (@MSSV, @HoTenSV, @GioiTinh, @NgaySinh, @Email, @DiaChi, @KhoaHoc, @DRL, @MaLop)";

            SqlParameter[] parameters = {
            new SqlParameter("@MSSV", sv.MSSV),
            new SqlParameter("@HoTenSV", sv.HoTenSV),
            new SqlParameter("@GioiTinh", sv.GioiTinh),
            new SqlParameter("@NgaySinh", sv.NgaySinh),
            new SqlParameter("@Email", sv.Email),
            new SqlParameter("@DiaChi", sv.DiaChi),
            new SqlParameter("@KhoaHoc", sv.KhoaHoc),
            new SqlParameter("@DRL", sv.DRL),
            new SqlParameter("@MaLop", sv.MaLop)
        };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool InsertLecturerDAL(GiangVien gv)
        {
            string query = "INSERT INTO GiangVien (MSGV, Ho_Ten, Gioi_Tinh, Ngay_Sinh, Dia_Chi, Email, Ma_Khoa) " +
                           "VALUES (@MSGV, @HoTenGV, @GioiTinh, @NgaySinh, @DiaChi, @Email, @MaKhoa)";

            SqlParameter[] parameters = {
            new SqlParameter("@MSGV", gv.MSGV),
            new SqlParameter("@HoTenGV", gv.HoTen),
            new SqlParameter("@GioiTinh", gv.GioiTinh),
            new SqlParameter("@NgaySinh", gv.NgaySinh),
            new SqlParameter("@Email", gv.Email),
            new SqlParameter("@DiaChi", gv.DiaChi),
            new SqlParameter("@MaKhoa", gv.MaKhoa)
        };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool InsertCourseDAL(MonHoc mh)
        {

            string query = "INSERT INTO MonHoc (Ma_Mon_Hoc, Ten_Mon_Hoc, So_Tin_Chi) " +
                           "VALUES (@MaMonHoc, @TenMonHoc, @SoTinChi)";

            SqlParameter[] parameters = {
            new SqlParameter("@MaMonHoc", mh.MaMonHoc),
            new SqlParameter("@TenMonHoc", mh.TenMonHoc),
            new SqlParameter("@SoTinChi", mh.SoTinChi)
        };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;


        }

        public bool InsertCourseClassDAL(LopMonHoc lopMonHoc)
        {

            string query = "INSERT INTO LopMonHoc (Ma_Lop_Mon_Hoc, Ma_Mon_Hoc, MSGV, Ma_Hoc_Ky, Ma_Khoa, SL_Dang_Ky_Toi_Da) " +
                           "VALUES (@MaLopMonHoc, @MaMonHoc, @MSGV, @MaHocKi, @MaKhoa, @SLDangKyToiDa)";

            SqlParameter[] parameters = {
            new SqlParameter("@MaLopMonHoc", lopMonHoc.MaLopMonHoc),
            new SqlParameter("@MaMonHoc", lopMonHoc.MaMonHoc),
            new SqlParameter("@MSGV", lopMonHoc.MSGV),
            new SqlParameter("@MaHocKi", lopMonHoc.MaHocKi),
            new SqlParameter("@MaKhoa", lopMonHoc.MaKhoa),
            new SqlParameter("@SLDangKyToiDa", lopMonHoc.SLDK)
        };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;



        }

        public bool InsertGradeDAL(DiemSV diem)
        {

            string query = "INSERT INTO Diem (MSSV, MaMonHoc, MaHocKy, DiemQuaTrinh, DiemThi, LanThi, DiemTongKet) " +
                           "VALUES (@MSSV, @MaMonHoc, @MaHocKy, @DiemQuaTrinh, @DiemThi, @LanThi, @DiemTongKet)";

            SqlParameter[] parameters = {
            new SqlParameter("@MSSV", diem.MSSV),
            new SqlParameter("@MaMonHoc", diem.MaMonHoc),
            new SqlParameter("@MaHocKy", diem.MaHocKy),
            new SqlParameter("@DiemQuaTrinh", diem.DiemQuaTrinh),
            new SqlParameter("@DiemThi", diem.DiemThi),
            new SqlParameter("@LanThi", diem.LanThi),
            new SqlParameter("@DiemTongKet", diem.DiemTongKet)
        };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }


        public bool InsertScheduleDAL(ThoiKhoaBieu tkb)
        {

            string query = "INSERT INTO ThoiKhoaBieu (Ma_TKB, Ma_Lop_Mon_Hoc, Ngay_Hoc, Gio_Bat_Dau, Gio_Ket_Thuc, Phong_Hoc, Ngay_BD, Ngay_KT) " +
                           "VALUES (@MaTKB, @MaLopMonHoc, @NgayHoc, @GioBatDau, @GioKetThuc, @PhongHoc, @NgayBD, @NgayKT)";

            SqlParameter[] parameters = {
            new SqlParameter("@MaTKB", tkb.MaTKB),
            new SqlParameter("@MaLopMonHoc", tkb.MaLopMonHoc),
            new SqlParameter("@NgayHoc", tkb.NgayHoc),
            new SqlParameter("@GioBatDau", tkb.GioBatDau),
            new SqlParameter("@GioKetThuc", tkb.GioKetThuc),
            new SqlParameter("@PhongHoc", tkb.PhongHoc),
            new SqlParameter("@NgayBD", tkb.NgayBD),
            new SqlParameter("@NgayKT", tkb.NgayKT)
        };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;

        }

        public bool InsertExamScheduleDAL(LichThi lichThi)
        {

            string query = "INSERT INTO LichThi (Ma_Lich_Thi, Ma_Lop_Mon_Hoc, Ngay_Thi, Ma_Hoc_Ky, Gio_Bat_Dau, Gio_Ket_Thuc, Phong_Thi) " +
                           "VALUES (@MaLichThi, @MaLopMonHoc, @NgayThi, @MaHocKy, @GioBatDau, @GioKetThuc, @PhongThi)";

            SqlParameter[] parameters =
            {
                    new SqlParameter("@MaLichThi", lichThi.MaLichThi),
                    new SqlParameter("@MaLopMonHoc", lichThi.MaLopMonHoc),
                    new SqlParameter("@NgayThi", lichThi.NgayThi),
                    new SqlParameter("@PhongThi", lichThi.PhongThi),
                    new SqlParameter("@MaHocKy", lichThi.MaHocKy),
                    new SqlParameter("@GioBatDau", lichThi.GioBatDau),
                    new SqlParameter("@GioKetThuc", lichThi.GioKetThuc)
                };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;

        }

        public bool InsertAccountDAL(TaiKhoan taiKhoan)
        {
            if (taiKhoan == null) return false; // Kiểm tra null tránh lỗi

            string query = @"
        INSERT INTO TaiKhoan (Ten_Dang_Nhap, Mat_Khau, Loai_Tai_Khoan,Trang_Thai)
        VALUES (@tenDangNhap, @matKhau, @loaiTaiKhoan,@trangThai)";

            SqlParameter[] parameters = {
        new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap),
        new SqlParameter("@matKhau", taiKhoan.MatKhau),
        new SqlParameter("@loaiTaiKhoan", taiKhoan.LoaiTaiKhoan),
        new SqlParameter("@trangThai",taiKhoan.TrangThai)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }



        //Các hàm xóa
        public bool DeleteStudentDAL(string mssv)
        {
            string query = "DELETE FROM SinhVien WHERE MSSV = @MSSV";
            SqlParameter[] parameters = { new SqlParameter("@MSSV", mssv) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteLecturerDAL(string msgv)
        {
            string query = "DELETE FROM GiangVien WHERE MSGV = @MSGV";
            SqlParameter[] parameters = { new SqlParameter("@MSGV", msgv) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCourseDAL(string maMonHoc)
        {
            string query = "DELETE FROM MonHoc WHERE Ma_Mon_Hoc = @MaMonHoc";
            SqlParameter[] parameters = { new SqlParameter("@MaMonHoc", maMonHoc) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCourseClassDAL(string maLopMonHoc)
        {
            string query = "DELETE FROM LopMonHoc WHERE MaLopMonHoc = @MaLopMonHoc";
            SqlParameter[] parameters = { new SqlParameter("@MaLopMonHoc", maLopMonHoc) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteGradeDAL(string mssv, string maMonHoc, string maHocKy)
        {
            string query = "DELETE FROM Diem WHERE MSSV = @MSSV AND MaMonHoc = @MaMonHoc AND MaHocKy = @MaHocKy";
            SqlParameter[] parameters = {
        new SqlParameter("@MSSV", mssv),
        new SqlParameter("@MaMonHoc", maMonHoc),
        new SqlParameter("@MaHocKy", maHocKy)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteScheduleDAL(string maTKB)
        {
            string query = "DELETE FROM ThoiKhoaBieu WHERE Ma_TKB = @MaTKB";
            SqlParameter[] parameters = { new SqlParameter("@MaTKB", maTKB) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteExamScheduleDAL(string maLichThi)
        {
            string query = "DELETE FROM LichThi WHERE Ma_Lich_Thi = @MaLichThi";
            SqlParameter[] parameters = { new SqlParameter("@MaLichThi", maLichThi) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteAccountDAL(string tenDangNhap)
        {
            string query = "DELETE FROM TaiKhoan WHERE ten_Dang_Nhap = @tenDangNhap";
            SqlParameter[] parameters = { new SqlParameter("@tenDangNhap", tenDangNhap) };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        //Hàm cập nhật dữ liệu
        public bool UpdateStudentDAL(SinhVien sv)
        {
            string query = "UPDATE SinhVien " +
                           "SET Ten_Day_Du = @HoTenSV, Gioi_Tinh = @GioiTinh, Ngay_Sinh = @NgaySinh, " +
                           "Email = @Email, Dia_Chi = @DiaChi, Khoa_Hoc = @KhoaHoc, " +
                           "Diem_Ren_Luyen = @DRL, Ma_Lop = @MaLop " +
                           "WHERE MSSV = @MSSV"; // Điều kiện cập nhật theo MSSV (khóa chính)

            SqlParameter[] parameters = {
        new SqlParameter("@MSSV", sv.MSSV),
        new SqlParameter("@HoTenSV", sv.HoTenSV),
        new SqlParameter("@GioiTinh", sv.GioiTinh),
        new SqlParameter("@NgaySinh", sv.NgaySinh),
        new SqlParameter("@Email", sv.Email),
        new SqlParameter("@DiaChi", sv.DiaChi),
        new SqlParameter("@KhoaHoc", sv.KhoaHoc),
        new SqlParameter("@DRL", sv.DRL),
        new SqlParameter("@MaLop", sv.MaLop)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateLecturerDAL(GiangVien gv)
        {
            string query = "UPDATE GiangVien " +
                           "SET Ho_Ten = @HoTen, Gioi_Tinh = @GioiTinh, Ngay_Sinh = @NgaySinh, " +
                           "Dia_Chi = @DiaChi, Email = @Email, Ma_Khoa = @MaKhoa " +
                           "WHERE MSGV = @MSGV"; // Điều kiện cập nhật theo MSGV (khóa chính)

            SqlParameter[] parameters = {
            new SqlParameter("@MSGV", gv.MSGV),
            new SqlParameter("@HoTen", gv.HoTen),
            new SqlParameter("@GioiTinh", gv.GioiTinh),
            new SqlParameter("@NgaySinh", gv.NgaySinh),
            new SqlParameter("@DiaChi", gv.DiaChi),
            new SqlParameter("@Email", gv.Email),
            new SqlParameter("@MaKhoa", gv.MaKhoa)
            };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCourseDAL(MonHoc mh)
        {
            string query = "UPDATE MonHoc " +
                           "SET Ten_Mon_Hoc = @TenMonHoc, So_Tin_Chi = @SoTinChi " +
                           "WHERE Ma_Mon_Hoc = @MaMonHoc"; // Điều kiện cập nhật theo Ma_Mon_Hoc (khóa chính)

            SqlParameter[] parameters = {
        new SqlParameter("@MaMonHoc", mh.MaMonHoc),
        new SqlParameter("@TenMonHoc", mh.TenMonHoc),
        new SqlParameter("@SoTinChi", mh.SoTinChi)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCourseClassDAL(LopMonHoc lopMonHoc)
        {
            string query = "UPDATE LopMonHoc " +
                           "SET Ma_Mon_Hoc = @MaMonHoc, MSGV = @MSGV, Ma_Hoc_Ky = @MaHocKi, " +
                           "Ma_Khoa = @MaKhoa, SL_Dang_Ky_Toi_Da = @SLDangKyToiDa " +
                           "WHERE Ma_Lop_Mon_Hoc = @MaLopMonHoc"; // Điều kiện cập nhật theo Ma_Lop_Mon_Hoc (khóa chính)

            SqlParameter[] parameters = {
        new SqlParameter("@MaLopMonHoc", lopMonHoc.MaLopMonHoc),
        new SqlParameter("@MaMonHoc", lopMonHoc.MaMonHoc),
        new SqlParameter("@MSGV", lopMonHoc.MSGV),
        new SqlParameter("@MaHocKi", lopMonHoc.MaHocKi),
        new SqlParameter("@MaKhoa", lopMonHoc.MaKhoa),
        new SqlParameter("@SLDangKyToiDa", lopMonHoc.SLDK)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateGradeDAL(DiemSV diem)
        {
            string query = "UPDATE Diem " +
                           "SET Diem_Qua_Trinh = @DiemQuaTrinh, DiemThi = @DiemThi, " +
                           "Lan_Thi = @LanThi, Diem_Tong_Ket = @DiemTongKet " +
                           "WHERE MSSV = @MSSV AND Ma_Mon_Hoc = @MaMonHoc AND Ma_Hoc_Ky = @MaHocKy";

            SqlParameter[] parameters = {
        new SqlParameter("@MSSV", diem.MSSV),
        new SqlParameter("@MaMonHoc", diem.MaMonHoc),
        new SqlParameter("@MaHocKy", diem.MaHocKy),
        new SqlParameter("@DiemQuaTrinh", diem.DiemQuaTrinh),
        new SqlParameter("@DiemThi", diem.DiemThi),
        new SqlParameter("@LanThi", diem.LanThi),
        new SqlParameter("@DiemTongKet", diem.DiemTongKet)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateScheduleDAL(ThoiKhoaBieu tkb)
        {
            string query = "UPDATE ThoiKhoaBieu " +
                           "SET Ma_Lop_Mon_Hoc = @MaLopMonHoc, Ngay_Hoc = @NgayHoc, " +
                           "Gio_Bat_Dau = @GioBatDau, Gio_Ket_Thuc = @GioKetThuc, " +
                           "Phong_Hoc = @PhongHoc, Ngay_BD = @NgayBD, Ngay_KT = @NgayKT " +
                           "WHERE Ma_TKB = @MaTKB";

            SqlParameter[] parameters = {
        new SqlParameter("@MaTKB", tkb.MaTKB),
        new SqlParameter("@MaLopMonHoc", tkb.MaLopMonHoc),
        new SqlParameter("@NgayHoc", tkb.NgayHoc),
        new SqlParameter("@GioBatDau", tkb.GioBatDau),
        new SqlParameter("@GioKetThuc", tkb.GioKetThuc),
        new SqlParameter("@PhongHoc", tkb.PhongHoc),
        new SqlParameter("@NgayBD", tkb.NgayBD),
        new SqlParameter("@NgayKT", tkb.NgayKT)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateExamScheduleDAL(LichThi lichThi)
        {
            string query = "UPDATE LichThi " +
                           "SET Ma_Lop_Mon_Hoc = @MaLopMonHoc, Ngay_Thi = @NgayThi, " +
                           "Ma_Hoc_Ky = @MaHocKy, Gio_Bat_Dau = @GioBatDau, " +
                           "Gio_Ket_Thuc = @GioKetThuc, Phong_Thi = @PhongThi " +
                           "WHERE Ma_Lich_Thi = @MaLichThi";

            SqlParameter[] parameters =
            {
        new SqlParameter("@MaLichThi", lichThi.MaLichThi),
        new SqlParameter("@MaLopMonHoc", lichThi.MaLopMonHoc),
        new SqlParameter("@NgayThi", lichThi.NgayThi),
        new SqlParameter("@MaHocKy", lichThi.MaHocKy),
        new SqlParameter("@GioBatDau", lichThi.GioBatDau),
        new SqlParameter("@GioKetThuc", lichThi.GioKetThuc),
        new SqlParameter("@PhongThi", lichThi.PhongThi)
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }


        public bool UpdateAccountDAL(TaiKhoan taiKhoan)
        {
            string query = "UPDATE TaiKhoan" +
                "\r\nSET Mat_Khau=@matKhau , Loai_Tai_Khoan = @loaiTaiKhoan" +
                "\r\nWHERE Ten_Dang_Nhap = @tenDangNhap";

            SqlParameter[] parameters = {
        new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap),
        new SqlParameter("@matKhau", taiKhoan.MatKhau),
        new SqlParameter("@loaiTaiKhoan", taiKhoan.LoaiTaiKhoan),
    };

            return DBConnectDAL.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
