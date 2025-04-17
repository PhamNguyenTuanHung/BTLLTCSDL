using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormThemGiangVien : Form
    {
        public FormThemGiangVien()
        {
            InitializeComponent();
        }

        AdminBUS adminBUS;
        GiangVien giangVien;
        byte[] imageBytes;
        Dictionary<string,List<String>> foreignKeyValues;


        public FormThemGiangVien(GiangVien giangVien, int Type)
        {
            InitializeComponent(); // Khởi tạo giao diện form

            this.giangVien = giangVien ?? new GiangVien(); // Nếu giangVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 1) hay Sửa (Type = 0)
            CheckAddOrUpdate(Type);
            LoadKeys("GiangVien");

            LoadComboBox();
            if (Type == 0 && giangVien != null)
            {
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowLecturerDetails(giangVien);
            }
        }


        private void LoadKeys(string tableName)
        {
            this.foreignKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS( "GiangVien");
        }


        private void LoadComboBox()
        {
            List<string> gioiTinhList = new List<string> {"Nam", "Nữ" };
            cbGioiTinhGV.DataSource = gioiTinhList;
            cbGioiTinhGV.SelectedIndex = 0;

            cbKhoa.DataSource = foreignKeyValues["Ma_Khoa"];
            cbKhoa.SelectedIndex = 0;
        }
        private void ShowLecturerDetails(GiangVien giangVien)
        {
            txtMSGV.Text = giangVien.MSGV;
            txtHoTen.Text = giangVien.HoTen;
            if (giangVien.GioiTinh == "Nam")
            {
                cbGioiTinhGV.SelectedIndex = 0;  // Chọn "Nam"
            }
            else cbGioiTinhGV.SelectedIndex = 1;  // Chọn "Nữ"

            dtNgaySinh.Value = giangVien.NgaySinh;
            txtEmail.Text = giangVien.Email;
            txtDiaChi.Text = giangVien.DiaChi;
            int index = cbKhoa.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == giangVien.MaKhoa);

            if (index >= 0)
                cbKhoa.SelectedIndex = index;


            if (giangVien.Anh != null && giangVien.Anh.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(giangVien.Anh))
                {
                    pbAnh.Image = Image.FromStream(ms);
                    pbAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                btnThemAnh.Text = "Đổi ảnh";
            }
            else
            {
                pbAnh.Image = null;
                btnThemAnh.Text = "Thêm ảnh";
            }
        }


        public bool ValidateLecturerForm()
        {
            if (string.IsNullOrWhiteSpace(txtMSGV.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV.");
                txtMSGV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên.");
                txtHoTen.Focus();
                return false;
            }

            if (cbGioiTinhGV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                cbGioiTinhGV.Focus();
                return false;
            }

            if (dtNgaySinh.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ.");
                dtNgaySinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.");
                txtEmail.Focus();
                return false;
            }


            if (cbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp.");
                cbKhoa.Focus();
                return false;
            }
            return true;
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
                txtMSGV.ReadOnly = true;
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateLecturerForm() != true) return;
                giangVien = new GiangVien(
                    txtMSGV.Text,
                    txtHoTen.Text,
                    cbGioiTinhGV.SelectedValue?.ToString().Trim() ?? "",
                    dtNgaySinh.Value,
                    txtDiaChi.Text,
                    txtEmail.Text,
                    cbKhoa.SelectedValue?.ToString() ?? "",
                    imageBytes ?? null
            ); ;

                if (adminBUS.InsertLecturerBUS(giangVien))
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
                if (ValidateLecturerForm() != true) return;
                giangVien = new GiangVien(
                    txtMSGV.Text,
                    txtHoTen.Text,
                    cbGioiTinhGV.SelectedValue?.ToString().Trim() ?? "",
                    dtNgaySinh.Value,
                    txtEmail.Text,
                    txtDiaChi.Text,
                    cbKhoa.SelectedValue?.ToString() ?? "",
                    imageBytes ?? null
            ); ;

                if (adminBUS.UpdateLecturerBUS(giangVien))
                {
                    MessageBox.Show("Sửa thành công");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"; // Chỉ chọn file ảnh

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Đọc ảnh vào mảng byte
                        imageBytes = File.ReadAllBytes(filePath);

                        // Nếu mảng byte không rỗng, hiển thị ảnh trong PictureBox
                        if (imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pbAnh.Image = Image.FromStream(ms);
                            }

                            // Nếu ảnh đã được chọn, thay đổi text của nút
                            btnThemAnh.Text = "Đổi ảnh";
                        }
                        else
                        {
                            MessageBox.Show("Ảnh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi khi đọc ảnh
                        MessageBox.Show("Lỗi khi đọc ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
