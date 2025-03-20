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
        TaiKhoan_BUS taikhoanBAL = new TaiKhoan_BUS();
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

            TaiKhoan CheckLogin = taikhoanBAL.CheckLoginBAl(taikhoan);
            if (CheckLogin == null)
            {
                MessageBox.Show("Thông tin tài khoarn mật khẩu không chính xác");
                return;
            }

            if (CheckLogin.Type==1)
            { 
                SinhVien_BUS svBUS = new SinhVien_BUS();
                SinhVien sv = svBUS.ThongTinSinhVienBUS(txt_TaiKhoan.Text); 
                Form form = new FormSinhVien(sv,taikhoan);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }   
            
            if (CheckLogin.Type==2)
            {
                GiangVien_BUS gvBUS = new GiangVien_BUS();
                GiangVien gv = gvBUS.ThongTinGVBUS(txt_TaiKhoan.Text);
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
    }
}
