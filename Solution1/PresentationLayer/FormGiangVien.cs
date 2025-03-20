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

namespace PresentationLayer
{
    public partial class FormGiangVien : Form
    {
        private GiangVien gv;
        private TaiKhoan tk;
        public FormGiangVien(GiangVien gv, TaiKhoan tk)
        {
            this.gv = gv;
            this.tk = tk;
            ThongTinCacLopCuaGV();
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return; // Tránh lỗi nếu chưa chọn

            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            string mamonhoc = comboBox1.SelectedItem.ToString(); // Lấy đúng giá trị môn học

            List<DiemSV> ds = giangVienBL.DanhSachDiemSVBUS(gv.MSGV, mamonhoc);

            if (ds.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MSSV");
                dt.Columns.Add("Tên sinh viên");
                dt.Columns.Add("Điểm quá trình");
                dt.Columns.Add("Điểm thi");
                dt.Columns.Add("Điểm tổng kết");
                dt.Columns.Add("Lần thi");

                foreach (var sv in ds)
                {
                    dt.Rows.Add(sv.MSSV, sv.TenDayDu, sv.DiemQuaTrinh, sv.DiemThi, sv.DiemTongKet, sv.LanThi);
                }

                dgvThongTinLop.DataSource = dt;
                dgvThongTinLop.Dock = DockStyle.Fill;
                dgvThongTinLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThongTinLop.AllowUserToAddRows = false;
                dgvThongTinLop.ReadOnly = true;
                dgvThongTinLop.ClearSelection();
            }
            else
            {
                dgvThongTinLop.DataSource = null;
            }
        }

        private void ThongTinCacLopCuaGV()
        {
            
            GiangVien_BUS gvBL = new GiangVien_BUS();
            List<LopHoc> ds = gvBL.DanhSachLopHocBUS(gv.MSGV);

            foreach (var lop in ds)
            {
                comboBox1.Items.Add(lop.TenMonHoc); // Hiển thị đúng tên môn học
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Chọn mặc định môn đầu tiên
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TabIndex = tabControl.SelectedIndex;
            SinhVien_BUS sinhVienBUS = new SinhVien_BUS();
            DataTable dt = new DataTable();
            switch (TabIndex)
            {

                case 0:
                    
                    break;
                case 1:
                    ThongTinCacLopCuaGV();
                    break;
                /*case 2:
                    dt = sinhVienBUS.TKBSinhVienBUS(sv.MSSV);
                    LoadData(dgvTKB, dt);
                    break;
                case 3:
                    dt = sinhVienBUS.LichThiBUS(sv.MSSV);
                    LoadData(dgvLichThi, dt);
                    break;
                case 4:
                    dt = sinhVienBUS.DanhSachMonDangKiBUS();
                    dt.Columns.Add("Chon", typeof(bool));
                    LoadData(dgvDSMonDK, dt);
                    break;*/
                default:
                    break;
            }
        }
    }
}
