using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormGV : Form
    {
        private Panel panelContent;// Panel chứa nội dung động
        private GiangVien gv;
        private TaiKhoan tk;
        List<DiemSV> ds;
        private string mamonhoc;

        public FormGV(GiangVien giangvien, TaiKhoan taikhoan)
        {
            InitializeComponent();
            this.tk = taikhoan;
            this.gv = giangvien;
            panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, menuStrip1.Height, 0, 0)
            };
            this.Controls.Add(panelContent);
            ThongTinCacLopCuaGV();
            ThongTinGVPL();
            HienThiPanel(panel1);
        }

        private void HienThiPanel(Control control)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
            panel1.Visible = false;
            flowLayoutPanel1.Visible = false;
            panelDoiMatKhau.Visible = false;
            control.Dock= DockStyle.Fill;
            control.Visible = true;

        }

        private void ThongTinGVPL()
        {
            if (gv != null)
            {
                lbMSGV.Text = gv.MSGV;
                lbHoTen.Text = gv.HoTenGV;
                lbGioiTinh.Text = gv.GioiTinh;
                lbEmail.Text = gv.SDT;
                lbKhoa.Text = gv.MaKhoa;
            }
        }

        
        private void Lop_Click(object sender, EventArgs e)
        {
            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            mamonhoc = item.Tag.ToString();
            
            // 🔹 Lấy danh sách điểm sinh viên
            ds = giangVienBL.DanhSachDiemSVBUS(gv.MSGV, mamonhoc);

            if (ds.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MSSV");
                dt.Columns.Add("Tên sinh viên");
                dt.Columns.Add("Điểm quá trình");
                dt.Columns.Add("Điểm thi");
                dt.Columns.Add("Điểm tổng kết");
                dt.Columns.Add("Lần thi");

                foreach (var sv in ds)
                {
                    dt.Rows.Add(sv.MSSV, sv.TenDayDu, sv.DiemQuaTrinh, sv.DiemThi, sv.DiemTongKet,sv.LanThi);
                }
                dgv.DataSource = dt;
                dgv.Dock = DockStyle.Fill;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.Dock = DockStyle.Fill;
                dgv.ClearSelection();
                panelSua.Visible = true;
            }

            HienThiPanel(flowLayoutPanel1);
        }

        private void ThongTinGVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiPanel(panel1);
            ThongTinGVPL();
        }
        private void ThongTinCacLopCuaGV()
        {
            this.QLLHToolStripMenuItem.DropDownItems.Clear();

            GiangVien_BUS gvBL = new GiangVien_BUS();
            List<LopHoc> ds = gvBL.DanhSachLopHocBUS(gv.MSGV);

            foreach (var lop in ds)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(lop.TenMonHoc);
                menuItem.Tag = lop.MaMonHoc;
                menuItem.Click += Lop_Click;
                this.QLLHToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                txtMSSV.Text = row.Cells["MSSV"].Value.ToString();
                txtHoTen.Text = row.Cells["Tên sinh viên"].Value.ToString();
                txtDiemQT.Text = row.Cells["Điểm quá trình"].Value.ToString();
                txtDiemThi.Text = row.Cells["Điểm thi"].Value.ToString();
                txtDiemTongKet.Text = row.Cells["Điểm tổng kết"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable) dgv.DataSource;
            string keyword = txtTimKiem.Text.Trim().ToLower();

            // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // Kiểm tra xem bảng có chứa cả hai cột không
                bool coTenSV = dt.Columns.Contains("Tên sinh viên");
                bool coTenMonHoc = dt.Columns.Contains("Ten_Mon_Hoc");

                // Tạo bộ lọc linh hoạt
                string filter = "";

                if (coTenSV)
                    filter += $"[Tên sinh viên] LIKE '%{keyword}%'";

                if (coTenMonHoc)
                {
                    if (!string.IsNullOrEmpty(filter))
                        filter += " OR ";
                    filter += $"[Ten_Mon_Hoc] LIKE '%{keyword}%'";
                }
                dt.DefaultView.RowFilter = filter;
            }
            dgv.DataSource = dt;
        }

        private void TKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            DataTable dt = giangVienBL.TKBGiangVienBUS(gv.MSGV);
           
            // Đổi tên cột trong DataGridView
            dgv.DataSource = dt;
            dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn Học";
            dgv.Columns["Ngay_Hoc"].HeaderText = "Ngày Học";
            dgv.Columns["Gio_Bat_Dau"].HeaderText = "Giờ Bắt Đầu";
            dgv.Columns["Gio_Ket_Thuc"].HeaderText = "Giờ Kết Thúc";
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;

            panelSua.Visible = false;
            HienThiPanel(flowLayoutPanel1);
        }

        private void ChangePassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelDoiMatKhau.Dock = DockStyle.Fill;

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
                GiangVien_BUS GiangVienBUS = new GiangVien_BUS();
                if (GiangVienBUS.DoiMatKhauBUS(gv.MSGV, txtNewPass.Text) == true)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Đổi mật khẩu thành công!";
                }
            };


            panelDoiMatKhau.Controls.AddRange(new Control[] { lblOld, txtOldPass, lblNew, txtNewPass, lblConfirm, txtConfirmPass, chkShowPass, btnChange, lblMessage });
            panelContent.Controls.Add(panelDoiMatKhau);
            HienThiPanel(panelDoiMatKhau);
        }

        private void LogOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new FormDangNhap();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (txtDiemQT.Text == "")
            {
                txtDiemQT.Focus();
                return;
            }
            if (txtDiemThi.Text == "")

            {
                txtDiemThi.Focus();
                return;
            }
            txtDiemTongKet.Text = Math.Round((float.Parse(txtDiemQT.Text) * 0.4 + float.Parse(txtDiemThi.Text) * 0.6),3).ToString();

            GiangVien_BUS gvBUS = new GiangVien_BUS();
            BindingContext[dgv.DataSource].EndCurrentEdit();
            dgv.Refresh();
            if (gvBUS.SuaDiemSVBUS(txtMSSV.Text, mamonhoc, float.Parse(txtDiemQT.Text), float.Parse(txtDiemThi.Text), float.Parse(txtDiemTongKet.Text)) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
