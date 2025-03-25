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
    public class GiangVien_DAL
    {
        public GiangVien ThongTinGiaoVienDAL(string msgv)
        {
            {
                GiangVien gv = null;
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    string query = "SELECT GiaoVien.*,Lop.Ma_Lop FROM GiaoVien,Lop" +
                        " WHERE Lop.MSGVCN=@msgv";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@msgv", msgv);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gv = new GiangVien()
                            {
                                MSGV = reader["MSGV"].ToString(),
                                HoTenGV = reader["Ten_Day_Du"].ToString(),
                                GioiTinh = reader["Gioi_Tinh"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["Ngay_Sinh"]),
                                Email = reader["Email"].ToString(),
                                DiaChi = reader["Dia_Chi"].ToString(),
                                MaKhoa = reader["Ma_Khoa"].ToString(),
                                MaLop = reader["Ma_Lop"].ToString()
                            };
                        }
                    }
                }
                return gv;
            }
        }
        public DataTable ThongTinGVDAL(string msgv)
        {
            try
            {
                string query = "SELECT GiaoVien.*,Lop.Ma_Lop FROM GiaoVien,Lop"
                    +" WHERE Lop.MSGVCN=@msgv";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@msgv",msgv)
                };
                return DBConnect_DAL.GetData(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong ThongTinGVDAL: " + ex.Message, ex);
            }
        }

        public DataTable DanhSachLopHocDAL(string msgv)
        {
            try
            {
                string query = "SELECT Ma_Lop_Mon_Hoc,Ten_Mon_Hoc FROM LopMonHoc,MonHoc" +
                    "\r\nWHERE MSGV=@msgv AND LopMonHoc.Ma_Mon_Hoc= MonHoc.Ma_Mon_Hoc";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@msgv",msgv)
                };
                return DBConnect_DAL.GetData(query, parameters);

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DanhSachLopHocDAL: " + ex.Message, ex);
            }
        }

        public DataTable TKBGiangVienDAL(string msgv)
        {
            try
            {
                string query = "SELECT LopMonHoc.Ma_Lop_Mon_Hoc,Ten_Mon_Hoc,Ngay_Hoc,Gio_Bat_Dau, Gio_Ket_Thuc" +
                    "\r\nFROM LopMonHoc,ThoiKhoaBieu,MonHoc" +
                    "\r\nWHERE LopMonHoc.MSGV=@msgv" +
                    "\r\nAND LopMonHoc.Ma_Lop_Mon_Hoc=ThoiKhoaBieu.Ma_Lop_Mon_Hoc" +
                    "\r\nAND LopMonHoc.Ma_Mon_Hoc=MonHoc.Ma_Mon_Hoc";
                SqlParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter ("@msgv",msgv)
                };
                return DBConnect_DAL.GetData (query, parameters);

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong TKBGiangVienDAL: " + ex.Message, ex);
            }
        }

        public DataTable DanhSachDiemSVDAL(string msgv, string malopmonhoc)
        {
            try
            {
                     string query = "SELECT Diem.MSSV,SinhVien.Ten_Day_Du,Diem_Qua_Trinh,Diem_Thi,Diem_Tong_Ket" +
                    "\r\nFROM SinhVien,Diem,LopMonHoc,DangKy,MonHoc" +
                    "\r\nWHERE SinhVien.MSSV=Diem.MSSV" +
                    "\r\nAND DangKy.MSSV=SinhVien.MSSV" +
                    "\r\nAND DangKy.Ma_Lop_Mon_Hoc=LopMonHoc.Ma_Lop_Mon_Hoc" +
                    "\r\nAND Diem.MSSV=DangKy.MSSV" +
                    "\r\nAND Diem.Ma_Mon_Hoc=LopMonHoc.Ma_Mon_Hoc" +
                    "\r\nand LopMonHoc.MSGV=@msgv" +
                    "\r\nand LopMonHoc.Ma_Lop_Mon_Hoc=@malopmonhoc" +
                    "\r\nAnd MonHoc.Ma_Mon_Hoc=LopMonHoc.Ma_Mon_Hoc"
                    ;
                SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@msgv",msgv),
                    new SqlParameter("@malopmonhoc",malopmonhoc)
                    };

                return DBConnect_DAL.GetData(query,parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DanhSachDiemSVDAL: " + ex.Message, ex);
            }
        }

        public bool DoiMatKhauDAl(string msgv, string pass)
        {
            try
            {
                string query = "UPDATE TaiKhoan SET Mat_Khau=@pass WHERE Ten_Dang_Nhap=@msgv";
                SqlParameter[] parameters = new SqlParameter[] 
                {
                    new SqlParameter("@pass",pass),
                    new SqlParameter("@msgv",msgv)
                };
                return DBConnect_DAL.ExecuteQuery(query, parameters)>0;

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DoiMatKhauDAl: " + ex.Message, ex);
            }
        }

        public bool SuaDiemSVDAL(string mssv, string malopmonhoc, double diemQT, double diemThi, double diemTK)
        {
            try
            {
                string query = "UPDATE Diem SET Diem_Qua_Trinh=@diemQT, Diem_Thi=@diemThi, Diem_Tong_Ket=@diemTK " +
                               "WHERE MSSV=@mssv " +
                               "AND Ma_Mon_Hoc= (SELECT Ma_Mon_Hoc FROM LopMonHoc WHERE Ma_Lop_Mon_Hoc = @malopmonhoc)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mssv", mssv),
                    new SqlParameter ("@malopmonhoc", malopmonhoc),
                    new SqlParameter("@diemQT", diemQT),
                    new SqlParameter("@diemThi", diemThi),
                    new SqlParameter("@diemTK", diemTK)
                };

                    return DBConnect_DAL.ExecuteQuery(query,parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong SuaDiemSVDAL: " + ex.Message, ex);
            }
        }
    }
}
