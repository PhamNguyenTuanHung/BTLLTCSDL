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
        private DataGridView dataGridView;
        private Panel panelQuanLyDiem;
        private TextBox txtMSSV, txtHoTen, txtDiemQT, txtDiemThi, txtDiemTongKet;
        private Button btnSua;
        private GiangVien gv;

        public FormGV(GiangVien giangvien)
        {
            InitializeComponent();
            this.gv = giangvien;  // Gán giảng viên truyền vào
            
            panelContent = new Panel { Dock = DockStyle.Fill };
            this.Controls.Add(panelContent);
            ThongTinCacLopCuaGV();
            ThongTinGVPL();
        }


        private void KhoiTaoPanelQuanLyDiem()
        {
            panelQuanLyDiem = new Panel { Dock = DockStyle.Fill };
            Panel panelSearch = new Panel { Dock = DockStyle.Top, Height = 40 };
            TextBox txtSearch = new TextBox { Width = 200, Location = new Point(10, 10) };
            Button btnSearch = new Button { Text = "Tìm kiếm", Location = new Point(220, 8) };
            //btnSearch.Click += (s, e) => TimKiem(txtSearch.Text);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);

            dataGridView = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;

            Panel panelEdit = new Panel { Dock = DockStyle.Bottom, Height = 100 };
            txtMSSV = new TextBox { ReadOnly = true, Location = new Point(10, 10), Width = 100 };
            txtHoTen = new TextBox { ReadOnly = true, Location = new Point(120, 10), Width = 150 };
            txtDiemQT = new TextBox { Location = new Point(280, 10), Width = 50 };
            txtDiemThi = new TextBox { Location = new Point(340, 10), Width = 50 };
            txtDiemTongKet = new TextBox { ReadOnly = true, Location = new Point(400, 10), Width = 50 };
            btnSua = new Button { Text = "Sửa", Location = new Point(460, 8) };
            //btnSua.Click += BtnSua_Click;

            panelEdit.Controls.AddRange(new Control[] { txtMSSV, txtHoTen, txtDiemQT, txtDiemThi, txtDiemTongKet, btnSua });
            panelQuanLyDiem.Controls.AddRange(new Control[] { panelSearch, dataGridView, panelEdit });
            this.Controls.Add(panelQuanLyDiem);
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

                // Cập nhật lại DataGridView với dữ liệu đã lọc
                dgv.DataSource = dt.DefaultView;


            };

            // Thêm TextBox và Button vào Panel
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);

            return panelSearch;
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
            GiangVienBL giangVienBL = new GiangVienBL();
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            // 🔹 Lấy danh sách điểm sinh viên
            List<DiemSV> ds = giangVienBL.DanhSachDiemSVBL(gv.MSGV, item.Tag.ToString());

            if (ds.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MSSV");
                dt.Columns.Add("Tên sinh viên");
                dt.Columns.Add("Điểm quá trình");
                dt.Columns.Add("Điểm thi");
                dt.Columns.Add("Điểm tổng kết");

                foreach (var sv in ds)
                {
                    dt.Rows.Add(sv.MSSV, sv.TenDayDu, sv.DiemQuaTrinh, sv.DiemThi, sv.DiemTongKet);
                }

                DataGridView dgv = TaoDataGridView(dt);
                Panel panelSearch = TaoPanelTimKiem(dgv, dt);

                Panel panelDiemSV = new Panel { Dock = DockStyle.Fill };
                panelDiemSV.Controls.Add(dgv);
                panelDiemSV.Controls.Add(panelSearch);
                panelContent.Padding = new Padding(0, menuStrip1.Height, 0, 0); // Đẩy xuống dưới MenuStrip

                HienThiPanel(panelDiemSV);
                //dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                txtDiemQT.Text = row.Cells["Diem_Qua_Trinh"].Value.ToString();
                txtDiemThi.Text = row.Cells["Diem_Thi"].Value.ToString();
                txtDiemTongKet.Text = row.Cells["Diem_Tong_Ket"].Value.ToString();
                //panelBottom.Visible = true;
            }
        }


        private void thôngTinGVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiPanel(panel1);
            ThongTinGVPL();
        }

        private void ThongTinCacLopCuaGV()
        {
            this.QLLHToolStripMenuItem.DropDownItems.Clear();

            GiangVienBL gvBL = new GiangVienBL();
            List<LopHoc> ds = gvBL.DanhSachLopHocBL(gv.MSGV);

            foreach (var lop in ds)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(lop.TenMonHoc);
                menuItem.Tag = lop.MaMonHoc;
                menuItem.Click += Lop_Click;
                this.QLLHToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void thờiKhóaBiểuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiangVienBL giangVienBL = new GiangVienBL();
            DataTable dt = giangVienBL.TKBGiangVienBL(gv.MSGV);
            DataGridView dgv = TaoDataGridView(dt);
            Panel panelSearch = TaoPanelTimKiem(dgv, dt);

            // Đảm bảo panelSearch hiển thị đúng vị trí
            panelSearch.Dock = DockStyle.Top;
            dgv.Dock = DockStyle.Fill;

            Panel panelTKB = new Panel { Dock = DockStyle.Fill };
            panelTKB.Controls.Add(dgv);       // Thêm DataGridView trước
            panelTKB.Controls.Add(panelSearch); // Sau đó thêm panel tìm kiếm
            panelContent.Dock = DockStyle.Fill;
            panelContent.Padding = new Padding(0, menuStrip1.Height, 0, 0); // Đẩy xuống dưới MenuStrip
            HienThiPanel(panelTKB);
        }
    }
}
