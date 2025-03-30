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

        public MonHoc() { }

        public MonHoc(string mamonhoc, string tenmonhoc, int sotinchi)
        {
            this.mamonhoc = mamonhoc;
            this.tenmonhoc = tenmonhoc;
            this.sotinchi = sotinchi;
        }

        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public int SoTinChi { get => sotinchi; set => sotinchi = value; }


        public string LayTenThucThe() => "Môn Học";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Mã Môn Học", mamonhoc },
            { "Tên Môn Học", tenmonhoc },
            { "Số Tín Chỉ", sotinchi }
        };
        }
    }
}
