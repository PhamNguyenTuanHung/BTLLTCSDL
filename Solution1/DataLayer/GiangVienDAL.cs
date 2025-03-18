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
        public GiangVien ThongTinGVDAL(string msgv)
        {
            try
            {
                GiangVien gv = null;
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    string query = "SELECT * FROM GiaoVien WHERE MSGV = @msgv";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@msgv", msgv);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        gv = new GiangVien()
                        {
                            MSGV = reader["MSGV"].ToString(),
                            HoTenGV = reader["Ten_Day_Du"].ToString(),
                            GioiTinh = reader["Gioi_Tinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["Ngay_Sinh"]),
                            DiaChi = reader["Dia_Chi"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            MaKhoa = reader["Ma_Khoa"].ToString()
                        };
                    }
                    reader.Close();
                }
                return gv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong ThongTinGVDAL: " + ex.Message, ex);
            }
        }

        public List<LopHoc> DanhSachLopHocDAL(string msgv)
        {
            try
            {
                List<LopHoc> ds = new List<LopHoc>();
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    string query = "SELECT LopHocPhan.Ma_Mon_Hoc, Ten_Mon_Hoc, Ngay_Hoc, Gio_Bat_Dau, Gio_Ket_Thuc " +
                                   "FROM LopHocPhan, MonHoc WHERE LopHocPhan.MSGV=@msgv " +
                                   "AND MonHoc.Ma_Mon_Hoc= LopHocPhan.Ma_Mon_Hoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@msgv", msgv);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LopHoc lh = new LopHoc()
                        {
                            MaMonHoc = reader["Ma_Mon_Hoc"].ToString(),
                            TenMonHoc = reader["Ten_Mon_Hoc"].ToString(),
                            NgayHoc = reader["Ngay_Hoc"].ToString(),
                            GioBatDau = TimeSpan.Parse(reader["Gio_Bat_Dau"].ToString()),
                            GioKetThuc = TimeSpan.Parse(reader["Gio_Ket_Thuc"].ToString())
                        };
                        ds.Add(lh);
                    }
                    reader.Close();
                }
                return ds;
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
                DataTable dt = new DataTable();
                string query = "SELECT Ten_Mon_Hoc, Ngay_Hoc, Gio_Bat_Dau, Gio_Ket_Thuc " +
                               "FROM LopHocPhan, MonHoc WHERE LopHocPhan.MSGV = @msgv " +
                               "AND MonHoc.Ma_Mon_Hoc = LopHocPhan.Ma_Mon_Hoc";
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@msgv", msgv);
                    conn.Open();
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                    sqlAdapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong TKBGiangVienDAL: " + ex.Message, ex);
            }
        }

        public List<DiemSV> DanhSachDiemSVDAL(string msgv, string mamonhoc)
        {
            try
            {
                List<DiemSV> ds = new List<DiemSV>();
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    conn.Open();
                    string query = "SELECT SinhVien.Ten_Day_Du, Diem.* " +
                                   "FROM SinhVien, Diem, GiaoVien, DangKy " +
                                   "WHERE SinhVien.MSSV = DangKy.MSSV " +
                                   "AND GiaoVien.MSGV=@msgv " +
                                   "AND Diem.Ma_Mon_Hoc = @mamonhoc " +
                                   "AND Diem.MSSV = SinhVien.MSSV " +
                                   "AND DangKy.Ma_Mon_Hoc = Diem.Ma_Mon_Hoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@msgv", msgv);
                        cmd.Parameters.AddWithValue("@mamonhoc", mamonhoc);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DiemSV diemSV = new DiemSV()
                                {
                                    MSSV = reader["MSSV"].ToString(),
                                    DiemQuaTrinh = reader.IsDBNull(reader.GetOrdinal("Diem_Qua_Trinh")) ? 0 : reader.GetDouble(reader.GetOrdinal("Diem_Qua_Trinh")),
                                    DiemThi = reader.IsDBNull(reader.GetOrdinal("Diem_Thi")) ? 0 : reader.GetDouble(reader.GetOrdinal("Diem_Thi")),
                                    DiemTongKet = reader.IsDBNull(reader.GetOrdinal("Diem_Tong_Ket")) ? 0 : reader.GetDouble(reader.GetOrdinal("Diem_Tong_Ket")),
                                    LanThi = reader.GetInt32(reader.GetOrdinal("Lan_Thi")),
                                    TenDayDu = reader["Ten_Day_Du"].ToString()
                                };
                                ds.Add(diemSV);
                            }
                        }
                    }
                }
                return ds;
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
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@msgv", msgv);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong DoiMatKhauDAl: " + ex.Message, ex);
            }
        }

        public bool SuaDiemSVDAL(string mssv, string mamonhoc, float diemQT, float diemThi, float diemTK)
        {
            try
            {
                string query = "UPDATE Diem SET Diem_Qua_Trinh=@diemQT, Diem_Thi=@diemThi, Diem_Tong_Ket=@diemTK " +
                               "WHERE MSSV=@mssv AND Ma_Mon_Hoc=@mamonhoc";
                using (SqlConnection conn = DBConnect_DAL.Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@mamonhoc", mamonhoc);
                    cmd.Parameters.AddWithValue("@diemQT", diemQT);
                    cmd.Parameters.AddWithValue("@diemThi", diemThi);
                    cmd.Parameters.AddWithValue("@diemTK", diemTK);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong SuaDiemSVDAL: " + ex.Message, ex);
            }
        }
    }
}
