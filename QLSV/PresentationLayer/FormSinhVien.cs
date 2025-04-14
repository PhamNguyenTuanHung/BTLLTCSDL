using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DOT;
using System.IO;

namespace PresentationLayer
{
    public partial class FormSinhVien : Form
    {
        private SinhVien sinhVien;
        private SinhVienBUS sVBus;
        private TaiKhoan taiKhoan;
        List<string> ThemMonDK, XoaMonDk;
        private string maHocKyTKB,maHocKyDiem;

        public FormSinhVien(SinhVien sinhvien, TaiKhoan taikhoan)
        {
            InitializeComponent();
            sinhVien = sinhvien;
            taiKhoan = taikhoan;
            ThongTinSVPL();
            LoadComboBoxSemester(); 
        }

        //Thêm thông tin cho các combox Học kì
        private void LoadComboBoxSemester()
        {
            DataTable dt = new DataTable();
            dt = sVBus.GetSemesterBUS();
            //thêm hàng tất cả để bỏ lọc
            DataRow dr = dt.NewRow();
            dr["Ma_Hoc_Ky"] = 0;
            dr["Ten_Hoc_Ky"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);


            // GỠ SỰ KIỆN TRƯỚC KHI GÁN DATASOURCE
            cbHocKyDiem.SelectedIndexChanged -= cbHocKyDiem_SelectedIndexChanged;

            cbHocKyDiem.DataSource = dt.Copy();
            cbHocKyDiem.DisplayMember = "Ten_Hoc_Ky";
            cbHocKyDiem.ValueMember = "Ma_Hoc_Ky";
            cbHocKyDiem.SelectedValue=0;
            maHocKyDiem = cbHocKyDiem.SelectedValue.ToString();


            // GẮN LẠI SAU KHI HOÀN TẤT
            cbHocKyDiem.SelectedIndexChanged += cbHocKyDiem_SelectedIndexChanged;
            // ComboBox thứ 2 tương tự
            cbHocKyTKB.SelectedIndexChanged -= cbHocKyTKB_SelectedIndexChanged;

            cbHocKyTKB.DataSource = dt.Copy();
            cbHocKyTKB.DisplayMember = "Ten_Hoc_Ky";
            cbHocKyTKB.ValueMember = "Ma_Hoc_Ky";
            cbHocKyTKB.SelectedValue = 0;
            maHocKyTKB = cbHocKyTKB.SelectedValue.ToString();

            cbHocKyTKB.SelectedIndexChanged += cbHocKyTKB_SelectedIndexChanged;

        }
        private void ThongTinSVPL()
        {
            sVBus = new SinhVienBUS();
            DataTable dt = sVBus.GetStudentInfoTableBUS(sinhVien.MSSV);
            if (dt != null && dt.Rows.Count > 0) // Kiểm tra nếu có dữ liệu
            {
                lbMSSV.Text = dt.Rows[0]["MSSV"].ToString();
                lbHoTen.Text = dt.Rows[0]["Ho_Ten"].ToString();
                lbEmail.Text = dt.Rows[0]["Email"].ToString();
                lbNgaySinh.Text = Convert.ToDateTime(dt.Rows[0]["Ngay_Sinh"]).ToString("dd/MM/yyyy"); // Định dạng ngày
                lbDRL.Text = dt.Rows[0]["Diem_Ren_Luyen"].ToString();
                lbKhoaHoc.Text = dt.Rows[0]["Khoa_Hoc"].ToString();
                lbLop.Text = dt.Rows[0]["Ma_Lop"].ToString();
                lbKhoa.Text = dt.Rows[0]["Ten_Khoa"].ToString();
                lbGioiTinh.Text = dt.Rows[0]["Gioi_Tinh"].ToString();
                if (dt.Rows[0]["Anh"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])dt.Rows[0]["Anh"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbAnhSV.Image = Image.FromStream(ms);
                    }
                }
                else pbAnhSV.Image = null;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sinh viên!");
            }

        }

        private void Search(DataGridView dgv,TextBox txt)
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
                    string filter = $"[Ten_Mon_Hoc] LIKE '%{keyword}%'";
                    dt.DefaultView.RowFilter = filter; ;
                }
                dgv.DataSource = dt;
            }
            else MessageBox.Show("Dữ liệu null");
        }

        //hàm load dữ liệu cho các tab
        private void LoadData(DataGridView dgv, DataTable dt)
        {
            if (dt != null && dt.Columns.Count > 0)
            {
                dgv.DataSource = dt;

                //đặt tên cho các cột
                if (dt.Columns.Contains("Phong_Thi"))
                    dgv.Columns["Phong_Thi"].HeaderText = "Phòng thi";

                if (dt.Columns.Contains("Ten_Mon_Hoc"))
                    dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên môn học";

                if (dt.Columns.Contains("Ten_Day_Du"))
                    dgv.Columns["Ten_Day_Du"].HeaderText = "Họ tên";

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

            }
            //Cài dặt hiển thị cho dgv
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
        }
        private void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TabIndex = TabMain.SelectedIndex;
            DataTable dt = new DataTable();
            switch (TabIndex)
            {

                case 0:
                    ThongTinSVPL();
                    break;
                case 1:
                    dt =sVBus.GetStudentGradesBUS(sinhVien.MSSV);
                    LoadData(dgvDiem,dt);
                    FilterDataGridView(maHocKyDiem, dgvDiem, "Ma_Hoc_Ky");
                    break;
                case 2:
                    dt = sVBus.GetStudentScheduleBUS(sinhVien.MSSV);
                    LoadData(dgvTKB,dt);
                    FilterDataGridView(maHocKyTKB, dgvTKB, "Ma_Hoc_Ky");
                    break;
                case 3:
                    dt = sVBus.GetExamScheduleBUS(sinhVien.MSSV);
                    LoadData(dgvLichThi, dt);
                    break;
                case 4:
                    dt = sVBus.GetAvailableCoursesBUS();
                    dt.Columns.Add("Chon", typeof(bool));
                    DataTable dt1= new DataTable();
                    dt1=sVBus.GetRegisteredCoursesBUS(sinhVien.MSSV);

                    foreach (DataRow row in dt.Rows)
                    {
                        string MaLopMonHoc = row["Ma_Lop_Mon_Hoc"].ToString();

                        // Kiểm tra xem môn học này có trong danh sách đã đăng ký không
                        bool isRegistered = dt1.AsEnumerable().Any(r => r["Ma_Lop_Mon_Hoc"].ToString() == MaLopMonHoc);

                        // Nếu có, set giá trị của cột checkbox thành true
                        if (isRegistered)
                        {
                            row["Chon"] = true;
                        }
                    }
                    LoadData(dgvDSMonDK, dt);
                    LoadData(dgvMonDK, dt1);
                    break;
                default:
                    break;
            }

        }

        List<string> danhSachDangKy = new List<string>();
        List<string> danhSachHuyDangKy = new List<string>();

        private void dgvDSMonDK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvDSMonDK.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)) return;
            dgvDSMonDK.EndEdit(); // Cập nhật trạng thái ngay lập tức

            bool isChecked = Convert.ToBoolean(dgvDSMonDK.Rows[e.RowIndex].Cells["Chon"].Value);
            string MaLopMonHoc = dgvDSMonDK.Rows[e.RowIndex].Cells["Ma_Lop_Mon_Hoc"].Value?.ToString();
            string TenMonHoc = dgvDSMonDK.Rows[e.RowIndex].Cells["Ten_Mon_Hoc"].Value?.ToString();
            int SoTinChi = Convert.ToInt32(dgvDSMonDK.Rows[e.RowIndex].Cells["So_Tin_Chi"].Value);

            // Nếu đã check 
            if (isChecked)
            {
                //Nếu chưa có trong danh sách đăng kí
                if (!danhSachDangKy.Contains(MaLopMonHoc))
                {
                    danhSachDangKy.Add(MaLopMonHoc);
                    danhSachHuyDangKy.Remove(MaLopMonHoc);
                }

                //Kiểm tra coi datagridview Môn đăng kí có dữ liệu chưa
                DataTable dt = (DataTable)dgvMonDK.DataSource ?? new DataTable();
                // Nếu chưa
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("Ma_Lop_Mon_Hoc", typeof(string));
                    dt.Columns.Add("Ten_Mon_Hoc", typeof(string));
                    dt.Columns.Add("Ngay_Dang_Ky", typeof(DateTime));
                    dt.Columns.Add("So_Tin_Chi", typeof(int));
                }
                // kiểm tra có môn này trong bảng chưa
                bool isExist = dt.AsEnumerable().Any(row => row["Ma_Lop_Mon_Hoc"].ToString() == MaLopMonHoc);
                // Thêm vào dgv nếu chưa có
                if (!isExist)
                {
                    // thêm vào dgv
                    dt.Rows.Add(MaLopMonHoc, TenMonHoc, DateTime.Now.ToString("yyyy-MM-dd"), SoTinChi);
                    dgvMonDK.DataSource = dt;
                }
            }
            // Nếu không check
            else
            {
                //Kiểm tra có trong danh sách hủy đăng kí chưa
                if (!danhSachHuyDangKy.Contains(MaLopMonHoc))
                {
                    danhSachHuyDangKy.Add(MaLopMonHoc);
                    danhSachDangKy.Remove(MaLopMonHoc);
                }

                //tương tự như trên
                DataTable dt = (DataTable)dgvMonDK.DataSource;
                if (dt != null)
                {
                    // xóa các môn ra khỏi bảng
                    DataRow rowToDelete = dt.AsEnumerable().FirstOrDefault(row => row["Ma_Lop_Mon_Hoc"].ToString() == MaLopMonHoc);
                    if (rowToDelete != null)
                    {
                        dt.Rows.Remove(rowToDelete);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string maLop in danhSachDangKy)
                {
                    sVBus.RegisterCourseBUS(sinhVien.MSSV, maLop, DateTime.Now);
                }

                foreach (string maLop in danhSachHuyDangKy)
                {
                    sVBus.UnregisterCourseBUS(sinhVien.MSSV, maLop);
                }

                MessageBox.Show("Cập nhật đăng ký môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = sVBus.GetAvailableCoursesBUS();
                dt.Columns.Add("Chon", typeof(bool));
                DataTable dt1 = new DataTable();
                dt1 = sVBus.GetRegisteredCoursesBUS(sinhVien.MSSV);

                foreach (DataRow row in dt.Rows)
                {
                    string MaLopMonHoc = row["Ma_Lop_Mon_Hoc"].ToString();

                    // Kiểm tra xem môn học này có trong danh sách đã đăng ký không
                    bool isRegistered = dt1.AsEnumerable().Any(r => r["Ma_Lop_Mon_Hoc"].ToString() == MaLopMonHoc);

                    // Nếu có, set giá trị của cột checkbox thành true
                    if (isRegistered)
                    {
                        row["Chon"] = true;
                    }
                }
                LoadData(dgvDSMonDK, dt);
                LoadData(dgvMonDK, dt1);
                danhSachDangKy.Clear();
                danhSachHuyDangKy.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); 
            }
            
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau form = new FormDoiMatKhau(sinhVien, taiKhoan);
            if (form.ShowDialog() == DialogResult.OK)
            {
                taiKhoan.MatKhau = form.newPass; // Cập nhật mật khẩu mới
            }

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form form = new FormDangNhap();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void btnTimKiemTKB_Click(object sender, EventArgs e)
        {
            Search(dgvTKB,txtTimKiemTKB);
        }

        private void btnTimKiemDiem_Click(object sender, EventArgs e)
        {
            Search(dgvDiem, txtTimKiemDiem);
        }

        private void btnTimKiemLichThi_Click(object sender, EventArgs e)
        {
            Search(dgvLichThi, txtTimKiemLichThi);
        }
        private void btnTimKiemMonDangKi_Click(object sender, EventArgs e)
        {
            Search(dgvDSMonDK, txtTimKiemMonDK);
        }

        private void FilterDataGridView(string keyword, DataGridView dgv, string columnName)
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
                    string filter = $"[{columnName}] LIKE '%{keyword}%'";
                    dt.DefaultView.RowFilter = filter; ;
                }
                dgv.DataSource = dt;
            }
        }


        private void cbHocKyDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            maHocKyDiem = cbHocKyDiem.SelectedValue.ToString();
            FilterDataGridView(maHocKyDiem, dgvDiem, "Ma_Hoc_Ky");
        }

        private void pbAnhSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes = File.ReadAllBytes(filePath); // Chuyển ảnh thành mảng byte
                    try
                    {
                        if (sVBus.ChangeImageBUS(imageBytes, sinhVien.MSSV))
                            MessageBox.Show("Thành công");
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbAnhSV.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void cbHocKyTKB_SelectedIndexChanged(object sender, EventArgs e)
        {
            maHocKyTKB = cbHocKyTKB.SelectedValue.ToString();
            FilterDataGridView(maHocKyTKB, dgvTKB, "Ma_Hoc_Ky");
        }
    }
}
