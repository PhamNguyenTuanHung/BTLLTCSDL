using System;
using System.Collections.Generic;
using System.Data;
using DataLayer;
using DOT;

namespace BusinessLayer
{
    public class GiangVien_BUS
    {
        private readonly GiangVien_DAL gvDAL = new GiangVien_DAL();

        public GiangVien ThongTinGVBUS(string msgv)
        {

            return gvDAL.ThongTinGiaoVienDAL(msgv);
        }

        public DataTable ThongTinGiaoVienBUS(string msgv)
        {
            return gvDAL.ThongTinGVDAL(msgv);
        }
        public DataTable TKBGiangVienBUS(string msgv)
        {
            return gvDAL.TKBGiangVienDAL(msgv) ;
        }

        public DataTable DanhSachLopHocBUS(string msgv)
        {
            try
            {
                return gvDAL.DanhSachLopHocDAL(msgv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DanhSachDiemSVBUS(string msgv, string mamonhoc)
        {
            try
            {
                return gvDAL.DanhSachDiemSVDAL(msgv, mamonhoc);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool DoiMatKhauBUS(string msgv, string pass)
        {
            try
            {
                return gvDAL.DoiMatKhauDAl(msgv, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public bool SuaDiemSVBUS(string mssv, string mamonhoc, double diemQT, double diemThi, double diemTK)
        {
            try
            {
                return gvDAL.SuaDiemSVDAL(mssv, mamonhoc,diemQT,diemThi,diemTK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
