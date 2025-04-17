using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class MonMoDangKy
    {

        public MonMoDangKy() { }
        string malopmo;
        string malopmonhoc;
        string mahocky;
        int soluongtoida;

        public string MaLopMo { get => malopmo; set => malopmo = value; }
        public string MaLopMonHoc { get => malopmonhoc; set => malopmonhoc = value; }
        public string MaHocKy { get => mahocky; set => mahocky = value; }
        public int SoLuongToiDa { get => soluongtoida; set => soluongtoida = value; }


        public MonMoDangKy( string malopmonhoc, string mahocky, int soluongtoida)
        {

            this.malopmonhoc = malopmonhoc;
            this.mahocky = mahocky;
            this.soluongtoida = soluongtoida;
        }

        public MonMoDangKy(string malopmo, string malopmonhoc, string mahocky, int soluongtoida)
        {
            this.malopmo = malopmo;
            this.malopmonhoc = malopmonhoc;
            this.mahocky = mahocky;
            this.soluongtoida = soluongtoida;
        }
    }
}
