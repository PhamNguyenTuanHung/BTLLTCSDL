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
        private Panel panelContent;  // Panel chứa nội dung động

        public FormSV(SinhVien SINHVIEN)
        {
            InitializeComponent();
            sv = SINHVIEN;
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

        private void thôngTinSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiPanel(panel1);
            ThongTinSVPL(); // Cập nhật lại thông tin sinh viên
        }

        private void xemĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void thờiKhóaBiểuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVien_BUS sinhVienBL = new SinhVien_BUS();
            DataTable dt = sinhVienBL.TKBSinhVienBUS(sv.MSSV);
            DataGridView dgv = TaoDataGridView(dt);
            Panel panelSearch = TaoPanelTimKiem(dgv, dt);

            // Đảm bảo vị trí chính xác
            panelSearch.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;

            Panel panelTKB = new Panel { Dock = DockStyle.Fill };
            panelTKB.Controls.Add(dgv);
            panelTKB.Controls.Add(panelSearch); 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Padding = new Padding(0, menuStrip1.Height, 0, 0); // Đẩy xuống dưới MenuStrip
            HienThiPanel(panelTKB);
        }
    }
}
