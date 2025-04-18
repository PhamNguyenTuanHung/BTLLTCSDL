﻿namespace PresentationLayer
{
    partial class FormGiangVien
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ThongTinGVTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.pbAnhGV = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNgaySinh = new System.Windows.Forms.Label();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbHoTen = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbMSGV = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbKhoa = new System.Windows.Forms.Label();
            this.lbLop = new System.Windows.Forms.Label();
            this.LopTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvThongTinLop = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSuaDiem = new System.Windows.Forms.Button();
            this.btnTimKiemSinhVien = new System.Windows.Forms.Button();
            this.txtTimKiemSinhVien = new System.Windows.Forms.TextBox();
            this.cbLopSV = new System.Windows.Forms.ComboBox();
            this.TKBTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTKB = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnTimKiemTKB = new System.Windows.Forms.Button();
            this.txtTimKiemTKB = new System.Windows.Forms.TextBox();
            this.btnAnh = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.ThongTinGVTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.LopTab.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinLop)).BeginInit();
            this.panel2.SuspendLayout();
            this.TKBTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ThongTinGVTab);
            this.tabControl.Controls.Add(this.LopTab);
            this.tabControl.Controls.Add(this.TKBTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // ThongTinGVTab
            // 
            this.ThongTinGVTab.Controls.Add(this.panel1);
            this.ThongTinGVTab.Location = new System.Drawing.Point(4, 25);
            this.ThongTinGVTab.Name = "ThongTinGVTab";
            this.ThongTinGVTab.Padding = new System.Windows.Forms.Padding(3);
            this.ThongTinGVTab.Size = new System.Drawing.Size(792, 421);
            this.ThongTinGVTab.TabIndex = 0;
            this.ThongTinGVTab.Text = "Thông tin giáng viên";
            this.ThongTinGVTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnAnh);
            this.panel1.Controls.Add(this.btnDangXuat);
            this.panel1.Controls.Add(this.btnDoiMK);
            this.panel1.Controls.Add(this.pbAnhGV);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 415);
            this.panel1.TabIndex = 4;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.AutoSize = true;
            this.btnDangXuat.Location = new System.Drawing.Point(576, 346);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(76, 26);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.AutoSize = true;
            this.btnDoiMK.Location = new System.Drawing.Point(466, 346);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(94, 26);
            this.btnDoiMK.TabIndex = 2;
            this.btnDoiMK.Text = "Đổi mật khẩu";
            this.btnDoiMK.UseVisualStyleBackColor = true;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // pbAnhGV
            // 
            this.pbAnhGV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbAnhGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAnhGV.Location = new System.Drawing.Point(466, 40);
            this.pbAnhGV.Name = "pbAnhGV";
            this.pbAnhGV.Size = new System.Drawing.Size(186, 246);
            this.pbAnhGV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnhGV.TabIndex = 1;
            this.pbAnhGV.TabStop = false;
            this.pbAnhGV.Click += new System.EventHandler(this.pbAnhGV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(40, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin giảng viên";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbEmail, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbNgaySinh, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbGioiTinh, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbHoTen, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMSGV, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbKhoa, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbLop, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.36718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.60547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 363);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(153, 242);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(41, 16);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày sinh :";
            // 
            // lbNgaySinh
            // 
            this.lbNgaySinh.AutoSize = true;
            this.lbNgaySinh.Location = new System.Drawing.Point(153, 192);
            this.lbNgaySinh.Name = "lbNgaySinh";
            this.lbNgaySinh.Size = new System.Drawing.Size(70, 16);
            this.lbNgaySinh.TabIndex = 0;
            this.lbNgaySinh.Text = "Ngày  sinh";
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Location = new System.Drawing.Point(153, 142);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(54, 16);
            this.lbGioiTinh.TabIndex = 0;
            this.lbGioiTinh.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giới tính :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Họ tên :";
            // 
            // lbHoTen
            // 
            this.lbHoTen.AutoSize = true;
            this.lbHoTen.Location = new System.Drawing.Point(153, 92);
            this.lbHoTen.Name = "lbHoTen";
            this.lbHoTen.Size = new System.Drawing.Size(46, 16);
            this.lbHoTen.TabIndex = 0;
            this.lbHoTen.Text = "Họ tên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "MSGV :";
            // 
            // lbMSGV
            // 
            this.lbMSGV.AutoSize = true;
            this.lbMSGV.Location = new System.Drawing.Point(153, 42);
            this.lbMSGV.Name = "lbMSGV";
            this.lbMSGV.Size = new System.Drawing.Size(46, 16);
            this.lbMSGV.TabIndex = 0;
            this.lbMSGV.Text = "MSGV";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(3, 292);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(30, 16);
            this.lb.TabIndex = 8;
            this.lb.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khoa : ";
            // 
            // lbKhoa
            // 
            this.lbKhoa.AutoSize = true;
            this.lbKhoa.Location = new System.Drawing.Point(153, 342);
            this.lbKhoa.Name = "lbKhoa";
            this.lbKhoa.Size = new System.Drawing.Size(47, 16);
            this.lbKhoa.TabIndex = 0;
            this.lbKhoa.Text = "Khoa : ";
            // 
            // lbLop
            // 
            this.lbLop.AutoSize = true;
            this.lbLop.Location = new System.Drawing.Point(153, 292);
            this.lbLop.Name = "lbLop";
            this.lbLop.Size = new System.Drawing.Size(30, 16);
            this.lbLop.TabIndex = 9;
            this.lbLop.Text = "Lớp";
            // 
            // LopTab
            // 
            this.LopTab.Controls.Add(this.tableLayoutPanel5);
            this.LopTab.Location = new System.Drawing.Point(4, 25);
            this.LopTab.Name = "LopTab";
            this.LopTab.Padding = new System.Windows.Forms.Padding(3);
            this.LopTab.Size = new System.Drawing.Size(792, 421);
            this.LopTab.TabIndex = 1;
            this.LopTab.Text = "Quản lý lớp học";
            this.LopTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.dgvThongTinLop, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.57143F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(786, 415);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // dgvThongTinLop
            // 
            this.dgvThongTinLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongTinLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTinLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongTinLop.Location = new System.Drawing.Point(3, 91);
            this.dgvThongTinLop.Name = "dgvThongTinLop";
            this.dgvThongTinLop.RowHeadersWidth = 51;
            this.dgvThongTinLop.RowTemplate.Height = 24;
            this.dgvThongTinLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongTinLop.Size = new System.Drawing.Size(780, 321);
            this.dgvThongTinLop.TabIndex = 4;
            this.dgvThongTinLop.SelectionChanged += new System.EventHandler(this.dgvThongTinLop_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.btnSuaDiem);
            this.panel2.Controls.Add(this.btnTimKiemSinhVien);
            this.panel2.Controls.Add(this.txtTimKiemSinhVien);
            this.panel2.Controls.Add(this.cbLopSV);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 44);
            this.panel2.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.AutoSize = true;
            this.btnExcel.Location = new System.Drawing.Point(655, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(100, 31);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Xuất file Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSuaDiem
            // 
            this.btnSuaDiem.AutoSize = true;
            this.btnSuaDiem.Location = new System.Drawing.Point(506, 6);
            this.btnSuaDiem.Name = "btnSuaDiem";
            this.btnSuaDiem.Size = new System.Drawing.Size(91, 29);
            this.btnSuaDiem.TabIndex = 6;
            this.btnSuaDiem.Text = "Sửa";
            this.btnSuaDiem.UseVisualStyleBackColor = true;
            this.btnSuaDiem.Click += new System.EventHandler(this.btnSuaDiem_Click);
            // 
            // btnTimKiemSinhVien
            // 
            this.btnTimKiemSinhVien.AutoSize = true;
            this.btnTimKiemSinhVien.Location = new System.Drawing.Point(316, 7);
            this.btnTimKiemSinhVien.Name = "btnTimKiemSinhVien";
            this.btnTimKiemSinhVien.Size = new System.Drawing.Size(94, 30);
            this.btnTimKiemSinhVien.TabIndex = 1;
            this.btnTimKiemSinhVien.Text = "Tìm kiếm";
            this.btnTimKiemSinhVien.UseVisualStyleBackColor = true;
            this.btnTimKiemSinhVien.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiemSinhVien
            // 
            this.txtTimKiemSinhVien.Location = new System.Drawing.Point(178, 11);
            this.txtTimKiemSinhVien.Name = "txtTimKiemSinhVien";
            this.txtTimKiemSinhVien.Size = new System.Drawing.Size(116, 22);
            this.txtTimKiemSinhVien.TabIndex = 0;
            // 
            // cbLopSV
            // 
            this.cbLopSV.FormattingEnabled = true;
            this.cbLopSV.Location = new System.Drawing.Point(3, 11);
            this.cbLopSV.Name = "cbLopSV";
            this.cbLopSV.Size = new System.Drawing.Size(108, 24);
            this.cbLopSV.TabIndex = 5;
            this.cbLopSV.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TKBTab
            // 
            this.TKBTab.Controls.Add(this.tableLayoutPanel2);
            this.TKBTab.Location = new System.Drawing.Point(4, 25);
            this.TKBTab.Name = "TKBTab";
            this.TKBTab.Size = new System.Drawing.Size(792, 421);
            this.TKBTab.TabIndex = 2;
            this.TKBTab.Text = "Thời khóa biểu";
            this.TKBTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvTKB, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(792, 421);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // dgvTKB
            // 
            this.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTKB.Location = new System.Drawing.Point(3, 87);
            this.dgvTKB.Name = "dgvTKB";
            this.dgvTKB.RowHeadersWidth = 51;
            this.dgvTKB.RowTemplate.Height = 24;
            this.dgvTKB.Size = new System.Drawing.Size(786, 331);
            this.dgvTKB.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnTimKiemTKB);
            this.panel8.Controls.Add(this.txtTimKiemTKB);
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(780, 76);
            this.panel8.TabIndex = 0;
            // 
            // btnTimKiemTKB
            // 
            this.btnTimKiemTKB.AutoSize = true;
            this.btnTimKiemTKB.Location = new System.Drawing.Point(343, 29);
            this.btnTimKiemTKB.Name = "btnTimKiemTKB";
            this.btnTimKiemTKB.Size = new System.Drawing.Size(94, 26);
            this.btnTimKiemTKB.TabIndex = 3;
            this.btnTimKiemTKB.Text = "Tìm kiếm";
            this.btnTimKiemTKB.UseVisualStyleBackColor = true;
            this.btnTimKiemTKB.Click += new System.EventHandler(this.btnTimKiemTKB_Click);
            // 
            // txtTimKiemTKB
            // 
            this.txtTimKiemTKB.Location = new System.Drawing.Point(74, 33);
            this.txtTimKiemTKB.Name = "txtTimKiemTKB";
            this.txtTimKiemTKB.Size = new System.Drawing.Size(173, 22);
            this.txtTimKiemTKB.TabIndex = 0;
            // 
            // btnAnh
            // 
            this.btnAnh.AutoSize = true;
            this.btnAnh.Location = new System.Drawing.Point(658, 263);
            this.btnAnh.Name = "btnAnh";
            this.btnAnh.Size = new System.Drawing.Size(77, 26);
            this.btnAnh.TabIndex = 4;
            this.btnAnh.Text = "Thêm ảnh";
            this.btnAnh.UseVisualStyleBackColor = true;
            this.btnAnh.Click += new System.EventHandler(this.btnAnh_Click);
            // 
            // FormGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "FormGiangVien";
            this.Text = "FormGiangVien";
            this.tabControl.ResumeLayout(false);
            this.ThongTinGVTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.LopTab.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinLop)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TKBTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ThongTinGVTab;
        private System.Windows.Forms.TabPage LopTab;
        private System.Windows.Forms.TabPage TKBTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.PictureBox pbAnhGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbNgaySinh;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbHoTen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbMSGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvTKB;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnTimKiemTKB;
        private System.Windows.Forms.TextBox txtTimKiemTKB;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label lbLop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dgvThongTinLop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnSuaDiem;
        private System.Windows.Forms.Button btnTimKiemSinhVien;
        private System.Windows.Forms.TextBox txtTimKiemSinhVien;
        private System.Windows.Forms.ComboBox cbLopSV;
        private System.Windows.Forms.Button btnAnh;
    }
}