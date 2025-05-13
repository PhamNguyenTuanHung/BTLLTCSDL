namespace DOT
{
    public class MonMoDangKy
    {
        public MonMoDangKy()
        {
        }


        public MonMoDangKy(string malopmonhoc, string mahocky)
        {
            this.MaLopMonHoc = malopmonhoc;
            this.MaHocKy = mahocky;
        }

        public MonMoDangKy(string malopmo, string malopmonhoc, string mahocky)
        {
            this.MaLopMo = malopmo;
            this.MaLopMonHoc = malopmonhoc;
            this.MaHocKy = mahocky;
        }

        public string MaLopMo { get; set; }

        public string MaLopMonHoc { get; set; }

        public string MaHocKy { get; set; }
    }
}