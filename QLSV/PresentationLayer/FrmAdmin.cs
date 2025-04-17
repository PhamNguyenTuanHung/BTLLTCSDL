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
            LoadData("GiangVien");
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            LoadData("SinhVien");
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            LoadData("Diem");
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            LoadData("MonHoc");
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            LoadData("ThoiKhoaBieu");
        }

        private void btnLichThi_Click(object sender, EventArgs e)
        {
            LoadData("LichThi");
        }

        private void btnMonDangKy_Click(object sender, EventArgs e)
        {
            LoadData("MonMoDangKy");
        }

        private void btnLopMonHoc_Click(object sender, EventArgs e)
        {
            LoadData("LopMonHoc");
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
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
    }
}
