using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class LopHoc
    {
        string malopmonhoc;
        string mamonhoc;
        string msgv;
        string mahocki;
        string makhoa;
        int sldangkytoida;

        public LopHoc() { }
        public LopHoc(string malopmonhoc, string mamonhoc, string msgv, string mahocki, string makhoa, int sldangkytoida)
        {
            this.malopmonhoc = malopmonhoc;
            this.mamonhoc = mamonhoc;
            this.msgv = msgv;
            this.mahocki = mahocki;
            this.makhoa = makhoa;
            this.sldangkytoida = sldangkytoida;
        }

        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string MaLopMonHoc { get => malopmonhoc; set => malopmonhoc = value; }
        public string MSGV { get => msgv; set => msgv = value; }
        public string MaHocKi { get => mahocki; set => mahocki = value; }
        public string MaKhoa { get => makhoa; set => makhoa = value; }

        public int SLDK { get => sldangkytoida;set => sldangkytoida = value;}


    }
}
