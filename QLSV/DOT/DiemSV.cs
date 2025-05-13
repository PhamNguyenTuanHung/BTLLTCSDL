using System.Collections.Generic;

namespace DOT
{
    public class DiemSV : IThucThe
    {
        public DiemSV()
        {
        }

        public DiemSV(string mssv, string mamonhoc, string mahocky, decimal diemquatrinh, decimal diemthi,
            decimal diemtongket, int lanthi)
        {
            this.MSSV = mssv;
            this.MaMonHoc = mamonhoc;
            this.MaHocKy = mahocky;
            this.DiemQuaTrinh = diemquatrinh;
            this.DiemThi = diemthi;
            this.LanThi = lanthi;
            this.DiemTongKet = diemtongket;
        }

        public DiemSV(string mssv, string mamonhoc, string mahocky, decimal diemquatrinh, decimal diemthi, int lanthi)
        {
            this.MSSV = mssv;
            this.MaMonHoc = mamonhoc;
            this.MaHocKy = mahocky;
            this.DiemQuaTrinh = diemquatrinh;
            this.DiemThi = diemthi;
            this.LanThi = lanthi;
        }


        public string MSSV { get; set; }

        public string MaHocKy { get; set; }

        public decimal DiemQuaTrinh { get; set; }

        public decimal DiemThi { get; set; }

        public decimal DiemTongKet { get; set; }

        public int LanThi { get; set; }

        public string MaMonHoc { get; set; }

        //Implement Interface
        public string LayTenThucThe()
        {
            return "Điểm";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "MSSV", MSSV },
                { "Mã Môn Học", MaMonHoc },
                { "Mã Học Kỳ", MaHocKy },
                { "Điểm Quá Trình", DiemQuaTrinh },
                { "Điểm Thi", DiemThi },
                { "Lần Thi", LanThi },
                { "Điểm Tổng Kết", DiemTongKet }
            };
        }
    }
}