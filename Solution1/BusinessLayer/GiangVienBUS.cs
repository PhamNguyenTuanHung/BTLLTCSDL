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
    public class GiangVien_BUS
    {
        GiangVien_DAL gvDL= new GiangVien_DAL();
        public GiangVien ThongTinGVBUS(string msgv)
        {
            return gvDL.ThongTinGVDAL(msgv);
        }

        public DataTable TKBGiangVienBUS(string msgv)
        {
            return gvDL.TKBGiangVienDAL(msgv);
        }

        public List<LopHoc> DanhSachLopHocBUS(string msgv)
        {
            return gvDL.DanhSachLopHocDAL(msgv);
        }

        public List<DiemSV> DanhSachDiemSVBUS(string msgv,string mamonhoc)
        {
            return gvDL.DanhSachDiemSVDAL(msgv, mamonhoc);
        }
    }
}
