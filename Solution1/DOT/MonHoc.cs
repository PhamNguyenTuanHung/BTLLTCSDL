using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class MonHoc
    {
        private string mamonhoc;
        string tenmonhoc;
        int sotinchi;

        public MonHoc() { }

        public MonHoc(string mamonhoc, string tenmonhoc, int sotinchi)
        {
            this.Mamonhoc = mamonhoc;
            this.Tenmonhoc = tenmonhoc;
            this.Sotinchi = sotinchi;
        }

        public string Mamonhoc { get => mamonhoc; set => mamonhoc = value; }
        public string Tenmonhoc { get => tenmonhoc; set => tenmonhoc = value; }
        public int Sotinchi { get => sotinchi; set => sotinchi = value; }
    }
}
