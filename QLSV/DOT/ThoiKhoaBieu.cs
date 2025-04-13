using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class ThoiKhoaBieu : IThucThe
    {
        private string maTKB;
        private string maLopMonHoc;
        private DateTime ngayHoc;
        private TimeSpan gioBatDau;
        private TimeSpan gioKetThuc;
        private string phongHoc;
        private DateTime ngayBD;
        private DateTime ngayKT;

        public ThoiKhoaBieu() { }

        public ThoiKhoaBieu(string maTKB, string maLopMonHoc, DateTime ngayHoc, TimeSpan gioBatDau, TimeSpan gioKetThuc, string phongHoc, DateTime ngayBD, DateTime ngayKT)
        {
            this.maTKB = maTKB;
            this.maLopMonHoc = maLopMonHoc;
            this.ngayHoc = ngayHoc;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
            this.phongHoc = phongHoc;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

        public string MaTKB { get => maTKB; set => maTKB = value; }
        public string MaLopMonHoc { get => maLopMonHoc; set => maLopMonHoc = value; }
        public DateTime NgayHoc { get => ngayHoc; set => ngayHoc = value; }
        public TimeSpan GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public TimeSpan GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
        public string PhongHoc { get => phongHoc; set => phongHoc = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }

        public string LayTenThucThe() => "Thời Khóa Biểu";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Mã TKB", maTKB },
            { "Mã Lớp Môn Học", maLopMonHoc },
            { "Ngày Học", ngayHoc },
            { "Giờ Bắt Đầu", gioBatDau },
            { "Giờ Kết Thúc", gioKetThuc },
            { "Phòng Học", phongHoc },
            { "Ngày Bắt Đầu", ngayBD },
            { "Ngày Kết Thúc", ngayKT }
        };
        }
    }

}
