namespace SciDoc_Mgmt
{
    partial class frmHoiNghi
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
            this.dtwHoiNghi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateNgayToChuc = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCapHoiNghi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaNXB = new System.Windows.Forms.Button();
            this.btnSuaNXB = new System.Windows.Forms.Button();
            this.btnThemNXB = new System.Windows.Forms.Button();
            this.txtTenHoiNghi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHoiNghi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtwHoiNghi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtwHoiNghi
            // 
            this.dtwHoiNghi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtwHoiNghi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtwHoiNghi.Location = new System.Drawing.Point(7, 278);
            this.dtwHoiNghi.Name = "dtwHoiNghi";
            this.dtwHoiNghi.RowHeadersWidth = 51;
            this.dtwHoiNghi.RowTemplate.Height = 24;
            this.dtwHoiNghi.Size = new System.Drawing.Size(968, 395);
            this.dtwHoiNghi.TabIndex = 20;
            this.dtwHoiNghi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtwHoiNghi_CellClick);
            this.dtwHoiNghi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtwHoiNghi_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox2.Controls.Add(this.dateNgayToChuc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDiaDiem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCapHoiNghi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnXoaNXB);
            this.groupBox2.Controls.Add(this.btnSuaNXB);
            this.groupBox2.Controls.Add(this.btnThemNXB);
            this.groupBox2.Controls.Add(this.txtTenHoiNghi);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMaHoiNghi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 200);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin hội nghị";
            // 
            // dateNgayToChuc
            // 
            this.dateNgayToChuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNgayToChuc.Location = new System.Drawing.Point(147, 115);
            this.dateNgayToChuc.Name = "dateNgayToChuc";
            this.dateNgayToChuc.Size = new System.Drawing.Size(296, 27);
            this.dateNgayToChuc.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Ngày tổ chức:";
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(668, 79);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(253, 27);
            this.txtDiaDiem.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Địa điểm:";
            // 
            // txtCapHoiNghi
            // 
            this.txtCapHoiNghi.Location = new System.Drawing.Point(668, 46);
            this.txtCapHoiNghi.Name = "txtCapHoiNghi";
            this.txtCapHoiNghi.Size = new System.Drawing.Size(253, 27);
            this.txtCapHoiNghi.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Cấp hội nghị:";
            // 
            // btnXoaNXB
            // 
            this.btnXoaNXB.Location = new System.Drawing.Point(817, 141);
            this.btnXoaNXB.Name = "btnXoaNXB";
            this.btnXoaNXB.Size = new System.Drawing.Size(104, 36);
            this.btnXoaNXB.TabIndex = 20;
            this.btnXoaNXB.Text = "Xóa";
            this.btnXoaNXB.UseVisualStyleBackColor = true;
            this.btnXoaNXB.Click += new System.EventHandler(this.btnXoaNXB_Click);
            // 
            // btnSuaNXB
            // 
            this.btnSuaNXB.Location = new System.Drawing.Point(654, 141);
            this.btnSuaNXB.Name = "btnSuaNXB";
            this.btnSuaNXB.Size = new System.Drawing.Size(104, 36);
            this.btnSuaNXB.TabIndex = 19;
            this.btnSuaNXB.Text = "Sửa";
            this.btnSuaNXB.UseVisualStyleBackColor = true;
            this.btnSuaNXB.Click += new System.EventHandler(this.btnSuaNXB_Click);
            // 
            // btnThemNXB
            // 
            this.btnThemNXB.Location = new System.Drawing.Point(489, 141);
            this.btnThemNXB.Name = "btnThemNXB";
            this.btnThemNXB.Size = new System.Drawing.Size(104, 36);
            this.btnThemNXB.TabIndex = 18;
            this.btnThemNXB.Text = "Thêm";
            this.btnThemNXB.UseVisualStyleBackColor = true;
            this.btnThemNXB.Click += new System.EventHandler(this.btnThemNXB_Click);
            // 
            // txtTenHoiNghi
            // 
            this.txtTenHoiNghi.Location = new System.Drawing.Point(147, 79);
            this.txtTenHoiNghi.Name = "txtTenHoiNghi";
            this.txtTenHoiNghi.Size = new System.Drawing.Size(296, 27);
            this.txtTenHoiNghi.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tên hội nghị:";
            // 
            // txtMaHoiNghi
            // 
            this.txtMaHoiNghi.Location = new System.Drawing.Point(147, 46);
            this.txtMaHoiNghi.Name = "txtMaHoiNghi";
            this.txtMaHoiNghi.Size = new System.Drawing.Size(296, 27);
            this.txtMaHoiNghi.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã hội nghị:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Cursor = System.Windows.Forms.Cursors.No;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(325, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(356, 38);
            this.label16.TabIndex = 18;
            this.label16.Text = "THÔNG TIN HỘI NGHỊ";
            // 
            // frmHoiNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.dtwHoiNghi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label16);
            this.Name = "frmHoiNghi";
            this.Text = "frmHoiNghi";
            ((System.ComponentModel.ISupportInitialize)(this.dtwHoiNghi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtwHoiNghi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateNgayToChuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCapHoiNghi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoaNXB;
        private System.Windows.Forms.Button btnSuaNXB;
        private System.Windows.Forms.Button btnThemNXB;
        private System.Windows.Forms.TextBox txtTenHoiNghi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHoiNghi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
    }
}