using System;
using System.Collections.Generic;

namespace DOT
{
    public class GiangVien : IThucThe
    {
        public GiangVien()
        {
        }

        public GiangVien(string msgv, string hotengv, string gioitinh, DateTime ngaysinh,  string diachi, string email,
            string makhoa, byte[] anh)
        {
            this.MSGV = msgv;
            this.HoTen = hotengv;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.Email = email;
            this.DiaChi = diachi;
            this.MaKhoa = makhoa;
            this.Anh = anh;
        }

        public string MSGV { get; set; }

        public string HoTen { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string MaKhoa { get; set; }

        public byte[] Anh { get; set; }

        // Implement Interface
        public string LayTenThucThe()
        {
            return "Giảng viên";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "MSGV", MSGV },
                { "Họ tên", HoTen },
                { "Giới tính", GioiTinh },
                { "Ngày sinh", NgaySinh },
                { "Email", Email },
                { "Địa chỉ", DiaChi },
                { "Mã khoa", MaKhoa },
                { "Ảnh", Anh }
            };
        }
    }
}