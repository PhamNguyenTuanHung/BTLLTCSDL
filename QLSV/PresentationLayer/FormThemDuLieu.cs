using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DOT;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Excel = Microsoft.Office.Interop.Excel;

namespace PresentationLayer
{
    public partial class FormThemChung : Form
    {
        private IThucThe thucThe;
        private Dictionary<string, Control> dicControls = new Dictionary<string, Control>();
        private AdminBUS adminBUS;

        public FormThemChung()
        {
            InitializeComponent();
        }
        public FormThemChung(IThucThe thucThe)
        {
            InitializeComponent();
            this.thucThe = thucThe;
            this.Text = "Thêm " + thucThe.LayTenThucThe(); // Đặt tiêu đề form
            KhoiTaoForm();
        }

        private void KhoiTaoForm()
        {
            Dictionary<string, object> duLieu = thucThe.LayDuLieuThucThe();
            int y = 20; // Vị trí bắt đầu trên form

            foreach (var item in duLieu)
            {
                Label lbl = new Label
                {
                    Text = item.Key,
                    Location = new System.Drawing.Point(20, y),
                    AutoSize = true
                };
                this.Controls.Add(lbl);

                TextBox txt = new TextBox
                {
                    Name = "txt" + item.Key.Replace(" ", ""),
                    Location = new System.Drawing.Point(150, y),
                    Width = 200
                };
                this.Controls.Add(txt);

                dicControls[item.Key] = txt;
                y += 30;
            }

            Button btnLuu = new Button
            {
                Text = "Lưu",
                Location = new System.Drawing.Point(150, y + 10)
            };
            btnLuu.Click += BtnLuu_Click;
            this.Controls.Add(btnLuu);
        }


        private void BtnLuu_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> duLieu = thucThe.LayDuLieuThucThe();

            foreach (var key in duLieu.Keys.ToList())
            {
                if (dicControls.ContainsKey(key))
                {
                    string input = dicControls[key].Text;
                    // Chuyển đổi kiểu dữ liệu phù hợp
                    if (duLieu[key] is int)
                        duLieu[key] = int.TryParse(input, out int result) ? result : 0;
                    else if (duLieu[key] is double)
                        duLieu[key] = double.TryParse(input, out double result) ? result : 0;
                    else if (duLieu[key] is DateTime)
                        duLieu[key] = DateTime.TryParse(input, out DateTime result) ? result : DateTime.Now;
                    else
                        duLieu[key] = input;
                }
            }

            var properties = thucThe.GetType().GetProperties().ToList(); // Lấy danh sách thuộc tính của thucThe
            var keyValuePairs = duLieu.ToList(); // Chuyển Dictionary thành danh sách để duyệt theo index

            for (int i = 0; i < properties.Count && i < keyValuePairs.Count; i++)
            {
                var prop = properties[i];       // Lấy thuộc tính theo index
                var key = keyValuePairs[i].Key; // Lấy key từ dictionary
                var value = keyValuePairs[i].Value; // Lấy giá trị

                // Chuyển đổi kiểu dữ liệu nếu cần
                if (dicControls.ContainsKey(key))
                {
                    string input = dicControls[key].Text.Trim();

                    // Kiểm tra dữ liệu có rỗng không
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        MessageBox.Show($"Trường {key} không được để trống!");
                        dicControls[key].Focus();
                        return;
                    }

                    // Chuyển đổi kiểu dữ liệu nếu cần
                    if (prop.PropertyType == typeof(int))
                    {
                        if (int.TryParse(input, out int intValue))
                        {
                            value = intValue;
                        }
                        else
                        {
                            MessageBox.Show($"Trường {key} phải là số nguyên!");
                            dicControls[key].Focus();

                            return; ;
                        }
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        if (double.TryParse(input, out double doubleValue))
                        {
                            value = doubleValue;
                        }
                        else
                        {
                            MessageBox.Show($"Trường {key} phải là số thực!");
                            dicControls[key].Focus();

                            return;
                        }
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        if (DateTime.TryParse(input, out DateTime dateValue))
                        {
                            value = dateValue;
                        }
                        else
                        {
                            MessageBox.Show($"Trường {key} phải là ngày hợp lệ!");
                            dicControls[key].Focus();

                            continue;
                        }
                    }
                    else
                    {
                        value = input; // Mặc định là string
                    }
                }

                prop.SetValue(thucThe, value); // Gán giá trị vào thuộc tính
            }


            if (InsertEntity(thucThe))
            {
                MessageBox.Show("Thêm thành công");
                ClearAllTextBoxes();
                
            }
           
        }

        private void ClearAllTextBoxes()
        {
            TextBox firstTextBox = null;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear(); // Xóa nội dung TextBox

                    // Lưu lại TextBox đầu tiên để focus sau khi xóa
                    if (firstTextBox == null)
                        firstTextBox = textBox;
                }
            }
            firstTextBox.Focus();
        }

        public bool InsertEntity(IThucThe entity)
        {
            bool ketQua = false;
            adminBUS = new AdminBUS();

            try
            {
                if (entity is SinhVien sinhVien)
                {
                    ketQua = adminBUS.InsertStudentBUS(sinhVien);
                }
                else if (entity is GiangVien giangVien)
                {
                    ketQua = adminBUS.InsertLecturerBUS(giangVien);
                }
                else if (entity is MonHoc monHoc)
                {
                    ketQua = adminBUS.InsertCourseBUS(monHoc);
                }
                else if (entity is LopMonHoc lopMonHoc)
                {
                    ketQua = adminBUS.InsertCourseClassBUS(lopMonHoc);
                }
                else if (entity is DiemSV diem)
                {
                    ketQua = adminBUS.InsertGradeBUS(diem);
                }
                else if (entity is ThoiKhoaBieu tkb)
                {
                    ketQua = adminBUS.InsertScheduleBUS(tkb);
                }
                else if (entity is LichThi lichThi)
                {
                    ketQua = adminBUS.InsertExamScheduleBUS(lichThi);
                }
                else if (entity is TaiKhoan taiKhoan)
                {
                    ketQua = adminBUS.InsertAccountBUS(taiKhoan);
                }    
                else
                {
                     MessageBox.Show("Loại thực thể không hợp lệ!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}");   
                return false;
            }

            return ketQua;
        }

        private void FormThemChung_Load(object sender, EventArgs e)
        {

        }
    }
}
