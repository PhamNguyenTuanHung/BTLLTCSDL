using System;
using System.Collections.Generic;

namespace DOT
{
    public class SinhVien : IThucThe
    {
        public SinhVien()
        {
        }

        public SinhVien(string mssv, string hotensv, string gioitinh, DateTime ngaysinh, string email, string diachi,
            string khoahoc, double drl, string malop, byte[] anh)
        {
            this.MSSV = mssv;
            HoTen = hotensv;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            Email = email;
            this.DiaChi = diachi;
            this.KhoaHoc = khoahoc;
            DiemRenLuyen = drl;
            this.MaLop = malop;
            this.Anh = anh;
        }


        public string MSSV { get; set; }

        public string HoTen { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string KhoaHoc { get; set; }

        public double DiemRenLuyen { get; set; }

        public string MaLop { get; set; }

        public byte[] Anh { get; set; }


        // Implement Interface
        public string LayTenThucThe()
        {
            return "Sinh viên";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "Mã SV", MSSV },
                { "Họ tên", HoTen },
                { "Giới tính", GioiTinh },
                { "Ngày sinh", NgaySinh.ToShortDateString() }, // Chuyển DateTime về string ngắn gọn
                { "Email", Email },
                { "Địa chỉ", DiaChi },
                { "Khóa học", KhoaHoc },
                { "Điểm rèn luyện", DiemRenLuyen },
                { "Mã lớp", MaLop },
                { "Ảnh", Anh }
            };
        }
    }
}