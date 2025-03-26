using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private GiangVien_BUS gvBUS;
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

                if (dt.Columns.Contains("Ten_Day_Du"))
                    dgv.Columns["Ten_Day_Du"].HeaderText = "Tên sinh viên";

                if (dt.Columns.Contains("Ma_Hoc_Ky"))
                    dgv.Columns["Ma_Hoc_Ki"].HeaderText = "Mã học kỳ";
            }
        }

        public void GetLecturerInfo()
        {
            gvBUS = new GiangVien_BUS();
            DataTable dt = gvBUS.GetLecturerInfoTableBUS(gv.MSGV);
            if (dt != null && dt.Rows.Count > 0) // Kiểm tra nếu có dữ liệu
            {
                lbMSGV.Text = dt.Rows[0]["MSGV"].ToString();
                lbHoTen.Text = dt.Rows[0]["Ten_Day_Du"].ToString();
                lbEmail.Text = dt.Rows[0]["Email"].ToString();
                lbNgaySinh.Text = Convert.ToDateTime(dt.Rows[0]["Ngay_Sinh"]).ToString("dd/MM/yyyy"); // Định dạng ngày
                lbLop.Text = dt.Rows[0]["Ma_Lop"].ToString();
                lbKhoa.Text = dt.Rows[0]["Ma_Khoa"].ToString();
                lbGioiTinh.Text = dt.Rows[0]["Gioi_Tinh"].ToString();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sinh viên!");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return; // Tránh lỗi nếu chưa chọn
            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            string malopmonhoc = comboBox1.SelectedValue.ToString(); // Lấy đúng giá trị môn học
            DataTable dt = new DataTable();
            dt = giangVienBL.GetStudentGradesBUS(gv.MSGV, malopmonhoc);
            LoadData(dt, dgvThongTinLop);
        }

        private void GetLecturerClassInfo()
        {
            
            GiangVien_BUS gvBUS = new GiangVien_BUS();
            DataTable dt = new DataTable();
            dt = gvBUS.GetClassListBUS(gv.MSGV);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember= "Ten_Mon_Hoc";
            comboBox1.ValueMember = "Ma_Lop_Mon_Hoc";
            comboBox1.DataSource = dt ;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Chọn mặc định môn đầu tiên
            }
        }
        public void StudentGrades(string msgv,string malopmonhoc)
        {
            DataTable dt = new DataTable();
            GiangVien_BUS gvBUS = new GiangVien_BUS();
            dt =gvBUS.GetStudentGradesBUS(msgv, malopmonhoc);
            dgvThongTinLop.DataSource = dt;
        }

        private void Schedule()
        {
            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            DataTable dt = giangVienBL.GetLecturerScheduleBUS(gv.MSGV);
            LoadData(dt, dgvTKB);
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TabIndex = tabControl.SelectedIndex;
            SinhVien_BUS sinhVienBUS = new SinhVien_BUS();
            DataTable dt = new DataTable();
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
                default:
                    break;
            }
        }

        private void Search(DataGridView dgv, TextBox txt)
        {
            if (dgv.DataSource != null)
            {
                DataTable dt = (DataTable)dgv.DataSource;

                string keyword = txt.Text.Trim().ToLower();

                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    if (dgv == dgvThongTinLop)
                    {
                        string filter = $"[Ten_Day_Du] LIKE '%{keyword}%' ";              
                        dt.DefaultView.RowFilter = filter; ;
                    }
                    if (dgv == dgvTKB)
                    {
                        string filter = $"[Ten_Mon_Hoc] LIKE '%{keyword}%' ";
                        dt.DefaultView.RowFilter = filter; ;
                    }
                }
                dgv.DataSource = dt;
            }
            else MessageBox.Show("Dữ liệu null");
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
            FormDoiMatKhau formDoiMatKhau = new FormDoiMatKhau(gv,tk);
            this.Enabled = false;
            if (formDoiMatKhau.ShowDialog() == DialogResult.OK)
            {
                tk.Pass_word = formDoiMatKhau.newPass; // Cập nhật mật khẩu mới
            }
            this.Enabled = true;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap form = new FormDangNhap();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }


        private void dgvThongTinLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThongTinLop.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvThongTinLop.SelectedRows[0];
                txtMSSV.Text = row.Cells["MSSV"].Value.ToString();
                txtTenSV.Text = row.Cells["Ten_Day_Du"].Value.ToString();
                txtDiemQT.Text = row.Cells["Diem_Qua_Trinh"].Value.ToString();
                txtDiemThi.Text = row.Cells["Diem_Thi"].Value.ToString();
                txtDiemTongKet.Text = row.Cells["Diem_Tong_Ket"].Value.ToString();
                txtHeSoQT.Text = 0.ToString();
            }
        }


        private void UpdateGrade()
        {
            // Kiểm tra xem các giá trị có hợp lệ không
            if (double.TryParse(txtDiemQT.Text, out double diemQT) &&
                double.TryParse(txtDiemThi.Text, out double diemThi) &&
                double.TryParse(txtHeSoQT.Text, out double heSo))
            {
                // Giới hạn hệ số trong khoảng hợp lệ (0 <= heSo <= 1)
                if (heSo < 0 || heSo > 1)
                {
                    MessageBox.Show("Hệ số điểm quá trình phải từ 0 đến 1!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính điểm tổng kết
                double diemTongKet = (diemQT * heSo) + (diemThi * (1 - heSo));

                // Hiển thị kết quả
                txtDiemTongKet.Text = diemTongKet.ToString("0.00");
            }
            else
            {
                // Nếu nhập sai, xóa kết quả
                txtDiemTongKet.Text = "";
            }
        }
        private void txtDiemQT_TextChanged(object sender, EventArgs e)
        {
            UpdateGrade();
        }

        private void txtDiemThi_TextChanged(object sender, EventArgs e)
        {
            UpdateGrade();
        }

        private void txtHeSoQT_TextChanged(object sender, EventArgs e)
        {
            UpdateGrade();
        }

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtDiemQT.Text, out double diemQT))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho Điểm Quá Trình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemQT.Focus();
                return ;
            }

            if (!double.TryParse(txtDiemThi.Text, out double diemThi))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho Điểm Thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemThi.Focus();
                return ;
            }

            if (!double.TryParse(txtDiemTongKet.Text, out double diemTK))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho Điểm Tổng Kết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemTongKet.Focus();
                return ;
            }

            bool check = gvBUS.UpdateStudentGradesBUS(txtMSSV.Text, comboBox1.SelectedValue.ToString(),
                 double.Parse(txtDiemQT.Text), double.Parse(txtDiemThi.Text),
                 double.Parse(txtDiemTongKet.Text));
            if (check) MessageBox.Show("Sủa điểm thành công");
            else MessageBox.Show("Sửa không thành công");
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
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "DiemSinhVien.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Khởi tạo ứng dụng Excel
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                    // Ghi tiêu đề cột
                    for (int i = 0; i < dgvThongTinLop.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvThongTinLop.Columns[i].HeaderText;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }

                    // Ghi dữ liệu từ DataGridView vào Excel
                    for (int i = 0; i < dgvThongTinLop.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvThongTinLop.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvThongTinLop.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Tự động căn chỉnh độ rộng cột
                    worksheet.Columns.AutoFit();

                    // Lưu file
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LopTab_Click(object sender, EventArgs e)
        {

        }
    }
}
