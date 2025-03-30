using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void GetNameTableInDB()
        {
            adminBUS = new AdminBUS();
            tableNames = adminBUS.GetTableNameDAL();
        }
        void GetPrimayryKeys()
        {
            primaryKeys = new List<string>();
            foreach (string tableName in tableNames)
            {
                primaryKeys.AddRange(adminBUS.GetPrimaryKeysBUS(tableName));
            }
            
        }

        //Thêm các usercontrol vào từ tabpage
        private void LoadUserControls()
        {
            // Thêm UserControl vào Dictionary với tên riêng
            userControls["tpGV"] = new ucChucNangChung(tableNames,primaryKeys) { Name = "ucGV" };
            userControls["tpSV"] = new ucChucNangChung(tableNames,primaryKeys) { Name = "ucSV" };
            userControls["tpMH"] = new ucChucNangChung(tableNames, primaryKeys) { Name = "ucMH" };
            userControls["tpLop"] = new ucChucNangChung(tableNames, primaryKeys) { Name = "ucLop" };
            userControls["tpTKB"] = new ucChucNangChung(tableNames, primaryKeys) { Name = "ucTKB" };
            userControls["tpDiem"] = new ucChucNangChung(tableNames, primaryKeys) { Name = "ucDiem" };
            userControls["tpLichThi"] = new ucChucNangChung(tableNames, primaryKeys) { Name = "ucLichThi" };
            userControls["tpTK"] = new ucChucNangChung(tableNames, primaryKeys) { Name = "ucTK" };
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
            tpLop.Controls.Add(userControls["tpLop"]);
            tpTKB.Controls.Add(userControls["tpTKB"]);
            tpDiem.Controls.Add(userControls["tpDiem"]);
            tpLichThi.Controls.Add(userControls["tpLichThi"]);
            tpTK.Controls.Add(userControls["tpTK"]);
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            GetNameTableInDB();
            GetPrimayryKeys();
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
