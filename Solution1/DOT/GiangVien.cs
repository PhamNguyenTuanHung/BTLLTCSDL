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

        public GiangVien(string msgv, string hotengv, string gioitinh, DateTime ngaysinh, string email, string malop, string diachi, string makhoa)
        {
            this.msgv = msgv;
            this.hotengv = hotengv;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.email = email;
            this.malop = malop;
            this.diachi = diachi;
            this.makhoa = makhoa;
        }

        string msgv;
        string hotengv;
        string gioitinh;
        DateTime ngaysinh;
        string email;
        string diachi;  
        string makhoa;
        string malop;

        public string MSGV { get => msgv; set => msgv = value; }
        public string HoTenGV { get => hotengv; set => hotengv = value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string MaLop { get => malop; set => malop = value; }
        public string MaKhoa { get => makhoa; set => makhoa = value; }


    }
}
