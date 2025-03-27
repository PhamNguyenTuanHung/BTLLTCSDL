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
using DOT;

namespace PresentationLayer
{
    public partial class FormDangNhap : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBUS taikhoanBAL = new TaiKhoanBUS();
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

            taikhoan.User_name = txt_TaiKhoan.Text;
            taikhoan.Pass_word = txt_MatKhau.Text;

            TaiKhoan CheckLogin = taikhoanBAL.ValidateLoginBUS(taikhoan);
            if (CheckLogin == null)
            {
                MessageBox.Show("Thông tin tài khoản mật khẩu không chính xác");
                txt_MatKhau.Focus();
                return;
            }

            if (CheckLogin.Type==1)
            { 
                taikhoan.Type = 1;
                SinhVienBUS svBUS = new SinhVienBUS();
                SinhVien sv = svBUS.GetStudentDetailsBUS(txt_TaiKhoan.Text); 
                Form form = new FormSinhVien(sv,taikhoan);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }   
            
            if (CheckLogin.Type==2)
            {
                taikhoan.Type = 2;
                GiangVienBUS gvBUS = new GiangVienBUS();
                GiangVien gv = gvBUS.GetLecturerInfoBUS(txt_TaiKhoan.Text);
                Form form = new FormGiangVien(gv,taikhoan);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }    
            if (CheckLogin.Type==3)
            {
                return;
            }    
            
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void CheckBoxHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            txt_MatKhau.PasswordChar = CheckBoxHienThiMK.Checked ? '\0' : '*';
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            
            this.Hide();

            using (FormQuenMatKhau frm = new FormQuenMatKhau())
            {
                DialogResult result = frm.ShowDialog();

                if (result == DialogResult.Yes)  // Nếu thành công
                {
                    this.Show(); // Hiện lại form đăng nhập
                }
                else
                {
                    this.Close(); // Đóng ứng dụng
                }
            }

        }
    }
}
