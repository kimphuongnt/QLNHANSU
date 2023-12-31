namespace QUANLYNHANSU
{
    partial class frmNhanThan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanThan));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnLoc = new System.Windows.Forms.ToolStripButton();
            this.btnTim = new System.Windows.Forms.ToolStripDropDownButton();
            this.tìmTheoTênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmTheoMãToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNhanThan = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grpNhanThan = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNT = new System.Windows.Forms.Label();
            this.lblTenNT = new System.Windows.Forms.Label();
            this.lblQuanHe = new System.Windows.Forms.Label();
            this.txtMaNT = new System.Windows.Forms.TextBox();
            this.txtTenNT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgaySinhNT = new System.Windows.Forms.DateTimePicker();
            this.masktxtSDTNT = new System.Windows.Forms.MaskedTextBox();
            this.txtNgheNghiep = new System.Windows.Forms.TextBox();
            this.txtQuanHe = new System.Windows.Forms.TextBox();
            this.grpNhanVien = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblSDTNV = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.dtpNgaySinhNV = new System.Windows.Forms.DateTimePicker();
            this.masktxtSDTNV = new System.Windows.Forms.MaskedTextBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanThan)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpNhanThan.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpNhanVien.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.btnLoc,
            this.btnTim,
            this.toolStripSeparator1,
            this.btnLuu,
            this.btnHuy});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1075, 34);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "Menu";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::QUANLYNHANSU.Properties.Resources.icon_add;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnThem.Size = new System.Drawing.Size(89, 29);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::QUANLYNHANSU.Properties.Resources.remove;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnXoa.Size = new System.Drawing.Size(76, 29);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::QUANLYNHANSU.Properties.Resources.icon_edit;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnSua.Size = new System.Drawing.Size(75, 29);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::QUANLYNHANSU.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnRefresh.Size = new System.Drawing.Size(103, 29);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Image = global::QUANLYNHANSU.Properties.Resources.filter;
            this.btnLoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(67, 29);
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
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
            this.btnTim.Size = new System.Drawing.Size(88, 29);
            this.btnTim.Text = "Tìm";
            // 
            // tìmTheoTênToolStripMenuItem
            // 
            this.tìmTheoTênToolStripMenuItem.Name = "tìmTheoTênToolStripMenuItem";
            this.tìmTheoTênToolStripMenuItem.Size = new System.Drawing.Size(308, 34);
            this.tìmTheoTênToolStripMenuItem.Text = "Tìm Theo Tên Nhân Thân";
            this.tìmTheoTênToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoTênToolStripMenuItem_Click);
            // 
            // tìmTheoMãToolStripMenuItem
            // 
            this.tìmTheoMãToolStripMenuItem.Name = "tìmTheoMãToolStripMenuItem";
            this.tìmTheoMãToolStripMenuItem.Size = new System.Drawing.Size(308, 34);
            this.tìmTheoMãToolStripMenuItem.Text = "Tìm Theo Mã Nhân Thân";
            this.tìmTheoMãToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoMãToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::QUANLYNHANSU.Properties.Resources.save;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnLuu.Size = new System.Drawing.Size(74, 29);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QUANLYNHANSU.Properties.Resources.icon_cancel;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnHuy.Size = new System.Drawing.Size(77, 29);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvNhanThan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 519);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvNhanThan
            // 
            this.dgvNhanThan.AllowUserToAddRows = false;
            this.dgvNhanThan.AllowUserToDeleteRows = false;
            this.dgvNhanThan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanThan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvNhanThan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanThan.Location = new System.Drawing.Point(4, 3);
            this.dgvNhanThan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvNhanThan.MultiSelect = false;
            this.dgvNhanThan.Name = "dgvNhanThan";
            this.dgvNhanThan.ReadOnly = true;
            this.dgvNhanThan.RowHeadersWidth = 62;
            this.dgvNhanThan.RowTemplate.Height = 28;
            this.dgvNhanThan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanThan.Size = new System.Drawing.Size(1067, 253);
            this.dgvNhanThan.TabIndex = 0;
            this.dgvNhanThan.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvNhanThan_RowPrePaint);
            this.dgvNhanThan.SelectionChanged += new System.EventHandler(this.dgvNhanThan_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.grpNhanThan, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grpNhanVien, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 262);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1067, 254);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // grpNhanThan
            // 
            this.grpNhanThan.Controls.Add(this.tableLayoutPanel3);
            this.grpNhanThan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNhanThan.Location = new System.Drawing.Point(4, 3);
            this.grpNhanThan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpNhanThan.Name = "grpNhanThan";
            this.grpNhanThan.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpNhanThan.Size = new System.Drawing.Size(525, 248);
            this.grpNhanThan.TabIndex = 0;
            this.grpNhanThan.TabStop = false;
            this.grpNhanThan.Text = "Thông tin nhân thân";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.923077F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.84615F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.30769F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.923077F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaNT, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTenNT, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblQuanHe, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtMaNT, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTenNT, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.dtpNgaySinhNT, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.masktxtSDTNT, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtNgheNghiep, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtQuanHe, 2, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 26);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66742F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66616F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66616F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66616F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66743F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(517, 219);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaNT
            // 
            this.lblMaNT.AutoSize = true;
            this.lblMaNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNT.Location = new System.Drawing.Point(12, 0);
            this.lblMaNT.Name = "lblMaNT";
            this.lblMaNT.Size = new System.Drawing.Size(143, 36);
            this.lblMaNT.TabIndex = 0;
            this.lblMaNT.Text = "Mã Nhân Thân";
            this.lblMaNT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTenNT
            // 
            this.lblTenNT.AutoSize = true;
            this.lblTenNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNT.Location = new System.Drawing.Point(12, 36);
            this.lblTenNT.Name = "lblTenNT";
            this.lblTenNT.Size = new System.Drawing.Size(143, 36);
            this.lblTenNT.TabIndex = 1;
            this.lblTenNT.Text = "Tên Nhân Thân";
            this.lblTenNT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblQuanHe
            // 
            this.lblQuanHe.AutoSize = true;
            this.lblQuanHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuanHe.Location = new System.Drawing.Point(12, 72);
            this.lblQuanHe.Name = "lblQuanHe";
            this.lblQuanHe.Size = new System.Drawing.Size(143, 36);
            this.lblQuanHe.TabIndex = 2;
            this.lblQuanHe.Text = "Mối Quan Hệ";
            this.lblQuanHe.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaNT
            // 
            this.txtMaNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNT.Location = new System.Drawing.Point(161, 3);
            this.txtMaNT.Name = "txtMaNT";
            this.txtMaNT.Size = new System.Drawing.Size(341, 30);
            this.txtMaNT.TabIndex = 5;
            this.txtMaNT.TextChanged += new System.EventHandler(this.txtMaNT_TextChanged);
            this.txtMaNT.Leave += new System.EventHandler(this.txtMaNT_Leave);
            // 
            // txtTenNT
            // 
            this.txtTenNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNT.Location = new System.Drawing.Point(161, 39);
            this.txtTenNT.Name = "txtTenNT";
            this.txtTenNT.Size = new System.Drawing.Size(341, 30);
            this.txtTenNT.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ngày Sinh";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(12, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 36);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số Điện Thoại";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nghề Nghiệp";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpNgaySinhNT
            // 
            this.dtpNgaySinhNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgaySinhNT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinhNT.Location = new System.Drawing.Point(161, 111);
            this.dtpNgaySinhNT.Name = "dtpNgaySinhNT";
            this.dtpNgaySinhNT.Size = new System.Drawing.Size(341, 30);
            this.dtpNgaySinhNT.TabIndex = 11;
            // 
            // masktxtSDTNT
            // 
            this.masktxtSDTNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masktxtSDTNT.Location = new System.Drawing.Point(161, 147);
            this.masktxtSDTNT.Mask = "(999) 000-0000";
            this.masktxtSDTNT.Name = "masktxtSDTNT";
            this.masktxtSDTNT.Size = new System.Drawing.Size(341, 30);
            this.masktxtSDTNT.TabIndex = 12;
            // 
            // txtNgheNghiep
            // 
            this.txtNgheNghiep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgheNghiep.Location = new System.Drawing.Point(161, 183);
            this.txtNgheNghiep.Name = "txtNgheNghiep";
            this.txtNgheNghiep.Size = new System.Drawing.Size(341, 30);
            this.txtNgheNghiep.TabIndex = 13;
            // 
            // txtQuanHe
            // 
            this.txtQuanHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuanHe.Location = new System.Drawing.Point(161, 75);
            this.txtQuanHe.Name = "txtQuanHe";
            this.txtQuanHe.Size = new System.Drawing.Size(341, 30);
            this.txtQuanHe.TabIndex = 14;
            // 
            // grpNhanVien
            // 
            this.grpNhanVien.Controls.Add(this.tableLayoutPanel4);
            this.grpNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNhanVien.Location = new System.Drawing.Point(537, 3);
            this.grpNhanVien.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpNhanVien.Name = "grpNhanVien";
            this.grpNhanVien.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpNhanVien.Size = new System.Drawing.Size(526, 248);
            this.grpNhanVien.TabIndex = 1;
            this.grpNhanVien.TabStop = false;
            this.grpNhanVien.Text = "Thông tin nhân viên";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.923077F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.84615F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.30769F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.923077F));
            this.tableLayoutPanel4.Controls.Add(this.lblMaNV, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTenNV, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblNgaySinh, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblSDTNV, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.lblChucVu, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.cboMaNV, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTenNV, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.dtpNgaySinhNV, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.masktxtSDTNV, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.cboChucVu, 2, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 26);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(518, 219);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNV.Location = new System.Drawing.Point(12, 0);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(143, 36);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã Nhân Viên";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNV.Location = new System.Drawing.Point(12, 36);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(143, 36);
            this.lblTenNV.TabIndex = 1;
            this.lblTenNV.Text = "Tên Nhân Viên";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgaySinh.Location = new System.Drawing.Point(12, 72);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(143, 36);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày Sinh";
            // 
            // lblSDTNV
            // 
            this.lblSDTNV.AutoSize = true;
            this.lblSDTNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSDTNV.Location = new System.Drawing.Point(12, 108);
            this.lblSDTNV.Name = "lblSDTNV";
            this.lblSDTNV.Size = new System.Drawing.Size(143, 36);
            this.lblSDTNV.TabIndex = 3;
            this.lblSDTNV.Text = "Số Điện Thoại";
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChucVu.Location = new System.Drawing.Point(12, 144);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(143, 36);
            this.lblChucVu.TabIndex = 4;
            this.lblChucVu.Text = "Chức Vụ";
            // 
            // cboMaNV
            // 
            this.cboMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(161, 3);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(342, 30);
            this.cboMaNV.TabIndex = 5;
            this.cboMaNV.SelectedIndexChanged += new System.EventHandler(this.cboMaNV_SelectedIndexChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNV.Location = new System.Drawing.Point(161, 39);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(342, 30);
            this.txtTenNV.TabIndex = 6;
            // 
            // dtpNgaySinhNV
            // 
            this.dtpNgaySinhNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgaySinhNV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinhNV.Location = new System.Drawing.Point(161, 75);
            this.dtpNgaySinhNV.Name = "dtpNgaySinhNV";
            this.dtpNgaySinhNV.Size = new System.Drawing.Size(342, 30);
            this.dtpNgaySinhNV.TabIndex = 7;
            // 
            // masktxtSDTNV
            // 
            this.masktxtSDTNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masktxtSDTNV.Location = new System.Drawing.Point(161, 111);
            this.masktxtSDTNV.Mask = "(999) 000-0000";
            this.masktxtSDTNV.Name = "masktxtSDTNV";
            this.masktxtSDTNV.Size = new System.Drawing.Size(342, 30);
            this.masktxtSDTNV.TabIndex = 8;
            // 
            // cboChucVu
            // 
            this.cboChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(161, 147);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(342, 30);
            this.cboChucVu.TabIndex = 9;
            // 
            // frmNhanThan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1075, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmNhanThan";
            this.Text = "Quản Lý Nhân Thân";
            this.Load += new System.EventHandler(this.frmNhanThan_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanThan)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpNhanThan.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grpNhanVien.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnLoc;
        private System.Windows.Forms.ToolStripDropDownButton btnTim;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoTênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoMãToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvNhanThan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grpNhanThan;
        private System.Windows.Forms.GroupBox grpNhanVien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblMaNT;
        private System.Windows.Forms.Label lblTenNT;
        private System.Windows.Forms.Label lblQuanHe;
        private System.Windows.Forms.TextBox txtMaNT;
        private System.Windows.Forms.TextBox txtTenNT;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblSDTNV;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.DateTimePicker dtpNgaySinhNV;
        private System.Windows.Forms.MaskedTextBox masktxtSDTNV;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgaySinhNT;
        private System.Windows.Forms.MaskedTextBox masktxtSDTNT;
        private System.Windows.Forms.TextBox txtNgheNghiep;
        private System.Windows.Forms.TextBox txtQuanHe;
    }
}