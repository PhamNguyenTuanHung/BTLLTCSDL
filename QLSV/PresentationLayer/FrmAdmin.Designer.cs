namespace PresentationLayer
{
    partial class FrmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnDiem = new System.Windows.Forms.Button();
            this.btnLichThi = new System.Windows.Forms.Button();
            this.btnMonHoc = new System.Windows.Forms.Button();
            this.btnMonDangKy = new System.Windows.Forms.Button();
            this.btnTKB = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.btnLopMonHoc = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.pHienThiForm = new System.Windows.Forms.Panel();
            this.ucChucNangChung = new PresentationLayer.ucChucNangChung();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pHienThiForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pHienThiForm, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(996, 404);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnDangXuat, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.865169F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.13483F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 398);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.Red;
            this.btnDangXuat.Location = new System.Drawing.Point(2, 358);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(208, 38);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTaiKhoan);
            this.groupBox2.Controls.Add(this.btnKhoa);
            this.groupBox2.Controls.Add(this.btnDiem);
            this.groupBox2.Controls.Add(this.btnLichThi);
            this.groupBox2.Controls.Add(this.btnMonHoc);
            this.groupBox2.Controls.Add(this.btnMonDangKy);
            this.groupBox2.Controls.Add(this.btnTKB);
            this.groupBox2.Controls.Add(this.btnLop);
            this.groupBox2.Controls.Add(this.btnLopMonHoc);
            this.groupBox2.Controls.Add(this.btnGiangVien);
            this.groupBox2.Controls.Add(this.btnSinhVien);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 322);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.Location = new System.Drawing.Point(6, 290);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(194, 26);
            this.btnTaiKhoan.TabIndex = 11;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoa.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoa.Image")));
            this.btnKhoa.Location = new System.Drawing.Point(111, 243);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(89, 41);
            this.btnKhoa.TabIndex = 10;
            this.btnKhoa.Text = "Khoa";
            this.btnKhoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // btnDiem
            // 
            this.btnDiem.BackColor = System.Drawing.Color.White;
            this.btnDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiem.Image = ((System.Drawing.Image)(resources.GetObject("btnDiem.Image")));
            this.btnDiem.Location = new System.Drawing.Point(111, 194);
            this.btnDiem.Name = "btnDiem";
            this.btnDiem.Size = new System.Drawing.Size(89, 43);
            this.btnDiem.TabIndex = 9;
            this.btnDiem.Text = "Điểm";
            this.btnDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDiem.UseVisualStyleBackColor = false;
            this.btnDiem.Click += new System.EventHandler(this.btnDiem_Click);
            // 
            // btnLichThi
            // 
            this.btnLichThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichThi.Image = ((System.Drawing.Image)(resources.GetObject("btnLichThi.Image")));
            this.btnLichThi.Location = new System.Drawing.Point(111, 133);
            this.btnLichThi.Name = "btnLichThi";
            this.btnLichThi.Size = new System.Drawing.Size(89, 53);
            this.btnLichThi.TabIndex = 8;
            this.btnLichThi.Text = "Lịch thi";
            this.btnLichThi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLichThi.UseVisualStyleBackColor = true;
            this.btnLichThi.Click += new System.EventHandler(this.btnLichThi_Click);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonHoc.Image = ((System.Drawing.Image)(resources.GetObject("btnMonHoc.Image")));
            this.btnMonHoc.Location = new System.Drawing.Point(111, 74);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Size = new System.Drawing.Size(89, 53);
            this.btnMonHoc.TabIndex = 7;
            this.btnMonHoc.Text = "Môn học";
            this.btnMonHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMonHoc.UseVisualStyleBackColor = true;
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);
            // 
            // btnMonDangKy
            // 
            this.btnMonDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonDangKy.Image = ((System.Drawing.Image)(resources.GetObject("btnMonDangKy.Image")));
            this.btnMonDangKy.Location = new System.Drawing.Point(6, 194);
            this.btnMonDangKy.Name = "btnMonDangKy";
            this.btnMonDangKy.Size = new System.Drawing.Size(99, 43);
            this.btnMonDangKy.TabIndex = 6;
            this.btnMonDangKy.Text = "Môn mở đăng ký";
            this.btnMonDangKy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMonDangKy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMonDangKy.UseVisualStyleBackColor = true;
            this.btnMonDangKy.Click += new System.EventHandler(this.btnMonDangKy_Click);
            // 
            // btnTKB
            // 
            this.btnTKB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKB.Image = ((System.Drawing.Image)(resources.GetObject("btnTKB.Image")));
            this.btnTKB.Location = new System.Drawing.Point(6, 133);
            this.btnTKB.Name = "btnTKB";
            this.btnTKB.Size = new System.Drawing.Size(99, 53);
            this.btnTKB.TabIndex = 5;
            this.btnTKB.Text = "Thời khóa biểu";
            this.btnTKB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTKB.UseVisualStyleBackColor = true;
            this.btnTKB.Click += new System.EventHandler(this.btnTKB_Click);
            // 
            // btnLop
            // 
            this.btnLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLop.Image = ((System.Drawing.Image)(resources.GetObject("btnLop.Image")));
            this.btnLop.Location = new System.Drawing.Point(6, 243);
            this.btnLop.Name = "btnLop";
            this.btnLop.Size = new System.Drawing.Size(99, 39);
            this.btnLop.TabIndex = 5;
            this.btnLop.Text = "Lớp";
            this.btnLop.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLop.UseVisualStyleBackColor = true;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // btnLopMonHoc
            // 
            this.btnLopMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopMonHoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLopMonHoc.Image")));
            this.btnLopMonHoc.Location = new System.Drawing.Point(6, 74);
            this.btnLopMonHoc.Name = "btnLopMonHoc";
            this.btnLopMonHoc.Size = new System.Drawing.Size(99, 53);
            this.btnLopMonHoc.TabIndex = 4;
            this.btnLopMonHoc.Text = "Lớp môn học";
            this.btnLopMonHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLopMonHoc.UseVisualStyleBackColor = true;
            this.btnLopMonHoc.Click += new System.EventHandler(this.btnLopMonHoc_Click);
            // 
            // btnGiangVien
            // 
            this.btnGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiangVien.Image = ((System.Drawing.Image)(resources.GetObject("btnGiangVien.Image")));
            this.btnGiangVien.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGiangVien.Location = new System.Drawing.Point(111, 11);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Size = new System.Drawing.Size(89, 53);
            this.btnGiangVien.TabIndex = 3;
            this.btnGiangVien.Text = "Giảng viên";
            this.btnGiangVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGiangVien.UseVisualStyleBackColor = true;
            this.btnGiangVien.Click += new System.EventHandler(this.btnGiangVien_Click);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhVien.Image = ((System.Drawing.Image)(resources.GetObject("btnSinhVien.Image")));
            this.btnSinhVien.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSinhVien.Location = new System.Drawing.Point(6, 11);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(99, 53);
            this.btnSinhVien.TabIndex = 2;
            this.btnSinhVien.Text = "Sinh Viên";
            this.btnSinhVien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSinhVien.UseVisualStyleBackColor = true;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // pHienThiForm
            // 
            this.pHienThiForm.Controls.Add(this.ucChucNangChung);
            this.pHienThiForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pHienThiForm.Location = new System.Drawing.Point(220, 3);
            this.pHienThiForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pHienThiForm.Name = "pHienThiForm";
            this.pHienThiForm.Size = new System.Drawing.Size(773, 398);
            this.pHienThiForm.TabIndex = 1;
            // 
            // ucChucNangChung
            // 
            this.ucChucNangChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChucNangChung.Location = new System.Drawing.Point(0, 0);
            this.ucChucNangChung.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucChucNangChung.Name = "ucChucNangChung";
            this.ucChucNangChung.Size = new System.Drawing.Size(773, 398);
            this.ucChucNangChung.TabIndex = 0;
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 404);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdmin";
            this.Text = "FrmAdmin";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pHienThiForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pHienThiForm;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGiangVien;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnDiem;
        private System.Windows.Forms.Button btnLichThi;
        private System.Windows.Forms.Button btnMonHoc;
        private System.Windows.Forms.Button btnMonDangKy;
        private System.Windows.Forms.Button btnTKB;
        private System.Windows.Forms.Button btnLop;
        private System.Windows.Forms.Button btnLopMonHoc;
        private System.Windows.Forms.Button btnTaiKhoan;
        private ucChucNangChung ucChucNangChung;
    }
}