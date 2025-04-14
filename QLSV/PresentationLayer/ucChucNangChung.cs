using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessLayer;
using DOT;
using Excel = Microsoft.Office.Interop.Excel;


namespace PresentationLayer
{
    public partial class ucChucNangChung : UserControl
    {
        private DataTable dt; // Dữ liệu của DataGridView
        public string tenTabPage { get; set; }//Nhận tên tab của form Admin

        List<string> primaryKeys,foriegnKeys, foriegnKeyValues;

        string tableName;

        private AdminBUS adminBUS;

        private object obj;
        string keyword;

        public ucChucNangChung()
        {
            InitializeComponent();
        }

        public ucChucNangChung(string TableName)
        {
            InitializeComponent();
            this.tableName =TableName;
            primaryKeys = new List<string>();
            foriegnKeys = new List<string>();
            adminBUS = new AdminBUS();
            this.primaryKeys = adminBUS.GetPrimaryKeysBUS(tableName);
            this.foriegnKeys= adminBUS.GetForiegnKeysBUS(tableName);
            this.foriegnKeyValues= adminBUS.GetForeignKeyValuesBUS(foriegnKeys,tableName);
            LoadComboBox();

        }


        private void LoadComboBox()
        {
            cb.DataSource = foriegnKeyValues;
        }
        //Tải dữ liệu vào dgv
        public void LoadData()
        {
            dt = new DataTable();
            CreateTableData(tenTabPage);
            dgv.ClearSelection();
            dgv.DataSource = dt;
            if (dt.Columns.Contains("Gioi_Tinh"))
                dgv.Columns["Gioi_Tinh"].HeaderText = "Giới tính";

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

            if (dt.Columns.Contains("So_Luong_DK_Toi_Da"))
                dgv.Columns["So_Luong_DK_Toi_Da"].HeaderText = "SL tối đa";

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
                dgv.Columns["Ma_Lop_Mon_Hoc"].HeaderText = "Mã Nhóm Học";

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
            btnLuu.Visible = false;
            btnThoat.Visible = false;

        }

        //Hiển thị các control theo nút Sửa
        private void DisplayControl()
        {
            foreach (Control control in panel2.Controls)
            {
                control.Visible = !control.Visible;
            }
            dgv.ReadOnly = !dgv.ReadOnly;

            dgv.SelectionMode = dgv.SelectionMode == DataGridViewSelectionMode.CellSelect
                    ? DataGridViewSelectionMode.FullRowSelect
                    : DataGridViewSelectionMode.CellSelect;

        }


        public static List<T> ConvertDataTableToList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();
                foreach (DataColumn column in dataTable.Columns)
                {
                    PropertyInfo prop = typeof(T).GetProperty(column.ColumnName.Replace("_", ""), BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null && row[column] != DBNull.Value)
                    {
                        object value = row[column];

                        // Nếu là kiểu Nullable, ta phải lấy kiểu gốc
                        Type targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                        // Chuyển đổi kiểu dữ liệu chính xác
                        object safeValue = Convert.ChangeType(value, targetType);
                        prop.SetValue(obj, safeValue);
                    }
                }
                list.Add(obj);
            }
            return list;

        }


        public static T ConvertDataGridViewRowToObject<T>(DataGridViewRow row) where T : new()
        {
            T obj = new T();
            foreach (DataGridViewCell cell in row.Cells)
            {
                // Tìm thuộc tính trong lớp T dựa trên tên cột
                PropertyInfo prop = typeof(T).GetProperty(cell.OwningColumn.Name.Replace("_", ""), BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && cell.Value != null && cell.Value != DBNull.Value)
                {
                    object value = cell.Value;

                    // Nếu là kiểu Nullable, lấy kiểu gốc
                    Type targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    // Chuyển đổi kiểu dữ liệu chính xác
                    object safeValue = Convert.ChangeType(value, targetType);
                    prop.SetValue(obj, safeValue);
                }
            }
            return obj;
        }

        public static T ConvertDGVRowToObject<T>(DataGridViewRow dgvrow) where T : new()
        {
            T obj = new T();
            foreach (DataGridViewCell cell in dgvrow.Cells)
            {
                PropertyInfo prop = typeof(T).GetProperty(cell.OwningColumn.Name.Replace("_", ""), BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && cell.Value != DBNull.Value)
                {
                    object value = cell.Value;

                    // Nếu là kiểu Nullable, ta phải lấy kiểu gốc
                    Type targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    // Chuyển đổi kiểu dữ liệu chính xác
                    object safeValue = Convert.ChangeType(value, targetType);
                    prop.SetValue(obj, safeValue);
                }
            }
            return obj;
        }


        //Đổ dữ liệu từ DB vào datatable
        private void CreateTableData(string tenBang)
        {
            adminBUS = new AdminBUS();
            switch (tenBang)
            {
                case "tpSV":
                    dt = adminBUS.GetStudentsListBUS();
                    break;
                case "tpGV":
                    dt = adminBUS.GetLecturersListBUS();
                    break;
                case "tpMH":
                    dt = adminBUS.GetSubjectsListBUS();
                    break;
                case "tpLopMonHoc":
                    dt = adminBUS.GetClassListBUS();
                    break;
                case "tpTKB":
                    dt = adminBUS.GetScheduleBUS();
                    break;
                case "tpLichThi":
                    dt = adminBUS.GetExamScheduleBUS();
                    break;
                case "tpDiem":
                    dt = adminBUS.GetStudentGradesBUS();
                    break;
                case "tpTK":
                    dt = adminBUS.GetAccountListBUS();
                    break;
                default:
                    break;
            }
        }
        private void btnTK_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();


                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = $"[{dt.Columns[0].ColumnName}] LIKE '%{keyword}%' OR [{dt.Columns[1].ColumnName}] LIKE '%{keyword}%' ";
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn cột tìm kiếm hoặc chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            switch (tenTabPage)
            {
                case "tpGV":
                    FormThemGiangVien formThemGiangVien = new FormThemGiangVien(null, 1);
                    formThemGiangVien.ShowDialog();
                    break;
                case "tpSV":
                    FormThemSinhVien formThemSinhVien = new FormThemSinhVien(null, 1);
                     formThemSinhVien.ShowDialog();
                    break;
                case "tpMH":
                    new FormThemChung(new MonHoc()).ShowDialog();
                    break;
                case "tpLopMonHoc":
                    new FormThemChung(new LopMonHoc()).ShowDialog();
                    break;
                case "tpTKB":
                    new FormThemChung(new ThoiKhoaBieu()).ShowDialog();
                    break;
                case "tpDiem":
                    new FormThemChung(new DiemSV()).ShowDialog();
                    break;
                case "tpLichThi":
                    new FormThemChung(new LichThi()).ShowDialog();
                    break;
                case "tpTK":
                    new FormThemChung(new TaiKhoan()).ShowDialog();
                    break;
                default:
                    break;
            }
            LoadData();
        }

        public static void ShowStudentDetails(SinhVien sinhVien)
        {
            Console.WriteLine("MSSV: " + sinhVien.MSSV);
            Console.WriteLine("Họ tên: " + sinhVien.HoTen);
            Console.WriteLine("Giới tính: " + sinhVien.GioiTinh);
            Console.WriteLine("Ngày sinh: " + sinhVien.NgaySinh.ToShortDateString());
            Console.WriteLine("Email: " + sinhVien.Email);
            Console.WriteLine("Địa chỉ: " + sinhVien.DiaChi);
            Console.WriteLine("Khóa học: " + sinhVien.KhoaHoc);
            Console.WriteLine("Điểm rèn luyện: " + sinhVien.DiemRenLuyen);
            Console.WriteLine("Mã lớp: " + sinhVien.MaLop);
            Console.WriteLine("Ảnh: " + (sinhVien.Anh != null ? "Có ảnh" : "Không có ảnh"));
            Console.WriteLine("-----------------------------------");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            /*DisplayControl();
            
            // Khóa cột khóa chính (MSGV)
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (primaryKeys.Contains(col.Name))
                {
                    col.ReadOnly = true;
                }
            }*/

            if (dgv.SelectedRows.Count > 0)
            {
                // Lấy thông tin dòng đã chọn
                var row = dgv.SelectedRows[0];

                switch (tenTabPage)
                {
                    case "tpGV":
                        GiangVien giangVien = ConvertDataGridViewRowToObject<GiangVien>(row);
                        new FormThemGiangVien(giangVien, 0).ShowDialog();
                        break;
                    case "tpSV":
                        SinhVien sinhVien = ConvertDataGridViewRowToObject<SinhVien>(row);
                        new FormThemSinhVien(sinhVien, 0).ShowDialog();
                        break;
                    case "tpMH":
                        new FormThemChung(new MonHoc()).ShowDialog();
                        break;
                    case "tpLopMonHoc":
                        new FormThemChung(new LopMonHoc()).ShowDialog();
                        break;
                    case "tpTKB":
                        new FormThemChung(new ThoiKhoaBieu()).ShowDialog();
                        break;
                    case "tpDiem":
                        new FormThemChung(new DiemSV()).ShowDialog();
                        break;
                    case "tpLichThi":
                        new FormThemChung(new LichThi()).ShowDialog();
                        break;
                    case "tpTK":
                        new FormThemChung(new TaiKhoan()).ShowDialog();
                        break;
                    default:
                        break;
                }
            LoadData();
            }


        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                if (MessageBox.Show("Bạn muốn xóa", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)

                {
                    switch (tenTabPage)
                    {
                        case "tpGV":
                            GiangVien gv = new GiangVien();
                            gv = ConvertDGVRowToObject<GiangVien>(dgv.CurrentRow);
                            check = adminBUS.DeleteLecturer(gv.MSGV);
                            break;
                        case "tpSV":
                            SinhVien sv = new SinhVien();
                            sv = ConvertDGVRowToObject<SinhVien>(dgv.CurrentRow);
                            check = adminBUS.DeleteStudent(sv.MSSV);
                            break;
                        case "tpMH":
                            MonHoc mh = new MonHoc();
                            mh = ConvertDGVRowToObject<MonHoc>(dgv.CurrentRow);
                            check = adminBUS.DeleteCourse(mh.MaMonHoc);
                            break;
                        case "tpLopMonHoc":
                            LopMonHoc lopMonHoc = new LopMonHoc();
                            lopMonHoc = ConvertDGVRowToObject<LopMonHoc>(dgv.CurrentRow);
                            check = adminBUS.DeleteCourseClass(lopMonHoc.MaLopMonHoc);
                            break;
                        case "tpTKB":
                            ThoiKhoaBieu tkb = new ThoiKhoaBieu();
                            tkb = ConvertDGVRowToObject<ThoiKhoaBieu>(dgv.CurrentRow);
                            check = adminBUS.DeleteSchedule(tkb.MaTKB);
                            break;
                        case "tpDiem":
                            DiemSV diemSV = new DiemSV();
                            diemSV = ConvertDGVRowToObject<DiemSV>(dgv.CurrentRow);
                            check = adminBUS.DeleteGrade(diemSV.MSSV, diemSV.MaHocKy, diemSV.MaMonHoc);
                            break;
                        case "tpLichThi":
                            LichThi lichThi = new LichThi();
                            lichThi = ConvertDGVRowToObject<LichThi>(dgv.CurrentRow);
                            check = adminBUS.DeleteExamSchedule(lichThi.MaLichThi);

                            break;
                        case "tpTK":
                            TaiKhoan taiKhoan = new TaiKhoan();
                            taiKhoan = ConvertDGVRowToObject<TaiKhoan>(dgv.CurrentRow);
                            check = adminBUS.DeleteAccountBUS(taiKhoan.TenDangNhap);
                            break;
                    }
                    LoadData();
                    if (check) MessageBox.Show("Xóa thành công");
                    else MessageBox.Show("Xóa thất bại");
                }
                else return;
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
            SaveFileDialog sfd = new SaveFileDialog
            {

                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "new.xlsx"
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
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }

                    // Ghi dữ liệu từ DataGridView vào Excel
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
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

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                btnXoa.Enabled= true;
            }
            else btnXoa.Enabled = false;
        }

        private bool UpdateValuesData(string tenBang)       
        {
            adminBUS = new AdminBUS();
            switch (tenTabPage)
            {
                case "tpGV":
                    List<GiangVien> gvs = ConvertDataTableToList<GiangVien>(dt);
                    foreach (GiangVien gv in gvs)
                        adminBUS.UpdateLecturerBUS(gv);
                    break;

                case "tpSV":
                    List<SinhVien> svs = ConvertDataTableToList<SinhVien>(dt);
                    foreach (SinhVien sv in svs)
                        adminBUS.UpdateStudentBUS(sv);
                    break;

                case "tpMH":
                    List<MonHoc> mhs = ConvertDataTableToList<MonHoc>(dt);
                    foreach (MonHoc mh in mhs)
                        adminBUS.UpdateCourseBUS(mh);
                    break;

                case "tpLopMonHoc":
                    List<LopMonHoc> lmhs = ConvertDataTableToList<LopMonHoc>(dt);
                    foreach (LopMonHoc lmh in lmhs)
                        adminBUS.UpdateCourseClassBUS(lmh);
                    break;

                case "tpTKB":
                    List<ThoiKhoaBieu> tkbs = ConvertDataTableToList<ThoiKhoaBieu>(dt);
                    foreach (ThoiKhoaBieu tkb in tkbs)
                        adminBUS.UpdateScheduleBUS(tkb);
                    break;

                case "tpDiem":
                    List<DiemSV> diems = ConvertDataTableToList<DiemSV>(dt);
                    foreach (DiemSV diem in diems)
                        adminBUS.UpdateGradeBUS(diem);
                    break;

                case "tpLichThi":
                    List<LichThi> lts = ConvertDataTableToList<LichThi>(dt);
                    foreach (LichThi lt in lts)
                        adminBUS.UpdateExamScheduleBUS(lt);
                    break;
            }
            MessageBox.Show("Sửa thành công");
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateValuesData(tenTabPage))
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu những thay đổi", "Lưu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DisplayControl();
                    }
                }
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void FilterDataGridView(string keyword, DataGridView dgv, List<string> columnNames)
        {
            if (dgv.DataSource != null)
            {
                DataTable dt = (DataTable)dgv.DataSource;

                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                if (keyword == "0")
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {

                    // Tạo một danh sách các điều kiện lọc cho mỗi cột
                    string filter = string.Join(" OR ", columnNames.Select(col => $"[{col}] LIKE '%{keyword}%'"));

                    // Áp dụng filter vào DataTable
                    dt.DefaultView.RowFilter = filter;
                }
                dgv.DataSource = dt;
            }
        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyword = cb.SelectedValue.ToString();
            FilterDataGridView(keyword, dgv, foriegnKeys);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DisplayControl();
        }
    }
}
