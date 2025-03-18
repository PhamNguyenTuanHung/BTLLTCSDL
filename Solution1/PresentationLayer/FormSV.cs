using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormSV : Form
    {
        private SinhVien sv;
        private TaiKhoan tk;
        private Panel panelContent;  // Panel chứa nội dung động

        public FormSV(SinhVien sinhvien,TaiKhoan taikhoan)
        {
            InitializeComponent();
            sv = sinhvien;
            tk = taikhoan;
            panelContent = new Panel
            { Dock = DockStyle.Fill };
            this.Controls.Add(panelContent);
            ThongTinSVPL();
            // Hiển thị thông tin sinh viên ban đầu
        }

        private Panel TaoPanelTimKiem(DataGridView dgv, DataTable dt)
        {
            // Tạo Panel chứa ô tìm kiếm
            Panel panelSearch = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40
            };

            // Tạo TextBox nhập từ khóa tìm kiếm
            TextBox txtSearch = new TextBox
            {
                Width = 200,
                Location = new Point(10, 10)
            };

            // Tạo Button tìm kiếm
            Button btnSearch = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(220, 8)
            };

            // Gắn sự kiện tìm kiếm
            btnSearch.Click += (s, e) =>
            {

                string keyword = txtSearch.Text.Trim().ToLower();

                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Lọc theo cột "Ten_Mon_Hoc"
                    dt.DefaultView.RowFilter = $"CONVERT(Ten_Mon_Hoc, 'System.String') LIKE '%{keyword}%'";
                }

                // Cập nhật lại DataGridView với dữ liệu đã lọc
                dgv.DataSource = dt.DefaultView;


            };

            // Thêm TextBox và Button vào Panel
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);

            return panelSearch;
        }


        private void ThongTinSVPL()
        {
            if (sv != null)
            {
                lbMSSV.Text = sv.MSSV;
                lbHoTen.Text = sv.HoTenSV;
                lbGioiTinh.Text = sv.GioiTinh;
                lbNgaySinh.Text = sv.NgaySinh.ToString("dd/MM/yyyy");
                lbKhoaHoc.Text = sv.KhoaHoc;
                lbDRL.Text = sv.DRL.ToString();
                lbKhoa.Text = sv.TenKhoa;
                lbEmail.Text = sv.Email;
            }
        }

        private DataGridView TaoDataGridView(DataTable dt)
        {
            DataGridView dgv = new DataGridView
            {
                DataSource = dt,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };

            // Thiết lập HeaderText nếu có
            dgv.DataBindingComplete += (s, e) =>
            {

                if (dt.Columns.Contains("Ten_Mon_Hoc")) dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn";
                if (dt.Columns.Contains("Diem_Qua_Trinh")) dgv.Columns["Diem_Qua_Trinh"].HeaderText = "Điểm QT";
                if (dt.Columns.Contains("Diem_Thi")) dgv.Columns["Diem_Thi"].HeaderText = "Điểm Thi";
                if (dt.Columns.Contains("Diem_Tong_Ket")) dgv.Columns["Diem_Tong_Ket"].HeaderText = "Tổng Kết";
                if (dt.Columns.Contains("Ma_Nhom_Hoc")) dgv.Columns["Ma_Nhom_Hoc"].HeaderText = "Mã nhóm học";
                if (dt.Columns.Contains("Gio_Bat_Dau")) dgv.Columns["Gio_Bat_Dau"].HeaderText = "Giờ bắt đầu";
                if (dt.Columns.Contains("Gio_Ket_Thuc")) dgv.Columns["Gio_Ket_Thuc"].HeaderText = "Giờ kết thúc";
                if (dt.Columns.Contains("Ngay_Hoc")) dgv.Columns["Ngay_Hoc"].HeaderText = "Ngày học";
            };

            return dgv;
        }

        private void HienThiPanel(Control control)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            if (control != panel1)
            {
                panel1.Visible = false;
            }
            else panel1.Visible = true;
        }

        

        private void XemDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.DiemSVBUS(sv.MSSV);
            DataGridView dgv = TaoDataGridView(dt);
            Panel panelSearch = TaoPanelTimKiem(dgv, dt);

            // Đảm bảo panelSearch hiển thị đúng vị trí
            panelSearch.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;

            Panel panelBangDiem = new Panel { Dock = DockStyle.Fill };
            panelBangDiem.Controls.Add(dgv);       // Thêm DataGridView trước
            panelBangDiem.Controls.Add(panelSearch); // Sau đó thêm panel tìm kiếm
            panelContent.Dock = DockStyle.Fill;
            panelContent.Padding = new Padding(0, menuStrip1.Height, 0, 0); // Đẩy xuống dưới MenuStrip
            HienThiPanel(panelBangDiem);
        }

        private void TKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.TKBSinhVienBUS(sv.MSSV);
            DataGridView dgv = TaoDataGridView(dt);
            Panel panelSearch = TaoPanelTimKiem(dgv, dt);

            // Đảm bảo vị trí chính xác
            panelSearch.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;

            Panel panelTKB = new Panel 
            { 
                Dock = DockStyle.Fill 
            };

            panelTKB.Controls.Add(dgv);
            panelTKB.Controls.Add(panelSearch);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Padding = new Padding(0, menuStrip1.Height, 0, 0); // Đẩy xuống dưới MenuStrip
            HienThiPanel(panelTKB);
        }

        private void ThongTinSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinSVPL();
            panel1.Visible = true;
        }

        private void DoiMKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Panel panelChangePass = new Panel { Dock = DockStyle.Fill };

            int panelWidth = panelContent.Width;
            int panelHeight = panelContent.Height;
            int textBoxWidth = 250;
            int labelWidth = 180;
            int spacing = 15;

            int centerX = (panelWidth - textBoxWidth - labelWidth - spacing) / 2;
            int centerY = (panelHeight - 200) / 2;

            Label lblOld = new Label { Text = "Mật khẩu cũ:", Width = labelWidth, TextAlign = ContentAlignment.MiddleRight, Location = new Point(centerX, centerY) };
            Label lblNew = new Label { Text = "Mật khẩu mới:", Width = labelWidth, TextAlign = ContentAlignment.MiddleRight, Location = new Point(centerX, centerY + 50) };
            Label lblConfirm = new Label { Text = "Nhập lại mật khẩu:", Width = labelWidth, TextAlign = ContentAlignment.MiddleRight, Location = new Point(centerX, centerY + 100) };

            TextBox txtOldPass = new TextBox { Location = new Point(centerX + labelWidth + spacing, centerY), Width = textBoxWidth, PasswordChar = '*' };
            TextBox txtNewPass = new TextBox { Location = new Point(centerX + labelWidth + spacing, centerY + 50), Width = textBoxWidth, PasswordChar = '*' };
            TextBox txtConfirmPass = new TextBox { Location = new Point(centerX + labelWidth + spacing, centerY + 100), Width = textBoxWidth, PasswordChar = '*' };

            // CheckBox căn chỉnh ngay dưới textbox cuối cùng
            CheckBox chkShowPass = new CheckBox { Text = "Hiển thị mật khẩu", AutoSize = true, Location = new Point(centerX + labelWidth, centerY + 135) };
            chkShowPass.CheckedChanged += (s, ex) =>
            {
                bool isChecked = chkShowPass.Checked;
                txtOldPass.PasswordChar = isChecked ? '\0' : '*';
                txtNewPass.PasswordChar = isChecked ? '\0' : '*';
                txtConfirmPass.PasswordChar = isChecked ? '\0' : '*';
            };

            // Button căn giữa theo textbox
            Button btnChange = new Button { Text = "Đổi mật khẩu", Width = 120, Location = new Point(centerX + labelWidth + (textBoxWidth - 120) / 2, centerY + 180) };
            Label lblMessage = new Label { ForeColor = Color.Red, Location = new Point(centerX + labelWidth, centerY + 220), AutoSize = true };

            btnChange.Click += (s, ex) =>
            {
                if (txtOldPass.Text != tk.Pass_word)
                {
                    lblMessage.Text = "Mật khẩu không chính xác";
                    return;
                }

                if (txtNewPass.Text != txtConfirmPass.Text)
                {
                    lblMessage.Text = "Mật khẩu mới không khớp!";
                    return;
                }
                SinhVien_BUS sinhVienBUS = new SinhVien_BUS();
                if (sinhVienBUS.DoiMatKhauBUS(sv.MSSV, txtNewPass.Text) == true)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Đổi mật khẩu thành công!";
                }
            };

            panelChangePass.Controls.AddRange(new Control[] { lblOld, txtOldPass, lblNew, txtNewPass, lblConfirm, txtConfirmPass, chkShowPass, btnChange, lblMessage });

            HienThiPanel(panelChangePass);
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormDangNhap();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
    
}
