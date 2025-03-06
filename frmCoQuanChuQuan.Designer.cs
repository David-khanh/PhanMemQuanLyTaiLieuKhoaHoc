namespace SciDoc_Mgmt
{
    partial class frmCoQuanChuQuan
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
            this.dtwCQCQ = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKhoaCoQuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoaiCoQuan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaNXB = new System.Windows.Forms.Button();
            this.btnSuaNXB = new System.Windows.Forms.Button();
            this.btnThemNXB = new System.Windows.Forms.Button();
            this.txtTenCoQuanChuQuan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaCoQuanChuQuan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtwCQCQ)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtwCQCQ
            // 
            this.dtwCQCQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtwCQCQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtwCQCQ.Location = new System.Drawing.Point(8, 366);
            this.dtwCQCQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtwCQCQ.Name = "dtwCQCQ";
            this.dtwCQCQ.RowHeadersWidth = 51;
            this.dtwCQCQ.RowTemplate.Height = 24;
            this.dtwCQCQ.Size = new System.Drawing.Size(1089, 420);
            this.dtwCQCQ.TabIndex = 17;
            this.dtwCQCQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtwCQCQ_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox2.Controls.Add(this.txtKhoaCoQuan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLoaiCoQuan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnXoaNXB);
            this.groupBox2.Controls.Add(this.btnSuaNXB);
            this.groupBox2.Controls.Add(this.btnThemNXB);
            this.groupBox2.Controls.Add(this.txtTenCoQuanChuQuan);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMaCoQuanChuQuan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 81);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1080, 256);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cơ quan chủ quản";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtKhoaCoQuan
            // 
            this.txtKhoaCoQuan.Location = new System.Drawing.Point(752, 99);
            this.txtKhoaCoQuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKhoaCoQuan.Name = "txtKhoaCoQuan";
            this.txtKhoaCoQuan.Size = new System.Drawing.Size(284, 31);
            this.txtKhoaCoQuan.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Khoa cơ quan:";
            // 
            // txtLoaiCoQuan
            // 
            this.txtLoaiCoQuan.Location = new System.Drawing.Point(752, 58);
            this.txtLoaiCoQuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoaiCoQuan.Name = "txtLoaiCoQuan";
            this.txtLoaiCoQuan.Size = new System.Drawing.Size(284, 31);
            this.txtLoaiCoQuan.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Loại cơ quan:";
            // 
            // btnXoaNXB
            // 
            this.btnXoaNXB.Location = new System.Drawing.Point(664, 175);
            this.btnXoaNXB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoaNXB.Name = "btnXoaNXB";
            this.btnXoaNXB.Size = new System.Drawing.Size(117, 45);
            this.btnXoaNXB.TabIndex = 20;
            this.btnXoaNXB.Text = "Xóa";
            this.btnXoaNXB.UseVisualStyleBackColor = true;
            this.btnXoaNXB.Click += new System.EventHandler(this.btnXoaNXB_Click);
            // 
            // btnSuaNXB
            // 
            this.btnSuaNXB.Location = new System.Drawing.Point(480, 175);
            this.btnSuaNXB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSuaNXB.Name = "btnSuaNXB";
            this.btnSuaNXB.Size = new System.Drawing.Size(117, 45);
            this.btnSuaNXB.TabIndex = 19;
            this.btnSuaNXB.Text = "Sửa";
            this.btnSuaNXB.UseVisualStyleBackColor = true;
            this.btnSuaNXB.Click += new System.EventHandler(this.btnSuaNXB_Click);
            // 
            // btnThemNXB
            // 
            this.btnThemNXB.Location = new System.Drawing.Point(295, 175);
            this.btnThemNXB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemNXB.Name = "btnThemNXB";
            this.btnThemNXB.Size = new System.Drawing.Size(117, 45);
            this.btnThemNXB.TabIndex = 18;
            this.btnThemNXB.Text = "Thêm";
            this.btnThemNXB.UseVisualStyleBackColor = true;
            this.btnThemNXB.Click += new System.EventHandler(this.btnThemNXB_Click);
            // 
            // txtTenCoQuanChuQuan
            // 
            this.txtTenCoQuanChuQuan.Location = new System.Drawing.Point(242, 99);
            this.txtTenCoQuanChuQuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenCoQuanChuQuan.Name = "txtTenCoQuanChuQuan";
            this.txtTenCoQuanChuQuan.Size = new System.Drawing.Size(256, 31);
            this.txtTenCoQuanChuQuan.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tên cơ quan chủ quản:";
            // 
            // txtMaCoQuanChuQuan
            // 
            this.txtMaCoQuanChuQuan.Location = new System.Drawing.Point(242, 58);
            this.txtMaCoQuanChuQuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaCoQuanChuQuan.Name = "txtMaCoQuanChuQuan";
            this.txtMaCoQuanChuQuan.Size = new System.Drawing.Size(256, 31);
            this.txtMaCoQuanChuQuan.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã cơ quan chủ quản:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Cursor = System.Windows.Forms.Cursors.No;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(248, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(661, 46);
            this.label16.TabIndex = 15;
            this.label16.Text = "THÔNG TIN CƠ QUAN CHỦ QUẢN";
            // 
            // frmCoQuanChuQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 816);
            this.Controls.Add(this.dtwCQCQ);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label16);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCoQuanChuQuan";
            this.Text = "frmCoQuanChuQuan";
            ((System.ComponentModel.ISupportInitialize)(this.dtwCQCQ)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtwCQCQ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoaNXB;
        private System.Windows.Forms.Button btnSuaNXB;
        private System.Windows.Forms.Button btnThemNXB;
        private System.Windows.Forms.TextBox txtTenCoQuanChuQuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaCoQuanChuQuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtKhoaCoQuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoaiCoQuan;
        private System.Windows.Forms.Label label4;
    }
}