using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;

namespace BusinessLayer
{

    public class SinhVien_BUS
    {
        private SinhVien_DAL sinhvienDAL = new SinhVien_DAL();
        public SinhVien ThongTinSVBUS(string MSSV)
        {
            return sinhvienDAL.ThongTinSVDAL(MSSV);
        }
        public DataTable DiemSVBUS(string query)
        {
            return sinhvienDAL.DiemSVDAL(query);
        }

        public DataTable TKBSinhVienBUS(string query)
        {
            return sinhvienDAL.TKBSinhVienDAL(query);
        }

        public bool DangKyMonHocBUS(string mssv, string mamonhoc, DateTime date)
        {
            return sinhvienDAL.DangKyMonHocDAL(mssv, mamonhoc, date);
        }
    }
}
