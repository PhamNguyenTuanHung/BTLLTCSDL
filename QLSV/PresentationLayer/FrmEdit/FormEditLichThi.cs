using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer.FormThem
{
    public partial class FormEditLichThi : Form
    {
        public FormEditLichThi()
        {
            InitializeComponent();
        }

        AdminBUS adminBUS;
        LichThi lichThi;
        List<string> foreignKeys;
        Dictionary<string, List<string>> foriegnKeyValues;
        public FormEditLichThi(LichThi lichThi,int type)
        {
            InitializeComponent(); 
            adminBUS = new AdminBUS();
            this.lichThi = lichThi ?? new LichThi();
            foreignKeys = new List<string>();
            CheckAddOrUpdate(type);
            LoadKeys("LichThi");
            LoadComboBox();
            if (type == 0 && lichThi != null)
            {
                // Nếu là sửa, hiển thị thông tin lịch thi lên form
                ShowExamScheduleDetails(lichThi);
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


        private void LoadKeys(string tableName)
        {
            this.foreignKeys = adminBUS.GetForiegnKeysBUS(tableName);
            this.foriegnKeyValues = adminBUS.GetForeignKeyValuesWithReferencedTablesBUS(tableName);
        }

        private void LoadComboBox()
        {

            //Lấy dữ liệu từ các key khóa ngoai tương ứng
            cbMaLopMonHoc.DataSource = this.foriegnKeyValues["Ma_Lop_Mon_Hoc"];
            cbMaLopMonHoc.SelectedIndex = 0;
            cbMaHK.DataSource = this.foriegnKeyValues["Ma_Hoc_Ky"];
            cbMaHK.SelectedIndex = 0;

        }

        public bool ValidateExamScheduleForm()
        {
            // Mã lớp môn học bắt buộc
            if (cbMaLopMonHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Mã lớp môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ngày học không được rỗng (vì DateTimePicker luôn có giá trị, nên thường không cần check null)


            // Giờ bắt đầu < giờ kết thúc
            TimeSpan gioBD = dtBatDau.Value.TimeOfDay;
            TimeSpan gioKT = dtKetThuc.Value.TimeOfDay;
            if (gioBD >= gioKT)
            {
                MessageBox.Show("Giờ bắt đầu phải nhỏ hơn giờ kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Phòng học không được trống
            if (string.IsNullOrWhiteSpace(txtPhongHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập phòng học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ngày bắt đầu <= ngày kết thúc
            DateTime ngayThi = dtNgayThi.Value.Date;

            if (ngayThi <DateTime.Today)
            {
                MessageBox.Show("Ngày bắt đầu phải sau ngày hôm nay.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateExamScheduleForm())
                {
                    lichThi = new LichThi(
                        cbMaLopMonHoc.SelectedValue.ToString(),
                        cbMaHK.SelectedValue.ToString(),
                        dtNgayThi.Value,
                        dtBatDau.Value.TimeOfDay,
                        dtKetThuc.Value.TimeOfDay,
                        txtPhongHoc.Text
                        );
                    if (adminBUS.InsertExamScheduleBUS(lichThi))
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

        private void ShowExamScheduleDetails(LichThi lichThi)
        {
            int indexMaLMH = cbMaLopMonHoc.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == lichThi.MaLopMonHoc);

            if (indexMaLMH >= 0)
                cbMaLopMonHoc.SelectedIndex = indexMaLMH;

            int indexMaHK = cbMaHK.Items
                 .Cast<string>()
                 .ToList()
                 .FindIndex(item => item == lichThi.MaHocKy.Trim());

            if (indexMaHK >= 0)
                cbMaHK.SelectedIndex = indexMaHK;

            // Giờ bắt đầu và giờ kết thúc
            dtBatDau.Value = DateTime.Today.Add(lichThi.GioBatDau);  
            dtKetThuc.Value = DateTime.Today.Add(lichThi.GioKetThuc);

            // Phòng học
            txtPhongHoc.Text = lichThi.PhongThi;

            // Ngày bắt đầu thi
            dtNgayThi.Value = lichThi.NgayThi;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateExamScheduleForm())
                {
                    lichThi = new LichThi(
                        lichThi.MaLichThi,
                        cbMaLopMonHoc.SelectedValue.ToString(),
                        cbMaHK.SelectedValue.ToString(),
                        dtNgayThi.Value,
                        dtBatDau.Value.TimeOfDay,
                        dtKetThuc.Value.TimeOfDay,
                        txtPhongHoc.Text
                        );
                    if (adminBUS.UpdateExamScheduleBUS(lichThi))
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
    }
}
