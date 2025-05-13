using System.Collections.Generic;

namespace DOT
{
    public class TaiKhoan : IThucThe
    {
        public TaiKhoan()
        {
        }

        public TaiKhoan(string taiKhoan, string matKhau, int loaiTaiKhoan, int trangThai)
        {
            TenDangNhap = taiKhoan;
            this.MatKhau = matKhau;
            this.LoaiTaiKhoan = loaiTaiKhoan;
            this.TrangThai = trangThai;
        }

        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }

        public int LoaiTaiKhoan { get; set; }

        public int TrangThai { get; set; }


        public string LayTenThucThe()
        {
            return "Tài khoản";
        }

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
            {
                { "Tên đăng nhập ", TenDangNhap },
                { "Mật khẩu", MatKhau },
                { "Loại tài khoản", LoaiTaiKhoan },
                { "Trạng thái", TrangThai }
            };
        }
    }
}