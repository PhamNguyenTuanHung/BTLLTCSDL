using System;

namespace PresentationLayer
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btnQuenMK = new System.Windows.Forms.Button();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.CheckBoxHienThiMK = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txt_TaiKhoan);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_DangNhap);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_Thoat);
            this.panel1.Controls.Add(this.btnQuenMK);
            this.panel1.Controls.Add(this.txt_MatKhau);
            this.panel1.Controls.Add(this.CheckBoxHienThiMK);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txt_TaiKhoan, "txt_TaiKhoan");
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.login;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.btn_DangNhap, "btn_DangNhap");
            this.btn_DangNhap.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.user;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Thoat, "btn_Thoat");
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btnQuenMK
            // 
            resources.ApplyResources(this.btnQuenMK, "btnQuenMK");
            this.btnQuenMK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuenMK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuenMK.Name = "btnQuenMK";
            this.btnQuenMK.UseVisualStyleBackColor = false;
            this.btnQuenMK.Click += new System.EventHandler(this.btnQuenMK_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txt_MatKhau, "txt_MatKhau");
            this.txt_MatKhau.Name = "txt_MatKhau";
            // 
            // CheckBoxHienThiMK
            // 
            resources.ApplyResources(this.CheckBoxHienThiMK, "CheckBoxHienThiMK");
            this.CheckBoxHienThiMK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CheckBoxHienThiMK.Name = "CheckBoxHienThiMK";
            this.CheckBoxHienThiMK.UseVisualStyleBackColor = false;
            this.CheckBoxHienThiMK.CheckedChanged += new System.EventHandler(this.CheckBoxHienThiMK_CheckedChanged);
            // 
            // FormDangNhap
            // 
            this.AcceptButton = this.btn_DangNhap;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormDangNhap";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btnQuenMK;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.CheckBox CheckBoxHienThiMK;
    }
}

