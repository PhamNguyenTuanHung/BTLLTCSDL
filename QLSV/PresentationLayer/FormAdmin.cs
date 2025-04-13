using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BusinessLayer;
using DOT;

namespace PresentationLayer
{
    public partial class FormAdmin : Form
    {
        AdminBUS AdminBUS;
        //Danh sách tên các usercontrol
        private Dictionary<string, ucChucNangChung> userControls
            = new Dictionary<string, ucChucNangChung>();

        // kiểm tra các usercontrol đã tải dữ liệu chưa
        private Dictionary<string, bool> tabLoaded = new Dictionary<string, bool>();

        private AdminBUS adminBUS;

        DataTable dt;

        public List<string> primaryKeys;

        public List<string> tableNames;
        public FormAdmin()
        {
            InitializeComponent();


        }


        //Thêm các usercontrol vào từ tabpage
        private void LoadUserControls()
        {
            // Thêm UserControl vào Dictionary với tên riêng
            userControls["tpGV"] = new ucChucNangChung("GiangVien") { Name = "ucGV" };
            userControls["tpSV"] = new ucChucNangChung("SinhVien") { Name = "ucSV" };
            userControls["tpMH"] = new ucChucNangChung("MonHoc") { Name = "ucMH" };
            userControls["tpLopMonHoc"] = new ucChucNangChung("LopMonHoc") { Name = "ucLopMonHoc" };
            userControls["tpTKB"] = new ucChucNangChung("ThoiKhoaBieu") { Name = "ucTKB" };
            userControls["tpDiem"] = new ucChucNangChung("Diem") { Name = "ucDiem" };
            userControls["tpLichThi"] = new ucChucNangChung("LichThi") { Name = "ucLichThi" };
            userControls["tpTK"] = new ucChucNangChung("TaiKhoan") { Name = "ucTK" };
            // Đặt Dock để căn chỉnh kích thước tự động

            foreach (var uc in userControls.Values)
            {
                uc.Dock = DockStyle.Fill;
                /*uc.BtnSua.Enabled = false;
                uc.BtnXoa.Enabled = false;*/
            }

            // Thêm vào từng TabPage
            tpGV.Controls.Add(userControls["tpGV"]);
            tpSV.Controls.Add(userControls["tpSV"]);
            tpMH.Controls.Add(userControls["tpMH"]);
            tpLopMonHoc.Controls.Add(userControls["tpLopMonHoc"]);
            tpTKB.Controls.Add(userControls["tpTKB"]);
            tpDiem.Controls.Add(userControls["tpDiem"]);
            tpLichThi.Controls.Add(userControls["tpLichThi"]);
            tpTK.Controls.Add(userControls["tpTK"]);
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadUserControls();
            AdminBUS = new AdminBUS();
            string tabName = tCAdmin.SelectedTab.Name; // Lấy tên tab
            userControls[tabName].tenTabPage = tabName;
            userControls[tabName].LoadData();   
        }



        private void tCAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabName = tCAdmin.SelectedTab.Name; // Lấy tên tab
            userControls[tabName].tenTabPage = tabName;
            userControls[tabName].LoadData();
            
        }
    }
}
