using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public  class Khoa
    {
        string maKhoa, tenKhoa;

        public Khoa() { }

        public Khoa(string maKhoa, string tenKhoa)
        {
            this.MaKhoa = maKhoa;
            this.TenKhoa = tenKhoa;
        }

        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }
    }
}
