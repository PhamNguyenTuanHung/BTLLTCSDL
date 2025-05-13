using System;
using System.Collections.Generic;

namespace DOT
{
    public class LichThi : IThucThe
    {
        public LichThi()
        {
        }

        public LichThi(string maLichThi, string maLopMonHoc, string maHocKy, DateTime ngayThi, TimeSpan gioBatDau,
            TimeSpan gioKetThuc, string phongThi)
        {
            this.MaLopMonHoc = maLopMonHoc;
            this.MaHocKy = maHocKy;
            this.NgayThi = ngayThi;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.PhongThi = phongThi;
            this.MaLichThi = maLichThi;
        }

        public LichThi(string maLopMonHoc, string maHocKy, DateTime ngayThi, TimeSpan gioBatDau, TimeSpan gioKetThuc,
            string phongThi)
        {
            this.MaLopMonHoc = maLopMonHoc;
            this.MaHocKy = maHocKy;
            this.NgayThi = ngayThi;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.PhongThi = phongThi;
        }

        public string MaLichThi { get; set; }

        public string MaLopMonHoc { get; set; }

        public string MaHocKy { get; set; }

        public DateTime NgayThi { get; set; }

        public TimeSpan GioBatDau { get; set; }

        public TimeSpan GioKetThuc { get; set; }

        public string PhongThi { get; set; }

        // Implement IThucThe
        public string LayTenThucThe()
        {
            return "Lịch thi";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "Mã lớp môn học", MaLopMonHoc },
                { "Mã học kỳ", MaHocKy },
                { "Ngày thi", NgayThi },
                { "Giờ bắt đầu", GioBatDau },
                { "Giờ kết thúc", GioKetThuc },
                { "Phòng thi", PhongThi }
            };
        }
    }
}