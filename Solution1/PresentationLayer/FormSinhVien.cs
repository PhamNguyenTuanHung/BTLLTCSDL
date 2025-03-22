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

namespace PresentationLayer
{
    public partial class FormSinhVien : Form
    {
        private SinhVien sv;
        private SinhVien_BUS svBus;
        private TaiKhoan tk;

        public FormSinhVien(SinhVien sinhvien, TaiKhoan taikhoan)
        {
            InitializeComponent();
            sv = sinhvien;
            tk = taikhoan;
            ThongTinSVPL();
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


        private void TimKiem(DataGridView dgv,TextBox txt)
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


        private void LoadData(DataGridView dgv, DataTable dt)
        {
            if (dt != null && dt.Columns.Count > 0)
            {
                dgv.DataSource = dt;
                if (dt.Columns.Contains("Ma_Nhom_Hoc"))
                    dgv.Columns["Ma_Nhom_Hoc"].HeaderText = "Nhóm học";
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
                    dgv.Columns["Ma_Lop_Mon_Hoc"].HeaderText = "Mã Môn Học";
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
            SinhVien_BUS sinhVienBUS = new SinhVien_BUS();
            DataTable dt = new DataTable();
            switch (TabIndex)
            {

                case 0:
                    ThongTinSVPL();
                    break;
                case 1:
                    dt = sinhVienBUS.DiemSVBUS(sv.MSSV);
                    LoadData(dgvDiem,dt);
                    break;
                case 2:
                    dt = sinhVienBUS.TKBSinhVienBUS(sv.MSSV);
                    LoadData(dgvTKB,dt);
                    break;
                case 3:
                    dt = sinhVienBUS.LichThiBUS(sv.MSSV);
                    LoadData(dgvLichThi, dt);
                    break;
                case 4:
                    dt = sinhVienBUS.DanhSachMonDangKiBUS();
                    dt.Columns.Add("Chon", typeof(bool));
                    LoadData(dgvDSMonDK, dt);
                    break;
                default:
                    break;
            }

        }

        private void dgvDSMonDK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải checkbox không
            if (dgvDSMonDK.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                dgvDSMonDK.EndEdit(); // Cập nhật trạng thái ngay lập tức

                bool isChecked = Convert.ToBoolean(dgvDSMonDK.Rows[e.RowIndex].Cells["Chon"].Value);
                string maMonHoc = dgvDSMonDK.Rows[e.RowIndex].Cells["Ma_Lop_Mon_Hoc"].Value?.ToString();
                string tenMonHoc = dgvDSMonDK.Rows[e.RowIndex].Cells["Ten_Mon_Hoc"].Value?.ToString();
                int soTinChi = Convert.ToInt32(dgvDSMonDK.Rows[e.RowIndex].Cells["So_Tin_Chi"].Value);

                if (isChecked)
                {
                    // Thêm vào dgvMonDangKy nếu chưa có
                    DataTable dt = (DataTable)dgvMonDK.DataSource ?? new DataTable();

                    // Nếu là lần đầu, cần tạo cột
                    if (dt.Columns.Count == 0)
                    {
                        dt.Columns.Add("Ma_Lop_Mon_Hoc", typeof(string));
                        dt.Columns.Add("Ten_Mon_Hoc", typeof(string));
                        dt.Columns.Add("So_Tin_Chi", typeof(int));
                    }

                    // Kiểm tra trùng
                    bool isExist = dt.AsEnumerable().Any(row => row["Ma_Lop_Mon_Hoc"].ToString() == maMonHoc);
                    if (!isExist)
                    {
                        dt.Rows.Add(maMonHoc, tenMonHoc, soTinChi);
                        dgvMonDK.DataSource = dt;
                    }
                }
                else
                {
                    // Bỏ check thì xóa khỏi dgvMonDangKy
                    DataTable dt = (DataTable)dgvMonDK.DataSource;
                    if (dt != null)
                    {
                        DataRow rowToDelete = dt.AsEnumerable().FirstOrDefault(row => row["Ma_Lop_Mon_Hoc"].ToString() == maMonHoc);
                        if (rowToDelete != null)
                        {
                            dt.Rows.Remove(rowToDelete);
                        }
                    }
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMonDK.Rows)
            {
                if (row.Cells["Ma_Lop_Mon_Hoc"].Value != null)
                {
                    string mamonhoc = row.Cells["Ma_Lop_Mon_Hoc"].Value.ToString();
                    string mssv = sv.MSSV;
                    DateTime date = DateTime.Now;
                    svBus.DangKyMonHocBUS(mssv, mamonhoc, date);
                }
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau form = new FormDoiMatKhau(sv, tk);
            form.ShowDialog();
            
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
            TimKiem(dgvTKB,txtTimKiemTKB);
        }

        private void btnTimKiemDiem_Click(object sender, EventArgs e)
        {
            TimKiem(dgvDiem, txtTimKiemDiem);
        }

        private void btnTimKiemLichThi_Click(object sender, EventArgs e)
        {
            TimKiem(dgvLichThi, txtTimKiemLichThi);
        }

        private void btnTimKiemMonDangKi_Click(object sender, EventArgs e)
        {
            TimKiem(dgvDSMonDK, txtTimKiemMonDK);
        }
    }
}
