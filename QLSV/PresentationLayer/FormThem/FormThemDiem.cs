using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormThemDiem : Form
    {
        public FormThemDiem()
        {
            InitializeComponent();
        }


        AdminBUS adminBUS;
        DiemSV diemSV;

        List<string> foriegnKeys;
        Dictionary<string, List<string>> foriegnKeyValues;
        public FormThemDiem(DiemSV diemSV , int type)
        {
            InitializeComponent();
            adminBUS = new AdminBUS();
            this.diemSV = diemSV ?? new DiemSV();
            CheckAddOrUpdate(type);
            LoadKeys("Diem");
            LoadComboBox();

            if (type == 0 && diemSV != null)
            {
                // Nếu là sửa, hiển thị thông tin sinh viên lên form
                ShowGradeDetails(diemSV);
            }
        }


        private void LoadKeys(string tableName)
        {
            this.foriegnKeys = adminBUS.GetForiegnKeysBUS(tableName);
            this.foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS( tableName);
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
                !decimal.TryParse(txtDQT.Text, out decimal diemQT) || diemQT < 0 || diemQT > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10.");
                txtDQT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDT.Text) ||
               !decimal.TryParse(txtDT.Text, out decimal diemThi) || diemThi < 0 || diemThi > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10."); txtDQT.Focus();
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
            int indexMaHK = cbMaHK.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == diemSV.MaHocKy);

            if (indexMaHK >= 0)
                cbMaHK.SelectedIndex = indexMaHK;


            int indexMaMH = cbMaMonHoc.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == diemSV.MaMonHoc);

            if (indexMaMH >= 0)
                cbMaMonHoc.SelectedIndex = indexMaMH;

            int indexMSSV = cbMSSV.Items
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
                        this.Close();
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
                        this.Close();
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
            cbMaHK.DataSource = this.foriegnKeyValues["Ma_Hoc_Ky"];
            cbMaHK.SelectedIndex = 0;

            cbMSSV.DataSource = this.foriegnKeyValues["MSSV"];
            cbMSSV.SelectedIndex = 0;

            cbMaMonHoc.DataSource = this.foriegnKeyValues["Ma_Mon_Hoc"];
            cbMaMonHoc.SelectedIndex = 0;

        }
    }
}
