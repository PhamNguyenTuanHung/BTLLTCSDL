/*using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private SinhVien_BUS svBus;
        private TaiKhoan tk;
        private Panel panelContent,panelDoiMK;  // Panel chứa nội dung động

        public FormSV(SinhVien sinhvien,TaiKhoan taikhoan)
        {
            InitializeComponent();
            sv = sinhvien;
            tk = taikhoan;
            panelContent = new Panel
            { 
                Dock = DockStyle.Fill,
                Padding = new Padding(0, menuStrip1.Height, 0, 0)
            };
            this.Controls.Add(panelContent);
            ThongTinSVPL();
            HienThiPanel(panel1);
        }


        private void HienThiPanel(Control control)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
            panel1.Visible = false;
            flowLayoutPanel1.Visible = false;
            control.Dock = DockStyle.Fill;
            control.Visible = true;

        }


        private void ThongTinSVPL()
        {
            svBus = new SinhVien_BUS();
            DataTable dt = svBus.ThongTinSVBUS(sv.MSSV);
            if (dt != null && dt.Rows.Count > 0) // Kiểm tra nếu có dữ liệu
            {
                lbMSSV.Text = dt.Rows[0]["MSSV"].ToString();
                lbHoTen.Text = dt.Rows[0]["Ten_Day_Du"].ToString();
                lbEmail.Text = dt.Rows[0]["Email"].ToString();
                lbNgaySinh.Text = Convert.ToDateTime(dt.Rows[0]["Ngay_Sinh"]).ToString("dd/MM/yyyy"); // Định dạng ngày
                lbDRL.Text = dt.Rows[0]["Diem_Ren_Luyen"].ToString();
                lbKhoaHoc.Text = dt.Rows[0]["Khoa_Hoc"].ToString();
                lbLop.Text = dt.Rows[0]["Ma_Lop"].ToString();
                lbKhoa.Text = dt.Rows[0]["Ten_Khoa"].ToString();
                lbGioiTinh.Text = dt.Rows[0]["Gioi_Tinh"].ToString();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sinh viên!");
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

            dgv.DataBindingComplete += (s, e) =>
            {

                if (dt.Columns.Contains("Ten_Mon_Hoc")) 
                    dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn";

                if (dt.Columns.Contains("Diem_Qua_Trinh")) 
                    dgv.Columns["Diem_Qua_Trinh"].HeaderText = "Điểm QT";

                if (dt.Columns.Contains("Diem_Thi")) 
                    dgv.Columns["Diem_Thi"].HeaderText = "Điểm Thi";

                if (dt.Columns.Contains("Diem_Tong_Ket"))
                    dgv.Columns["Diem_Tong_Ket"].HeaderText = "Tổng Kết";

                if (dt.Columns.Contains("Ma_Nhom_Hoc")) 
                    dgv.Columns["Ma_Nhom_Hoc"].HeaderText = "Mã nhóm học";

                if (dt.Columns.Contains("Gio_Bat_Dau")) 
                    dgv.Columns["Gio_Bat_Dau"].HeaderText = "Giờ bắt đầu";

                if (dt.Columns.Contains("Gio_Ket_Thuc")) 
                    dgv.Columns["Gio_Ket_Thuc"].HeaderText = "Giờ kết thúc";

                if (dt.Columns.Contains("Ngay_Hoc")) 
                    dgv.Columns["Ngay_Hoc"].HeaderText = "Ngày học";

                if (dt.Columns.Contains("Ma_Mon_Hoc"))
                    dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Mã Môn Học";

                if (dt.Columns.Contains("Ngay_BD"))
                    dgv.Columns["Ngay_BD"].HeaderText = "Ngày Bắt Đầu";

                if (dt.Columns.Contains("Ngay_KT"))
                    dgv.Columns["Ngay_KT"].HeaderText = "Ngày Kết Thúc";

                if (dt.Columns.Contains("Ten_Mon_Hoc"))
                    dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn Học";

                if (dt.Columns.Contains("So_Tin_Chi"))
                    dgv.Columns["So_Tin_Chi"].HeaderText = "Số Tín Chỉ";

                if (dt.Columns.Contains("Ma_Mon_Hoc"))
                    dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Số Tín Chỉ";

            };

            return dgv;
        }

        private void XemDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLuu.Hide();
            txtTimKiem.Clear();
            panelDSMonDK.Visible = false;
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.DiemSVBUS(sv.MSSV);
            dgv.DataSource = dt;

            if (dt.Columns.Contains("Ten_Mon_Hoc"))
                dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn";

            if (dt.Columns.Contains("Diem_Qua_Trinh"))
                dgv.Columns["Diem_Qua_Trinh"].HeaderText = "Điểm QT";

            if (dt.Columns.Contains("Diem_Thi"))
                dgv.Columns["Diem_Thi"].HeaderText = "Điểm Thi";

            if (dt.Columns.Contains("Diem_Tong_Ket"))
                dgv.Columns["Diem_Tong_Ket"].HeaderText = "Tổng Kết";

            // Đảm bảo panelSearch hiển thị đúng vị trí
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            panelTimKiem.Dock = DockStyle.Top;
            HienThiPanel(flowLayoutPanel1);
        }



        private void ThongTinSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinSVPL();
            HienThiPanel(panel1);
        }

        private void TKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLuu.Hide();
            txtTimKiem.Clear();
            panelDSMonDK.Visible = false;
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.TKBSinhVienBUS(sv.MSSV);
            panelTimKiem.Dock = DockStyle.Top;
            dgv.DataSource = dt;
            dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn Học";
            dgv.Columns["Ngay_Hoc"].HeaderText = "Ngày Học";
            dgv.Columns["Gio_Bat_Dau"].HeaderText = "Giờ Bắt Đầu";
            dgv.Columns["Gio_Ket_Thuc"].HeaderText = "Giờ Kết Thúc";
            // Đảm bảo vị trí chính xác
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            panelDSMonDK.Visible = false;
            HienThiPanel(flowLayoutPanel1);
        }
        private void DoiMKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnLuu.Hide();
            txtTimKiem.Clear();
            panelDSMonDK.Visible=false;
            panelDoiMK = new Panel { Dock = DockStyle.Fill };

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
                if (sinhVienBUS.ChangePasswordBUS(sv.MSSV, txtNewPass.Text) == true)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Đổi mật khẩu thành công!";
                }
            };

            panelDoiMK.Controls.AddRange(new Control[] { lblOld, txtOldPass, lblNew, txtNewPass, lblConfirm, txtConfirmPass, chkShowPass, btnChange, lblMessage });

            HienThiPanel(panelDoiMK);
        }

        private void LichThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLuu.Hide();
            txtTimKiem.Clear();
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.LichThiBUS(sv.MSSV);
            dgv.DataSource = dt;
            dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Mã môn học";
            dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên môn học";
            dgv.Columns["Ngay_Thi"].HeaderText = "Ngày thi";
            dgv.Columns["Gio_BD"].HeaderText = "Giờ bắt đầu";
            dgv.Columns["Gio_KT"].HeaderText = "Giờ kết thúc";
            // Đảm bảo vị trí chính xác
            panelTimKiem.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            panelDSMonDK.Visible = false;
            HienThiPanel(flowLayoutPanel1);
        }

        private void DKMonHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            txtTimKiem.Clear();
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.GetAvailableCoursesBUS();
            dt.Columns.Add("Chọn", typeof(bool));
            dgv.DataSource = dt;
            if (dt.Columns.Contains("Ma_Mon_Hoc"))
                dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Mã Môn Học";

            if (dt.Columns.Contains("Ngay_BD"))
                dgv.Columns["Ngay_BD"].HeaderText = "Ngày Bắt Đầu";

            if (dt.Columns.Contains("Ngay_KT"))
                dgv.Columns["Ngay_KT"].HeaderText = "Ngày Kết Thúc";

            if (dt.Columns.Contains("Ten_Mon_Hoc"))
                dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn Học";

            if (dt.Columns.Contains("So_Tin_Chi"))
                dgv.Columns["So_Tin_Chi"].HeaderText = "Số Tín Chỉ";
            dgv.CellContentClick += dgv_CellContentClick;

            // Đảm bảo vị trí chính xác
            panelTimKiem.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;

            panelDSMonDK.Visible = true;

            HienThiPanel(flowLayoutPanel1);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dgv.DataSource != null)
            {
                DataTable dt = (DataTable)dgv.DataSource;

                string keyword = txtTimKiem.Text.Trim().ToLower();

                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    string filter = $"[Ten_Mon_Hoc] LIKE '%{keyword}%'"; *//*OR [Ma_Mon_Hoc] LIKE '%{keyword}%'";*//*
                    dt.DefaultView.RowFilter = filter; ;
                }
                dgv.DataSource = dt;
            }
            else MessageBox.Show("Dữ liệu null");

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingList<MonHoc> dsMonHoc = (BindingList<MonHoc>)dgv.DataSource;
            if (dsMonHoc != null)
            {
           //     dsMonHoc.Add(new MonHoc { Ma_Mon_Hoc = "MH003", Ten_Mon_Hoc = "Lập trình Java", So_Tin_Chi = 3 });
            }

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
*/