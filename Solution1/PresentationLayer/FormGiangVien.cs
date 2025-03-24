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
        private GiangVien_BUS gvBUS;
        public FormGiangVien(GiangVien gv, TaiKhoan tk)
        {
            this.gv = gv;
            this.tk = tk;
            InitializeComponent();
            ThongTinGV();
            ThongTinCacLopCuaGV();
        }


        public void LoadData(DataTable dt, DataGridView dgv)
        {
            if (dt != null && dt.Columns.Count > 0)
            {
                dgv.DataSource = dt;

                if (dt.Columns.Contains("Ten_Mon_Hoc"))
                    dgv.Columns["Ten_Mon_Hoc"].HeaderText = "Tên môn học";

                if (dt.Columns.Contains("Diem_Qua_Trinh"))
                    dgv.Columns["Diem_Qua_Trinh"].HeaderText = "Điểm QT";

                if (dt.Columns.Contains("Diem_Thi"))
                    dgv.Columns["Diem_Thi"].HeaderText = "Điểm Thi";

                if (dt.Columns.Contains("Diem_Tong_Ket"))
                    dgv.Columns["Diem_Tong_Ket"].HeaderText = "Tổng Kết";

                if (dt.Columns.Contains("Ma_Mon_Hoc"))
                    dgv.Columns["Ma_Mon_Hoc"].HeaderText = "Mã Môn Học";

                if (dt.Columns.Contains("Ma_Lop_Mon_Hoc"))
                    dgv.Columns["Ma_Lop_Mon_Hoc"].HeaderText = "Mã Nhóm Học";

                if (dt.Columns.Contains("Ngay_BD"))
                    dgv.Columns["Ngay_BD"].HeaderText = "Ngày Bắt Đầu";

                if (dt.Columns.Contains("Ngay_KT"))
                    dgv.Columns["Ngay_KT"].HeaderText = "Ngày Kết Thúc";

                if (dt.Columns.Contains("So_Tin_Chi"))
                    dgv.Columns["So_Tin_Chi"].HeaderText = "Số Tín Chỉ";

                if (dt.Columns.Contains("Ngay_Hoc"))
                    dgv.Columns["Ngay_Hoc"].HeaderText = "Ngày Học";

                if (dt.Columns.Contains("Gio_Bat_Dau"))
                    dgv.Columns["Gio_Bat_Dau"].HeaderText = "Giờ Bắt Đầu";

                if (dt.Columns.Contains("Gio_Ket_Thuc"))
                    dgv.Columns["Gio_Ket_Thuc"].HeaderText = "Giờ Kết Thúc";

                if (dt.Columns.Contains("Ngay_Thi"))
                    dgv.Columns["Ngay_Thi"].HeaderText = "Ngày thi";

                if (dt.Columns.Contains("Gio_BD"))
                    dgv.Columns["Gio_BD"].HeaderText = "Giờ bắt đầu";

                if (dt.Columns.Contains("Gio_KT"))
                    dgv.Columns["Gio_KT"].HeaderText = "Giờ kết thúc";
                
            }
        }

        public void ThongTinGV()
        {
            gvBUS = new GiangVien_BUS();
            DataTable dt = gvBUS.ThongTinGiaoVienBUS(gv.MSGV);
            if (dt != null && dt.Rows.Count > 0) // Kiểm tra nếu có dữ liệu
            {
                lbMSGV.Text = dt.Rows[0]["MSGV"].ToString();
                lbHoTen.Text = dt.Rows[0]["Ten_Day_Du"].ToString();
                lbEmail.Text = dt.Rows[0]["Email"].ToString();
                lbNgaySinh.Text = Convert.ToDateTime(dt.Rows[0]["Ngay_Sinh"]).ToString("dd/MM/yyyy"); // Định dạng ngày
                lbLop.Text = dt.Rows[0]["Ma_Lop"].ToString();
                lbKhoa.Text = dt.Rows[0]["Ma_Khoa"].ToString();
                lbGioiTinh.Text = dt.Rows[0]["Gioi_Tinh"].ToString();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sinh viên!");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return; // Tránh lỗi nếu chưa chọn
            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            string malopmonhoc = comboBox1.SelectedValue.ToString(); // Lấy đúng giá trị môn học
            DataTable dt = new DataTable();
            dt = giangVienBL.DanhSachDiemSVBUS(gv.MSGV, malopmonhoc);
            LoadData(dt, dgvThongTinLop);
        }

        private void ThongTinCacLopCuaGV()
        {
            
            GiangVien_BUS gvBUS = new GiangVien_BUS();
            DataTable dt = new DataTable();
            dt = gvBUS.DanhSachLopHocBUS(gv.MSGV);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember= "Ten_Mon_Hoc";
            comboBox1.ValueMember = "Ma_Lop_Mon_Hoc";
            comboBox1.DataSource = dt ;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Chọn mặc định môn đầu tiên
            }
        }
        public void SinhVienCacLop(string msgv,string malopmonhoc)
        {
            DataTable dt = new DataTable();
            GiangVien_BUS gvBUS = new GiangVien_BUS();
            dt =gvBUS.DanhSachDiemSVBUS(msgv, malopmonhoc);
            dgvThongTinLop.DataSource = dt;
        }

        private void ThoiKhoaBieuPL()
        {
            GiangVien_BUS giangVienBL = new GiangVien_BUS();
            DataTable dt = giangVienBL.TKBGiangVienBUS(gv.MSGV);
            LoadData(dt, dgvTKB);
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TabIndex = tabControl.SelectedIndex;
            SinhVien_BUS sinhVienBUS = new SinhVien_BUS();
            DataTable dt = new DataTable();
            switch (TabIndex)
            {
                case 0:
                    ThongTinGV();
                    break;
                case 1:
                    ThongTinCacLopCuaGV();
                    break;
                case 2:
                default:
                    break;
            }
        }
    }
}
