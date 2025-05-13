using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer.FrmEdit
{
    public partial class FormEditLop : Form
    {
        private readonly AdminBUS adminBUS;
        private List<string> foriegnKeys;
        private Dictionary<string, List<string>> foriegnKeyValues;
        private Lop Lop;

        public FormEditLop()
        {
            InitializeComponent();
        }


        public FormEditLop(Lop lop, int Type)
        {
            InitializeComponent(); // Khởi tạo giao diện form

            Lop = lop ?? new Lop(); // Nếu sinhVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(Type);
            LoadKeys("Lop");
            LoadComboBox();

            if (Type == 0 && lop != null)
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowClassDetails(lop);
        }

        private void LoadKeys(string tableName)
        {
            foriegnKeys = adminBUS.GetForiegnKeysBUS(tableName);
            foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS(tableName);
        }

        private void LoadComboBox()
        {
            //Lấy dữ liệu từ các key khóa ngoai tương ứng
            cbMSGV.DataSource = foriegnKeyValues["MSGV"];
            cbMSGV.SelectedIndex = 0;

            cbMaKhoa.DataSource = foriegnKeyValues["Ma_Khoa"];
            ;
            cbMaKhoa.SelectedIndex = 0;
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
                txtMaLop.ReadOnly = true;
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }

        private void ShowClassDetails(Lop lop)
        {
            txtMaLop.Text = lop.MaLop;
            var indexMSGV = cbMSGV.Items
                .Cast<string>()
                .ToList()
                .FindIndex(item => item == lop.MSGVCN);

            if (indexMSGV >= 0)
                cbMSGV.SelectedIndex = indexMSGV;


            var indexMaKhoa = cbMaKhoa.Items
                .Cast<string>()
                .ToList()
                .FindIndex(item => item == lop.MaKhoa);

            if (indexMaKhoa >= 0)
                cbMaKhoa.SelectedIndex = indexMaKhoa;
        }

        public bool ValidateClassForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp.");
                txtMaLop.Focus();
                return false;
            }

            if (cbMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa.");
                cbMaKhoa.Focus();
                return false;
            }


            if (cbMSGV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp.");
                cbMSGV.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateClassForm() != true) return;
                Lop = new Lop(
                    txtMaLop.Text,
                    cbMSGV.SelectedValue.ToString(),
                    cbMaKhoa.SelectedValue.ToString()
                );

                if (adminBUS.InsertClassBUSDAL(Lop))
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
                if (ValidateClassForm() != true) return;
                Lop = new Lop(
                    txtMaLop.Text,
                    cbMSGV.SelectedValue.ToString(),
                    cbMaKhoa.SelectedValue.ToString()
                );

                if (adminBUS.InsertClassBUSDAL(Lop))
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
    }
}