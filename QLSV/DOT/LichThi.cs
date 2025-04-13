using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class LichThi : IThucThe
    {
        private string maLichThi;
        private string maLopMonHoc;
        private string maHocKy;
        private DateTime ngayThi;
        private TimeSpan gioBatDau;
        private TimeSpan gioKetThuc;
        private string phongThi;

        public LichThi() { }

        public LichThi(string maLichThi, string maLopMonHoc, string maHocKy, DateTime ngayThi, TimeSpan gioBatDau, TimeSpan gioKetThuc, string phongThi)
        {
            this.maLichThi = maLichThi;
            this.maLopMonHoc = maLopMonHoc;
            this.maHocKy = maHocKy;
            this.ngayThi = ngayThi;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
            this.phongThi = phongThi;
        }

        public string MaLichThi { get => maLichThi; set => maLichThi = value; }
        public string MaLopMonHoc { get => maLopMonHoc; set => maLopMonHoc = value; }
        public string MaHocKy { get => maHocKy; set => maHocKy = value; }
        public DateTime NgayThi { get => ngayThi; set => ngayThi = value; }
        public TimeSpan GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public TimeSpan GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
        public string PhongThi { get => phongThi; set => phongThi = value; }

        // Implement IThucThe
        public string LayTenThucThe() => "Lịch thi";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Mã lịch thi", MaLichThi },
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
