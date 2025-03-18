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
            if (string.IsNullOrEmpty(msgv))
                throw new ArgumentException("MSGV không được để trống!");

            return gvDAL.ThongTinGVDAL(msgv) ?? throw new Exception("Không tìm thấy thông tin giảng viên!");
        }

        public DataTable TKBGiangVienBUS(string msgv)
        {
            if (string.IsNullOrEmpty(msgv))
                throw new ArgumentException("MSGV không được để trống!");

            return gvDAL.TKBGiangVienDAL(msgv) ?? throw new Exception("Không lấy được thời khóa biểu!");
        }

        public List<LopHoc> DanhSachLopHocBUS(string msgv)
        {
            if (string.IsNullOrEmpty(msgv))
                throw new ArgumentException("MSGV không được để trống!");

            var result = gvDAL.DanhSachLopHocDAL(msgv);
            if (result == null || result.Count == 0)
                throw new Exception("Không có lớp học nào!");
            return result;
        }

        public List<DiemSV> DanhSachDiemSVBUS(string msgv, string mamonhoc)
        {
            if (string.IsNullOrEmpty(msgv) || string.IsNullOrEmpty(mamonhoc))
                throw new ArgumentException("MSGV hoặc Mã môn học không được để trống!");

            var result = gvDAL.DanhSachDiemSVDAL(msgv, mamonhoc);
            if (result == null || result.Count == 0)
                throw new Exception("Không có danh sách điểm nào!");
            return result;
        }

        public bool DoiMatKhauBUS(string msgv, string pass)
        {
            if (string.IsNullOrEmpty(msgv) || string.IsNullOrEmpty(pass))
                throw new ArgumentException("MSGV hoặc mật khẩu không được để trống!");

            if (!gvDAL.DoiMatKhauDAl(msgv, pass))
                throw new Exception("Đổi mật khẩu thất bại!");
            return true;
        }

        public bool SuaDiemSVBUS(string mssv, string mamonhoc, float diemQT, float diemThi, float diemTK)
        {
            if (!gvDAL.SuaDiemSVDAL(mssv, mamonhoc, diemQT, diemThi, diemTK))
                throw new Exception("Cập nhật điểm sinh viên thất bại!");
            return true;
        }
    }
}
