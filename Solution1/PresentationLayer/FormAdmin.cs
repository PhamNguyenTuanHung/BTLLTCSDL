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

        DataTable dt;
        public FormAdmin()
        {
            InitializeComponent();
            
        }

        private void LoadUserControls()
        {
            // Thêm UserControl vào Dictionary với tên riêng
            userControls["tpGV"] = new ucChucNangChung { Name = "ucGV" };
            userControls["tpSV"] = new ucChucNangChung { Name = "ucSV" };
            userControls["tpMH"] = new ucChucNangChung { Name = "ucMH" };
            userControls["tpLop"] = new ucChucNangChung  { Name = "ucLop" };
            userControls["tpTKB"] = new ucChucNangChung  { Name = "ucTKB" };
            userControls["tpDiem"] = new ucChucNangChung { Name = "ucDiem" };
            userControls["tpLichThi"] = new ucChucNangChung { Name = "ucLichThi" };
            // Đặt Dock để căn chỉnh kích thước tự động
            foreach (var uc in userControls.Values)
            {
                uc.Dock = DockStyle.Fill;
            }

            // Thêm vào từng TabPage
            tpGV.Controls.Add(userControls["tpGV"]);
            tpSV.Controls.Add(userControls["tpSV"]);
            tpMH.Controls.Add(userControls["tpMH"]);
            tpLop.Controls.Add(userControls["tpLop"]);
            tpTKB.Controls.Add(userControls["tpTKB"]);
            tpDiem.Controls.Add(userControls["tpDiem"]);
            tpLichThi.Controls.Add(userControls["tpLichThi"]);
        }


        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadUserControls();
            AdminBUS = new AdminBUS();
            dt = new DataTable();
            dt = LoadData("tpGV");
            userControls["tpGV"].LoadData(dt); // Load dữ liệu
            userControls["tpGV"].tenCot = dt.Columns[1].ColumnName; 
        }

        private DataTable LoadData(string tenBang)
        {
            DataTable dataTable= new DataTable();   
            switch (tenBang)
            {
                case "tpSV":
                    dataTable = AdminBUS.GetStudentsListBUS();
                    break;
                case "tpGV":
                    dataTable = AdminBUS.GetLecturersListBUS();
                    break;
                case "tpMH":
                    dataTable = AdminBUS.GetSubjectsListBUS();
                    break;
                case "tpLop":
                    dataTable = AdminBUS.GetClassListBUS();
                    break;
                case "tpTKB":
                    dataTable = AdminBUS.GetScheduleBUS();
                    break;
                case "tpLichThi":
                    dataTable = AdminBUS.GetExamScheduleBUS();
                    break;
                case "tpDiem": 
                    dataTable = AdminBUS.GetStudentGradesBUS();
                    break;
                default:
                    dataTable = null;
                    break;
            }
            return dataTable;
        }

        private void tCAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabName = tCAdmin.SelectedTab.Name; // Lấy tên tab
            int index = tCAdmin.SelectedIndex;
            if (userControls.ContainsKey(tabName))
            {  
                dt = LoadData(tabName);
                if (dt != null)
                {
                    userControls[tabName].LoadData(dt); // Gọi hàm LoadData với dữ liệu đúng
                    userControls[tabName].tenCot=dt.Columns[1].ColumnName; 
                    tabLoaded[tabName] = true; // Đánh dấu đã load để tránh load lại
                }
            }
        }
    }
}
