namespace nuce.ctsv.excels
{
    partial class frmMain
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
            this.btnDongBoEmailSinhVien = new System.Windows.Forms.Button();
            this.btnDongBoThongTinHoKhauThuongTru = new System.Windows.Forms.Button();
            this.btnDongBoThongTinDiaChiTamTru = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDongBoEmailSinhVien
            // 
            this.btnDongBoEmailSinhVien.Location = new System.Drawing.Point(30, 13);
            this.btnDongBoEmailSinhVien.Name = "btnDongBoEmailSinhVien";
            this.btnDongBoEmailSinhVien.Size = new System.Drawing.Size(302, 50);
            this.btnDongBoEmailSinhVien.TabIndex = 0;
            this.btnDongBoEmailSinhVien.Text = "Đồng bộ email sinh viên";
            this.btnDongBoEmailSinhVien.UseVisualStyleBackColor = true;
            this.btnDongBoEmailSinhVien.Click += new System.EventHandler(this.btnDongBoEmailSinhVien_Click);
            // 
            // btnDongBoThongTinHoKhauThuongTru
            // 
            this.btnDongBoThongTinHoKhauThuongTru.Location = new System.Drawing.Point(30, 69);
            this.btnDongBoThongTinHoKhauThuongTru.Name = "btnDongBoThongTinHoKhauThuongTru";
            this.btnDongBoThongTinHoKhauThuongTru.Size = new System.Drawing.Size(302, 50);
            this.btnDongBoThongTinHoKhauThuongTru.TabIndex = 1;
            this.btnDongBoThongTinHoKhauThuongTru.Text = "Đồng bộ thông tin hộ khẩu thường trú";
            this.btnDongBoThongTinHoKhauThuongTru.UseVisualStyleBackColor = true;
            this.btnDongBoThongTinHoKhauThuongTru.Click += new System.EventHandler(this.btnDongBoThongTinHoKhauThuongTru_Click);
            // 
            // btnDongBoThongTinDiaChiTamTru
            // 
            this.btnDongBoThongTinDiaChiTamTru.Location = new System.Drawing.Point(30, 125);
            this.btnDongBoThongTinDiaChiTamTru.Name = "btnDongBoThongTinDiaChiTamTru";
            this.btnDongBoThongTinDiaChiTamTru.Size = new System.Drawing.Size(302, 50);
            this.btnDongBoThongTinDiaChiTamTru.TabIndex = 2;
            this.btnDongBoThongTinDiaChiTamTru.Text = "Đồng bộ thông tin địa chỉ tạm trú";
            this.btnDongBoThongTinDiaChiTamTru.UseVisualStyleBackColor = true;
            this.btnDongBoThongTinDiaChiTamTru.Click += new System.EventHandler(this.btnDongBoThongTinDiaChiTamTru_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 266);
            this.Controls.Add(this.btnDongBoThongTinDiaChiTamTru);
            this.Controls.Add(this.btnDongBoThongTinHoKhauThuongTru);
            this.Controls.Add(this.btnDongBoEmailSinhVien);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDongBoEmailSinhVien;
        private System.Windows.Forms.Button btnDongBoThongTinHoKhauThuongTru;
        private System.Windows.Forms.Button btnDongBoThongTinDiaChiTamTru;
    }
}

