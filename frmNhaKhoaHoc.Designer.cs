namespace SciDoc_Mgmt
{
    partial class frmNhaKhoaHoc
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtwNKH = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxHocVi = new System.Windows.Forms.ComboBox();
            this.cbxLinhVuc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.XoaNKH = new System.Windows.Forms.Button();
            this.btnSuaNKH = new System.Windows.Forms.Button();
            this.btnThemNKH = new System.Windows.Forms.Button();
            this.txtTenNhaKhoaHoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNhaKhoaHoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtwVaiTro = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoaVaiTro = new System.Windows.Forms.Button();
            this.btnSuaVaiTro = new System.Windows.Forms.Button();
            this.btnThemVaiTro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenVaiTro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaVaiTro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtwNKH)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtwVaiTro)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 653);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtwNKH);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 620);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhà khoa học";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtwNKH
            // 
            this.dtwNKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtwNKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtwNKH.Location = new System.Drawing.Point(3, 275);
            this.dtwNKH.Name = "dtwNKH";
            this.dtwNKH.RowHeadersWidth = 51;
            this.dtwNKH.RowTemplate.Height = 24;
            this.dtwNKH.Size = new System.Drawing.Size(968, 338);
            this.dtwNKH.TabIndex = 11;
            this.dtwNKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtwNKH_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox2.Controls.Add(this.cbxHocVi);
            this.groupBox2.Controls.Add(this.cbxLinhVuc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.XoaNKH);
            this.groupBox2.Controls.Add(this.btnSuaNKH);
            this.groupBox2.Controls.Add(this.btnThemNKH);
            this.groupBox2.Controls.Add(this.txtTenNhaKhoaHoc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMaNhaKhoaHoc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 220);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhà khoa học";
            // 
            // cbxHocVi
            // 
            this.cbxHocVi.FormattingEnabled = true;
            this.cbxHocVi.Location = new System.Drawing.Point(190, 115);
            this.cbxHocVi.Name = "cbxHocVi";
            this.cbxHocVi.Size = new System.Drawing.Size(253, 28);
            this.cbxHocVi.TabIndex = 24;
            // 
            // cbxLinhVuc
            // 
            this.cbxLinhVuc.FormattingEnabled = true;
            this.cbxLinhVuc.Location = new System.Drawing.Point(190, 148);
            this.cbxLinhVuc.Name = "cbxLinhVuc";
            this.cbxLinhVuc.Size = new System.Drawing.Size(253, 28);
            this.cbxLinhVuc.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Lĩnh vực:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Học vị:";
            // 
            // XoaNKH
            // 
            this.XoaNKH.Location = new System.Drawing.Point(826, 93);
            this.XoaNKH.Name = "XoaNKH";
            this.XoaNKH.Size = new System.Drawing.Size(104, 36);
            this.XoaNKH.TabIndex = 20;
            this.XoaNKH.Text = "Xóa";
            this.XoaNKH.UseVisualStyleBackColor = true;
            this.XoaNKH.Click += new System.EventHandler(this.XoaNKH_Click);
            // 
            // btnSuaNKH
            // 
            this.btnSuaNKH.Location = new System.Drawing.Point(663, 93);
            this.btnSuaNKH.Name = "btnSuaNKH";
            this.btnSuaNKH.Size = new System.Drawing.Size(104, 36);
            this.btnSuaNKH.TabIndex = 19;
            this.btnSuaNKH.Text = "Sửa";
            this.btnSuaNKH.UseVisualStyleBackColor = true;
            this.btnSuaNKH.Click += new System.EventHandler(this.btnSuaNKH_Click);
            // 
            // btnThemNKH
            // 
            this.btnThemNKH.Location = new System.Drawing.Point(498, 93);
            this.btnThemNKH.Name = "btnThemNKH";
            this.btnThemNKH.Size = new System.Drawing.Size(104, 36);
            this.btnThemNKH.TabIndex = 18;
            this.btnThemNKH.Text = "Thêm";
            this.btnThemNKH.UseVisualStyleBackColor = true;
            this.btnThemNKH.Click += new System.EventHandler(this.btnThemNKH_Click);
            // 
            // txtTenNhaKhoaHoc
            // 
            this.txtTenNhaKhoaHoc.Location = new System.Drawing.Point(190, 79);
            this.txtTenNhaKhoaHoc.Name = "txtTenNhaKhoaHoc";
            this.txtTenNhaKhoaHoc.Size = new System.Drawing.Size(253, 27);
            this.txtTenNhaKhoaHoc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tên nhà khoa học:";
            // 
            // txtMaNhaKhoaHoc
            // 
            this.txtMaNhaKhoaHoc.Location = new System.Drawing.Point(190, 46);
            this.txtMaNhaKhoaHoc.Name = "txtMaNhaKhoaHoc";
            this.txtMaNhaKhoaHoc.Size = new System.Drawing.Size(253, 27);
            this.txtMaNhaKhoaHoc.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã nhà khoa học:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Cursor = System.Windows.Forms.Cursors.No;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(285, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(463, 38);
            this.label16.TabIndex = 9;
            this.label16.Text = "THÔNG TIN NHÀ KHOA HỌC";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtwVaiTro);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(974, 620);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vai trò";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtwVaiTro
            // 
            this.dtwVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtwVaiTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtwVaiTro.Location = new System.Drawing.Point(3, 166);
            this.dtwVaiTro.Name = "dtwVaiTro";
            this.dtwVaiTro.RowHeadersWidth = 51;
            this.dtwVaiTro.RowTemplate.Height = 24;
            this.dtwVaiTro.Size = new System.Drawing.Size(968, 447);
            this.dtwVaiTro.TabIndex = 11;
            this.dtwVaiTro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtwVaiTro_CellClick_1);
            this.dtwVaiTro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtwVaiTro_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.btnXoaVaiTro);
            this.groupBox1.Controls.Add(this.btnSuaVaiTro);
            this.groupBox1.Controls.Add(this.btnThemVaiTro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenVaiTro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaVaiTro);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 111);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin vai trò";
            // 
            // btnXoaVaiTro
            // 
            this.btnXoaVaiTro.Location = new System.Drawing.Point(816, 33);
            this.btnXoaVaiTro.Name = "btnXoaVaiTro";
            this.btnXoaVaiTro.Size = new System.Drawing.Size(104, 36);
            this.btnXoaVaiTro.TabIndex = 13;
            this.btnXoaVaiTro.Text = "Xóa";
            this.btnXoaVaiTro.UseVisualStyleBackColor = true;
            this.btnXoaVaiTro.Click += new System.EventHandler(this.btnXoaVaiTro_Click);
            // 
            // btnSuaVaiTro
            // 
            this.btnSuaVaiTro.Location = new System.Drawing.Point(653, 33);
            this.btnSuaVaiTro.Name = "btnSuaVaiTro";
            this.btnSuaVaiTro.Size = new System.Drawing.Size(104, 36);
            this.btnSuaVaiTro.TabIndex = 12;
            this.btnSuaVaiTro.Text = "Sửa";
            this.btnSuaVaiTro.UseVisualStyleBackColor = true;
            this.btnSuaVaiTro.Click += new System.EventHandler(this.btnSuaVaiTro_Click);
            // 
            // btnThemVaiTro
            // 
            this.btnThemVaiTro.Location = new System.Drawing.Point(488, 33);
            this.btnThemVaiTro.Name = "btnThemVaiTro";
            this.btnThemVaiTro.Size = new System.Drawing.Size(104, 36);
            this.btnThemVaiTro.TabIndex = 11;
            this.btnThemVaiTro.Text = "Thêm";
            this.btnThemVaiTro.UseVisualStyleBackColor = true;
            this.btnThemVaiTro.Click += new System.EventHandler(this.btnThemVaiTro_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 10;
            // 
            // txtTenVaiTro
            // 
            this.txtTenVaiTro.Location = new System.Drawing.Point(133, 59);
            this.txtTenVaiTro.Name = "txtTenVaiTro";
            this.txtTenVaiTro.Size = new System.Drawing.Size(253, 27);
            this.txtTenVaiTro.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên vai trò:";
            // 
            // txtMaVaiTro
            // 
            this.txtMaVaiTro.Location = new System.Drawing.Point(133, 26);
            this.txtMaVaiTro.Name = "txtMaVaiTro";
            this.txtMaVaiTro.Size = new System.Drawing.Size(253, 27);
            this.txtMaVaiTro.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã vai trò:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.No;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(285, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(338, 38);
            this.label8.TabIndex = 9;
            this.label8.Text = "THÔNG TIN VAI TRÒ";
            // 
            // frmNhaKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmNhaKhoaHoc";
            this.Text = "frmNhaKhoaHoc";
            this.Load += new System.EventHandler(this.frmNhaKhoaHoc_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtwNKH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtwVaiTro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtwNKH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dtwVaiTro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoaVaiTro;
        private System.Windows.Forms.Button btnSuaVaiTro;
        private System.Windows.Forms.Button btnThemVaiTro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenVaiTro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaVaiTro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxHocVi;
        private System.Windows.Forms.ComboBox cbxLinhVuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button XoaNKH;
        private System.Windows.Forms.Button btnSuaNKH;
        private System.Windows.Forms.Button btnThemNKH;
        private System.Windows.Forms.TextBox txtTenNhaKhoaHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNhaKhoaHoc;
        private System.Windows.Forms.Label label2;
    }
}