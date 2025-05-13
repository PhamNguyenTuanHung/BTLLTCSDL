using System.Collections.Generic;

namespace DOT
{
    public class MonHoc : IThucThe
    {
        public MonHoc()
        {
        }

        public MonHoc(string mamonhoc, string tenmonhoc, int sotinchi, decimal hesoqt)
        {
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.SoTinChi = sotinchi;
            this.HeSoQT = hesoqt;
        }

        public string MaMonHoc { get; set; }

        public string TenMonHoc { get; set; }

        public int SoTinChi { get; set; }

        public decimal HeSoQT { get; set; }

        public string LayTenThucThe()
        {
            return "Môn Học";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "Hệ số quá trình", HeSoQT },
                { "Mã Môn Học", MaMonHoc },
                { "Tên Môn Học", TenMonHoc },
                { "Số Tín Chỉ", SoTinChi }
            };
        }
    }
}