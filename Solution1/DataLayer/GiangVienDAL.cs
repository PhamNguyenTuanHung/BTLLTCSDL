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
                        NgaySinh = Convert.ToDateTime(reader["Ngay_Sinh"]), // Nếu có thể NULL, cần kiểm tra DBNull
                        DiaChi = reader["Dia_Chi"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        MaKhoa = reader["Ma_Khoa"].ToString()

                    };
                }
                reader.Close();
            }
            return gv;
        }
        public List<LopHoc> DanhSachLopHocDAL(string msgv)
        {
            List<LopHoc> ds = new List<LopHoc>();
            LopHoc lh = null;
            using (SqlConnection conn = DBConnect_DAL.Connect())
            {
                string query = "SELECT LopMonHoc.Ma_Mon_Hoc,Ten_Mon_Hoc,Ngay_Hoc,Gio_Bat_Dau,Gio_Ket_Thuc FROM DayMonHoc,LopMonHoc, MonHoc" +
                    "\r\nWHERE @msgv = DayMonHoc.MSGV AND DayMonHoc.Ma_Mon_Hoc=LopMonHoc.Ma_Mon_Hoc" +
                    "\r\nAND MonHoc.Ma_Mon_Hoc= LopMonHoc.Ma_Mon_Hoc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lh = new LopHoc()
                    {
                        MaMonHoc = reader["Ma_Mon_Hoc"].ToString(),
                        TenMonHoc = reader["Ten_Mon_Hoc"].ToString(),
                        NgayHoc = reader["Ngay_Hoc"].ToString(),
                        GioBatDau = TimeSpan.Parse(reader["Gio_Bat_Dau"].ToString()) ,
                        GioKetThuc = TimeSpan.Parse(reader["Gio_Ket_Thuc"].ToString())
                    };
                    ds.Add(lh);
                }
                reader.Close();
            }
             return ds;
        }
        public DataTable TKBGiangVienDAL(string msgv)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Ten_Mon_Hoc,Ngay_Hoc,Gio_Bat_Dau,Gio_Ket_Thuc FROM DayMonHoc,LopMonHoc, MonHoc "
                            + "WHERE DayMonHoc.MSGV = @msgv AND DayMonHoc.Ma_Mon_Hoc = LopMonHoc.Ma_Mon_Hoc "
                            + "AND MonHoc.Ma_Mon_Hoc = LopMonHoc.Ma_Mon_Hoc";
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

        public List<DiemSV> DanhSachDiemSVDAL(string msgv, string mamonhoc)
        {
            List<DiemSV> ds = new List<DiemSV>();
            DiemSV DiemSV = null;
            using (SqlConnection conn = DBConnect_DAL.Connect())
            {
                conn.Open();
                string query = "SELECT SinhVien.Ten_Day_Du,Diem.* " +
                    "\r\nFROM SinhVien, Diem, GiaoVien ,DangKy , DayMonHoc  " +
                    "\r\nWHERE SinhVien.MSSV = DangKy.MSSV " +
                    "\r\nAND  GiaoVien.MSGV = DayMonHoc.MSGV " +
                    "\r\nAND DangKy.Ma_Mon_Hoc = DayMonHoc.Ma_Mon_Hoc " +
                    "\r\nAND GiaoVien.MSGV=@msgv" +
                    "\r\nAND DayMonHoc.Ma_Mon_Hoc = @mamonhoc" +
                    "\r\nAND Diem.Ma_Mon_Hoc = @mamonhoc" +
                    "\r\nAND Diem.MSSV = SinhVien.MSSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
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
                return ds;
            }
        }
    }
}
