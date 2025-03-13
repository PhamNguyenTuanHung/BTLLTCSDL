using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class LopHoc
    {
        string mamonhoc;
        string tenmonhoc;
        string ngayhoc;
        TimeSpan giobatdau, gioketthuc;

        public LopHoc() { }
        public LopHoc(string mamonhoc,string tenmonhoc, string ngayhoc, TimeSpan giobatdau, TimeSpan gioketthuc)
        {
            this.mamonhoc = mamonhoc;
            this.tenmonhoc = tenmonhoc;
            this.ngayhoc = ngayhoc;
            this.giobatdau = giobatdau;
            this.gioketthuc = gioketthuc;
        }


        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }

        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public string NgayHoc { get => ngayhoc; set => ngayhoc = value; }
        public TimeSpan GioBatDau { get => giobatdau; set => giobatdau = value; }
        public TimeSpan GioKetThuc { get => gioketthuc; set => gioketthuc = value; }



    }
}
