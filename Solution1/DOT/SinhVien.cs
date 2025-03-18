using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class SinhVien
    {
        public SinhVien() { }

        public SinhVien(string mssv, string hotensv, string gioitinh, DateTime ngaysinh, string email, string sdt, string diachi, string khoahoc, double drl, string malop)
        {
            this.mssv = mssv;
            this.hotensv = hotensv;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.Email = email;
            this.SDT = sdt;
            this.diachi = diachi;
            this.khoahoc = khoahoc;
            this.drl = drl;
            this.malop = malop;
        }

        private string mssv;
        private string hotensv;
        private string gioitinh;
        private DateTime ngaysinh ;
        private string email;
        private string sdt;
        private string diachi;
        private string khoahoc;
        private double drl;
        private string malop;


        public string MSSV { get=>mssv; set=>mssv=value ; }
        public string HoTenSV { get=>hotensv; set=>hotensv=value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string Email { get => email; set => email = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string KhoaHoc { get => khoahoc; set => khoahoc = value; }
        public double DRL { get => drl; set => drl = value; }
        public string MaLop { get => malop; set => malop = value; }
    }
}
