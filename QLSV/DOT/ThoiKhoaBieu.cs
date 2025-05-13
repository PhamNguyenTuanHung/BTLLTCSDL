using System;
using System.Collections.Generic;

namespace DOT
{
    public class ThoiKhoaBieu : IThucThe
    {
        public ThoiKhoaBieu()
        {
        }

        public ThoiKhoaBieu(string maLopMonHoc)
        {
            this.MaLopMonHoc = maLopMonHoc;
        }

        public ThoiKhoaBieu(string maLopMonHoc, string ngayHoc, TimeSpan gioBatDau, TimeSpan gioKetThuc,
            string phongHoc, DateTime ngayBD, DateTime ngayKT)
        {
            this.MaLopMonHoc = maLopMonHoc;
            this.NgayHoc = ngayHoc;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.PhongHoc = phongHoc;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
        }

        public ThoiKhoaBieu(int maTKB, string maLopMonHoc, string ngayHoc, TimeSpan gioBatDau, TimeSpan gioKetThuc,
            string phongHoc, DateTime ngayBD, DateTime ngayKT)
        {
            this.MaTKB = maTKB;
            this.MaLopMonHoc = maLopMonHoc;
            this.NgayHoc = ngayHoc;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.PhongHoc = phongHoc;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
        }

        public string MaLopMonHoc { get; set; }

        public string NgayHoc { get; set; }

        public TimeSpan GioBatDau { get; set; }

        public TimeSpan GioKetThuc { get; set; }

        public string PhongHoc { get; set; }

        public DateTime NgayBD { get; set; }

        public DateTime NgayKT { get; set; }

        public int MaTKB { get; set; }

        public string LayTenThucThe()
        {
            return "Thời Khóa Biểu";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "Mã TKB", MaTKB },
                { "Mã Lớp Môn Học", MaLopMonHoc },
                { "Ngày Học", NgayHoc },
                { "Giờ Bắt Đầu", GioBatDau },
                { "Giờ Kết Thúc", GioKetThuc },
                { "Phòng Học", PhongHoc },
                { "Ngày Bắt Đầu", NgayBD },
                { "Ngày Kết Thúc", NgayKT }
            };
        }
    }
}