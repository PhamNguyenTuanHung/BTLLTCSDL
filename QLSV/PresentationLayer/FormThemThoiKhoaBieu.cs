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

namespace PresentationLayer
{
    public partial class FormThemThoiKhoaBieu : Form
    {

        AdminBUS adminBUS;
        ThoiKhoaBieu thoiKhoaBieu;
        List<string> primaryKeys, foreignKeys;
        Dictionary<string, List<string>> foriegnKeyValues;
        public FormThemThoiKhoaBieu()
        {
            InitializeComponent();
        }

        public FormThemThoiKhoaBieu(ThoiKhoaBieu thoiKhoaBieu, int type)
        {
            InitializeComponent();
            this.thoiKhoaBieu = thoiKhoaBieu ?? new ThoiKhoaBieu(); // Nếu sinhVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(type);
            LoadKeys("ThoiKhoaBieu");
            LoadComboBox();

            if (type == 0 && thoiKhoaBieu != null)
            {
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowScheduleDetails(thoiKhoaBieu);
            }
        }

        private void CheckAddOrUpdate(int type)
        {
            if (type == 1)
            {
                btnThem.Enabled = true;
                btnThem.Visible = true;
                btnSua.Enabled = false;
                btnSua.Visible = false;
            }
            else
            {
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }

        private void ShowScheduleDetails(ThoiKhoaBieu thoiKhoaBieu)
        {
            txtPhongHoc.Text = thoiKhoaBieu.PhongHoc;
            int indexMaLMH = cbMaLopMonHoc.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == thoiKhoaBieu.MaLopMonHoc);

            if (indexMaLMH >= 0)
                cbMaLopMonHoc.SelectedIndex = indexMaLMH;

            int indexNgayHoc = cbNgayHoc.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == thoiKhoaBieu.NgayHoc);

            if (indexNgayHoc >= 0)
                cbNgayHoc.SelectedIndex = indexNgayHoc;

            // Giờ bắt đầu và giờ kết thúc
            dtBatDau.Value = DateTime.Today.Add(thoiKhoaBieu.GioBatDau);  // Thêm vào ngày hiện tại để chuyển thành DateTime
            dtKetThuc.Value = DateTime.Today.Add(thoiKhoaBieu.GioKetThuc);

            // Phòng học
            txtPhongHoc.Text = thoiKhoaBieu.PhongHoc;

            // Ngày bắt đầu học phần
            dtNgayBatDau.Value = thoiKhoaBieu.NgayBD;

            // Ngày kết thúc học phần
            dtNgayKetThuc.Value = thoiKhoaBieu.NgayKT;
            
        }

        public bool ValidateScheduleClassForm()
        {
            // Mã lớp môn học bắt buộc
            if (cbMaLopMonHoc.SelectedIndex<0 )
            {
                MessageBox.Show("Vui lòng chọn Mã lớp môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ngày học không được rỗng (vì DateTimePicker luôn có giá trị, nên thường không cần check null)
            

            // Giờ bắt đầu < giờ kết thúc
            TimeSpan gioBD = dtBatDau.Value.TimeOfDay;
            TimeSpan gioKT = dtKetThuc.Value.TimeOfDay;
            if (gioBD >= gioKT)
            {
                MessageBox.Show("Giờ bắt đầu phải nhỏ hơn giờ kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Phòng học không được trống
            if (string.IsNullOrWhiteSpace(txtPhongHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập phòng học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ngày bắt đầu <= ngày kết thúc
            DateTime ngayBD = dtNgayBatDau.Value.Date;
            DateTime ngayKT = dtNgayKetThuc.Value.Date;
            if (ngayBD > ngayKT)
            {
                MessageBox.Show("Ngày bắt đầu phải trước hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;





        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateScheduleClassForm() != true) return;
                thoiKhoaBieu = new ThoiKhoaBieu(
                   cbMaLopMonHoc.SelectedValue.ToString(),
                   cbNgayHoc.SelectedValue.ToString(),
                   dtBatDau.Value.TimeOfDay,
                   dtKetThuc.Value.TimeOfDay,
                   txtPhongHoc.Text,
                   dtNgayBatDau.Value,
                   dtNgayKetThuc.Value
                   );

                if (adminBUS.InsertScheduleBUS(thoiKhoaBieu))
                {
                    MessageBox.Show("Thêm thành công");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateScheduleClassForm() != true) return;
                thoiKhoaBieu = new ThoiKhoaBieu(
                    thoiKhoaBieu.MaTKB,
                    cbMaLopMonHoc.SelectedValue.ToString(),
                    cbNgayHoc.SelectedValue.ToString(),
                    dtBatDau.Value.TimeOfDay,
                    dtKetThuc.Value.TimeOfDay,
                    txtPhongHoc.Text,
                    dtNgayBatDau.Value,
                    dtNgayKetThuc.Value
                    );

                if (adminBUS.UpdateScheduleBUS(thoiKhoaBieu))
                {
                    MessageBox.Show("Sửa thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadKeys(string tableName)
        {
            this.foreignKeys = adminBUS.GetForiegnKeysBUS(tableName);
            this.foriegnKeyValues = adminBUS.GetForeignKeyValuesBUS(foreignKeys, tableName);
        }

        private void LoadComboBox()
        {

            cbNgayHoc.DataSource = new List<string>
                {
                    "Thứ 2",
                    "Thứ 3",
                    "Thứ 4",
                    "Thứ 5",
                    "Thứ 6",
                    "Thứ 7",
                    "Chủ Nhật"
                };
            cbNgayHoc.SelectedIndex = 0;

            //Lấy dữ liệu từ các key khóa ngoai tương ứng
            cbMaLopMonHoc.DataSource = this.foriegnKeyValues["Ma_Lop_Mon_Hoc"];
            cbMaLopMonHoc.SelectedIndex = 0;

        }
    }
}
