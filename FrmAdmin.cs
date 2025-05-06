using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();

        }

        ucChucNangChung ucChucNangChung;
        Dictionary<string, ucChucNangChung> _tabCache;


        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            _tabCache = new Dictionary<string, ucChucNangChung>();
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.GradientActiveCaption;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("GiangVien");
        }
        public void LoadData(string tableName)
        {
            
            if (!_tabCache.TryGetValue(tableName, out ucChucNangChung))
            {
                ucChucNangChung = new ucChucNangChung(tableName);
                ucChucNangChung.Dock = DockStyle.Fill;
                _tabCache[tableName] = ucChucNangChung;
                ucChucNangChung.LoadData();
            }
            pHienThiForm.Controls.Clear();
            ucChucNangChung.Dock = DockStyle.Fill;
            pHienThiForm.Controls.Add(ucChucNangChung);
            ucChucNangChung.BringToFront();
        }
        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.GradientActiveCaption;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("GiangVien");
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.GradientActiveCaption;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("SinhVien");
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.GradientActiveCaption;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("Diem");
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.GradientActiveCaption;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("MonHoc");
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.GradientActiveCaption;
            LoadData("ThoiKhoaBieu");
        }

        private void btnLichThi_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.GradientActiveCaption;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("LichThi");
        }

        private void btnMonDangKy_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.GradientActiveCaption;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("MonMoDangKy");
        }

        private void btnLopMonHoc_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.GradientActiveCaption;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("LopMonHoc");
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.GradientActiveCaption;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("TaiKhoan");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form formLogin = new FormDangNhap();
            if (DialogResult.OK==MessageBox.Show("Bạn muốn đăng xuất","Đăng xuất",MessageBoxButtons.OKCancel))
            {
                this.Hide();
                formLogin.Show();
                formLogin.FormClosed += (s, args) => this.Close();
            }
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.Window;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.GradientActiveCaption;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("Lop");
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            btnSinhVien.BackColor = SystemColors.Window;
            btnGiangVien.BackColor = SystemColors.Window;
            btnDiem.BackColor = SystemColors.Window;
            btnKhoa.BackColor = SystemColors.GradientActiveCaption;
            btnMonDangKy.BackColor = SystemColors.Window;
            btnMonHoc.BackColor = SystemColors.Window;
            btnLopMonHoc.BackColor = SystemColors.Window;
            btnTaiKhoan.BackColor = SystemColors.Window;
            btnLop.BackColor = SystemColors.Window;
            btnLichThi.BackColor = SystemColors.Window;
            btnTKB.BackColor = SystemColors.Window;
            LoadData("Khoa");
        }
    }
}
