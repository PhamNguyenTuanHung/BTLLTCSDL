using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormEditSinhVien : Form
    {
        private readonly AdminBUS adminBUS;
        private List<string> foriegnKeys;
        private Dictionary<string, List<string>> foriegnKeyValues;
        private byte[] imageBytes;
        private SinhVien sinhVien;

        public FormEditSinhVien()
        {
            InitializeComponent();
        }


        public FormEditSinhVien(SinhVien sinhVien, int Type)
        {
            InitializeComponent(); // Khởi tạo giao diện form

            this.sinhVien = sinhVien ?? new SinhVien(); // Nếu sinhVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(Type);
            LoadKeys("SinhVien");
            LoadComboBox();

            if (Type == 0 && sinhVien != null)
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowStudentDetails(sinhVien);
        }


        private void LoadKeys(string tableName)
        {
            foriegnKeys = adminBUS.GetForiegnKeysBUS(tableName);
            foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS(tableName);
        }


        private void LoadComboBox()
        {
            cbLop.DataSource = foriegnKeyValues["Ma_Lop"];
            var gioiTinhList = new List<string> { "Nam", "Nữ" };
            cbGioiTinh.DataSource = gioiTinhList;
            cbLop.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;
        }

        private void ShowStudentDetails(SinhVien sv)
        {
            txtMSSV.Text = sv.MSSV;
            txtHoTen.Text = sv.HoTen;
            cbGioiTinh.SelectedItem = sv.GioiTinh.Trim();

            dtNgaySinh.Value = sv.NgaySinh;
            txtEmail.Text = sv.Email;
            txtDiaChi.Text = sv.DiaChi;
            txtKhoaHoc.Text = sv.KhoaHoc;
            txtDRL.Text = sv.DiemRenLuyen.ToString();
            var index = cbLop.Items
                .Cast<string>()
                .ToList()
                .FindIndex(item => item == sv.MaLop);

            if (index >= 0)
                cbLop.SelectedIndex = index;

            if (sv.Anh != null && sv.Anh.Length > 0)
            {
                using (var ms = new MemoryStream(sv.Anh))
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

        public bool ValidateStudentForm()
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV.");
                txtMSSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên.");
                txtHoTen.Focus();
                return false;
            }

            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                cbGioiTinh.Focus();
                return false;
            }

            if (dtNgaySinh.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ.");
                dtNgaySinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDRL.Text) ||
                !float.TryParse(txtDRL.Text, out var diem) || diem < 0 || diem > 100)
            {
                MessageBox.Show("Điểm rèn luyện phải là số từ 0 đến 100.");
                txtDRL.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn Khóa học.");
                txtKhoaHoc.Focus();
                return false;
            }

            if (cbLop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp.");
                cbLop.Focus();
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
                txtMSSV.ReadOnly = true;
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
                if (ValidateStudentForm() != true) return;
                sinhVien = new SinhVien(
                    txtMSSV.Text,
                    txtHoTen.Text,
                    cbGioiTinh.SelectedValue?.ToString().Trim() ?? "",
                    dtNgaySinh.Value,
                    txtEmail.Text,
                    txtDiaChi.Text,
                    txtKhoaHoc.Text,
                    double.TryParse(txtDRL.Text, out var drl) ? drl : 0,
                    cbLop.SelectedValue?.ToString() ?? "",
                    imageBytes ?? null
                );
                ;

                if (adminBUS.InsertStudentBUS(sinhVien))
                {
                    MessageBox.Show("Thêm thành công");
                    Close();
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
                if (ValidateStudentForm() != true) return;
                sinhVien = new SinhVien(
                    txtMSSV.Text,
                    txtHoTen.Text,
                    cbGioiTinh.SelectedValue?.ToString().Trim() ?? "",
                    dtNgaySinh.Value,
                    txtEmail.Text,
                    txtDiaChi.Text,
                    txtKhoaHoc.Text,
                    double.TryParse(txtDRL.Text, out var drl) ? drl : 0,
                    cbLop.SelectedValue?.ToString() ?? "",
                    imageBytes ?? null
                );
                ;

                if (adminBUS.UpdateStudentBUS(sinhVien))
                {
                    MessageBox.Show("Sửa thành công");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pbAnh_Click(object sender, EventArgs e)
        {
        }

        private void lblMSSV_Click(object sender, EventArgs e)
        {
        }

        private void dtNgaySinh_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lbl_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDRL_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void txtKhoaHoc_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"; // Chỉ chọn file ảnh

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;

                    try
                    {
                        // Đọc ảnh vào mảng byte
                        imageBytes = File.ReadAllBytes(filePath);

                        // Nếu mảng byte không rỗng, hiển thị ảnh trong PictureBox
                        if (imageBytes.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageBytes))
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
                        MessageBox.Show("Lỗi khi đọc ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}