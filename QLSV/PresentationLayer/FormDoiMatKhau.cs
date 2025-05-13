using System;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormDoiMatKhau : Form
    {
        private readonly GiangVien gv;
        private readonly SinhVien sv;
        private readonly TaiKhoan tk;
        public string newPass;

        public FormDoiMatKhau(TaiKhoan tk)
        {
            this.tk = tk;
            InitializeComponent();
            label1.Visible = false;

            txtOldPass.Visible = false;
            txtOldPass.Text = tk.MatKhau;
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
                var sinhVienBUS = new SinhVienBUS();
                if (sinhVienBUS.ChangePasswordBUS(sv.MSSV, txtNewPass.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    newPass = txtNewPass.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }

            if (tk.LoaiTaiKhoan == 2)
            {
                var giangVienBUS = new GiangVienBUS();
                if (giangVienBUS.ChangePasswordBUS(gv.MSGV, txtNewPass.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    newPass = txtNewPass.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = checkShow.Checked;
            txtOldPass.PasswordChar = isChecked ? '\0' : '*';
            txtNewPass.PasswordChar = isChecked ? '\0' : '*';
            txtConfirmPass.PasswordChar = isChecked ? '\0' : '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Thoát", "Bạn có muốn thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Close();
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
        }
    }
}