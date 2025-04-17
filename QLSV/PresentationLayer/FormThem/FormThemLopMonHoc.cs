using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class FormThemLopMonHoc : Form
    {
        public FormThemLopMonHoc()
        {
            InitializeComponent();
        }

        AdminBUS adminBUS;
        LopMonHoc lopMonHoc;
        List<string> primaryKeys, foriegnKeys;
        Dictionary<string,List<string>> foriegnKeyValues;



        public FormThemLopMonHoc(LopMonHoc lopMonHoc, int Type)
        {
            InitializeComponent(); // Khởi tạo giao diện form

            this.lopMonHoc =lopMonHoc ?? new LopMonHoc(); // Nếu sinhVien null, tạo một đối tượng mới

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(Type);
            LoadKeys("LopMonHoc");
            LoadComboBox();

            if (Type == 0 && lopMonHoc != null)
            {
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowCourseClassDetails(lopMonHoc);
            }
        }

        private void LoadKeys(string tableName)
        {
            this.foriegnKeys = adminBUS.GetForiegnKeysBUS(tableName);
            this.foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS( tableName);
        }

        private void LoadComboBox()
        {
            //Lấy dữ liệu từ các key khóa ngoai tương ứng
            cbMaHK.DataSource = this.foriegnKeyValues["Ma_Hoc_Ky"];
            cbMaHK.SelectedIndex = 0;

            cbMSGV.DataSource = this.foriegnKeyValues["MSGV"];
            cbMSGV.SelectedIndex = 0;

            cbMaMH.DataSource = this.foriegnKeyValues["Ma_Mon_Hoc"];
            cbMaMH.SelectedIndex = 0;

            cbMaKhoa.DataSource = this.foriegnKeyValues["Ma_Khoa"]; ;
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
                txtMaLopMH.ReadOnly = true;
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }

        private void ShowCourseClassDetails(LopMonHoc lopMonHoc)
        {
            txtMaLopMH.Text = lopMonHoc.MaLopMonHoc;
            txtSL.Text=lopMonHoc.SoLuongDangKyToiDa.ToString();
            int indexMaHK = cbMaHK.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == lopMonHoc.MaHocKi);

            if (indexMaHK >= 0)
                cbMaHK.SelectedIndex = indexMaHK;


            int indexMaMH = cbMaMH.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == lopMonHoc.MaMonHoc);

            if (indexMaMH >= 0)
                cbMaMH.SelectedIndex = indexMaMH;

            int indexMSGV = cbMSGV.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == lopMonHoc.MSGV);

            if (indexMSGV >= 0)
                cbMSGV.SelectedIndex = indexMSGV;


            int indexMaKhoa = cbMaKhoa.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == lopMonHoc.MaKhoa);

            if (indexMaKhoa >= 0)
                cbMaKhoa.SelectedIndex =indexMaKhoa;

        }

        public bool ValidateCousersClassForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaLopMH.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV.");
                txtMaLopMH.Focus();
                return false;
            }

            if (cbMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                cbMaKhoa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSL.Text) ||
                !int.TryParse(txtSL.Text, out int diem))
            {
                MessageBox.Show("Điểm rèn luyện phải là số từ 0 đến 100.");
                txtSL.Focus();
                return false;
            }


            if (cbMaHK.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp.");
                cbMaHK.Focus();
                return false;
            }

            if (cbMaMH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp.");
                cbMaMH.Focus();
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
              
                if (ValidateCousersClassForm() != true) return;
                lopMonHoc = new LopMonHoc(
                    txtMaLopMH.Text,
                    cbMaMH.SelectedValue.ToString(),
                    cbMSGV.SelectedValue.ToString(),
                    cbMaHK.SelectedValue.ToString(),
                    cbMaKhoa.SelectedValue.ToString(),
                    int.Parse( txtSL.Text)
                    ); 

                if (adminBUS.InsertCourseClassBUS(lopMonHoc))
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

                if (ValidateCousersClassForm() != true) return;
                lopMonHoc = new LopMonHoc(
                    txtMaLopMH.Text,
                    cbMaMH.SelectedValue.ToString(),
                    cbMSGV.SelectedValue.ToString(),
                    cbMaHK.SelectedValue.ToString(),
                    cbMaKhoa.SelectedValue.ToString(),
                    int.Parse(txtSL.Text)
                    );

                if (adminBUS.UpdateCourseClassBUS(lopMonHoc))
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



        private void FormThemLopMonHoc_Load(object sender, EventArgs e)
        {

        }


    }
}
