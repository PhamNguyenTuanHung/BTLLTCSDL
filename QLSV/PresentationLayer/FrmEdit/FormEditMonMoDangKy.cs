using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer.FormThem
{
    public partial class FormEditMonMoDangKy : Form
    {
        public FormEditMonMoDangKy()
        {
            InitializeComponent();
        }


        AdminBUS adminBUS;
        MonMoDangKy monMoDangKy;
        List<string>  foriegnKeys;
        Dictionary<string, List<string>> foriegnKeyValues;



        public FormEditMonMoDangKy(MonMoDangKy monMoDangKy, int Type)
        {
            InitializeComponent(); // Khởi tạo giao diện form

            this.monMoDangKy = monMoDangKy ?? new MonMoDangKy(); 

            adminBUS = new AdminBUS(); // Khởi tạo lớp quản lý

            // Kiểm tra xem là Thêm mới (Type = 0) hay Sửa (Type = 1)
            CheckAddOrUpdate(Type);
            LoadKeys("MonMoDangKy");
            LoadComboBox();

            if (Type == 0 && monMoDangKy != null)
            {
                // Nếu là sửa, hiển thị thông tin lên form
                ShowCourseFromRegistrationDetails(monMoDangKy);
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

            cbMaLMH.DataSource = this.foriegnKeyValues["Ma_Lop_Mon_Hoc"];
            cbMaLMH.SelectedIndex = 0;


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
        private void ShowCourseFromRegistrationDetails(MonMoDangKy monMoDangKy)
        {
            int indexMaHK = cbMaHK.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == monMoDangKy.MaHocKy.Trim());

            if (indexMaHK >= 0)
                cbMaHK.SelectedIndex = indexMaHK;

            int indexMaLMH = cbMaLMH.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == monMoDangKy.MaLopMonHoc);

            if (indexMaLMH >= 0)
                cbMaLMH.SelectedIndex = indexMaLMH;

        }

        public bool ValidatCourseFromRegistrationForm()
        {

            if (cbMaLMH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                cbMaLMH.Focus();
                return false;
            }



            if (cbMaHK.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp.");
                cbMaHK.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidatCourseFromRegistrationForm() != true) return;
                    monMoDangKy = new MonMoDangKy(
                    cbMaLMH.SelectedValue.ToString(),
                    cbMaHK.SelectedValue.ToString()
                    );

                if (adminBUS.InsertCourseForRegistrationBUS(monMoDangKy))
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

                if (ValidatCourseFromRegistrationForm() != true) return;
                monMoDangKy = new MonMoDangKy(
                cbMaLMH.SelectedValue.ToString(),
                cbMaHK.SelectedValue.ToString()
                );

                if (adminBUS.InsertCourseForRegistrationBUS(monMoDangKy))
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

        private void FormEditMonMoDangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
