using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;
using Excel = Microsoft.Office.Interop.Excel;

namespace PresentationLayer
{
    public partial class FormGiangVien : Form
    {
        private GiangVien gv;
        private TaiKhoan tk;
        private DiemSV diemSV;
        private GiangVienBUS gvBUS;

        public FormGiangVien(GiangVien gv, TaiKhoan tk)
        {
            this.gv = gv;
            this.tk = tk;
            InitializeComponent();
            GetLecturerInfo();
            GetLecturerClassInfo();
        }


        public void LoadData(DataTable dt, DataGridView dgv)
        {
            if (dt != null && dt.Columns.Count > 0)
            {
                dgv.DataSource = dt;

                if (dt.Columns.Contains("Ten_Mon_Hoc"))
                    dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên môn học";

                if (dt.Columns.Contains("Diem_Qua_Trinh"))
                    dgv.Columns["Diem_Qua_Trinh"].HeaderText = "Điểm QT";

                if (dt.Columns.Contains("Diem_Thi"))
                    dgv.Columns["Diem_Thi"].HeaderText = "Điểm Thi";

                if (dt.Columns.Contains("Diem_Tong_Ket"))
                    dgv.Columns["Diem_Tong_Ket"].HeaderText = "Tổng Kết";

                if (dt.Columns.Contains("Ma_Mon_Hoc"))
                    dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Mã Môn Học";

                if (dt.Columns.Contains("Ma_Lop_Mon_Hoc"))
                    dgv.Columns["Ma_Lop_Mon_Hoc"].HeaderText = "Mã Nhóm Học";

                if (dt.Columns.Contains("Ngay_BD"))
                    dgv.Columns["Ngay_BD"].HeaderText = "Ngày Bắt Đầu";

                if (dt.Columns.Contains("Ngay_KT"))
                    dgv.Columns["Ngay_KT"].HeaderText = "Ngày Kết Thúc";

                if (dt.Columns.Contains("So_Tin_Chi"))
                    dgv.Columns["So_Tin_Chi"].HeaderText = "Số Tín Chỉ";

                if (dt.Columns.Contains("Ngay_Hoc"))
                    dgv.Columns["Ngay_Hoc"].HeaderText = "Ngày Học";

                if (dt.Columns.Contains("Gio_Bat_Dau"))
                    dgv.Columns["Gio_Bat_Dau"].HeaderText = "Giờ Bắt Đầu";

                if (dt.Columns.Contains("Gio_Ket_Thuc"))
                    dgv.Columns["Gio_Ket_Thuc"].HeaderText = "Giờ Kết Thúc";

                if (dt.Columns.Contains("Ngay_Thi"))
                    dgv.Columns["Ngay_Thi"].HeaderText = "Ngày thi";

                if (dt.Columns.Contains("Gio_BD"))
                    dgv.Columns["Gio_BD"].HeaderText = "Giờ bắt đầu";

                if (dt.Columns.Contains("Gio_KT"))
                    dgv.Columns["Gio_KT"].HeaderText = "Giờ kết thúc";

                if (dt.Columns.Contains("Ho_Ten"))
                    dgv.Columns["Ho_Ten"].HeaderText = "Tên sinh viên";

                if (dt.Columns.Contains("Ma_Hoc_Ky"))
                    dgv.Columns["Ma_Hoc_Ky"].HeaderText = "Mã học kỳ";
            }
        }

        public void GetLecturerInfo()
        {
            gvBUS = new GiangVienBUS();
            var dt = gvBUS.GetLecturerInfoTableBUS(gv.MSGV);
            if (dt != null && dt.Rows.Count > 0) // Kiểm tra nếu có dữ liệu
            {
                lbMSGV.Text = dt.Rows[0]["MSGV"].ToString();
                lbHoTen.Text = dt.Rows[0]["Ho_Ten"].ToString();
                lbEmail.Text = dt.Rows[0]["Email"].ToString();
                lbNgaySinh.Text = Convert.ToDateTime(dt.Rows[0]["Ngay_Sinh"]).ToString("dd/MM/yyyy"); // Định dạng ngày
                lbLop.Text = dt.Rows[0]["Ma_Lop"].ToString();
                lbKhoa.Text = dt.Rows[0]["Ma_Khoa"].ToString();
                lbGioiTinh.Text = dt.Rows[0]["Gioi_Tinh"].ToString();
                if (dt.Rows[0]["Anh"] != DBNull.Value)
                {
                    var imageBytes = (byte[])dt.Rows[0]["Anh"];
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pbAnhGV.Image = Image.FromStream(ms);
                    }
                    btnAnh.Text = "Đổi ảnh";
                }
                else
                {
                    pbAnhGV.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu giảng viên!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLopSV.SelectedItem == null) return; // Tránh lỗi nếu chưa chọn
            var giangVienBL = new GiangVienBUS();
            var malopmonhoc = cbLopSV.SelectedValue.ToString(); // Lấy đúng giá trị môn học
            var dt = new DataTable();
            dt = giangVienBL.GetStudentGradesBUS(gv.MSGV, malopmonhoc);
            LoadData(dt, dgvThongTinLop);
        }

        private void GetLecturerClassInfo()
        {
            var gvBUS = new GiangVienBUS();
            var dt = new DataTable();
            dt = gvBUS.GetClassListBUS(gv.MSGV);
            cbLopSV.DataSource = dt;
            cbLopSV.DisplayMember = "Ten_Mon_Hoc";
            cbLopSV.ValueMember = "Ma_Lop_Mon_Hoc";
            cbLopSV.DataSource = dt;
            if (cbLopSV.Items.Count > 0) cbLopSV.SelectedIndex = 0; // Chọn mặc định môn đầu tiên
        }

        public void StudentGrades(string msgv, string malopmonhoc)
        {
            var dt = new DataTable();
            var gvBUS = new GiangVienBUS();
            dt = gvBUS.GetStudentGradesBUS(msgv, malopmonhoc);
            dgvThongTinLop.DataSource = dt;
        }

        private void Schedule()
        {
            var giangVienBL = new GiangVienBUS();
            var dt = giangVienBL.GetLecturerScheduleBUS(gv.MSGV);
            LoadData(dt, dgvTKB);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var TabIndex = tabControl.SelectedIndex;
            var sinhVienBUS = new SinhVienBUS();
            var dt = new DataTable();
            switch (TabIndex)
            {
                case 0:
                    GetLecturerInfo();
                    break;
                case 1:
                    GetLecturerClassInfo();
                    break;
                case 2:
                    Schedule();
                    break;
            }
        }

        private void Search(DataGridView dgv, TextBox txt)
        {
            if (dgv.DataSource != null)
            {
                DataTable dt = null;

                if (dgv.DataSource is DataView view)
                    dt = view.Table;
                else if (dgv.DataSource is DataTable table)
                    dt = table;

                if (dt != null)
                {
                    var keyword = txt.Text.Trim().ToLower();

                    if (string.IsNullOrWhiteSpace(keyword))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        var filterExpression = string.Join(" OR ", dt.Columns.Cast<DataColumn>()
                            .Where(c => c.DataType == typeof(string))
                            .Select(c => $"[{c.ColumnName}] LIKE '%{keyword}%'"));

                        if (string.IsNullOrEmpty(filterExpression))
                        {
                            MessageBox.Show("Không có cột chuỗi để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            dt.DefaultView.RowFilter = filterExpression;
                        }
                    }

                    dgv.DataSource = dt.DefaultView; // cập nhật lại DataSource để hiển thị kết quả lọc
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu null");
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search(dgvThongTinLop, txtTimKiemSinhVien);
        }

        private void btnTimKiemTKB_Click(object sender, EventArgs e)
        {
            Search(dgvTKB, txtTimKiemTKB);
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            var formDoiMatKhau = new FormDoiMatKhau(gv, tk);
            Enabled = false;
            if (formDoiMatKhau.ShowDialog() == DialogResult.OK)
                tk.MatKhau = formDoiMatKhau.newPass; // Cập nhật mật khẩu mới
            Enabled = true;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var form = new FormDangNhap();
            Hide();
            form.ShowDialog();
            Close();
        }


        private decimal ParseDecimalSafe(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return 0m;

            if (decimal.TryParse(value.ToString(), out var result))
                return result;

            return 0; // Trả về 0 nếu không thể parse
        }


        private void dgvThongTinLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThongTinLop.SelectedRows.Count > 0)
            {
                var row = dgvThongTinLop.SelectedRows[0];

                diemSV = new DiemSV
                (
                    row.Cells["MSSV"].Value?.ToString(), // Giả sử cột MSSV có tên là "MSSV"
                    row.Cells["Ma_Mon_Hoc"].Value?.ToString(), // Giả sử cột Ma_Mon_Hoc có tên là "Ma_Mon_Hoc"
                    row.Cells["Ma_Hoc_Ky"].Value?.ToString(),
                    Math.Round(ParseDecimalSafe(row.Cells["Diem_Qua_Trinh"].Value), 1), // Kiểm tra null và parse
                    Math.Round(ParseDecimalSafe(row.Cells["Diem_Thi"].Value), 1), // Kiểm tra null và parse
                    Math.Round(ParseDecimalSafe(row.Cells["Diem_Tong_Ket"].Value), 1), // Kiểm tra null và parse
                    int.TryParse(row.Cells["Lan_Thi"].Value?.ToString(), out var lanThi)
                        ? lanThi
                        : 0 // Kiểm tra Lan_Thi
                );
            }
        }


        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            new FormEditDiem(diemSV, 0).ShowDialog();
            GetLecturerClassInfo();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongTinLop.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại lưu file
            var sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "DiemSinhVien.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
                try
                {
                    // Khởi tạo ứng dụng Excel
                    var excelApp = new Excel.Application();
                    var workbook = excelApp.Workbooks.Add();
                    var worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                    // Ghi tiêu đề cột
                    for (var i = 0; i < dgvThongTinLop.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvThongTinLop.Columns[i].HeaderText;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Interior.Color =
                            ColorTranslator.ToOle(Color.LightGray);
                    }

                    // Ghi dữ liệu từ DataGridView vào Excel
                    for (var i = 0; i < dgvThongTinLop.Rows.Count; i++)
                    for (var j = 0; j < dgvThongTinLop.Columns.Count; j++)
                        worksheet.Cells[i + 2, j + 1] = dgvThongTinLop.Rows[i].Cells[j].Value?.ToString();

                    // Tự động căn chỉnh độ rộng cột
                    worksheet.Columns.AutoFit();

                    // Lưu file
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var imageBytes = File.ReadAllBytes(filePath); // Chuyển ảnh thành mảng byte
                try
                {
                    if (gvBUS.ChangeImageBUS(imageBytes, gv.MSGV))
                        MessageBox.Show("Thành công");
                    if (imageBytes.Length > 0)
                    {
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pbAnhGV.Image = Image.FromStream(ms);
                        }

                        btnAnh.Text = "Đổi ảnh";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}