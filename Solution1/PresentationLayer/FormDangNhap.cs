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
        TaiKhoanBL taikhoanBL = new TaiKhoanBL();
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

            TaiKhoan CheckLogin = taikhoanBL.CheckLoginBl(taikhoan);
            if (CheckLogin == null)
            {
                MessageBox.Show("Thông tin tài khoarn mật khẩu không chính xác");
                return;
            }

            if (CheckLogin.Type==1)
            { 
                SinhVienBL svBL = new SinhVienBL();
                SinhVien sv = svBL.ThongTinSVBL(txt_TaiKhoan.Text); 
                Form form = new FormSV(sv);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }   
            
            if (CheckLogin.Type==2)
            {
                GiangVienBL giangvienBL = new GiangVienBL();
                GiangVien gv = giangvienBL.ThongTinGVBL(txt_TaiKhoan.Text);
                Form form = new FormGV(gv);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }    
            if (CheckLogin.Type==3)
            {
                return;
            }    
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kết nối");
        }
    }
}
