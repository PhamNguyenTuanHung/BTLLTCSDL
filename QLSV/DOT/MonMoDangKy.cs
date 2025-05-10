namespace DOT
{
    public class MonMoDangKy
    {

        public MonMoDangKy() { }
        string malopmo;
        string malopmonhoc;
        string mahocky;

        public string MaLopMo { get => malopmo; set => malopmo = value; }
        public string MaLopMonHoc { get => malopmonhoc; set => malopmonhoc = value; }
        public string MaHocKy { get => mahocky; set => mahocky = value; }


        public MonMoDangKy( string malopmonhoc, string mahocky)
        {
            this.malopmonhoc = malopmonhoc;
            this.mahocky = mahocky;
        }

        public MonMoDangKy(string malopmo, string malopmonhoc, string mahocky)
        {
            this.malopmo = malopmo;
            this.malopmonhoc = malopmonhoc;
            this.mahocky = mahocky;
        }
    }
}
