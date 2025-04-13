using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class TaiKhoan :IThucThe
    {
        private string tenDangNhap;
        private string matKhau;
        private int loaiTaiKhoan;
        private int trangThai;
        public TaiKhoan() { }
        public TaiKhoan(string taiKhoan, string matKhau, int loaiTaiKhoan, int trangThai)
        {
            this.tenDangNhap = taiKhoan;
            this.matKhau = matKhau;
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.trangThai = trangThai;
        }

        public string TenDangNhap { get=> this.tenDangNhap; set=> tenDangNhap =value; }
        public string MatKhau { get=>matKhau; set => matKhau =value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set =>loaiTaiKhoan=value; }

        public int TrangThai { get=>trangThai; set=>trangThai=value; }


        public string LayTenThucThe() => "Tài khoản";
        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Tên đăng nhập ", tenDangNhap  },
            { "Mật khẩu", matKhau },
            {"Loại tài khoản",loaiTaiKhoan },
                {"Trạng thái",trangThai }
        };
        }
    }
}
