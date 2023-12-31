using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmNhanVien : Form
    {
        //DONE

        private bool dangThem, dangSua, dangTimTheoTen, dangTimTheoMa, dangLoc;

        List<DTO_NhanVien> ketQuaTimKiem;

        BUS_NhanVien nhanVienBUS;
        BUS_PhongBan phongBanBUS;
        BUS_ChucVu chucVuBUS;
        BUS_TrinhDoHocVan trinhDoBUS;
        BUS_Luong luongBUS;
        public frmNhanVien()
        {
            InitializeComponent();
            nhanVienBUS = new BUS_NhanVien();
            phongBanBUS = new BUS_PhongBan();
            chucVuBUS = new BUS_ChucVu();
            trinhDoBUS = new BUS_TrinhDoHocVan();
            luongBUS = new BUS_Luong();
            LoadCombobox();
            LoadControls();
        }
        private void LoadControls()
        {
            dgvNhanVien.ClearSelection();
            txtMaNV.Text = txtHoTen.Text = txtCMND.Text = txtQueQuan.Text = masktxtSDT.Text = txtDanToc.Text = "";
            pictureBoxHinh.Image = null;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;
            grpThongTin.Enabled = false;
            grpViTri.Enabled = false;
            grpThongTinKhac.Enabled = false;
            grpGioiTinh.Enabled = false;
            btnChonAnh.Enabled = false;
            dangLoc = dangSua = dangThem = dangTimTheoMa = dangTimTheoTen = false;


        }
        private void LoadData()
        {
            dgvNhanVien.DataSource = null;
            nhanVienBUS = new BUS_NhanVien();
            dgvNhanVien.DataSource = nhanVienBUS.getAll();
            dgvNhanVien.Columns["Hinh"].Visible = dgvNhanVien.Columns["MaPB"].Visible =
                dgvNhanVien.Columns["MaNguoiQuanLy"].Visible = dgvNhanVien.Columns["MaCV"].Visible =
                dgvNhanVien.Columns["MucLuong"].Visible = dgvNhanVien.Columns["MaTDHV"].Visible = false;

            dgvNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns["MaPB"].HeaderText = "Mã Phòng Ban";
            dgvNhanVien.Columns["MaCV"].HeaderText = "Mã Chức Vụ";
            dgvNhanVien.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["CMND"].HeaderText = "Số CMND";
            dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvNhanVien.Columns["QueQuan"].HeaderText = "Quê Quán";
            dgvNhanVien.Columns["DanToc"].HeaderText = "Dân Tộc";
            dgvNhanVien.Columns["MucLuong"].HeaderText = "Mức Lương";
            dgvNhanVien.Columns["MaTDHV"].HeaderText = "Mã Trình Độ Học Vấn";
            dgvNhanVien.Columns["TinhTrangHonNhan"].HeaderText = "Tình Trạng Hôn Nhân";
            dgvNhanVien.Columns["MaNguoiQuanLy"].HeaderText = "Mã Người Quản Lý";

        }
        private void LoadCombobox()
        {
            List<DTO_PhongBan> phongBanList = phongBanBUS.getAll();
            phongBanList.Insert(0, new DTO_PhongBan { MaPB = "", TenPB = "Tất cả" });
            BindComboBox(cboPhongBan, phongBanList, "TenPB", "MaPB");

            List<DTO_ChucVu> chucVuList = chucVuBUS.getAll();
            chucVuList.Insert(0, new DTO_ChucVu { MaCV = "", TenCV = "Tất cả" });
            BindComboBox(cboChucVu, chucVuList, "TenCV", "MaCV");

            List<DTO_TrinhDoHocVan> tdhvList = trinhDoBUS.getAll();
            tdhvList.Insert(0, new DTO_TrinhDoHocVan { MaTDHV = "", TTDHV = "Tất cả" });
            BindComboBox(cboTrinhDoHocVan, tdhvList, "TTDHV", "MaTDHV");

            List<DTO_Luong> mucLuongList = luongBUS.getAll();
            mucLuongList.Insert(0, new DTO_Luong { MucLuong = "", LuongCB = 0 });
            BindComboBox(cboMucLuong, mucLuongList, "LuongCB", "MucLuong", true);

            List<DTO_NhanVien> nhanVienList = nhanVienBUS.getAll();
            nhanVienList.Insert(0, new DTO_NhanVien { MaNV = "", HoTen = "Không có" });
            BindComboBox(cboMaNguoiQuanLy, nhanVienList, "HoTen", "MaNV");
        }

        private void BindComboBox<T>(ComboBox comboBox, List<T> dataSource, string displayMember, string valueMember, bool isCurrency = false)
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;

            comboBox.DataSource = bindingSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (isCurrency)
            {
                comboBox.Format += (s, e) =>
                {
                    if (e.DesiredType == typeof(string))
                    {
                        object value = e.Value;
                        if (value != null)
                        {
                            e.Value = string.Format(new CultureInfo("vi-VN"), "{0:C0}", value);
                        }
                    }
                };
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadControls();
            LoadData();

        }

        private void
            dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            LoadCombobox();
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgvNhanVien.SelectedRows[0];
                string maNV = selected.Cells["MaNV"].Value.ToString();
                string maPB = selected.Cells["MaPB"].Value.ToString();
                string maCV = selected.Cells["MaCV"].Value.ToString();
                string hoTen = selected.Cells["HoTen"].Value.ToString();
                string ngaySinh = selected.Cells["NgaySinh"].Value.ToString();
                string gioiTinh = selected.Cells["GioiTinh"].Value.ToString();
                string cmnd = selected.Cells["CMND"].Value.ToString();
                string soDienThoai = selected.Cells["SoDienThoai"].Value.ToString();
                string queQuan = selected.Cells["QueQuan"].Value.ToString();
                string danToc = selected.Cells["DanToc"].Value.ToString();
                string MucLuong = selected.Cells["MucLuong"].Value.ToString();
                string maTDHV = selected.Cells["MaTDHV"].Value.ToString();
                string tthn = selected.Cells["TinhTrangHonNhan"].Value.ToString();
                Image hinh = (Image) selected.Cells["Hinh"].Value;
                string maNQL = selected.Cells["MaNguoiQuanLy"].Value.ToString();
                if (hinh != null)
                {
                    pictureBoxHinh.Image = hinh;
                }
                else
                {
                    pictureBoxHinh.Image = null;
                }

                txtMaNV.Text = maNV;
                txtHoTen.Text = hoTen;
                txtCMND.Text = cmnd;
                dtpNgaySinh.Text = ngaySinh.ToString();
                txtQueQuan.Text = queQuan;
                masktxtSDT.Text = soDienThoai;
                txtDanToc.Text = danToc;

                cboMucLuong.SelectedValue = MucLuong;
                cboPhongBan.SelectedValue = maPB;
                cboChucVu.SelectedValue = maCV;
                cboTrinhDoHocVan.SelectedValue = maTDHV;
                cboMaNguoiQuanLy.SelectedValue = maNQL;
                if (tthn == "Độc thân")
                {
                    radDocThan.Checked = true;
                    radKetHon.Checked = false;
                }
                else
                {
                    radDocThan.Checked = false;
                    radKetHon.Checked = true;
                }

                if (gioiTinh == "Nam")
                {
                    radNam.Checked = true;
                    radNu.Checked = false;
                }
                else
                {
                    radNu.Checked = true;
                    radNam.Checked = false;
                }


            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = btnHuy.Enabled = true;
            if (ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinh.Image = Image.FromFile(ofdOpenFile.FileName);
                this.Text = ofdOpenFile.FileName;
            }
        }
        private bool ThemNhanVien()
        {

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string tinhTrangHonNhan = radKetHon.Checked ? "Kết hôn" : "Độc thân";

            DateTime ngaySinh;
            if (nhanVienBUS.KiemTraTrungMa(txtMaNV.Text))
            {
                if (CheckInput() != false)
                {
                    if (DateTime.TryParse(dtpNgaySinh.Text, out ngaySinh))
                    {
                        int tuoi = DateTime.Now.Year - ngaySinh.Year;
                        if (tuoi >= 18 && tuoi <= 60)
                        {
                            if (cboMaNguoiQuanLy.SelectedIndex > 0)
                            {
                                return nhanVienBUS.insert(new DTO_NhanVien
                                {
                                    MaNV = txtMaNV.Text,
                                    MaPB = cboPhongBan.SelectedValue.ToString(),
                                    MaCV = cboChucVu.SelectedValue.ToString(),
                                    HoTen = txtHoTen.Text,
                                    NgaySinh = ngaySinh,
                                    GioiTinh = gioiTinh,
                                    CMND = txtCMND.Text,
                                    SoDienThoai = masktxtSDT.Text,
                                    QueQuan = txtQueQuan.Text,
                                    DanToc = txtDanToc.Text,
                                    MucLuong = cboMucLuong.SelectedValue.ToString(),
                                    MaTDHV = cboTrinhDoHocVan.SelectedValue.ToString(),
                                    TinhTrangHonNhan = tinhTrangHonNhan,
                                    MaNguoiQuanLy = cboMaNguoiQuanLy.SelectedValue.ToString(),
                                    Hinh = pictureBoxHinh.Image
                                });
                            }
                            else
                            {
                                return nhanVienBUS.insert(new DTO_NhanVien
                                {
                                    MaNV = txtMaNV.Text,
                                    MaPB = cboPhongBan.SelectedValue.ToString(),
                                    MaCV = cboChucVu.SelectedValue.ToString(),
                                    HoTen = txtHoTen.Text,
                                    NgaySinh = ngaySinh,
                                    GioiTinh = gioiTinh,
                                    CMND = txtCMND.Text,
                                    SoDienThoai = masktxtSDT.Text,
                                    QueQuan = txtQueQuan.Text,
                                    DanToc = txtDanToc.Text,
                                    MucLuong = cboMucLuong.SelectedValue.ToString(),
                                    MaTDHV = cboTrinhDoHocVan.SelectedValue.ToString(),
                                    TinhTrangHonNhan = tinhTrangHonNhan,
                                    MaNguoiQuanLy = null,
                                    Hinh = pictureBoxHinh.Image
                                });
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên phải từ 18 đến 59 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CapNhatNhanVien()
        {
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string tinhTrangHonNhan = radKetHon.Checked ? "Kết hôn" : "Độc thân";

            DateTime ngaySinh;
            if (CheckInput() != false)
            {
                if (DateTime.TryParse(dtpNgaySinh.Text, out ngaySinh))
                {
                    int tuoi = DateTime.Now.Year - ngaySinh.Year;
                    if (tuoi >= 18 && tuoi <= 60)
                    {
                        if (cboMaNguoiQuanLy.SelectedIndex > 0)
                        {
                            return nhanVienBUS.update(new DTO_NhanVien
                            {
                                MaNV = txtMaNV.Text,
                                MaPB = cboPhongBan.SelectedValue.ToString(),
                                MaCV = cboChucVu.SelectedValue.ToString(),
                                HoTen = txtHoTen.Text,
                                NgaySinh = ngaySinh,
                                GioiTinh = gioiTinh,
                                CMND = txtCMND.Text,
                                SoDienThoai = masktxtSDT.Text,
                                QueQuan = txtQueQuan.Text,
                                DanToc = txtDanToc.Text,
                                MucLuong = cboMucLuong.SelectedValue.ToString(),
                                MaTDHV = cboTrinhDoHocVan.SelectedValue.ToString(),
                                TinhTrangHonNhan = tinhTrangHonNhan,
                                MaNguoiQuanLy = cboMaNguoiQuanLy.SelectedValue.ToString(),
                                Hinh = pictureBoxHinh.Image
                            });
                        }
                        else
                        {
                            return nhanVienBUS.update(new DTO_NhanVien
                            {
                                MaNV = txtMaNV.Text,
                                MaPB = cboPhongBan.SelectedValue.ToString(),
                                MaCV = cboChucVu.SelectedValue.ToString(),
                                HoTen = txtHoTen.Text,
                                NgaySinh = ngaySinh,
                                GioiTinh = gioiTinh,
                                CMND = txtCMND.Text,
                                SoDienThoai = masktxtSDT.Text,
                                QueQuan = txtQueQuan.Text,
                                DanToc = txtDanToc.Text,
                                MucLuong = cboMucLuong.SelectedValue.ToString(),
                                MaTDHV = cboTrinhDoHocVan.SelectedValue.ToString(),
                                TinhTrangHonNhan = tinhTrangHonNhan,
                                MaNguoiQuanLy = null,
                                Hinh = pictureBoxHinh.Image
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên phải từ 18 đến 59 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) ||
                        string.IsNullOrEmpty(txtHoTen.Text) ||
                        string.IsNullOrEmpty(txtCMND.Text) ||
                        string.IsNullOrEmpty(masktxtSDT.Text) ||
                        string.IsNullOrEmpty(txtQueQuan.Text) ||
                        string.IsNullOrEmpty(txtDanToc.Text) ||
                        cboPhongBan.Text == "Tất cả" ||
                        cboChucVu.Text == "Tất cả" ||
                        cboTrinhDoHocVan.Text == "Tất cả" ||
                        cboMucLuong.Text == "Tất cả" || txtCMND.Text.Trim().Length > 12 || txtCMND.Text.Trim().Length < 9)
            {
                return false;
            }
            else
                return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThem)
                {

                    if (ThemNhanVien() != false)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        dangThem = false;

                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại\nVui lòng kiểm tra các trường dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (dangSua)
                {
                    if (CapNhatNhanVien() != false)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        dangSua = false;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại\nVui lòng kiểm tra các trường dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangTimTheoTen)
                {
                    ketQuaTimKiem = null;
                    string tenNV = txtHoTen.Text.Trim();
                    ketQuaTimKiem = nhanVienBUS.search(tenNV);

                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvNhanVien.DataSource = ketQuaTimKiem;
                        dangTimTheoTen = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK);
                    }
                    LoadControls();

                }
                else if (dangTimTheoMa)
                {
                    ketQuaTimKiem = null;
                    string maNV = txtMaNV.Text.Trim();
                    ketQuaTimKiem = nhanVienBUS.searchMa(maNV);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvNhanVien.DataSource = ketQuaTimKiem;
                        dangTimTheoMa = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK);
                    }
                    LoadControls();
                }
                else if (dangLoc == true)
                {
                    string selectedPhongBan = cboPhongBan.SelectedValue.ToString();
                    string selectedChucVu = cboChucVu.SelectedValue.ToString();
                    string selectedTrinhDo = cboTrinhDoHocVan.SelectedValue.ToString();
                    string selectedMucLuong = cboMucLuong.SelectedValue.ToString();
                    string selectedNguoiQuanLy = cboMaNguoiQuanLy.SelectedValue.ToString();
                    bool isMale = radNam.Checked;
                    bool isFemale = radNu.Checked;

                    List<DTO_NhanVien> filterNV = nhanVienBUS.filter(
                        selectedPhongBan == "Tất cả" ? "" : selectedPhongBan,
                        selectedChucVu == "Tất cả" ? "" : selectedChucVu,
                        selectedTrinhDo == "Tất cả" ? "" : selectedTrinhDo,
                        selectedMucLuong == "Tất cả" ? "" : selectedMucLuong,
                        selectedNguoiQuanLy == "Tất cả" ? "" : selectedNguoiQuanLy,
                        isMale,
                        isFemale
                    );

                    dgvNhanVien.DataSource = filterNV;
                    dangLoc = false;
                    LoadControls();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ngayHienTai = DateTime.Now.ToString("ddss");
            Random rand = new Random();
            int RAND = rand.Next(1, 9);

            dangLoc = dangSua = dangTimTheoMa = dangTimTheoTen = false;
            dangThem = true;
            grpThongTin.Enabled = true;
            grpViTri.Enabled = true;
            grpThongTinKhac.Enabled = true;
            grpGioiTinh.Enabled = true;
            btnChonAnh.Enabled = true;

            txtMaNV.Enabled = true;
            txtMaNV.Text = "NV" + RAND.ToString() + ngayHienTai + RAND.ToString();
            txtCMND.Enabled = txtQueQuan.Enabled = txtDanToc.Enabled = txtHoTen.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = radDocThan.Enabled = radKetHon.Enabled = true;
            pictureBoxHinh.Image = null;
            dgvNhanVien.ClearSelection();
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            txtHoTen.Text = txtCMND.Text = txtQueQuan.Text = masktxtSDT.Text = txtDanToc.Text = "";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                dangLoc = dangThem = dangTimTheoMa = dangTimTheoTen = false;
                dangSua = true;

                btnLuu.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
                grpThongTin.Enabled = true;
                grpViTri.Enabled = true;
                grpThongTinKhac.Enabled = true;
                grpGioiTinh.Enabled = true;
                btnChonAnh.Enabled = true;
                txtMaNV.Enabled = false;
                txtHoTen.Focus();
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadControls();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
            dangLoc = dangThem = dangSua = dangTimTheoTen = dangTimTheoMa = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;
            dgvNhanVien.ClearSelection();
            grpThongTin.Enabled = false;
            grpViTri.Enabled = false;
            grpThongTinKhac.Enabled = false;
            grpGioiTinh.Enabled = false;
            btnChonAnh.Enabled = false;

            txtMaNV.Text = txtHoTen.Text = txtCMND.Text = txtQueQuan.Text = masktxtSDT.Text = txtDanToc.Text = "";

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (dangThem == true)
            {
                if (!txtMaNV.Text.StartsWith("NV"))
                {
                    txtMaNV.Text = "NV" + txtMaNV.Text;
                    txtMaNV.SelectionStart = txtMaNV.Text.Length;
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
            dgvNhanVien.ClearSelection();
            pictureBoxHinh.Image = null;
            dangLoc = true;
            grpAnhNhanVien.Enabled = grpThongTin.Enabled = false;
            txtMaNV.Text = txtHoTen.Text = txtCMND.Text = txtQueQuan.Text = masktxtSDT.Text = txtDanToc.Text = "";
            grpGioiTinh.Enabled = grpThongTinKhac.Enabled = grpViTri.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;

        }

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoMa = true;
            dgvNhanVien.ClearSelection();
            pictureBoxHinh.Image = null;
            grpThongTin.Enabled = true;
            txtHoTen.Enabled = txtCMND.Enabled = txtQueQuan.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = txtDanToc.Enabled = radKetHon.Enabled = radDocThan.Enabled = false;
            txtMaNV.Text = txtHoTen.Text = txtCMND.Text = txtQueQuan.Text = masktxtSDT.Text = txtDanToc.Text = "";
            txtMaNV.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            grpViTri.Enabled = false;
            grpThongTinKhac.Enabled = false;
            grpGioiTinh.Enabled = false;
            btnChonAnh.Enabled = false;
            dangThem = dangSua = dangTimTheoTen = false;
        }


        private void tìmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoTen = true;
            dgvNhanVien.ClearSelection();
            pictureBoxHinh.Image = null;
            grpThongTin.Enabled = true;
            txtMaNV.Enabled = txtCMND.Enabled = txtQueQuan.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = txtDanToc.Enabled = radKetHon.Enabled = radDocThan.Enabled = false;
            txtMaNV.Text = txtHoTen.Text = txtCMND.Text = txtQueQuan.Text = masktxtSDT.Text = txtDanToc.Text = "";

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            grpViTri.Enabled = false;
            grpThongTinKhac.Enabled = false;
            grpGioiTinh.Enabled = false;
            btnChonAnh.Enabled = false;
            dangThem = dangSua = dangTimTheoMa = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool thanhcong = true;
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    List<DTO_NhanVien> dsxoa = new List<DTO_NhanVien>();
                    try
                    {
                        foreach (DataGridViewRow row in dgvNhanVien.SelectedRows)
                        {
                            string maNV = row.Cells["MaNV"].Value.ToString();
                            if (nhanVienBUS.kiemTraQuanLy(maNV) == false)
                            {
                                MessageBox.Show("Không thể xóa vì nhân viên đang là người quản lý");
                                thanhcong = false;

                            }
                            else
                            {
                                DTO_NhanVien nhanVien = new DTO_NhanVien();
                                nhanVien.MaNV = maNV;

                                dsxoa.Add(nhanVien);
                            }
                        }

                        foreach (DTO_NhanVien nv in dsxoa)
                        {
                            bool kq = nhanVienBUS.delete(nv);
                            if (!kq)
                            {
                                thanhcong = false;
                            }
                        }
                        if (thanhcong)
                        {
                            MessageBox.Show("Xóa thành công");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

            }
            else
            {
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

    }
}
