using System.Collections.Generic;

namespace DOT
{
    public class LopMonHoc : IThucThe
    {
        public LopMonHoc()
        {
        }

        public LopMonHoc(string malopmonhoc, string mamonhoc, string msgv, string mahocky, string makhoa,
            int sldangkytoida)
        {
            this.MaLopMonHoc = malopmonhoc;
            this.MaMonHoc = mamonhoc;
            this.MSGV = msgv;
            this.MaHocKy = mahocky;
            this.MaKhoa = makhoa;
            SoLuongDangKyToiDa = sldangkytoida;
        }

        public string MaMonHoc { get; set; }

        public string MaLopMonHoc { get; set; }

        public string MSGV { get; set; }

        public string MaHocKy { get; set; }

        public string MaKhoa { get; set; }

        public int SoLuongDangKyToiDa { get; set; }

        //Implement Interface
        public string LayTenThucThe()
        {
            return "Lớp Môn Học";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "Mã Lớp Môn Học", MaLopMonHoc },
                { "Mã Môn Học", MaMonHoc },
                { "Mã Giảng Viên", MSGV },
                { "Mã Học Kỳ", MaHocKy },
                { "Mã Khoa", MaKhoa },
                { "Số Lượng Đăng Kí Tối Đa", SoLuongDangKyToiDa }
            };
        }
    }
}