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
            this.tpLopMonHoc = new System.Windows.Forms.TabPage();
            this.tpTKB = new System.Windows.Forms.TabPage();
            this.tpDiem = new System.Windows.Forms.TabPage();
            this.tpLichThi = new System.Windows.Forms.TabPage();
            this.tpTK = new System.Windows.Forms.TabPage();
            this.tCAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tCAdmin
            // 
            this.tCAdmin.Controls.Add(this.tpGV);
            this.tCAdmin.Controls.Add(this.tpSV);
            this.tCAdmin.Controls.Add(this.tpMH);
            this.tCAdmin.Controls.Add(this.tpLopMonHoc);
            this.tCAdmin.Controls.Add(this.tpTKB);
            this.tCAdmin.Controls.Add(this.tpDiem);
            this.tCAdmin.Controls.Add(this.tpLichThi);
            this.tCAdmin.Controls.Add(this.tpTK);
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
            this.tpGV.Text = "Giáo viên";
            this.tpGV.UseVisualStyleBackColor = true;
            // 
            // tpSV
            // 
            this.tpSV.Location = new System.Drawing.Point(4, 25);
            this.tpSV.Name = "tpSV";
            this.tpSV.Padding = new System.Windows.Forms.Padding(3);
            this.tpSV.Size = new System.Drawing.Size(901, 421);
            this.tpSV.TabIndex = 1;
            this.tpSV.Text = "Sinh viên";
            this.tpSV.UseVisualStyleBackColor = true;
            // 
            // tpMH
            // 
            this.tpMH.Location = new System.Drawing.Point(4, 25);
            this.tpMH.Name = "tpMH";
            this.tpMH.Padding = new System.Windows.Forms.Padding(3);
            this.tpMH.Size = new System.Drawing.Size(901, 421);
            this.tpMH.TabIndex = 2;
            this.tpMH.Text = "Môn học";
            this.tpMH.UseVisualStyleBackColor = true;
            // 
            // tpLopMonHoc
            // 
            this.tpLopMonHoc.Location = new System.Drawing.Point(4, 25);
            this.tpLopMonHoc.Name = "tpLopMonHoc";
            this.tpLopMonHoc.Padding = new System.Windows.Forms.Padding(3);
            this.tpLopMonHoc.Size = new System.Drawing.Size(901, 421);
            this.tpLopMonHoc.TabIndex = 3;
            this.tpLopMonHoc.Text = "Lớp học";
            this.tpLopMonHoc.UseVisualStyleBackColor = true;
            // 
            // tpTKB
            // 
            this.tpTKB.Location = new System.Drawing.Point(4, 25);
            this.tpTKB.Name = "tpTKB";
            this.tpTKB.Size = new System.Drawing.Size(901, 421);
            this.tpTKB.TabIndex = 4;
            this.tpTKB.Text = "Thời khóa biểu";
            this.tpTKB.UseVisualStyleBackColor = true;
            // 
            // tpDiem
            // 
            this.tpDiem.Location = new System.Drawing.Point(4, 25);
            this.tpDiem.Name = "tpDiem";
            this.tpDiem.Size = new System.Drawing.Size(901, 421);
            this.tpDiem.TabIndex = 5;
            this.tpDiem.Text = "Diểm ";
            this.tpDiem.UseVisualStyleBackColor = true;
            // 
            // tpLichThi
            // 
            this.tpLichThi.Location = new System.Drawing.Point(4, 25);
            this.tpLichThi.Name = "tpLichThi";
            this.tpLichThi.Padding = new System.Windows.Forms.Padding(3);
            this.tpLichThi.Size = new System.Drawing.Size(901, 421);
            this.tpLichThi.TabIndex = 7;
            this.tpLichThi.Text = "Lịch thi";
            this.tpLichThi.UseVisualStyleBackColor = true;
            // 
            // tpTK
            // 
            this.tpTK.Location = new System.Drawing.Point(4, 25);
            this.tpTK.Name = "tpTK";
            this.tpTK.Padding = new System.Windows.Forms.Padding(3);
            this.tpTK.Size = new System.Drawing.Size(901, 421);
            this.tpTK.TabIndex = 8;
            this.tpTK.Text = "Tài khoản";
            this.tpTK.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TabPage tpLopMonHoc;
        private System.Windows.Forms.TabPage tpTKB;
        private System.Windows.Forms.TabPage tpLichThi;
        private System.Windows.Forms.TabPage tpMH;
        private System.Windows.Forms.TabPage tpDiem;
        private System.Windows.Forms.TabPage tpTK;
    }
}