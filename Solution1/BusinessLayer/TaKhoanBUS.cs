using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;
namespace BusinessLayer
{
    public class TaiKhoan_BUS
    {
        TaiKhoan_DAl TaiKhoanDAl = new TaiKhoan_DAl();
        public TaiKhoan CheckLoginBAl(TaiKhoan TaiKhoan)
        {
            return TaiKhoanDAl.CheckLoginDAL(TaiKhoan);
        }
    }
}
