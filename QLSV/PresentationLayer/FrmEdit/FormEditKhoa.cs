using System;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer.FrmEdit
{
    public partial class FormEditKhoa : Form
    {
        private readonly AdminBUS adminBUS;
        private Khoa khoa;

        public FormEditKhoa()
        {
            InitializeComponent();
        }

        public FormEditKhoa(Khoa khoa, int Type)
        {
            InitializeComponent(); // Khởi tạo giao diện form

            this.khoa = khoa ?? new Khoa(); // Nếu sinhVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(Type);

            if (Type == 0 && khoa != null)
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowDepartmentDetails(khoa);
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
                txtMaKhoa.ReadOnly = true;
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }

        private void ShowDepartmentDetails(Khoa khoa)
        {
            txtMaKhoa.Text = khoa.MaKhoa;
            txtTenKhoa.Text = khoa.TenKhoa;
        }

        public bool ValidateKhoaForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp.");
                txtMaKhoa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp.");
                txtTenKhoa.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateKhoaForm() != true) return;
                khoa = new Khoa(
                    txtMaKhoa.Text,
                    txtTenKhoa.Text
                );

                if (adminBUS.InsertDepartmentBUS(khoa))
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
                if (ValidateKhoaForm() != true) return;
                khoa = new Khoa(
                    txtMaKhoa.Text,
                    txtTenKhoa.Text
                );

                if (adminBUS.UpdateDepartmentBUS(khoa))
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
    }
}