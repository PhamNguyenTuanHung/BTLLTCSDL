using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;
namespace BusinessLayer
{
    public class TaiKhoanBL
    {
        TaiKhoanDl TaiKhoanDl = new TaiKhoanDl();
        public TaiKhoan CheckLoginBl(TaiKhoan TaiKhoan)
        {
            return TaiKhoanDl.CheckLoginDL(TaiKhoan);
        }
    }
}
