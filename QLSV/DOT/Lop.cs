using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class Lop
    {
        string maLop;
        string mSGVCN;
        string maKhoa;

        public Lop() { }

        public Lop(string maLop, string mSGVCN, string maKhoa)
        {
            this.maLop = maLop;
            this.mSGVCN = mSGVCN;
            this.maKhoa = maKhoa;
        }


        public string  MaLop {get => maLop; set => maLop = value; }

        public string MSGVCN { get => mSGVCN;set => mSGVCN = value; }
        public string MaKhoa { get=>maKhoa; set => maKhoa = value;}
    }
}
