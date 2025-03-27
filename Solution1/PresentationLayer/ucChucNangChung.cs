using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace PresentationLayer
{
    public partial class ucChucNangChung : UserControl
    {
        public event EventHandler ThemClicked;
        public event EventHandler SuaClicked;
        public event EventHandler XoaClicked;
        public event EventHandler XuatExcelClicked;
        private DataTable dtData; // Dữ liệu của DataGridView


        public string tenCot { get; set; }// Nhận tên cột tìm kiếm

        public void LoadData(DataTable dt)
        {
            dtData = dt;
            dgv.DataSource = dtData;
        }


        public ucChucNangChung()
        {
            InitializeComponent();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (dtData != null)
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();
                string columnName = tenCot;
                MessageBox.Show(tenCot);
                if (string.IsNullOrEmpty(tenCot))
                {
                    tenCot = dtData.Columns[1].ColumnName;
                }

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dtData.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dtData.DefaultView.RowFilter = $"[{columnName}] LIKE '%{keyword}%'";
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn cột tìm kiếm hoặc chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Mở hộp thoại lưu file
            SaveFileDialog sfd = new SaveFileDialog
            {
                
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "new.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Khởi tạo ứng dụng Excel
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                    // Ghi tiêu đề cột
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true;
                        ((Excel.Range)worksheet.Cells[1, i + 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }

                    // Ghi dữ liệu từ DataGridView vào Excel
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Tự động căn chỉnh độ rộng cột
                    worksheet.Columns.AutoFit();

                    // Lưu file
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
