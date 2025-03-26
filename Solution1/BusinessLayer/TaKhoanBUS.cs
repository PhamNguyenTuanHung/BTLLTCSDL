using System;
using System.CodeDom.Compiler;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class TaiKhoan_BUS
    {
        private TaiKhoan_DAl taiKhoanDAl = new TaiKhoan_DAl();

        public TaiKhoan KiemTraDangNhapBUS(TaiKhoan TaiKhoan)
        {
            try
            {
                return taiKhoanDAl.KiemTraDangNhapDAL(TaiKhoan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Business Layer khi kiểm tra đăng nhập: " + ex.Message);
            }
        }

        public bool KiemTraTonTaiTaiKhoanBUS(string taiKhoan)
        {
            try
            {
                return taiKhoanDAl.KiemTraTonTaiTaiKhoanDAl(taiKhoan);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string LayEmailCuaTaiKhoanBUS(string taiKhoan,int loaiTaiKhoan)
        {
            try
            {
                return taiKhoanDAl.LayEmailCuaTaiKhoanDAL(taiKhoan, loaiTaiKhoan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DoiMatKhauBUS(string taiKhoan,string matKhau)
        {
            try
            {
                return taiKhoanDAl.DoiMatKhauDAL(taiKhoan, matKhau);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
