using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormDoiMatKhau : Form
    {
        private SinhVien sv;
        private TaiKhoan tk;
        private GiangVien gv;
        public string newPass;
        public FormDoiMatKhau(TaiKhoan tk)
        {
            this.tk = tk;
            InitializeComponent();
            label1.Visible = false;

            txtOldPass.Visible = false;
            txtOldPass.Text=tk.MatKhau;
        }
        public FormDoiMatKhau(SinhVien sv, TaiKhoan tk)
        {
            this.sv = sv;
            this.tk = tk;
            InitializeComponent();
        }

        public FormDoiMatKhau(GiangVien gv, TaiKhoan tk)
        {
            this.gv = gv;
            this.tk = tk;
            InitializeComponent();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text != tk.MatKhau)
            {
                MessageBox.Show("Mật khẩu không chính xác");
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
                return;
            }
            if (tk.LoaiTaiKhoan == 1)
            {
                SinhVienBUS sinhVienBUS = new SinhVienBUS();
                if (sinhVienBUS.ChangePasswordBUS(sv.MSSV, txtNewPass.Text) == true)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    newPass = txtNewPass.Text;
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
            }

            if (tk.LoaiTaiKhoan == 2)
            {
                GiangVienBUS giangVienBUS = new GiangVienBUS();
                if (giangVienBUS.ChangePasswordBUS(gv.MSGV, txtNewPass.Text) == true)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    newPass = txtNewPass.Text;
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkShow.Checked;
            txtOldPass.PasswordChar = isChecked ? '\0' : '*';
            txtNewPass.PasswordChar = isChecked ? '\0' : '*';
            txtConfirmPass.PasswordChar = isChecked ? '\0' : '*';
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Thoát","Bạn có muốn thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
