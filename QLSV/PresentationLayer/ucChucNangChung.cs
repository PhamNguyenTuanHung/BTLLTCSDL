﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BusinessLayer;
using DOT;
using PresentationLayer.FormThem;
using PresentationLayer.FrmEdit;
using Excel = Microsoft.Office.Interop.Excel;


namespace PresentationLayer
{
    public partial class ucChucNangChung : UserControl
    {
        private readonly AdminBUS adminBUS;
        private DataTable dt; // Dữ liệu của DataGridView
        private Dictionary<string, List<string>> foreignKeyValues;
        private string keyword;

        private List<string> primaryKeys, foreignKeys;
        public string tableName;

        public ucChucNangChung()
        {
            InitializeComponent();
            adminBUS = new AdminBUS();
            primaryKeys = new List<string>();
            foreignKeys = new List<string>();
        }

        public ucChucNangChung(string TableName)
        {
            InitializeComponent();
        }

        private void LoadComboBox(string TableName)
        {
            tableName = TableName;
            primaryKeys = adminBUS.GetPrimaryKeysBUS(tableName);
            foreignKeys = adminBUS.GetForiegnKeysBUS(tableName);
            foreignKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS(tableName);
            var allValues = new List<string>();

            if (foreignKeyValues == null) return;

            foreach (var key in foreignKeyValues.Keys) allValues.AddRange(foreignKeyValues[key]);

            // Loại bỏ trùng lặp
            allValues = allValues.Distinct().ToList();

            // Thêm dòng "Tất cả" lên đầu
            allValues.Insert(0, "Tất cả");

            // Gán vào ComboBox
            cb.DataSource = allValues;
        }

        //Tải dữ liệu vào dgv
        public void LoadData()
        {
            dt = new DataTable();
            dgv.ClearSelection();
            CreateTableData(tableName);
            dgv.DataSource = dt;
            dgv.ClearSelection();
            LoadComboBox(tableName);
            dgv.ClearSelection();
            if (dt.Columns.Contains("Gioi_Tinh"))
                dgv.Columns["Gioi_Tinh"].HeaderText = "Giới tính";

            if (dt.Columns.Contains("He_So_QT"))
                dgv.Columns["He_So_QT"].HeaderText = "Hệ số quá trình";

            if (dt.Columns.Contains("Ngay_Sinh"))
                dgv.Columns["Ngay_Sinh"].HeaderText = "Ngày Sinh";

            if (dt.Columns.Contains("Dia_Chi"))
                dgv.Columns["Dia_Chi"].HeaderText = "Địa chỉ";

            if (dt.Columns.Contains("Ma_Hoc_Ky"))
                dgv.Columns["Ma_Hoc_Ky"].HeaderText = "Mã học kỳ";

            if (dt.Columns.Contains("Ma_Lich_Thi"))
                dgv.Columns["Ma_Lich_Thi"].HeaderText = "Mã lịch thi";

            if (dt.Columns.Contains("Lan_Thi"))
                dgv.Columns["Lan_Thi"].HeaderText = "Lần thi";

            if (dt.Columns.Contains("Phong_Thi"))
                dgv.Columns["Phong_Thi"].HeaderText = "Phòng thi";

            if (dt.Columns.Contains("Phong_Hoc"))
                dgv.Columns["Phong_Hoc"].HeaderText = "Phòng học";

            if (dt.Columns.Contains("Ma_Khoa"))
                dgv.Columns["Ma_Khoa"].HeaderText = "Mã khoa";

            if (dt.Columns.Contains("Ma_TKB"))
                dgv.Columns["Ma_TKB"].HeaderText = "Mã TKB";

            if (dt.Columns.Contains("Diem_Ren_Luyen"))
                dgv.Columns["Diem_Ren_Luyen"].HeaderText = "Điểm rèn luyện";

            if (dt.Columns.Contains("So_Luong_Dang_Ky_Toi_Da"))
                dgv.Columns["So_Luong_Dang_Ky_Toi_Da"].HeaderText = "Số lượng đăng kí tối đa";

            if (dt.Columns.Contains("Khoa_Hoc"))
                dgv.Columns["Khoa_Hoc"].HeaderText = "Khóa học";

            if (dt.Columns.Contains("Ma_Lop"))
                dgv.Columns["Ma_Lop"].HeaderText = "Mã Lớp";

            if (dt.Columns.Contains("Ho_Ten"))
                dgv.Columns["Ho_Ten"].HeaderText = "Họ tên";

            if (dt.Columns.Contains("Diem_Qua_Trinh"))
                dgv.Columns["Diem_Qua_Trinh"].HeaderText = "Điểm QT";

            if (dt.Columns.Contains("Diem_Thi"))
                dgv.Columns["Diem_Thi"].HeaderText = "Điểm Thi";

            if (dt.Columns.Contains("Diem_Tong_Ket"))
                dgv.Columns["Diem_Tong_Ket"].HeaderText = "Tổng Kết";

            if (dt.Columns.Contains("Ma_Mon_Hoc"))
                dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Mã Môn Học";

            if (dt.Columns.Contains("Ten_Mon_Hoc"))
                dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên Môn Học";

            if (dt.Columns.Contains("Ma_Lop_Mon_Hoc"))
                dgv.Columns["Ma_Lop_Mon_Hoc"].HeaderText = "Mã Lớp Môn Học";

            if (dt.Columns.Contains("Ngay_BD"))
                dgv.Columns["Ngay_BD"].HeaderText = "Ngày Bắt Đầu";

            if (dt.Columns.Contains("Ngay_KT"))
                dgv.Columns["Ngay_KT"].HeaderText = "Ngày Kết Thúc";

            if (dt.Columns.Contains("Ngay_Dang_Ky"))
                dgv.Columns["Ngay_Dang_Ky"].HeaderText = "Ngày Đăng Ký";

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


            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
        }


        public static T ConvertDataGridViewRowToObject<T>(DataGridViewRow row) where T : new()
        {
            var obj = new T();
            foreach (DataGridViewCell cell in row.Cells)
            {
                // Tìm thuộc tính trong lớp T dựa trên tên cột
                var prop = typeof(T).GetProperty(cell.OwningColumn.Name.Replace("_", ""),
                    BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && cell.Value != null && cell.Value != DBNull.Value)
                {
                    var value = cell.Value;

                    // Nếu là kiểu Nullable, lấy kiểu gốc
                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    // Chuyển đổi kiểu dữ liệu chính xác
                    var safeValue = Convert.ChangeType(value, targetType);
                    prop.SetValue(obj, safeValue);
                }
            }

            return obj;
        }

        public static T ConvertDGVRowToObject<T>(DataGridViewRow dgvrow) where T : new()
        {
            var obj = new T();
            foreach (DataGridViewCell cell in dgvrow.Cells)
            {
                var prop = typeof(T).GetProperty(cell.OwningColumn.Name.Replace("_", ""),
                    BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && cell.Value != DBNull.Value)
                {
                    var value = cell.Value;

                    // Nếu là kiểu Nullable, ta phải lấy kiểu gốc
                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    // Chuyển đổi kiểu dữ liệu chính xác
                    var safeValue = Convert.ChangeType(value, targetType);
                    prop.SetValue(obj, safeValue);
                }
            }

            return obj;
        }


        //Đổ dữ liệu từ DB vào datatable
        private void CreateTableData(string tenBang)
        {
            switch (tenBang)
            {
                case "SinhVien":
                    dt = adminBUS.GetStudentsListBUS();
                    break;
                case "GiangVien":
                    dt = adminBUS.GetLecturersListBUS();
                    break;
                case "MonHoc":
                    dt = adminBUS.GetSubjectsListBUS();
                    break;
                case "LopMonHoc":
                    dt = adminBUS.GetClassListBUS();
                    break;
                case "ThoiKhoaBieu":
                    dt = adminBUS.GetScheduleBUS();
                    break;
                case "LichThi":
                    dt = adminBUS.GetExamScheduleBUS();
                    break;
                case "Diem":
                    dt = adminBUS.GetStudentGradesBUS();
                    break;
                case "TaiKhoan":
                    dt = adminBUS.GetAccountListBUS();
                    break;
                case "MonMoDangKy":
                    dt = adminBUS.GetAllRegisteredCoursesBUS();
                    break;
                case "Lop":
                    dt = adminBUS.GetClassBUS();
                    break;
                case "Khoa":
                    dt = adminBUS.GetDepartmentsBUS();
                    break;
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                var keyword = txtTimKiem.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu không có từ khóa tìm kiếm, xóa bộ lọc
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Duyệt qua tất cả các cột trong DataTable để tìm kiếm
                    var filterExpression = string.Join(" OR ", dt.Columns.Cast<DataColumn>()
                        .Where(c => c.DataType == typeof(string)) // Tìm kiếm chỉ trên các cột kiểu chuỗi
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
            }
            else
            {
                MessageBox.Show("Chưa chọn cột tìm kiếm hoặc chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            switch (tableName)
            {
                case "GiangVien":
                    new FormEditGiangVien(null, 1).ShowDialog();
                    ;
                    break;
                case "SinhVien":
                    new FormEditSinhVien(null, 1).ShowDialog();
                    break;
                case "MonHoc":
                    new FormEditMonHoc(null, 1).ShowDialog();
                    break;
                case "LopMonHoc":
                    new FormEditLopMonHoc(null, 1).ShowDialog();
                    break;
                case "ThoiKhoaBieu":
                    new FormEditThoiKhoaBieu(null, 1).ShowDialog();
                    break;
                case "Diem":
                    new FormEditDiem(null, 1).ShowDialog();
                    break;
                case "LichThi":
                    new FormEditLichThi(null, 1).ShowDialog();
                    break;
                case "TaiKhoan":
                    new FormThemTaiKhoan(null, 1).ShowDialog();
                    break;
                case "MonMoDangKy":
                    new FormEditMonMoDangKy(null, 1).ShowDialog();
                    break;
                case "Lop":
                    new FormEditLop(null, 1).ShowDialog();
                    break;
                case "Khoa":
                    new FormEditKhoa(null, 1).ShowDialog();
                    break;
            }

            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                // Lấy thông tin dòng đã chọn
                var row = dgv.SelectedRows[0];

                switch (tableName)
                {
                    case "GiangVien":
                        var giangVien = ConvertDataGridViewRowToObject<GiangVien>(row);
                        new FormEditGiangVien(giangVien, 0).ShowDialog();
                        break;
                    case "SinhVien":
                        var sinhVien = ConvertDataGridViewRowToObject<SinhVien>(row);
                        new FormEditSinhVien(sinhVien, 0).ShowDialog();
                        break;
                    case "MonHoc":
                        var monHoc = ConvertDataGridViewRowToObject<MonHoc>(row);
                        new FormEditMonHoc(monHoc, 0).ShowDialog();
                        break;
                    case "LopMonHoc":
                        var lopMonHoc = ConvertDataGridViewRowToObject<LopMonHoc>(row);
                        new FormEditLopMonHoc(lopMonHoc, 0).ShowDialog();
                        break;
                    case "ThoiKhoaBieu":
                        var thoiKhoaBieu = ConvertDataGridViewRowToObject<ThoiKhoaBieu>(row);
                        new FormEditThoiKhoaBieu(thoiKhoaBieu, 0).ShowDialog();
                        break;
                    case "Diem":
                        var diemSV = ConvertDataGridViewRowToObject<DiemSV>(row);
                        new FormEditDiem(diemSV, 0).ShowDialog();
                        break;
                    case "LichThi":
                        var lichThi = ConvertDataGridViewRowToObject<LichThi>(row);
                        new FormEditLichThi(lichThi, 0).ShowDialog();
                        break;
                    case "TaiKhoan":
                        var taiKhoan = ConvertDataGridViewRowToObject<TaiKhoan>(row);
                        new FormThemTaiKhoan(taiKhoan, 0).ShowDialog();
                        break;
                    case "MonMoDangKy":
                        var monMoDangKy = new MonMoDangKy();
                        monMoDangKy = ConvertDGVRowToObject<MonMoDangKy>(row);
                        new FormEditMonMoDangKy(monMoDangKy, 0).ShowDialog();
                        break;
                    case "Lop":
                        var lop = new Lop();
                        lop = ConvertDGVRowToObject<Lop>(row);
                        new FormEditLop(lop, 0).ShowDialog();
                        break;
                    case "Khoa":
                        var khoa = new Khoa();
                        khoa = ConvertDGVRowToObject<Khoa>(row);
                        new FormEditKhoa(khoa, 0).ShowDialog();
                        break;
                }

                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var check = false;
                if (MessageBox.Show("Bạn muốn xóa", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (dgv.SelectedRows.Count > 0)
                    {
                        var row = dgv.SelectedRows[0];
                        {
                            switch (tableName)
                            {
                                case "GiangVien":
                                    var gv = new GiangVien();
                                    gv = ConvertDGVRowToObject<GiangVien>(row);
                                    check = adminBUS.DeleteLecturerBUS(gv.MSGV);
                                    break;
                                case "SinhVien":
                                    var sv = new SinhVien();
                                    sv = ConvertDGVRowToObject<SinhVien>(row);
                                    check = adminBUS.DeleteStudentBUS(sv.MSSV);
                                    break;
                                case "MonHoc":
                                    var mh = new MonHoc();
                                    mh = ConvertDGVRowToObject<MonHoc>(row);
                                    check = adminBUS.DeleteCourseBUS(mh.MaMonHoc);
                                    break;
                                case "LopMonHoc":
                                    var lopMonHoc = new LopMonHoc();
                                    lopMonHoc = ConvertDGVRowToObject<LopMonHoc>(row);
                                    check = adminBUS.DeleteCourseClassBUS(lopMonHoc.MaLopMonHoc);
                                    break;
                                case "ThoiKhoaBieu":
                                    var tkb = new ThoiKhoaBieu();
                                    tkb = ConvertDGVRowToObject<ThoiKhoaBieu>(row);
                                    check = adminBUS.DeleteScheduleBUS(tkb.MaTKB.ToString());
                                    break;
                                case "Diem":
                                    var diemSV = new DiemSV();
                                    diemSV = ConvertDGVRowToObject<DiemSV>(row);
                                    check = adminBUS.DeleteGradeBUS(diemSV.MSSV, diemSV.MaHocKy, diemSV.MaMonHoc);
                                    break;
                                case "LichThi":
                                    var lichThi = new LichThi();
                                    lichThi = ConvertDGVRowToObject<LichThi>(row);
                                    check = adminBUS.DeleteExamScheduleBUS(lichThi.MaLichThi);

                                    break;
                                case "TaiKhoan":
                                    var taiKhoan = new TaiKhoan();
                                    taiKhoan = ConvertDGVRowToObject<TaiKhoan>(row);

                                    check = adminBUS.DeleteAccountBUS(taiKhoan.TenDangNhap);
                                    break;
                                case "MonMoDangKy":
                                    var monMoDangKy = new MonMoDangKy();
                                    monMoDangKy = ConvertDGVRowToObject<MonMoDangKy>(row);
                                    check = adminBUS.DeleteCourseFromRegistrationDAL(monMoDangKy.MaLopMo);
                                    break;
                                case "Lop":
                                    var lop = new Lop();
                                    lop = ConvertDGVRowToObject<Lop>(row);
                                    check = adminBUS.DeleteClassBUS(lop.MaLop);
                                    break;
                                case "Khoa":
                                    var khoa = new Khoa();
                                    khoa = ConvertDGVRowToObject<Khoa>(row);
                                    check = adminBUS.DeleteDepartmentBUS(khoa.MaKhoa);
                                    break;
                            }

                            LoadData();
                            if (check) MessageBox.Show("Xóa thành công");
                            else MessageBox.Show("Xóa thất bại");
                        }
                    }
                    else
                    {
                        return;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Mở hộp thoại lưu file
            var sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "new.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
                try
                {
                    // Khởi tạo ứng dụng Excel
                    var excelApp = new Excel.Application();
                    var workbook = excelApp.Workbooks.Add();
                    var worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                    // Ghi tiêu đề cột
                    for (var i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Interior.Color =
                            ColorTranslator.ToOle(Color.LightGray);
                    }

                    // Ghi dữ liệu từ DataGridView vào Excel
                    for (var i = 0; i < dgv.Rows.Count; i++)
                    for (var j = 0; j < dgv.Columns.Count; j++)
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();

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

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void FilterDataGridView(string keyword, DataGridView dgv, List<string> columnNames)
        {
            if (dgv.DataSource != null)
            {
                var dt = (DataTable)dgv.DataSource;

                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                if (keyword == "0")
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Tạo một danh sách các điều kiện lọc cho mỗi cột
                    var filter = string.Join(" OR ", columnNames.Select(col => $"[{col}] LIKE '%{keyword}%'"));

                    // Áp dụng filter vào DataTable
                    dt.DefaultView.RowFilter = filter;
                }

                dgv.DataSource = dt;
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == 0)
            {
                keyword = "0";
                return;
            }

            keyword = cb.SelectedValue.ToString();
            FilterDataGridView(keyword, dgv, foreignKeys);
        }
    }
}