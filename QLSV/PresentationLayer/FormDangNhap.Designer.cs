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
            this.panel1.Location = new System.Drawing.Point(119, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 346);
            this.panel1.TabIndex = 0;
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_TaiKhoan.Location = new System.Drawing.Point(175, 67);
            this.txt_TaiKhoan.Multiline = true;
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(230, 30);
            this.txt_TaiKhoan.TabIndex = 15;
            this.txt_TaiKhoan.WordWrap = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.login;
            this.pictureBox2.Location = new System.Drawing.Point(108, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_DangNhap.Location = new System.Drawing.Point(174, 225);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(90, 30);
            this.btn_DangNhap.TabIndex = 18;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(108, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Thoat.Location = new System.Drawing.Point(315, 225);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(90, 30);
            this.btn_Thoat.TabIndex = 19;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btnQuenMK
            // 
            this.btnQuenMK.AutoSize = true;
            this.btnQuenMK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuenMK.Location = new System.Drawing.Point(175, 267);
            this.btnQuenMK.Name = "btnQuenMK";
            this.btnQuenMK.Size = new System.Drawing.Size(230, 30);
            this.btnQuenMK.TabIndex = 20;
            this.btnQuenMK.Text = "Quên mật khẩu";
            this.btnQuenMK.UseVisualStyleBackColor = false;
            this.btnQuenMK.Click += new System.EventHandler(this.btnQuenMK_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_MatKhau.Location = new System.Drawing.Point(175, 128);
            this.txt_MatKhau.Multiline = true;
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.Size = new System.Drawing.Size(230, 30);
            this.txt_MatKhau.TabIndex = 16;
            // 
            // CheckBoxHienThiMK
            // 
            this.CheckBoxHienThiMK.AutoSize = true;
            this.CheckBoxHienThiMK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CheckBoxHienThiMK.Location = new System.Drawing.Point(174, 174);
            this.CheckBoxHienThiMK.Name = "CheckBoxHienThiMK";
            this.CheckBoxHienThiMK.Size = new System.Drawing.Size(130, 20);
            this.CheckBoxHienThiMK.TabIndex = 17;
            this.CheckBoxHienThiMK.Text = "Hiển thị mật khẩu";
            this.CheckBoxHienThiMK.UseVisualStyleBackColor = false;
            this.CheckBoxHienThiMK.CheckedChanged += new System.EventHandler(this.CheckBoxHienThiMK_CheckedChanged);
            // 
            // FormDangNhap
            // 
            this.AcceptButton = this.btn_DangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
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

