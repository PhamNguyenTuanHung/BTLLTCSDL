using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class SinhVien_BUS
    {
        private SinhVien_DAL sinhvienDAL = new SinhVien_DAL();

        public DataTable ThongTinSVBUS(string MSSV)
        {
            try
            {
                return sinhvienDAL.ThongTinSVDAL(MSSV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SinhVien ThongTinSinhVienBUS(string MSSV)
        {
            try
            {
                return sinhvienDAL.ThongTinSinhVienDAL(MSSV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DiemSVBUS(string query)
        {
            try
            {
                return sinhvienDAL.DiemSVDAL(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy điểm sinh viên: " + ex.Message, ex);
            }
        }

        public DataTable TKBSinhVienBUS(string query)
        {
            try
            {
                return sinhvienDAL.TKBSinhVienDAL(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public bool DangKyMonHocBUS(string mssv, string mamonhoc, DateTime date)
        {
            try
            {
                return sinhvienDAL.DangKyMonHocDAL(mssv, mamonhoc, date);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng ký môn học: " + ex.Message, ex);
            }
        }

        public bool DoiMatKhauBUS(string mssv, string pass)
        {
            try
            {
                return sinhvienDAL.DoiMatKhauDAL(mssv, pass);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message, ex);
            }
        }

        
        public DataTable LichThiBUS(string mssv)
        {
            try
            {
                return sinhvienDAL.LichThiDAL(mssv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy lịch thi: " + ex.Message, ex);
            }
        }

        public DataTable DanhSachMonDangKiBUS()
        {
            try
            {
                return sinhvienDAL.DanhSachMonHocDangKiDAL();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy lịch thi: " + ex.Message, ex);
            }
        }
    }
}
