using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class DiemSV : IThucThe
    {
        string mssv;
        string mamonhoc;
        string mahocky;
        double diemquatrinh;
        double diemthi;
        int lanthi;
        double diemtongket;

        public DiemSV() { }
        public DiemSV(string mssv, string mamonhoc, string mahocky, double diemquatrinh, double diemthi, int lanthi, double diemtongket)
        {
            this.mssv = mssv;
            this.mamonhoc = mamonhoc;
            this.mahocky = mahocky;
            this.diemquatrinh = diemquatrinh;
            this.diemthi = diemthi;
            this.lanthi = lanthi;
            this.diemtongket = diemtongket;
        }


        public string MSSV { get => mssv; set => mssv = value; }
        public string MaHocKy { get => mahocky; set => mahocky = value; }
        public double DiemQuaTrinh { get => diemquatrinh; set => diemquatrinh = value; }
        public double DiemThi { get => diemthi; set => diemthi = value; }
        public double DiemTongKet { get => diemtongket; set => diemtongket = value; }
        public int LanThi { get => lanthi; set => lanthi = value; }
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }

        //Implement Interface
        public string LayTenThucThe() => "Điểm";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "MSSV", mssv },
            { "Mã Môn Học", mamonhoc },
            { "Mã Học Kỳ", mahocky },
            { "Điểm Quá Trình", diemquatrinh },
            { "Điểm Thi", diemthi },
            { "Lần Thi", lanthi },
            { "Điểm Tổng Kết", diemtongket }
        };

        }
    }
}
