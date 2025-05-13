namespace DOT
{
    public class Khoa
    {
        public Khoa()
        {
        }

        public Khoa(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }

        public string MaKhoa { get; set; }

        public string TenKhoa { get; set; }
    }
}