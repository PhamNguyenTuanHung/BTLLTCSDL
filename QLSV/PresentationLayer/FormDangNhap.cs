using System;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormDangNhap : Form
    {
        private readonly TaiKhoan taikhoan = new TaiKhoan();
        private readonly TaiKhoanBUS taikhoanBAL = new TaiKhoanBUS();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (txt_TaiKhoan.Text == "")
            {
                MessageBox.Show("Nhập tài khoản");
                txt_TaiKhoan.Focus();
                return;
            }

            if (txt_MatKhau.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu");
                txt_MatKhau.Focus();
                return;
            }

            taikhoan.TenDangNhap = txt_TaiKhoan.Text;
            taikhoan.MatKhau = txt_MatKhau.Text;

            var CheckLogin = taikhoanBAL.ValidateLoginBUS(taikhoan);
            if (CheckLogin == null)
            {
                MessageBox.Show("Thông tin tài khoản mật khẩu không chính xác");
                txt_MatKhau.Focus();
                return;
            }

            if (CheckLogin.LoaiTaiKhoan == 1)
            {
                taikhoan.LoaiTaiKhoan = 1;
                var svBUS = new SinhVienBUS();
                var sv = svBUS.GetStudentDetailsBUS(txt_TaiKhoan.Text);
                FormSinhVien form = new FormSinhVien(sv, taikhoan);
                Hide();
                form.ShowDialog();
                Close();
            }

            if (CheckLogin.LoaiTaiKhoan == 2)
            {
                taikhoan.LoaiTaiKhoan = 2;

                GiangVienBUS gvBUS = new GiangVienBUS();
                GiangVien gv = gvBUS.GetLecturerInfoBUS(txt_TaiKhoan.Text);
                FormGiangVien formGiangVien = new FormGiangVien(gv, taikhoan);
                Hide();
                formGiangVien.ShowDialog();
                Close();
            }

            if (CheckLogin.LoaiTaiKhoan == 3)
            {
                taikhoan.LoaiTaiKhoan = 3;
                FrmAdmin formAdmin = new FrmAdmin();
                Hide();
                formAdmin.ShowDialog();
                Close();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes) Application.Exit();
        }

        private void CheckBoxHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            txt_MatKhau.PasswordChar = CheckBoxHienThiMK.Checked ? '\0' : '*';
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            Hide();

            using (var frm = new FormQuenMatKhau())
            {
                var result = frm.ShowDialog();

                if (result == DialogResult.Yes) // Nếu thành công
                    Show(); // Hiện lại form đăng nhập
                else
                    Close(); // Đóng ứng dụng
            }
        }
    }
}