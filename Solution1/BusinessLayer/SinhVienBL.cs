using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;

namespace BusinessLayer
{

    public class SinhVienBL
    {
        private SinhVienDL sinhvienDL = new SinhVienDL();
        public SinhVien ThongTinSVBL(string MSSV)
        {
            return sinhvienDL.ThongTinSVDL(MSSV);
        }
        public DataTable DiemSVBL(string query)
        {
            return sinhvienDL.DiemSVDL(query);
        }

        public DataTable TKBSinhVienBL(string query)
        {
            return sinhvienDL.TKBSinhVienDL(query);
        }
    }
}
