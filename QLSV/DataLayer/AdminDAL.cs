using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            using (SqlConnection conn = DBProviderDAL.Connect())
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

            using (SqlConnection conn = DBProviderDAL.Connect())
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

        //Lấy khóa ngoại
        public List<string> GetForiegnKeysDAL(string tableName)
        {
            List<string> foreignKeys = new List<string>();
            string query = "SELECT kcu.COLUMN_NAME" +
                "\r\nFROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc" +
                "\r\nJOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu" +
                "\r\n    ON tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME" +
                "\r\nWHERE tc.TABLE_NAME = @tableName AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'";


            using (SqlConnection conn = DBProviderDAL.Connect())
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

        // Trả về cột khóa ngoại và bảng chưa nó
        // Lấy thông tin các khóa ngoại từ bảng nguồn
        public Dictionary<string, string> GetAllForeignKeysAndTables(string sourceTable)
        {
            string query = @"
            SELECT 
                c1.name AS ForeignKeyColumn,
                OBJECT_NAME(fk.referenced_object_id) AS ReferencedTable,
                c2.name AS ReferencedColumn
            FROM 
                sys.foreign_keys fk
            INNER JOIN 
                sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
            INNER JOIN 
                sys.columns c1 ON fkc.parent_object_id = c1.object_id AND fkc.parent_column_id = c1.column_id
            INNER JOIN 
                sys.columns c2 ON fkc.referenced_object_id = c2.object_id AND fkc.referenced_column_id = c2.column_id
            WHERE 
                OBJECT_NAME(fk.parent_object_id) = @SourceTable
            ";

            SqlParameter[] parameters = {
                new SqlParameter("@SourceTable", sourceTable)
            };

            DataTable dt = DBProviderDAL.GetDataTable(query, parameters);
            var result = new Dictionary<string, string>();

            foreach (DataRow row in dt.Rows)
            {
                string refCol = row["ReferencedColumn"].ToString();
                string refTable = row["ReferencedTable"].ToString();
                result[refCol] = refTable;
            }

            return result;
        }


        //trả về các giá trị của khóa ngoại trong bảng của nó (vd Ma_Khoa của bảng Khoa là khóa ngoại của bảng GV =>
        //lấy các giá trị Ma_Khoa của bảng Khoa)
         // Lấy các giá trị của khóa ngoại từ bảng
        public List<string> GetForeignKeyValues(string fkColumn, string sourceTable)
        {
            List<string> foreignKeyValues = new List<string>();
            string query = $"SELECT DISTINCT [{fkColumn}] FROM [{sourceTable}] WHERE [{fkColumn}] IS NOT NULL";
        

            DataTable dt = DBProviderDAL.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                string value = row[fkColumn].ToString();
                foreignKeyValues.Add(value);
            }

            return foreignKeyValues;
        }



        // Hàm kết hợp kết quả từ GetAllForeignKeysAndTables và GetForeignKeyValuesDAL
        public Dictionary<string, List<string>> GetForeignKeyValuesWithReferencedTablesDAL(string sourceTable)
        {
            // 1. Lấy thông tin tất cả khóa ngoại và bảng tham chiếu
            Dictionary<string,string> foreignKeysAndTables = GetAllForeignKeysAndTables(sourceTable);
            if (foreignKeysAndTables.Count == 0) return null;

            // 2. Tạo dictionary kết quả để lưu thông tin khóa ngoại và các giá trị tương ứng.
            Dictionary<string,List<string>> result = new Dictionary<string, List<string>>();

            // 3. Lặp qua từng khóa ngoại và lấy các giá trị tương ứng
            foreach (var fk in foreignKeysAndTables)
            {
                string fkColumn = fk.Key;  // Cột khóa ngoại
                string referencedTable = fk.Value;  // Bảng tham chiếu
                // 4. Lấy giá trị của cột khóa ngoại từ bảng nguồn
                List<string> foreignKeyValues = GetForeignKeyValues(fkColumn, referencedTable);
                foreach (string str in foreignKeyValues)
                {
                    Console.Write(str + " ");
                }
                    Console.WriteLine();
                // 5. Thêm vào kết quả nếu có giá trị.
                result[fkColumn] = foreignKeyValues;
            }

            // 6. Trả về kết quả
            return result;
        }



        public DataTable GetAllRegisteredCoursesDAL()
        {
            string query = "SELECT * FROM MonMoDangKy";
            return DBProviderDAL.GetDataTable(query);
        }


        //Lấy danh sách Giảng viên
        public DataTable GetLecturersListDAL()
        {

            string query = "SELECT * FROM GiangVien ";
            return DBProviderDAL.GetDataTable(query);

        }

        //Lấy danh sách sinh viên
        public DataTable GetStudentsListDAL()
        {

            string query = "SELECT * FROM SinhVien ";
            return DBProviderDAL.GetDataTable(query);

        }

        //Lấy danh sách môn học
        public DataTable GetSubjectsListDAL()
        {

            string query = "SELECT * FROM MonHoc ";
            return DBProviderDAL.GetDataTable(query);

        }
        //Lấy danh sách lớp môn học
        public DataTable GetClassListDAL()
        {

            string query = "SELECT * FROM LopMonHoc ";
            return DBProviderDAL.GetDataTable(query);

        }
        //Lấy danh sách lịch thi
        public DataTable GetExamScheduleDAL()
        {

            string query = "SELECT * FROM LichThi ";
            return DBProviderDAL.GetDataTable(query);

        }
        //Lấy danh sách điểm của các sinh viên
        public DataTable GetStudentGradesDAL()
        {

            string query = "SELECT * FROM Diem ";
            return DBProviderDAL.GetDataTable(query);


        }
        //Lấy thời khóa biểu
        public DataTable GetScheduleDAL()
        {

            string query = "SELECT * FROM ThoiKhoaBieu";
            return DBProviderDAL.GetDataTable(query);

        }
        //Danh sách tài khoản
        public DataTable GetAccountListsDAL()
        {
            string query = "SELECT * FROM TaiKhoan";
            return DBProviderDAL.GetDataTable(query);
        }

        public DataTable GetClassDAL()
        {
            string query = "SELECT * FROM Lop";

            return DBProviderDAL.GetDataTable(query);
        }

        public DataTable GetDepartmentsDAL()
        {
            string query = "SELECT * FROM Khoa";

            return DBProviderDAL.GetDataTable(query);
        }
        //Các hàm thêm dữ liệu

        public bool InsertClassDAL(Lop lop)
        { 
            string query = "INSERT INTO Lop " +
                            "VALUES (@MaLop,@MSGVCN,@MaKhoa )";
            SqlParameter[] parameters = {
             new SqlParameter("@MaLop", lop.MaLop),
            new SqlParameter("@MSGVCN", lop.MSGVCN),
            new SqlParameter("@MaKhoa", lop.MaKhoa)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool InsertDepartmentDAL(Khoa khoa)
        {
            string query = "INSERT INTO Khoa " +
                            "VALUES (@MaKhoa,@TenKhoa )";
            SqlParameter[] parameters = {
            new SqlParameter("@MaKhoa", khoa.MaKhoa),
            new SqlParameter("@TenKhoa",khoa.TenKhoa)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }


        public bool InsertCourseForRegistrationDAL(MonMoDangKy monMoDangKy)
        {
            string query = "INSERT INTO MonMoDangKy (Ma_Lop_Mon_Hoc,Ma_Hoc_Ky)  " +
                           "VALUES (@MaLopMonHoc,@MaHocKy)";

            SqlParameter[] parameters = {
             new SqlParameter("@MaLopMonHoc", monMoDangKy.MaLopMonHoc),
            new SqlParameter("@MaHocKy", monMoDangKy.MaHocKy)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }


        public bool InsertStudentDAL(SinhVien sv)
        {
            
            string query = "INSERT INTO SinhVien " +
                           "VALUES (@MSSV, @HoTenSV, @GioiTinh, @NgaySinh, @Email, @DiaChi, @KhoaHoc, @DRL, @MaLop,@Anh)";

            SqlParameter[] parameters = {
            new SqlParameter("@MSSV", sv.MSSV),
            new SqlParameter("@HoTenSV", sv.HoTen),
            new SqlParameter("@GioiTinh", sv.GioiTinh),
            new SqlParameter("@NgaySinh", sv.NgaySinh),
            new SqlParameter("@Email", sv.Email),
            new SqlParameter("@DiaChi", sv.DiaChi),
            new SqlParameter("@KhoaHoc", sv.KhoaHoc),
            new SqlParameter("@DRL", sv.DiemRenLuyen),
            new SqlParameter("@MaLop", sv.MaLop),
            new SqlParameter("@Anh", SqlDbType.VarBinary) { Value = sv.Anh ?? (object)DBNull.Value } // Chuyển ảnh thành DBNull nếu null
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
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

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
        public bool InsertCourseDAL(MonHoc mh)
        {

            string query = "INSERT INTO MonHoc (Ma_Mon_Hoc, Ten_Mon_Hoc, So_Tin_Chi,He_So_QT) " +
                           "VALUES (@MaMonHoc, @TenMonHoc, @SoTinChi,@HeSoQT)";

            SqlParameter[] parameters = {
            new SqlParameter("@MaMonHoc", mh.MaMonHoc),
            new SqlParameter("@TenMonHoc", mh.TenMonHoc),
            new SqlParameter("@SoTinChi", mh.SoTinChi),
            new SqlParameter("@HeSoQT",mh.HeSoQT)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;


        }
        public bool InsertCourseClassDAL(LopMonHoc lopMonHoc)
        {

            string query = "INSERT INTO LopMonHoc (Ma_Lop_Mon_Hoc, Ma_Mon_Hoc, MSGV, Ma_Hoc_Ky, Ma_Khoa, So_Luong_Dang_Ky_Toi_Da) " +
                           "VALUES (@MaLopMonHoc, @MaMonHoc, @MSGV, @MaHocKi, @MaKhoa, @SLDangKyToiDa)";

            SqlParameter[] parameters = {
            new SqlParameter("@MaLopMonHoc", lopMonHoc.MaLopMonHoc),
            new SqlParameter("@MaMonHoc", lopMonHoc.MaMonHoc),
            new SqlParameter("@MSGV", lopMonHoc.MSGV),
            new SqlParameter("@MaHocKi", lopMonHoc.MaHocKi),
            new SqlParameter("@MaKhoa", lopMonHoc.MaKhoa),
            new SqlParameter("@SLDangKyToiDa", lopMonHoc.SoLuongDangKyToiDa)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;



        }
        public bool InsertGradeDAL(DiemSV diem)
        {

            string query = "INSERT INTO Diem (MSSV, Ma_Mon_Hoc, Ma_Hoc_Ky, Diem_Qua_Trinh, Diem_Thi, Lan_Thi) " +
                           "VALUES (@MSSV, @MaMonHoc, @MaHocKy, @DiemQuaTrinh, @DiemThi, @LanThi)";

            SqlParameter[] parameters = {
            new SqlParameter("@MSSV", diem.MSSV),
            new SqlParameter("@MaMonHoc", diem.MaMonHoc),
            new SqlParameter("@MaHocKy", diem.MaHocKy),
            new SqlParameter("@DiemQuaTrinh", diem.DiemQuaTrinh),
            new SqlParameter("@DiemThi", diem.DiemThi),
            new SqlParameter("@LanThi", diem.LanThi)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
        public bool InsertScheduleDAL(ThoiKhoaBieu tkb)
        {

            string query = "INSERT INTO ThoiKhoaBieu ( Ma_Lop_Mon_Hoc, Ngay_Hoc, Gio_Bat_Dau, Gio_Ket_Thuc, Phong_Hoc, Ngay_BD, Ngay_KT) " +
                           "VALUES ( @MaLopMonHoc, @NgayHoc, @GioBatDau, @GioKetThuc, @PhongHoc, @NgayBD, @NgayKT)";

            SqlParameter[] parameters = {
            new SqlParameter("@MaLopMonHoc", tkb.MaLopMonHoc),
            new SqlParameter("@NgayHoc", tkb.NgayHoc),
            new SqlParameter("@GioBatDau", tkb.GioBatDau),
            new SqlParameter("@GioKetThuc", tkb.GioKetThuc),
            new SqlParameter("@PhongHoc", tkb.PhongHoc),
            new SqlParameter("@NgayBD", tkb.NgayBD),
            new SqlParameter("@NgayKT", tkb.NgayKT)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;

        }
        public bool InsertExamScheduleDAL(LichThi lichThi)
        {

            string query = "INSERT INTO LichThi ( Ma_Lop_Mon_Hoc, Ngay_Thi, Ma_Hoc_Ky, Gio_Bat_Dau, Gio_Ket_Thuc, Phong_Thi) " +
                           "VALUES ( @MaLopMonHoc, @NgayThi, @MaHocKy, @GioBatDau, @GioKetThuc, @PhongThi)";

            SqlParameter[] parameters =
            {
                    new SqlParameter("@MaLopMonHoc", lichThi.MaLopMonHoc),
                    new SqlParameter("@NgayThi", lichThi.NgayThi),
                    new SqlParameter("@PhongThi", lichThi.PhongThi),
                    new SqlParameter("@MaHocKy", lichThi.MaHocKy),
                    new SqlParameter("@GioBatDau", lichThi.GioBatDau),
                    new SqlParameter("@GioKetThuc", lichThi.GioKetThuc)
                };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;

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

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }



        //Các hàm xóa

        public bool DeleteDepartmentDAL(string maKhoa)
        {
            string query = "DELETE FROM Khoa " +
                           "WHERE  @MaKhoa=Ma_Khoa";
            SqlParameter[] parameters = {
            new SqlParameter("@MaKhoa", maKhoa)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteClassDAL(string maLop)
        {
            string query = "DELETE FROM Lop " +
                            "WHERE @MaLop = Ma_Lop";
            SqlParameter[] parameters = {
             new SqlParameter("@MaLop", maLop)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCourseFromRegistrationDAL(string maLopMo)
        {
            string query = "DELETE FROM MonMoDangKy " +
                           "WHERE Ma_Lop_Mo = @MaLopMo";

            SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLopMo", maLopMo)
                };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
        public bool DeleteStudentDAL(string mssv)
        {
            string query = "DELETE FROM SinhVien WHERE MSSV = @MSSV";
            SqlParameter[] parameters = { new SqlParameter("@MSSV", mssv) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteLecturerDAL(string msgv)
        {
            string query = "DELETE FROM GiangVien WHERE MSGV = @MSGV";
            SqlParameter[] parameters = { new SqlParameter("@MSGV", msgv) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCourseDAL(string maMonHoc)
        {
            string query = "DELETE FROM MonHoc WHERE Ma_Mon_Hoc = @MaMonHoc";
            SqlParameter[] parameters = { new SqlParameter("@MaMonHoc", maMonHoc) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCourseClassDAL(string maLopMonHoc)
        {
            string query = "DELETE FROM LopMonHoc WHERE Ma_Lop_Mon_Hoc = @MaLopMonHoc";
            SqlParameter[] parameters = { new SqlParameter("@MaLopMonHoc", maLopMonHoc) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteGradeDAL(string mssv, string maMonHoc, string maHocKy)
        {
            string query = "DELETE FROM Diem WHERE MSSV = @MSSV AND MaMonHoc = @MaMonHoc AND MaHocKy = @MaHocKy";
            SqlParameter[] parameters = {
        new SqlParameter("@MSSV", mssv),
        new SqlParameter("@MaMonHoc", maMonHoc),
        new SqlParameter("@MaHocKy", maHocKy)
    };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteScheduleDAL(string maTKB)
        {
            string query = "DELETE FROM ThoiKhoaBieu WHERE Ma_TKB = @MaTKB";
            SqlParameter[] parameters = { new SqlParameter("@MaTKB", maTKB) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteExamScheduleDAL(string maLichThi)
        {
            string query = "DELETE FROM LichThi WHERE Ma_Lich_Thi = @MaLichThi";
            SqlParameter[] parameters = { new SqlParameter("@MaLichThi", maLichThi) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteAccountDAL(string tenDangNhap)
        {
            string query = "DELETE FROM TaiKhoan WHERE ten_Dang_Nhap = @tenDangNhap";
            SqlParameter[] parameters = { new SqlParameter("@tenDangNhap", tenDangNhap) };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        //Hàm cập nhật dữ liệu

        public bool UpdateDepartmentDAL(Khoa khoa)
        {
            string query = "UPDATE Khoa " +
                            "SET Ten_Khoa = @TenKhoa " +
                            "WHERE Ma_Khoa = @MaKhoa";
            SqlParameter[] parameters = {
            new SqlParameter("@MaKhoa", khoa.MaKhoa),
            new SqlParameter("@TenKhoa",khoa.TenKhoa)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateClassDAL(Lop lop)
        {
            string query = "UPDATE  Lop " +
                            "SET  MSGVCN=@MSGVCN,Ma_Khoa = @MaKhoa " +
                            "WHERE @MaLop= Ma_Lop"
                            ;
            SqlParameter[] parameters = {
             new SqlParameter("@MaLop", lop.MaLop),
            new SqlParameter("@MSGVCN", lop.MSGVCN),
            new SqlParameter("@MaKhoa", lop.MaKhoa)
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCourseFromRegistrationDAL(MonMoDangKy monMoDangKy)
        {
            string query = "Update  MonMoDangKy " +
                           "SET  Ma_Lop_Mon_Hoc = @MaLopMonHoc, Ma_Hoc_Ky = @MaHocKi" +
                           "WHERE Ma_Lop_Mo=@MaLopMo";
            
            SqlParameter[] parameters = {
            new SqlParameter("@MaLopMo", monMoDangKy.MaLopMo),
            new SqlParameter("@MaLopMonHoc", monMoDangKy.MaLopMonHoc),
            new SqlParameter("@MaHocKi", monMoDangKy.MaHocKy),
        };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateStudentDAL(SinhVien sv)
        {
            string query = "UPDATE SinhVien " +
                           "SET Ho_Ten = @HoTenSV, Gioi_Tinh = @GioiTinh, Ngay_Sinh = @NgaySinh, " +
                           "Email = @Email, Dia_Chi = @DiaChi, Khoa_Hoc = @KhoaHoc, " +
                           "Diem_Ren_Luyen = @DRL, Ma_Lop = @MaLop , Anh=@Anh " +
                           "WHERE MSSV = @MSSV"; // Điều kiện cập nhật theo MSSV (khóa chính)

            SqlParameter[] parameters = {
        new SqlParameter("@MSSV", sv.MSSV),
        new SqlParameter("@HoTenSV", sv.HoTen),
        new SqlParameter("@GioiTinh", sv.GioiTinh),
        new SqlParameter("@NgaySinh", sv.NgaySinh),
        new SqlParameter("@Email", sv.Email),
        new SqlParameter("@DiaChi", sv.DiaChi),
        new SqlParameter("@KhoaHoc", sv.KhoaHoc),
        new SqlParameter("@DRL", sv.DiemRenLuyen),
        new SqlParameter("@MaLop", sv.MaLop),
        new SqlParameter("@Anh", SqlDbType.VarBinary) { Value = sv.Anh ?? (object)DBNull.Value } // Chuyển ảnh thành DBNull nếu null
    };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateLecturerDAL(GiangVien gv)
        {
            string query = "UPDATE GiangVien " +
                           "SET Ho_Ten = @HoTen, Gioi_Tinh = @GioiTinh, Ngay_Sinh = @NgaySinh, " +
                           "Dia_Chi = @DiaChi, Email = @Email, Ma_Khoa = @MaKhoa , ANh= @Anh " +
                           "WHERE MSGV = @MSGV"; // Điều kiện cập nhật theo MSGV (khóa chính)

            SqlParameter[] parameters = {
            new SqlParameter("@MSGV", gv.MSGV),
            new SqlParameter("@HoTen", gv.HoTen),
            new SqlParameter("@GioiTinh", gv.GioiTinh),
            new SqlParameter("@NgaySinh", gv.NgaySinh),
            new SqlParameter("@DiaChi", gv.DiaChi),
            new SqlParameter("@Email", gv.Email),
            new SqlParameter("@MaKhoa", gv.MaKhoa),
            new SqlParameter("@Anh", gv.Anh)
            };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCourseDAL(MonHoc mh)
        {
            string query = "UPDATE MonHoc " +
                           "SET Ten_Mon_Hoc = @TenMonHoc, So_Tin_Chi = @SoTinChi , He_So_QT=@HeSoQT " +
                           "WHERE Ma_Mon_Hoc = @MaMonHoc"; // Điều kiện cập nhật theo Ma_Mon_Hoc (khóa chính)

            SqlParameter[] parameters = {
        new SqlParameter("@MaMonHoc", mh.MaMonHoc),
        new SqlParameter("@TenMonHoc", mh.TenMonHoc),
        new SqlParameter("@SoTinChi", mh.SoTinChi),
        new SqlParameter("HeSoQT",mh.HeSoQT)
    };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCourseClassDAL(LopMonHoc lopMonHoc)
        {
            string query = "UPDATE LopMonHoc " +
                           "SET Ma_Mon_Hoc = @MaMonHoc, MSGV = @MSGV, Ma_Hoc_Ky = @MaHocKi, " +
                           "Ma_Khoa = @MaKhoa, So_Luong_Dang_Ky_Toi_Da = @SLDangKyToiDa " +
                           "WHERE Ma_Lop_Mon_Hoc = @MaLopMonHoc"; // Điều kiện cập nhật theo Ma_Lop_Mon_Hoc (khóa chính)

            SqlParameter[] parameters = {
        new SqlParameter("@MaLopMonHoc", lopMonHoc.MaLopMonHoc),
        new SqlParameter("@MaMonHoc", lopMonHoc.MaMonHoc),
        new SqlParameter("@MSGV", lopMonHoc.MSGV),
        new SqlParameter("@MaHocKi", lopMonHoc.MaHocKi),
        new SqlParameter("@MaKhoa", lopMonHoc.MaKhoa),
        new SqlParameter("@SLDangKyToiDa", lopMonHoc.SoLuongDangKyToiDa)
    };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateGradeDAL(DiemSV diem)
        {
            string query = "UPDATE DIEM" +
                "\r\n SET Diem_Qua_Trinh=@DiemQuaTrinh,Diem_Thi=@DiemThi " +
                "\r\n WHERE  Lan_Thi=@LanThi AND MSSV=@MSSV  AND  Ma_Mon_Hoc=@MaMonHoc AND Ma_Hoc_Ky=@MaHocKy";

            SqlParameter[] parameters = {
        new SqlParameter("@MSSV", diem.MSSV),
        new SqlParameter("@MaMonHoc", diem.MaMonHoc),
        new SqlParameter("@MaHocKy", diem.MaHocKy),
        new SqlParameter("@DiemQuaTrinh", diem.DiemQuaTrinh),
        new SqlParameter("@DiemThi", diem.DiemThi),
        new SqlParameter("@LanThi", diem.LanThi),
    };

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
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

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
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

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
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

            return DBProviderDAL.MyExecuteNonQuery(query, parameters) > 0;
        }
    }
}
