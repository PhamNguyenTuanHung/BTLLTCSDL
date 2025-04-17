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

namespace PresentationLayer.FormThem
{
    public partial class FormThemTaiKhoan : Form
    {
        public FormThemTaiKhoan()
        {
            InitializeComponent();
        }

        AdminBUS adminBUS;
        TaiKhoan taiKhoan;
        List<string> primaryKeys, foreignKeys;
        Dictionary<string, List<string>> foriegnKeyValues;

        public FormThemTaiKhoan(TaiKhoan taiKhoan, int type)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan ?? new TaiKhoan(); // Nếu sinhVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(type);
            LoadKeys("ThoiKhoaBieu");
            LoadComboBox();

            if (type == 0 && taiKhoan != null)
            {
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowAccountDetails(taiKhoan);
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

        private void ShowAccountDetails(TaiKhoan taiKhoan)
        {
            txtTaiKhoan.Text = taiKhoan.TenDangNhap;
            txtTaiKhoan.ReadOnly = true;
            txtMatKhau.Text = taiKhoan.MatKhau;
            int indexLoaiTaiKhoan = cbLoaiTaikhoan.Items
                 .Cast<int>()
                 .ToList()
                 .FindIndex(item => item == taiKhoan.LoaiTaiKhoan);

            if (indexLoaiTaiKhoan >= 0)
                cbLoaiTaikhoan.SelectedIndex = indexLoaiTaiKhoan;

            int indexTrangThai = cbLoaiTaikhoan.Items
                 .Cast<int>()
                 .ToList()
                 .FindIndex(item => item == taiKhoan.TrangThai);

            if (indexTrangThai >= 0)
                cbTrangThai.SelectedIndex = indexTrangThai; ;

          
        }

        public bool ValidateAccountForm()
        {
            // Mã lớp môn học bắt buộc
            if (cbTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Mã lớp môn học bắt buộc
            if (cbLoaiTaikhoan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại  tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Phòng học không được trống
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateAccountForm() != true) return;
                taiKhoan = new TaiKhoan(
                   txtTaiKhoan.Text,txtMatKhau.Text,
                   int.Parse(cbLoaiTaikhoan.SelectedValue.ToString()),
                   int.Parse(cbTrangThai.SelectedValue.ToString())
                   );

                if (adminBUS.InsertAccountBUS(taiKhoan))
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

                if (ValidateAccountForm() != true) return;
                taiKhoan = new TaiKhoan(
                   txtTaiKhoan.Text, txtMatKhau.Text,
                   int.Parse(cbLoaiTaikhoan.SelectedValue.ToString()),
                   int.Parse(cbTrangThai.SelectedValue.ToString())
                   );

                if (adminBUS.UpdateAccountBUS(taiKhoan))
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

        private void LoadKeys(string tableName)
        {
            this.foreignKeys = adminBUS.GetForiegnKeysBUS(tableName);
            this.foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS( tableName);
        }

        private void LoadComboBox()
        {

            cbLoaiTaikhoan.DataSource = new List<int>
                {
                    1,2,3
                };
            cbLoaiTaikhoan.SelectedIndex = 0;

            //Lấy dữ
            cbTrangThai.DataSource = new List<int>
            {
                0,1
                };
            cbLoaiTaikhoan.SelectedIndex = 0; 

        }
    }
}
