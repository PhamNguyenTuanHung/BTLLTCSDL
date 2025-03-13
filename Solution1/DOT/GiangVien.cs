using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class GiangVien
    {
        public GiangVien() { }

        public GiangVien(string msgv, string hotengv, string gioitinh, DateTime ngaysinh, string email, string sdt, string diachi, string makhoa)
        {
            this.msgv = msgv;
            this.hotengv = hotengv;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.email = email;
            this.sdt = sdt;
            this.diachi = diachi;
            this.makhoa = makhoa;
        }

        string msgv;
        string hotengv;
        string gioitinh;
        DateTime ngaysinh;
        string email;
        string sdt;
        string diachi;  
        string makhoa;

        public string MSGV { get => msgv; set => msgv = value; }
        public string HoTenGV { get => hotengv; set => hotengv = value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string Email { get => email; set => email = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string MaKhoa { get => makhoa; set => makhoa = value; }
    }
}
