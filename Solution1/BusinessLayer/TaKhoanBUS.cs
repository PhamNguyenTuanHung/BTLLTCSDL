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

        public TaiKhoan ValidateLoginBUS(TaiKhoan TaiKhoan)
        {
            try
            {
                return taiKhoanDAl.ValidateLoginDAL(TaiKhoan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Business Layer khi kiểm tra đăng nhập: " + ex.Message);
            }
        }

        public bool CheckAccountExistsBUS(string taiKhoan)
        {
            try
            {
                return taiKhoanDAl.CheckAccountExistsDAL(taiKhoan);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAccountEmailBUS(string taiKhoan,int loaiTaiKhoan)
        {
            try
            {
                return taiKhoanDAl.GetAccountEmailDAL(taiKhoan, loaiTaiKhoan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangePasswordBUS(string taiKhoan,string matKhau)
        {
            try
            {
                return taiKhoanDAl.ChangePasswordDAL(taiKhoan, matKhau);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
