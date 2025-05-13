namespace DOT
{
    public class Lop
    {
        public Lop()
        {
        }

        public Lop(string maLop, string mSGVCN, string maKhoa)
        {
            this.MaLop = maLop;
            this.MSGVCN = mSGVCN;
            this.MaKhoa = maKhoa;
        }


        public string MaLop { get; set; }

        public string MSGVCN { get; set; }

        public string MaKhoa { get; set; }
    }
}