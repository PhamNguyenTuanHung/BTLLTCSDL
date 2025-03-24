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
            if (txtOldPass.Text != tk.Pass_word)
            {
                MessageBox.Show("Mật khẩu không chính xác");
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
                return;
            }
            if (tk.Type == 1)
            {
                MessageBox.Show("sv");
                SinhVien_BUS sinhVienBUS = new SinhVien_BUS();
                if (sinhVienBUS.DoiMatKhauBUS(sv.MSSV, txtNewPass.Text) == true)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                }
            }

            if (tk.Type == 2)
            {
                GiangVien_BUS giangVien_BUS = new GiangVien_BUS();
                if (giangVien_BUS.DoiMatKhauBUS(gv.MSGV, txtNewPass.Text) == true)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
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
