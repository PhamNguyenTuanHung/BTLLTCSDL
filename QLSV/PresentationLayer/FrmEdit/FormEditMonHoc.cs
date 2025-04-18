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
    public partial class FormEditMonHoc : Form
    {
        public FormEditMonHoc()
        {
            InitializeComponent();
        }


        AdminBUS adminBUS;
        MonHoc monHoc;
        public FormEditMonHoc(MonHoc monhoc,int type)
        {
            InitializeComponent();
            adminBUS = new AdminBUS();
            this.monHoc = monhoc ?? new MonHoc();
            CheckAddOrUpdate(type);

            if (type == 0 && monHoc != null)
            {
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowCourseDetails(monhoc);
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
                txtMaMH.ReadOnly = true;
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }


        public bool ValidateObjectForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV.");
                txtMaMH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenMonHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên.");
                txtTenMonHoc.Focus();
                return false;
            }

           

            if (string.IsNullOrWhiteSpace(txtSoTinChi.Text) ||
                !int.TryParse(txtSoTinChi.Text, out int soTinChi) || soTinChi < 0 || soTinChi > 5)
            {
                MessageBox.Show("Điểm rèn luyện phải là số từ 1 đến 5.");
                txtSoTinChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHeSoQT.Text) ||
                !float.TryParse(txtHeSoQT.Text, out float heSoQT ) || heSoQT < 0 || heSoQT > 1)
            {
                MessageBox.Show("Hệ số quá trình phải từ 0 đến 1.");
                txtHeSoQT.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateObjectForm())
                {
                    monHoc = new MonHoc(
                        txtMaMH.Text,
                        txtTenMonHoc.Text,
                        int.Parse(txtSoTinChi.Text),
                        Math.Round(decimal.Parse(txtHeSoQT.Text), 1)
                        );
                    if (adminBUS.InsertCourseBUS(monHoc))
                    {
                        MessageBox.Show("Thêm thành công");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ShowCourseDetails(MonHoc monHoc)
        {
            txtMaMH.Text = monHoc.MaMonHoc;
            txtTenMonHoc.Text = monHoc.TenMonHoc;
            txtSoTinChi.Text = monHoc.SoTinChi.ToString();
            txtHeSoQT.Text=monHoc.HeSoQT.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateObjectForm())
                {
                    monHoc = new MonHoc(
                        txtMaMH.Text,
                        txtTenMonHoc.Text,
                        int.Parse(txtSoTinChi.Text),
                        Math.Round(decimal.Parse(txtHeSoQT.Text),1)

                        );
                    if (adminBUS.UpdateCourseBUS(monHoc))
                    {
                        MessageBox.Show("Sửa thành công");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormThemMonHoc_Load(object sender, EventArgs e)
        {

        }
    }
}
