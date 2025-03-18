using System;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class TaiKhoan_BUS
    {
        private TaiKhoan_DAl TaiKhoanDAl = new TaiKhoan_DAl();

        public TaiKhoan CheckLoginBAl(TaiKhoan TaiKhoan)
        {
            try
            {
                return TaiKhoanDAl.CheckLoginDAL(TaiKhoan);
            }
            catch (Exception ex)
            {
                // Xử lý hoặc log lỗi từ tầng DAL
                throw new Exception("Lỗi từ Business Layer khi kiểm tra đăng nhập: " + ex.Message);
            }
        }
    }
}
