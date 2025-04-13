using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT
{
    public class SinhVien : IThucThe
    {
        public SinhVien() { }
        public SinhVien(string mssv, string hotensv, string gioitinh, DateTime ngaysinh, string email, string diachi, string khoahoc, double drl, string malop, byte[] anh)
        {
            this.mssv = mssv;
            this.hotensv = hotensv;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.Email = email;
            this.diachi = diachi;
            this.khoahoc = khoahoc;
            this.drl = drl;
            this.malop = malop;
            this.anh= anh;
        }

        private string mssv;
        private string hotensv;
        private string gioitinh;
        private DateTime ngaysinh ;
        private string email;
        private string diachi;
        private string khoahoc;
        private double drl;
        private string malop;
        private byte[] anh;


        public string MSSV { get=>mssv; set=>mssv=value ; }
        public string HoTenSV { get=>hotensv; set=>hotensv=value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string KhoaHoc { get => khoahoc; set => khoahoc = value; }
        public double DRL { get => drl; set => drl = value; }
        public string MaLop { get => malop; set => malop = value; }
        public byte[] Anh { get=>anh; set=>anh= value; }


        // Implement Interface
        public string LayTenThucThe() => "Sinh viên";

        public Dictionary<string, object> LayDuLieuThucThe()
        {
            return new Dictionary<string, object>
        {
            { "Mã SV", MSSV },
            { "Họ tên", HoTenSV },
            { "Giới tính", GioiTinh },
            { "Ngày sinh", NgaySinh.ToShortDateString() }, // Chuyển DateTime về string ngắn gọn
            { "Email", Email },
            { "Địa chỉ", DiaChi },
            { "Khóa học", KhoaHoc },
            { "Điểm rèn luyện", DRL },
            { "Mã lớp", MaLop },
            {"Ảnh",anh }
        };
        }
    }
}
