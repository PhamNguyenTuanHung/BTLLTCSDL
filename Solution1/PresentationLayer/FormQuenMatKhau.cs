using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOT;
using BusinessLayer;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer
{
    public partial class FormQuenMatKhau : Form
    {
        int loaiTaiKhoan;
        TaiKhoan_BUS taiKhoan_BUS;
        TaiKhoan taiKhoan;
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }
        int randomNumber;
        

        string fromEmail = "phamnguyentuanhung2004@gmail.com";
        string password = "BeUyen12052004"; // Nên dùng mật khẩu ứng dụng nếu là Gmail

        public void GuiEamil(string Email)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("phamnguyentuanhung2004@gmail.com"); // Đổi thành email của bạn
                mail.To.Add(Email); // Email người nhận
                mail.Subject = "Lấy lại mật khẩu";
                Random random = new Random();
                randomNumber = random.Next(100000, 999999); // Tạo số có 6 chữ số
                Console.WriteLine(randomNumber);
                mail.Body =randomNumber.ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("phamnguyentuanhung2004@gmail.com", "jcvynfwdxqdzkjsu"); // Dùng App Password
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email đã gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
              
                if (taiKhoan_BUS.KiemTraTonTaiTaiKhoanBUS(txtTaiKhoan.Text))
                {
                    string Email = taiKhoan_BUS.LayEmailCuaTaiKhoanBUS(txtTaiKhoan.Text, loaiTaiKhoan);
                    GuiEamil(Email);
                    btnNhapMa.Visible = true;
                    txtCode.Visible = true;
                    
                    label2.Visible = true;
                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản");
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiTK.SelectedItem == null) return;
            loaiTaiKhoan = (int)cbLoaiTK.SelectedValue;
        }

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {
            cbLoaiTK.SelectedIndexChanged -= cbLoaiTK_SelectedIndexChanged;
            taiKhoan_BUS = new TaiKhoan_BUS();
            var DanhSachLoaiTaiKhoan  = new List<dynamic>
            {
                new { LoaiTaiKhoan = 1, TenTK = "Sinh viên" },
                new { LoaiTaiKhoan = 2, TenTK = "Giảng viên" },
            };

            // Gán dữ liệu vào ComboBox
            cbLoaiTK.DataSource = DanhSachLoaiTaiKhoan;
            cbLoaiTK.DisplayMember = "TenTK";  // Hiển thị loại tài khoản
            cbLoaiTK.ValueMember = "LoaiTaiKhoan"; // Giá trị trong DB
            if (cbLoaiTK.Items.Count > 0)
            {
                cbLoaiTK.SelectedIndex = 0;
            }
            cbLoaiTK.SelectedIndexChanged += cbLoaiTK_SelectedIndexChanged;
            loaiTaiKhoan = 1;
            btnNhapMa.Visible = false;
            txtCode.Visible = false;
            txtConfirmPass.Visible = false;
            txtNewPass.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            label2.Visible = false;
            taiKhoan_BUS = new TaiKhoan_BUS();
        }

        private void btnNhapMa_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == randomNumber.ToString())
            {
                txtConfirmPass.Visible = true;
                txtNewPass.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                return;
            }
            else MessageBox.Show("Vui lòng nhập lại mã otp");
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
                return;
            }
            if (taiKhoan_BUS.DoiMatKhauBUS(txtTaiKhoan.Text, txtNewPass.Text) == true)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                DialogResult = DialogResult.Yes;
                this.Close();
                return;
            }
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkShow.Checked;
            txtNewPass.PasswordChar = isChecked ? '\0' : '*';
            txtConfirmPass.PasswordChar = isChecked ? '\0' : '*';
        }
    }
}
