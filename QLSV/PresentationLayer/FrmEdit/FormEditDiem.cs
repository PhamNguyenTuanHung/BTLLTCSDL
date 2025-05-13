using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormEditDiem : Form
    {
        private readonly AdminBUS adminBUS;
        private DiemSV diemSV;

        private List<string> foriegnKeys;
        private Dictionary<string, List<string>> foriegnKeyValues;

        public FormEditDiem()
        {
            InitializeComponent();
        }

        public FormEditDiem(DiemSV diemSV, int type)
        {
            InitializeComponent();
            adminBUS = new AdminBUS();
            this.diemSV = diemSV ?? new DiemSV();
            CheckAddOrUpdate(type);
            LoadKeys("Diem");
            LoadComboBox();

            if (type == 0 && diemSV != null)
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowGradeDetails(diemSV);
        }


        private void LoadKeys(string tableName)
        {
            foriegnKeys = adminBUS.GetForiegnKeysBUS(tableName);
            foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS(tableName);
        }

        private void CheckAddOrUpdate(int type)
        {
            if (type == 1)
            {
                btnThem.Enabled = true;
                btnThem.Visible = true;
                btnSua.Enabled = false;
                btnSua.Visible = false;
                label12.Visible = false;
                txtDiemTK.Visible = false;
            }
            else
            {
                label12.Visible = true;
                txtDiemTK.Visible = true;
                cbMSSV.Enabled = false;
                cbMaMonHoc.Enabled = false;
                txtDiemTK.Enabled = false;
                cbMaHK.Enabled = false;
                cbMaMonHoc.Enabled = false;
                cbMSSV.Enabled = false;
                txtLanThi.Enabled = false;
                btnThem.Enabled = false;
                btnThem.Visible = false;
                btnSua.Enabled = true;
                btnSua.Visible = true;
            }
        }


        public bool ValidateGradetForm()
        {
            if (string.IsNullOrWhiteSpace(txtDQT.Text) ||
                !decimal.TryParse(txtDQT.Text, out var diemQT) || diemQT < 0 || diemQT > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10.");
                txtDQT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDT.Text) ||
                !decimal.TryParse(txtDT.Text, out var diemThi) || diemThi < 0 || diemThi > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10.");
                txtDQT.Focus();
                txtDT.Focus();
                return false;
            }

            return true;
        }

        private void ShowGradeDetails(DiemSV diemSV)
        {
            txtDQT.Text = diemSV.DiemQuaTrinh.ToString();
            txtDT.Text = diemSV.DiemThi.ToString();
            txtLanThi.Text = diemSV.LanThi.ToString();

            txtDiemTK.Text = diemSV.DiemTongKet.ToString();
            var indexMaHK = cbMaHK.Items
                .Cast<string>()
                .ToList()
                .FindIndex(item => item == diemSV.MaHocKy);

            if (indexMaHK >= 0)
                cbMaHK.SelectedIndex = indexMaHK;


            var indexMaMH = cbMaMonHoc.Items
                .Cast<string>()
                .ToList()
                .FindIndex(item => item == diemSV.MaMonHoc);

            if (indexMaMH >= 0)
                cbMaMonHoc.SelectedIndex = indexMaMH;

            var indexMSSV = cbMSSV.Items
                .Cast<string>()
                .ToList()
                .FindIndex(item => item == diemSV.MSSV);
            cbMSSV.SelectedIndex = indexMSSV;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateGradetForm())
                {
                    diemSV = new DiemSV(
                        cbMSSV.SelectedValue.ToString(),
                        cbMaMonHoc.SelectedValue.ToString(),
                        cbMaHK.SelectedValue.ToString(),
                        Math.Round(decimal.Parse(txtDQT.Text), 1),
                        Math.Round(decimal.Parse(txtDT.Text), 1),
                        int.Parse(txtLanThi.Text)
                    );
                    if (adminBUS.InsertGradeBUS(diemSV))
                    {
                        MessageBox.Show("Thêm thành công");
                        Close();
                    }
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
                if (ValidateGradetForm())
                {
                    diemSV = new DiemSV(
                        cbMSSV.SelectedValue.ToString(),
                        cbMaMonHoc.SelectedValue.ToString(),
                        cbMaHK.SelectedValue.ToString(),
                        Math.Round(decimal.Parse(txtDQT.Text), 1),
                        Math.Round(decimal.Parse(txtDT.Text), 1),
                        int.Parse(txtLanThi.Text)
                    );
                    if (adminBUS.UpdateGradeBUS(diemSV))
                    {
                        MessageBox.Show("Sửa thành công");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Sửa k thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadComboBox()
        {
            //Lấy dữ liệu từ các key khóa ngoai tương ứng
            cbMaHK.DataSource = foriegnKeyValues["Ma_Hoc_Ky"];
            cbMaHK.SelectedIndex = 0;

            cbMSSV.DataSource = foriegnKeyValues["MSSV"];
            cbMSSV.SelectedIndex = 0;

            cbMaMonHoc.DataSource = foriegnKeyValues["Ma_Mon_Hoc"];
            cbMaMonHoc.SelectedIndex = 0;
        }
    }
}