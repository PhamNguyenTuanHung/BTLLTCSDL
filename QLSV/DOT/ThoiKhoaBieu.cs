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
        private string maLopMonHoc;
        private string ngayHoc;
        private TimeSpan gioBatDau;
        private TimeSpan gioKetThuc;
        private string phongHoc;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private int  maTKB;

        public ThoiKhoaBieu() { }

        public ThoiKhoaBieu( string maLopMonHoc, string ngayHoc, TimeSpan gioBatDau, TimeSpan gioKetThuc, string phongHoc, DateTime ngayBD, DateTime ngayKT)
        {
            this.maLopMonHoc = maLopMonHoc;
            this.ngayHoc = ngayHoc;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
            this.phongHoc = phongHoc;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

        public ThoiKhoaBieu(int maTKB,string maLopMonHoc, string ngayHoc, TimeSpan gioBatDau, TimeSpan gioKetThuc, string phongHoc, DateTime ngayBD, DateTime ngayKT)
        {
            this.maTKB=maTKB;
            this.maLopMonHoc = maLopMonHoc;
            this.ngayHoc = ngayHoc;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
            this.phongHoc = phongHoc;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }
        public string MaLopMonHoc { get => maLopMonHoc; set => maLopMonHoc = value; }
        public string NgayHoc { get => ngayHoc; set => ngayHoc = value; }
        public TimeSpan GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public TimeSpan GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
        public string PhongHoc { get => phongHoc; set => phongHoc = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }

        public int MaTKB { get=>maTKB; set => maTKB = value; }
        public string LayTenThucThe() => "Thời Khóa Biểu";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Mã TKB",maTKB},
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
