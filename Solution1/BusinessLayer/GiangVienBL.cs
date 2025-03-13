using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class GiangVienBL
    {
        GiangVienDL gvDL= new GiangVienDL();
        public GiangVien ThongTinGVBL(string msgv)
        {
            return gvDL.ThongTinGVDL(msgv);
        }

        public DataTable TKBGiangVienBL(string msgv)
        {
            return gvDL.TKBGiangVienDL(msgv);
        }

        public List<LopHoc> DanhSachLopHocBL(string msgv)
        {
            return gvDL.DanhSachLopHocDL(msgv);
        }

        public List<DiemSV> DanhSachDiemSVBL(string msgv,string mamonhoc)
        {
            return gvDL.DanhSachDiemSVDL(msgv, mamonhoc);
        }
    }
}
