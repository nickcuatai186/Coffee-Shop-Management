﻿namespace Quanlyquancafe
{
    partial class FrmKhachhang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKhachhang));
            this.dgvKhachhang = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnSau = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnDau = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhachhang
            // 
            this.dgvKhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachhang.Location = new System.Drawing.Point(12, 142);
            this.dgvKhachhang.Name = "dgvKhachhang";
            this.dgvKhachhang.RowTemplate.Height = 24;
            this.dgvKhachhang.Size = new System.Drawing.Size(826, 344);
            this.dgvKhachhang.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.Blue;
            this.btnThem.Location = new System.Drawing.Point(12, 492);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(121, 55);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Blue;
            this.btnXoa.Location = new System.Drawing.Point(228, 492);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(121, 55);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.Blue;
            this.btnSua.Location = new System.Drawing.Point(461, 492);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(121, 55);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.Blue;
            this.btnThoat.Location = new System.Drawing.Point(717, 491);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(121, 55);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.txtTenKH);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 107);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm khách hàng:";
            // 
            // btnTim
            // 
            this.btnTim.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTim.FlatAppearance.BorderSize = 2;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.ForeColor = System.Drawing.Color.Blue;
            this.btnTim.Location = new System.Drawing.Point(367, 30);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(121, 50);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(95, 44);
            this.txtTenKH.MaxLength = 50;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(266, 22);
            this.txtTenKH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên KH:";
            // 
            // btnCuoi
            // 
            this.btnCuoi.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCuoi.ForeColor = System.Drawing.Color.Blue;
            this.btnCuoi.Location = new System.Drawing.Point(770, 97);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(68, 39);
            this.btnCuoi.TabIndex = 16;
            this.btnCuoi.Text = "Cuối";
            this.btnCuoi.UseVisualStyleBackColor = true;
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            // 
            // btnSau
            // 
            this.btnSau.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSau.ForeColor = System.Drawing.Color.Blue;
            this.btnSau.Location = new System.Drawing.Point(696, 97);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(68, 39);
            this.btnSau.TabIndex = 17;
            this.btnSau.Text = "Sau";
            this.btnSau.UseVisualStyleBackColor = true;
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnTruoc.ForeColor = System.Drawing.Color.Blue;
            this.btnTruoc.Location = new System.Drawing.Point(622, 97);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(68, 39);
            this.btnTruoc.TabIndex = 18;
            this.btnTruoc.Text = "Trước";
            this.btnTruoc.UseVisualStyleBackColor = true;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // btnDau
            // 
            this.btnDau.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDau.ForeColor = System.Drawing.Color.Blue;
            this.btnDau.Location = new System.Drawing.Point(548, 97);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(68, 39);
            this.btnDau.TabIndex = 15;
            this.btnDau.Text = "Đầu";
            this.btnDau.UseVisualStyleBackColor = true;
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            // 
            // FrmKhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(850, 558);
            this.Controls.Add(this.btnCuoi);
            this.Controls.Add(this.btnSau);
            this.Controls.Add(this.btnTruoc);
            this.Controls.Add(this.btnDau);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvKhachhang);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKhachhang";
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.FrmKhachhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhachhang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCuoi;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnDau;
    }
}