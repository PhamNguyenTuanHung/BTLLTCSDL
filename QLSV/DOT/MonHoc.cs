using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class MonHoc : IThucThe
    {
        string mamonhoc;
        string tenmonhoc;
        int sotinchi;
        decimal hesoqt;

        public MonHoc() { }

        public MonHoc(string mamonhoc, string tenmonhoc, int sotinchi, decimal hesoqt)
        {
            this.mamonhoc = mamonhoc;
            this.tenmonhoc = tenmonhoc;
            this.sotinchi = sotinchi;
            this.hesoqt = hesoqt;
        }

        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public int SoTinChi { get => sotinchi; set => sotinchi = value; }
        
        public decimal HeSoQT { get=>hesoqt; set => hesoqt = value; }

        public string LayTenThucThe() => "Môn Học";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Hệ số quá trình", hesoqt },
            { "Mã Môn Học", mamonhoc },
            { "Tên Môn Học", tenmonhoc },
            { "Số Tín Chỉ", sotinchi }
        };
        }
    }
}
