namespace QUANLYNHANSU
{
    partial class frmHopDongLaoDong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHopDongLaoDong));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnLoc = new System.Windows.Forms.ToolStripButton();
            this.btnTim = new System.Windows.Forms.ToolStripDropDownButton();
            this.tìmTheoMãHợpĐồngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmTheoMãToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmTheoLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmTheoNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grpHopDong = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblLoaiHD = new System.Windows.Forms.Label();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.txtLoaiHD = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.radConHan = new System.Windows.Forms.RadioButton();
            this.radHetHan = new System.Windows.Forms.RadioButton();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.grpNhanVien = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.masktxtSDT = new System.Windows.Forms.MaskedTextBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpHopDong.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grpNhanVien.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
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
            this.toolStrip.Size = new System.Drawing.Size(1266, 34);
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
            this.btnThem.ImageTransparentColor = System.Drawing.SystemColors.HotTrack;
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
            this.tìmTheoMãHợpĐồngToolStripMenuItem,
            this.tìmTheoNgàyToolStripMenuItem});
            this.btnTim.Image = global::QUANLYNHANSU.Properties.Resources.search;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnTim.Size = new System.Drawing.Size(88, 29);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // tìmTheoMãHợpĐồngToolStripMenuItem
            // 
            this.tìmTheoMãHợpĐồngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tìmTheoMãToolStripMenuItem,
            this.tìmTheoLoạiToolStripMenuItem});
            this.tìmTheoMãHợpĐồngToolStripMenuItem.Name = "tìmTheoMãHợpĐồngToolStripMenuItem";
            this.tìmTheoMãHợpĐồngToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.tìmTheoMãHợpĐồngToolStripMenuItem.Text = "Tìm Theo Hợp Đồng";
            // 
            // tìmTheoMãToolStripMenuItem
            // 
            this.tìmTheoMãToolStripMenuItem.Name = "tìmTheoMãToolStripMenuItem";
            this.tìmTheoMãToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.tìmTheoMãToolStripMenuItem.Text = "Tìm Theo Mã";
            this.tìmTheoMãToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoMãToolStripMenuItem_Click);
            // 
            // tìmTheoLoạiToolStripMenuItem
            // 
            this.tìmTheoLoạiToolStripMenuItem.Name = "tìmTheoLoạiToolStripMenuItem";
            this.tìmTheoLoạiToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.tìmTheoLoạiToolStripMenuItem.Text = "Tìm Theo Loại";
            this.tìmTheoLoạiToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoLoạiToolStripMenuItem_Click);
            // 
            // tìmTheoNgàyToolStripMenuItem
            // 
            this.tìmTheoNgàyToolStripMenuItem.Name = "tìmTheoNgàyToolStripMenuItem";
            this.tìmTheoNgàyToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.tìmTheoNgàyToolStripMenuItem.Text = "Tìm Theo Ngày";
            this.tìmTheoNgàyToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoNgàyToolStripMenuItem_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "employee-icon.ico");
            this.imageList1.Images.SetKeyName(1, "icon-add.png");
            this.imageList1.Images.SetKeyName(2, "icon-cancel.png");
            this.imageList1.Images.SetKeyName(3, "icon-contract.ico");
            this.imageList1.Images.SetKeyName(4, "icon-department.ico");
            this.imageList1.Images.SetKeyName(5, "icon-edit.png");
            this.imageList1.Images.SetKeyName(6, "refresh.png");
            this.imageList1.Images.SetKeyName(7, "remove.png");
            this.imageList1.Images.SetKeyName(8, "save.png");
            this.imageList1.Images.SetKeyName(9, "search.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvHopDong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1266, 604);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.AllowUserToAddRows = false;
            this.dgvHopDong.AllowUserToDeleteRows = false;
            this.dgvHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHopDong.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHopDong.Location = new System.Drawing.Point(4, 3);
            this.dgvHopDong.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.ReadOnly = true;
            this.dgvHopDong.RowHeadersWidth = 62;
            this.dgvHopDong.RowTemplate.Height = 28;
            this.dgvHopDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHopDong.Size = new System.Drawing.Size(1258, 296);
            this.dgvHopDong.TabIndex = 0;
            this.dgvHopDong.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvHopDong_RowPrePaint);
            this.dgvHopDong.SelectionChanged += new System.EventHandler(this.dgvHopDong_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.grpHopDong, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grpNhanVien, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 305);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1258, 296);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // grpHopDong
            // 
            this.grpHopDong.Controls.Add(this.tableLayoutPanel3);
            this.grpHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHopDong.Location = new System.Drawing.Point(4, 3);
            this.grpHopDong.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpHopDong.Name = "grpHopDong";
            this.grpHopDong.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpHopDong.Size = new System.Drawing.Size(621, 290);
            this.grpHopDong.TabIndex = 0;
            this.grpHopDong.TabStop = false;
            this.grpHopDong.Text = "Thông tin hợp đồng";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaHD, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblLoaiHD, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblNgayBD, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblNgayKT, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblTinhTrang, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtMaHD, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtLoaiHD, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.dtpNgayBD, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.dtpNgayKT, 2, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 26);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.92301F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.2301F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.2301F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.23356F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.2301F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.2301F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.92301F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(613, 261);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaHD.Location = new System.Drawing.Point(23, 5);
            this.lblMaHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(183, 50);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã Hợp Đồng";
            this.lblMaHD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLoaiHD
            // 
            this.lblLoaiHD.AutoSize = true;
            this.lblLoaiHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiHD.Location = new System.Drawing.Point(23, 55);
            this.lblLoaiHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoaiHD.Name = "lblLoaiHD";
            this.lblLoaiHD.Size = new System.Drawing.Size(183, 50);
            this.lblLoaiHD.TabIndex = 1;
            this.lblLoaiHD.Text = "Loại Hợp Đồng";
            this.lblLoaiHD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayBD.Location = new System.Drawing.Point(23, 105);
            this.lblNgayBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(183, 50);
            this.lblNgayBD.TabIndex = 2;
            this.lblNgayBD.Text = "Ngày Bắt Đầu";
            this.lblNgayBD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayKT.Location = new System.Drawing.Point(23, 155);
            this.lblNgayKT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(183, 50);
            this.lblNgayKT.TabIndex = 3;
            this.lblNgayKT.Text = "Ngày Kết Thúc";
            this.lblNgayKT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTinhTrang.Location = new System.Drawing.Point(23, 205);
            this.lblTinhTrang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(183, 50);
            this.lblTinhTrang.TabIndex = 4;
            this.lblTinhTrang.Text = "Tình Trạng";
            this.lblTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Location = new System.Drawing.Point(214, 8);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(375, 30);
            this.txtMaHD.TabIndex = 5;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // txtLoaiHD
            // 
            this.txtLoaiHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoaiHD.Location = new System.Drawing.Point(214, 58);
            this.txtLoaiHD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLoaiHD.Name = "txtLoaiHD";
            this.txtLoaiHD.Size = new System.Drawing.Size(375, 30);
            this.txtLoaiHD.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.radConHan, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.radHetHan, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(214, 208);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(375, 44);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // radConHan
            // 
            this.radConHan.AutoSize = true;
            this.radConHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radConHan.Location = new System.Drawing.Point(4, 3);
            this.radConHan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radConHan.Name = "radConHan";
            this.radConHan.Size = new System.Drawing.Size(179, 38);
            this.radConHan.TabIndex = 0;
            this.radConHan.TabStop = true;
            this.radConHan.Text = "Còn hạn";
            this.radConHan.UseVisualStyleBackColor = true;
            // 
            // radHetHan
            // 
            this.radHetHan.AutoSize = true;
            this.radHetHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radHetHan.Location = new System.Drawing.Point(191, 3);
            this.radHetHan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radHetHan.Name = "radHetHan";
            this.radHetHan.Size = new System.Drawing.Size(180, 38);
            this.radHetHan.TabIndex = 1;
            this.radHetHan.TabStop = true;
            this.radHetHan.Text = "Hết Hạn";
            this.radHetHan.UseVisualStyleBackColor = true;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(213, 108);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(377, 30);
            this.dtpNgayBD.TabIndex = 10;
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(213, 158);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(377, 30);
            this.dtpNgayKT.TabIndex = 11;
            // 
            // grpNhanVien
            // 
            this.grpNhanVien.Controls.Add(this.tableLayoutPanel5);
            this.grpNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNhanVien.Location = new System.Drawing.Point(632, 3);
            this.grpNhanVien.Name = "grpNhanVien";
            this.grpNhanVien.Size = new System.Drawing.Size(623, 290);
            this.grpNhanVien.TabIndex = 1;
            this.grpNhanVien.TabStop = false;
            this.grpNhanVien.Text = "Thông tin nhân viên";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125F));
            this.tableLayoutPanel5.Controls.Add(this.lblMaNV, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblTenNV, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblNgaySinh, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.lblSoDienThoai, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.lblChucVu, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.cboMaNV, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtTenNV, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.masktxtSDT, 2, 4);
            this.tableLayoutPanel5.Controls.Add(this.cboChucVu, 2, 5);
            this.tableLayoutPanel5.Controls.Add(this.dtpNgaySinh, 2, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7874016F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.68504F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7874016F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(617, 261);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNV.Location = new System.Drawing.Point(22, 2);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(186, 51);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã Nhân Viên";
            this.lblMaNV.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNV.Location = new System.Drawing.Point(22, 53);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(186, 51);
            this.lblTenNV.TabIndex = 1;
            this.lblTenNV.Text = "Tên Nhân Viên";
            this.lblTenNV.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgaySinh.Location = new System.Drawing.Point(22, 104);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(186, 51);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày Sinh";
            this.lblNgaySinh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoai.Location = new System.Drawing.Point(22, 155);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(186, 51);
            this.lblSoDienThoai.TabIndex = 3;
            this.lblSoDienThoai.Text = "Số Điện Thoại";
            this.lblSoDienThoai.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChucVu.Location = new System.Drawing.Point(22, 206);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(186, 51);
            this.lblChucVu.TabIndex = 4;
            this.lblChucVu.Text = "Chức Vụ";
            this.lblChucVu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboMaNV
            // 
            this.cboMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(214, 5);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(379, 30);
            this.cboMaNV.TabIndex = 5;
            this.cboMaNV.SelectedIndexChanged += new System.EventHandler(this.cboMaNV_SelectedIndexChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNV.Location = new System.Drawing.Point(214, 56);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(379, 30);
            this.txtTenNV.TabIndex = 6;
            // 
            // masktxtSDT
            // 
            this.masktxtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masktxtSDT.Location = new System.Drawing.Point(214, 158);
            this.masktxtSDT.Mask = "(999) 000-0000";
            this.masktxtSDT.Name = "masktxtSDT";
            this.masktxtSDT.Size = new System.Drawing.Size(379, 30);
            this.masktxtSDT.TabIndex = 8;
            // 
            // cboChucVu
            // 
            this.cboChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(214, 209);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(379, 30);
            this.cboChucVu.TabIndex = 9;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(214, 107);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(379, 30);
            this.dtpNgaySinh.TabIndex = 10;
            // 
            // frmHopDongLaoDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmHopDongLaoDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hợp đồng lao động";
            this.Load += new System.EventHandler(this.frmHopDongLaoDong_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpHopDong.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.grpNhanVien.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grpHopDong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblLoaiHD;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtLoaiHD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton radConHan;
        private System.Windows.Forms.RadioButton radHetHan;
        private System.Windows.Forms.GroupBox grpNhanVien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.MaskedTextBox masktxtSDT;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ToolStripButton btnLoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton btnTim;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoMãHợpĐồngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoMãToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoLoạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmTheoNgàyToolStripMenuItem;
    }
}