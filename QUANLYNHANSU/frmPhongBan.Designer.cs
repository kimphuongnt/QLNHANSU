namespace QUANLYNHANSU
{
    partial class frmPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongBan));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnTim = new System.Windows.Forms.ToolStripDropDownButton();
            this.tìmTheoTênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmTheoMãToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPhongBan = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaPB = new System.Windows.Forms.Label();
            this.lblTenPB = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblTongNV = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTongNV = new System.Windows.Forms.TextBox();
            this.txtMaPhongBan = new System.Windows.Forms.TextBox();
            this.txtTenPhongBan = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnRefresh,
            this.btnTim,
            this.toolStripSeparator1,
            this.btnLuu,
            this.btnHuy});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1346, 38);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "Menu";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::QUANLYNHANSU.Properties.Resources.icon_add;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnThem.Size = new System.Drawing.Size(89, 33);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::QUANLYNHANSU.Properties.Resources.remove;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnXoa.Size = new System.Drawing.Size(76, 33);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::QUANLYNHANSU.Properties.Resources.icon_edit;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnSua.Size = new System.Drawing.Size(75, 33);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::QUANLYNHANSU.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnRefresh.Size = new System.Drawing.Size(103, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTim
            // 
            this.btnTim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tìmTheoTênToolStripMenuItem,
            this.tìmTheoMãToolStripMenuItem});
            this.btnTim.Image = global::QUANLYNHANSU.Properties.Resources.search;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnTim.Size = new System.Drawing.Size(88, 33);
            this.btnTim.Text = "Tìm";
            // 
            // tìmTheoTênToolStripMenuItem
            // 
            this.tìmTheoTênToolStripMenuItem.Name = "tìmTheoTênToolStripMenuItem";
            this.tìmTheoTênToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.tìmTheoTênToolStripMenuItem.Text = "Tìm Theo Tên";
            this.tìmTheoTênToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoTênToolStripMenuItem_Click);
            // 
            // tìmTheoMãToolStripMenuItem
            // 
            this.tìmTheoMãToolStripMenuItem.Name = "tìmTheoMãToolStripMenuItem";
            this.tìmTheoMãToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.tìmTheoMãToolStripMenuItem.Text = "Tìm Theo Mã";
            this.tìmTheoMãToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoMãToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::QUANLYNHANSU.Properties.Resources.save;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnLuu.Size = new System.Drawing.Size(74, 33);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QUANLYNHANSU.Properties.Resources.icon_cancel;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnHuy.Size = new System.Drawing.Size(77, 33);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPhongBan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1346, 502);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvPhongBan
            // 
            this.dgvPhongBan.AllowUserToAddRows = false;
            this.dgvPhongBan.AllowUserToDeleteRows = false;
            this.dgvPhongBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongBan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhongBan.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPhongBan.Location = new System.Drawing.Point(4, 3);
            this.dgvPhongBan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPhongBan.Name = "dgvPhongBan";
            this.dgvPhongBan.ReadOnly = true;
            this.dgvPhongBan.RowHeadersWidth = 62;
            this.dgvPhongBan.RowTemplate.Height = 28;
            this.dgvPhongBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongBan.Size = new System.Drawing.Size(1338, 295);
            this.dgvPhongBan.TabIndex = 0;
            this.dgvPhongBan.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPhongBan_RowPrePaint);
            this.dgvPhongBan.SelectionChanged += new System.EventHandler(this.dgvPhongBan_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.01682F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.01682F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.70919F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.22351F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.01682F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.01682F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaPB, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTenPB, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDiaChi, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSoDienThoai, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTongNV, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtDiaChi, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTongNV, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtMaPhongBan, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTenPhongBan, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSDT, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 304);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1338, 195);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblMaPB
            // 
            this.lblMaPB.AutoSize = true;
            this.lblMaPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaPB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblMaPB.Location = new System.Drawing.Point(324, 0);
            this.lblMaPB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaPB.Name = "lblMaPB";
            this.lblMaPB.Size = new System.Drawing.Size(175, 39);
            this.lblMaPB.TabIndex = 0;
            this.lblMaPB.Text = "Mã Phòng Ban";
            this.lblMaPB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenPB
            // 
            this.lblTenPB.AutoSize = true;
            this.lblTenPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenPB.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTenPB.Location = new System.Drawing.Point(324, 39);
            this.lblTenPB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenPB.Name = "lblTenPB";
            this.lblTenPB.Size = new System.Drawing.Size(175, 39);
            this.lblTenPB.TabIndex = 1;
            this.lblTenPB.Text = "Tên Phòng Ban";
            this.lblTenPB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblDiaChi.Location = new System.Drawing.Point(324, 78);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(175, 39);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Địa Chỉ";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblSoDienThoai.Location = new System.Drawing.Point(324, 117);
            this.lblSoDienThoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(175, 39);
            this.lblSoDienThoai.TabIndex = 3;
            this.lblSoDienThoai.Text = "Số Điện Thoại";
            this.lblSoDienThoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongNV
            // 
            this.lblTongNV.AutoSize = true;
            this.lblTongNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongNV.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblTongNV.Location = new System.Drawing.Point(1018, 156);
            this.lblTongNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongNV.Name = "lblTongNV";
            this.lblTongNV.Size = new System.Drawing.Size(152, 39);
            this.lblTongNV.TabIndex = 4;
            this.lblTongNV.Text = "Số nhân viên";
            this.lblTongNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChi.Enabled = false;
            this.txtDiaChi.Location = new System.Drawing.Point(507, 81);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(503, 30);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtTongNV
            // 
            this.txtTongNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTongNV.Enabled = false;
            this.txtTongNV.Location = new System.Drawing.Point(1178, 159);
            this.txtTongNV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTongNV.Name = "txtTongNV";
            this.txtTongNV.Size = new System.Drawing.Size(156, 30);
            this.txtTongNV.TabIndex = 9;
            // 
            // txtMaPhongBan
            // 
            this.txtMaPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaPhongBan.Enabled = false;
            this.txtMaPhongBan.Location = new System.Drawing.Point(507, 3);
            this.txtMaPhongBan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMaPhongBan.Name = "txtMaPhongBan";
            this.txtMaPhongBan.Size = new System.Drawing.Size(503, 30);
            this.txtMaPhongBan.TabIndex = 10;
            this.txtMaPhongBan.TextChanged += new System.EventHandler(this.txtMaPhongBan_TextChanged);
            // 
            // txtTenPhongBan
            // 
            this.txtTenPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenPhongBan.Enabled = false;
            this.txtTenPhongBan.Location = new System.Drawing.Point(507, 42);
            this.txtTenPhongBan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTenPhongBan.Name = "txtTenPhongBan";
            this.txtTenPhongBan.Size = new System.Drawing.Size(503, 30);
            this.txtTenPhongBan.TabIndex = 11;
            // 
            // txtSDT
            // 
            this.txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSDT.Enabled = false;
            this.txtSDT.Location = new System.Drawing.Point(507, 120);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSDT.Mask = "(999) 000-0000";
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(503, 30);
            this.txtSDT.TabIndex = 12;
            // 
            // frmPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 540);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng ban";
            this.Load += new System.EventHandler(this.frmPhongBan_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPhongBan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMaPB;
        private System.Windows.Forms.Label lblTenPB;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblTongNV;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTongNV;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.TextBox txtMaPhongBan;
        private System.Windows.Forms.TextBox txtTenPhongBan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.MaskedTextBox txtSDT;
        private System.Windows.Forms.ToolStripDropDownButton btnTim;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoTênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoMãToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

