using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class FormQuenMatKhau : Form
    {
        private int countdown = 60; // 60 giây
        private string fromEmail = "yourAccount";
        private int loaiTaiKhoan;
        private string password = "yourPass"; // Nên dùng mật khẩu ứng dụng nếu là Gmail

        private int randomNumber;

        private TaiKhoanBUS taiKhoanBUS;

        /*TaiKhoan taiKhoan;*/
        private Timer timer;

        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        public void GuiEamil(string Email)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("phamnguyentuanhung2004@gmail.com"); // Đổi thành email của bạn
                mail.To.Add(Email); // Email người nhận
                mail.Subject = "Lấy lại mật khẩu";
                var random = new Random();
                randomNumber = random.Next(100000, 999999); // Tạo số có 6 chữ số
                Console.WriteLine(randomNumber);
                mail.Body = randomNumber.ToString();

                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials =
                    new NetworkCredential("phamnguyentuanhung2004@gmail.com", "jcvynfwdxqdzkjsu"); // Dùng App Password
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email đã gửi thành công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuiMa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (taiKhoanBUS.CheckAccountExistsBUS(txtTaiKhoan.Text, int.Parse(cbLoaiTK.SelectedValue.ToString())))
                {
                    var Email = taiKhoanBUS.GetAccountEmailBUS(txtTaiKhoan.Text, loaiTaiKhoan);
                    await Task.Run(() => GuiEamil(Email));
                    btnNhapMa.Visible = true;
                    txtCode.Visible = true;
                    label2.Visible = true;
                    btnGuiMa.Enabled = false; // Vô hiệu hóa nút
                    countdown = 60;

                    // Cập nhật text nếu muốn
                    btnGuiMa.Text = $"Chờ {countdown}s";

                    timer = new Timer();
                    timer.Interval = 1000; // 1 giây
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản");
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            countdown--;
            btnGuiMa.Text = $"Chờ {countdown}s";

            if (countdown == 0)
            {
                timer.Stop();
                btnGuiMa.Enabled = true;
                btnGuiMa.Text = "Gửi lại"; // Reset lại nội dung nút nếu cần
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
            taiKhoanBUS = new TaiKhoanBUS();
            var DanhSachLoaiTaiKhoan = new List<dynamic>
            {
                new { LoaiTaiKhoan = 1, TenTK = "Sinh viên" },
                new { LoaiTaiKhoan = 2, TenTK = "Giảng viên" }
            };

            // Gán dữ liệu vào ComboBox
            cbLoaiTK.DataSource = DanhSachLoaiTaiKhoan;
            cbLoaiTK.DisplayMember = "TenTK"; // Hiển thị loại tài khoản
            cbLoaiTK.ValueMember = "LoaiTaiKhoan"; // Giá trị trong DB
            if (cbLoaiTK.Items.Count > 0) cbLoaiTK.SelectedIndex = 0;
            cbLoaiTK.SelectedIndexChanged += cbLoaiTK_SelectedIndexChanged;
            loaiTaiKhoan = 1;
            btnNhapMa.Visible = false;
            txtCode.Visible = false;
            txtConfirmPass.Visible = false;
            txtNewPass.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            label2.Visible = false;
            btnDoiMatKhau.Visible = false;
            taiKhoanBUS = new TaiKhoanBUS();
        }

        private void btnNhapMa_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == randomNumber.ToString())
            {
                txtConfirmPass.Visible = true;
                txtNewPass.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                btnDoiMatKhau.Visible=true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại mã otp");
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
                return;
            }

            if (taiKhoanBUS.ChangePasswordBUS(txtTaiKhoan.Text, txtNewPass.Text))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = checkShow.Checked;
            txtNewPass.PasswordChar = isChecked ? '\0' : '*';
            txtConfirmPass.PasswordChar = isChecked ? '\0' : '*';
        }
    }
}