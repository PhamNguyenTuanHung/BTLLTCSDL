using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class GiangVien : IThucThe
    {
        public GiangVien() { }


        string msgv;
        string hoten;
        string gioitinh;
        DateTime ngaysinh;
        string email;
        string diachi;
        string makhoa;
        byte[] anh;
        public GiangVien(string msgv, string hotengv, string gioitinh, DateTime ngaysinh, string email, string diachi, string makhoa, byte[]anh)
        {
            this.msgv = msgv;
            this.hoten = hotengv;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.email = email;
            this.diachi = diachi;
            this.makhoa = makhoa;
            this.anh = anh;
        }

        public string MSGV { get => msgv; set => msgv = value; }
        public string HoTen { get => hoten; set =>hoten= value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string MaKhoa { get => makhoa; set => makhoa = value; }

        public byte[] Anh { get => anh; set => anh = value; }

        // Implement Interface
        public string LayTenThucThe() => "Giảng viên";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "MSGV", msgv },
            { "Họ tên", hoten },
            { "Giới tính", gioitinh },
            { "Ngày sinh", ngaysinh },
            { "Email", email },
            { "Địa chỉ", diachi },
            { "Mã khoa", makhoa },
            {"Ảnh",anh }
        };
        }


    }
}
