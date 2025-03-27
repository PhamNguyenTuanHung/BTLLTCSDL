namespace PresentationLayer
{
    partial class FormAdmin
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
            this.tCAdmin = new System.Windows.Forms.TabControl();
            this.tpGV = new System.Windows.Forms.TabPage();
            this.tpSV = new System.Windows.Forms.TabPage();
            this.tpMH = new System.Windows.Forms.TabPage();
            this.tpLop = new System.Windows.Forms.TabPage();
            this.tpTKB = new System.Windows.Forms.TabPage();
            this.tpDiem = new System.Windows.Forms.TabPage();
            this.tpLichThi = new System.Windows.Forms.TabPage();
            this.tpTaiKhoan = new System.Windows.Forms.TabPage();
            this.tCAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tCAdmin
            // 
            this.tCAdmin.Controls.Add(this.tpGV);
            this.tCAdmin.Controls.Add(this.tpSV);
            this.tCAdmin.Controls.Add(this.tpMH);
            this.tCAdmin.Controls.Add(this.tpLop);
            this.tCAdmin.Controls.Add(this.tpTKB);
            this.tCAdmin.Controls.Add(this.tpDiem);
            this.tCAdmin.Controls.Add(this.tpLichThi);
            this.tCAdmin.Controls.Add(this.tpTaiKhoan);
            this.tCAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCAdmin.Location = new System.Drawing.Point(0, 0);
            this.tCAdmin.Name = "tCAdmin";
            this.tCAdmin.SelectedIndex = 0;
            this.tCAdmin.Size = new System.Drawing.Size(909, 450);
            this.tCAdmin.TabIndex = 0;
            this.tCAdmin.SelectedIndexChanged += new System.EventHandler(this.tCAdmin_SelectedIndexChanged);
            // 
            // tpGV
            // 
            this.tpGV.Location = new System.Drawing.Point(4, 25);
            this.tpGV.Name = "tpGV";
            this.tpGV.Padding = new System.Windows.Forms.Padding(3);
            this.tpGV.Size = new System.Drawing.Size(901, 421);
            this.tpGV.TabIndex = 0;
            this.tpGV.Text = "Quản lý giáo viên";
            this.tpGV.UseVisualStyleBackColor = true;
            // 
            // tpSV
            // 
            this.tpSV.Location = new System.Drawing.Point(4, 25);
            this.tpSV.Name = "tpSV";
            this.tpSV.Padding = new System.Windows.Forms.Padding(3);
            this.tpSV.Size = new System.Drawing.Size(901, 421);
            this.tpSV.TabIndex = 1;
            this.tpSV.Text = "Quản lý sinh viên";
            this.tpSV.UseVisualStyleBackColor = true;
            // 
            // tpMH
            // 
            this.tpMH.Location = new System.Drawing.Point(4, 25);
            this.tpMH.Name = "tpMH";
            this.tpMH.Padding = new System.Windows.Forms.Padding(3);
            this.tpMH.Size = new System.Drawing.Size(901, 421);
            this.tpMH.TabIndex = 2;
            this.tpMH.Text = "Quản lý môn học";
            this.tpMH.UseVisualStyleBackColor = true;
            // 
            // tpLop
            // 
            this.tpLop.Location = new System.Drawing.Point(4, 25);
            this.tpLop.Name = "tpLop";
            this.tpLop.Padding = new System.Windows.Forms.Padding(3);
            this.tpLop.Size = new System.Drawing.Size(901, 421);
            this.tpLop.TabIndex = 3;
            this.tpLop.Text = "Quản lý lớp học";
            this.tpLop.UseVisualStyleBackColor = true;
            // 
            // tpTKB
            // 
            this.tpTKB.Location = new System.Drawing.Point(4, 25);
            this.tpTKB.Name = "tpTKB";
            this.tpTKB.Size = new System.Drawing.Size(901, 421);
            this.tpTKB.TabIndex = 4;
            this.tpTKB.Text = "Quản lý thời khóa biểu";
            this.tpTKB.UseVisualStyleBackColor = true;
            // 
            // tpDiem
            // 
            this.tpDiem.Location = new System.Drawing.Point(4, 25);
            this.tpDiem.Name = "tpDiem";
            this.tpDiem.Size = new System.Drawing.Size(901, 421);
            this.tpDiem.TabIndex = 5;
            this.tpDiem.Text = "Quản lý điểm ";
            this.tpDiem.UseVisualStyleBackColor = true;
            // 
            // tpLichThi
            // 
            this.tpLichThi.Location = new System.Drawing.Point(4, 25);
            this.tpLichThi.Name = "tpLichThi";
            this.tpLichThi.Padding = new System.Windows.Forms.Padding(3);
            this.tpLichThi.Size = new System.Drawing.Size(901, 421);
            this.tpLichThi.TabIndex = 7;
            this.tpLichThi.Text = "Quản lý lịch thi";
            this.tpLichThi.UseVisualStyleBackColor = true;
            // 
            // tpTaiKhoan
            // 
            this.tpTaiKhoan.Location = new System.Drawing.Point(4, 25);
            this.tpTaiKhoan.Name = "tpTaiKhoan";
            this.tpTaiKhoan.Size = new System.Drawing.Size(901, 421);
            this.tpTaiKhoan.TabIndex = 6;
            this.tpTaiKhoan.Text = "Tài khoản";
            this.tpTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 450);
            this.Controls.Add(this.tCAdmin);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tCAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tCAdmin;
        private System.Windows.Forms.TabPage tpGV;
        private System.Windows.Forms.TabPage tpSV;
        private System.Windows.Forms.TabPage tpLop;
        private System.Windows.Forms.TabPage tpTKB;
        private System.Windows.Forms.TabPage tpTaiKhoan;
        private System.Windows.Forms.TabPage tpLichThi;
        private System.Windows.Forms.TabPage tpMH;
        private System.Windows.Forms.TabPage tpDiem;
    }
}