using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    //DONE
    public partial class frmHopDongLaoDong : Form
    {
        private bool dangThem, dangSua, dangTimTheoLoaiHD, dangTimTheoMaHD, dangLoc, dangTimTheoNgay = false;

        List<DTO_HopDong> ketQuaTimKiem;

        BUS_HopDong hopDongBus;
        BUS_ChucVu chucVuBUS;
        BUS_NhanVien nhanVienBUS;

        public frmHopDongLaoDong()
        {
            InitializeComponent();
            hopDongBus = new BUS_HopDong();
            chucVuBUS = new BUS_ChucVu();
            nhanVienBUS = new BUS_NhanVien();

            LoadCombobox();
            LoadControls();
        }
        private void LoadControls()
        {
            txtMaHD.Text = txtLoaiHD.Text = dtpNgayBD.Text = dtpNgayKT.Text = dtpNgaySinh.Text = txtTenNV.Text = masktxtSDT.Text = "";
            cboMaNV.SelectedValue = "Tất cả";
            cboChucVu.SelectedValue = "Tất cả";

            grpHopDong.Enabled = false;
            grpNhanVien.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvHopDong.ClearSelection();
        }
        private void LoadData()
        {
            dgvHopDong.DataSource = null;
            hopDongBus = new BUS_HopDong();
            dgvHopDong.DataSource = hopDongBus.getAll();

            dgvHopDong.Columns["MaHD"].HeaderText = "Mã Hợp Đồng";
            dgvHopDong.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvHopDong.Columns["LoaiHD"].HeaderText = "Loại Hợp Đồng";
            dgvHopDong.Columns["TuNgay"].HeaderText = "Từ Ngày";
            dgvHopDong.Columns["DenNgay"].HeaderText = "Đến Ngày";
            dgvHopDong.Columns["TinhTrang"].HeaderText = "Tình Trạng";
        }

        private void LoadCombobox()
        {
            List<DTO_NhanVien> nhanVienList = nhanVienBUS.getAll();
            nhanVienList.Insert(0, new DTO_NhanVien { MaNV = "Tất cả", HoTen = "" });
            BindComboBox(cboMaNV, nhanVienList, "MaNV", "MaNV");

            List<DTO_ChucVu> chucVuList = chucVuBUS.getAll();
            chucVuList.Insert(0, new DTO_ChucVu { MaCV = "", TenCV = "Tất cả" });
            BindComboBox(cboChucVu, chucVuList, "TenCV", "MaCV");
        }

        private void BindComboBox<T>(ComboBox comboBox, List<T> dataSource, string displayMember, string valueMember, bool isCurrency = false)
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;

            comboBox.DataSource = bindingSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadControls();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ngayHienTai = DateTime.Now.ToString("ddss");
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9);

            LoadData();
            dangThem = true;

            grpHopDong.Enabled = true;
            grpNhanVien.Enabled = true;

            txtMaHD.Enabled = true;
            txtMaHD.Text = "HD" + randomNumber.ToString() + ngayHienTai + randomNumber.ToString();
            txtLoaiHD.Enabled = dtpNgayBD.Enabled = dtpNgayKT.Enabled = true;

            txtTenNV.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = cboChucVu.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            txtLoaiHD.Text = dtpNgayBD.Text = dtpNgayKT.Text = "";
            radConHan.Enabled = radHetHan.Enabled = false;
            radConHan.Checked = radHetHan.Checked = false;
            dgvHopDong.ClearSelection();

        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex > 0)
            {
                string maNV = cboMaNV.SelectedValue.ToString();


                string tenNV = hopDongBus.LayTenNhanVienTuMa(maNV);
                string ngaySinh = hopDongBus.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = hopDongBus.LaySDTNhanVienTuMa(maNV);
                string chucVu = hopDongBus.LayTenCV(maNV);

                txtTenNV.Text = tenNV;
                dtpNgaySinh.Text = ngaySinh;
                masktxtSDT.Text = sdt;
                cboChucVu.Text = chucVu;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThem)
                {

                    if (ThemHopDong() != false)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LoadControls();
                        dangThem = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (dangSua)
                {
                    if (dgvHopDong.SelectedRows.Count > 0)
                    {

                        if (CapNhatHopDong() != false)
                        {
                            hopDongBus.CapNhatTinhTrang();
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            LoadControls();
                            dangSua = false;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại\nVui lòng kiểm tra các trường dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hợp đồng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dangLoc)
                {
                    string selectedMaNV = cboMaNV.SelectedValue.ToString();
                    bool conHan = radConHan.Checked;
                    bool hetHan = radHetHan.Checked;
                    List<DTO_HopDong> filterHopDong = hopDongBus.filter(
                        selectedMaNV == "Tất cả" ? "" : selectedMaNV,
                        conHan, hetHan
                        );
                    dgvHopDong.DataSource = filterHopDong;
                    dangLoc = false;
                    LoadControls();
                }
                else if (dangTimTheoMaHD)
                {
                    ketQuaTimKiem = null;
                    string maHD = txtMaHD.Text.Trim();
                    ketQuaTimKiem = hopDongBus.searchMaHD(maHD);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvHopDong.DataSource = ketQuaTimKiem;
                        dangTimTheoMaHD = false;
                        LoadControls();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangTimTheoLoaiHD)
                {
                    ketQuaTimKiem = null;
                    string loaiHD = txtLoaiHD.Text.Trim();
                    ketQuaTimKiem = hopDongBus.searchLoaiHD(loaiHD);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvHopDong.DataSource = ketQuaTimKiem;
                        dangTimTheoLoaiHD = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangTimTheoNgay)
                {
                    ketQuaTimKiem = null;
                    if (DateTime.TryParse(dtpNgayBD.Text, out DateTime tuNgay))
                    {
                        ketQuaTimKiem = hopDongBus.TimHopDongTheoNgay(tuNgay);
                        if (ketQuaTimKiem.Count > 0)
                        {
                            dgvHopDong.DataSource = ketQuaTimKiem;
                            dangTimTheoNgay = false;
                            LoadControls();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                dangSua = true;
                grpHopDong.Enabled = true;
                grpNhanVien.Enabled = false;

                btnLuu.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

                txtMaHD.Enabled = false;
                txtLoaiHD.Enabled = dtpNgayBD.Enabled = dtpNgayKT.Enabled = true;
                txtLoaiHD.Focus();

                radConHan.Enabled = radHetHan.Enabled = false;
                radConHan.Checked = radConHan.Checked = false;
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void dgvHopDong_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvHopDong.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dgvHopDong.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvHopDong.SelectedRows)
                        {
                            string maHD = row.Cells["MaHD"].Value.ToString();
                            string maNV = row.Cells["MaNV"].Value.ToString();

                            DTO_HopDong hopDong = new DTO_HopDong();
                            hopDong.MaNV = maNV;
                            hopDong.MaHD = maHD;
                            bool kq = hopDongBus.delete(hopDong);
                            if (!kq)
                            {
                                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadControls();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dangLoc = true;
            LoadData();
            dgvHopDong.ClearSelection();
            grpHopDong.Enabled = true;
            grpNhanVien.Enabled = true;
            cboMaNV.Enabled = true;
            radConHan.Enabled = radHetHan.Enabled = true;

            txtMaHD.Enabled = txtLoaiHD.Enabled = dtpNgayBD.Enabled = dtpNgayKT.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = cboChucVu.Enabled = false;

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            LoadData();
            dangLoc = dangThem = dangSua = dangTimTheoLoaiHD = dangTimTheoMaHD = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvHopDong.ClearSelection();
            txtMaHD.Text = txtLoaiHD.Text = dtpNgayBD.Text = dtpNgayKT.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radConHan.Checked = radHetHan.Checked = false;
            txtLoaiHD.Enabled = dtpNgayBD.Enabled = dtpNgayKT.Enabled = radConHan.Enabled = radHetHan.Enabled = false;

            grpHopDong.Enabled = false;
            grpNhanVien.Enabled = false;
        }

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoMaHD = true;
            dgvHopDong.ClearSelection();
            grpHopDong.Enabled = true;
            txtMaHD.Enabled = true;
            txtMaHD.Focus();

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaHD.Text = txtLoaiHD.Text = dtpNgayBD.Text = dtpNgayKT.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radConHan.Checked = radHetHan.Checked = false;
            txtLoaiHD.Enabled = dtpNgayBD.Enabled = dtpNgayKT.Enabled = radConHan.Enabled = radHetHan.Enabled = false;
        }

        private void tìmTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoNgay = true;
            dgvHopDong.ClearSelection();
            grpHopDong.Enabled = true;
            dtpNgayBD.Enabled = true;
            dtpNgayKT.Enabled = false;

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaHD.Text = txtLoaiHD.Text = dtpNgayBD.Text = dtpNgayKT.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radConHan.Checked = radHetHan.Checked = false;
            txtLoaiHD.Enabled = txtMaHD.Enabled = radConHan.Enabled = radHetHan.Enabled = false;
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            if (dangThem == true)
            {
                if (!txtMaHD.Text.StartsWith("HD"))
                {
                    txtMaHD.Text = "HD" + txtMaHD.Text;
                    txtMaHD.SelectionStart = txtMaHD.Text.Length;
                }
            }

        }

        private void tìmTheoLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoLoaiHD = true;
            dgvHopDong.ClearSelection();
            grpHopDong.Enabled = true;
            txtLoaiHD.Enabled = true;
            txtLoaiHD.Focus();

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaHD.Text = txtLoaiHD.Text = dtpNgayBD.Text = dtpNgayKT.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radConHan.Checked = radHetHan.Checked = false;
            txtMaHD.Enabled = dtpNgayBD.Enabled = dtpNgayKT.Enabled = radConHan.Enabled = radHetHan.Enabled = false;
        }

        private void dgvHopDong_SelectionChanged(object sender, EventArgs e)
        {
            LoadCombobox();
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgvHopDong.SelectedRows[0];
                string maHD = selected.Cells["MaHD"].Value.ToString();
                string loaiHD = selected.Cells["LoaiHD"].Value.ToString();
                string tuNgay = selected.Cells["TuNgay"].Value.ToString();
                string denNgay = selected.Cells["DenNgay"].Value.ToString();
                string tinhTrang = selected.Cells["TinhTrang"].Value.ToString();
                if (tinhTrang == "Còn hạn")
                {
                    radConHan.Checked = true;
                    radHetHan.Checked = false;
                }
                else
                {
                    radConHan.Checked = false;
                    radHetHan.Checked = true;
                }

                string maNV = selected.Cells["MaNV"].Value.ToString();
                string tenNV = hopDongBus.LayTenNhanVienTuMa(maNV);
                string ngaySinh = hopDongBus.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = hopDongBus.LaySDTNhanVienTuMa(maNV);
                string maCV = hopDongBus.LayTenCV(maNV);

                txtMaHD.Text = maHD;
                txtLoaiHD.Text = loaiHD;
                cboMaNV.SelectedValue = maNV;
                dtpNgayBD.Text = tuNgay;
                dtpNgayKT.Text = denNgay;
                txtTenNV.Text = tenNV;
                dtpNgaySinh.Text = ngaySinh;
                masktxtSDT.Text = sdt;
                cboChucVu.Text = maCV;
            }

        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtMaHD.Text) || string.IsNullOrEmpty(txtLoaiHD.Text)
                || string.IsNullOrEmpty(dtpNgayBD.Text) || string.IsNullOrEmpty(dtpNgayKT.Text)
                || cboMaNV.Text == "Tất cả")
                return false;
            else
                return true;
        }
        private bool ThemHopDong()
        {
            DateTime ngayBatDau, ngayKetThuc;
            DateTime ngayhientai = DateTime.Now;

            if (cboMaNV.SelectedIndex > 0)
            {
                if (CheckInput())
                {
                    if (DateTime.TryParse(dtpNgayBD.Text, out ngayBatDau) &&
                    DateTime.TryParse(dtpNgayKT.Text, out ngayKetThuc))
                    {
                        if (ngayBatDau <= ngayKetThuc)
                        {
                            if (hopDongBus.KiemTraTrungMa(txtMaHD.Text, cboMaNV.SelectedValue.ToString()))
                            {
                                string tinhtrang = (ngayKetThuc < ngayhientai) ? "Hết hạn" : "Còn hạn";
                                return hopDongBus.insert(new DTO_HopDong
                                {
                                    MaHD = txtMaHD.Text,
                                    MaNV = cboMaNV.SelectedValue.ToString(),
                                    LoaiHD = txtLoaiHD.Text,
                                    TuNgay = ngayBatDau,
                                    DenNgay = ngayKetThuc,
                                    TinhTrang = tinhtrang,
                                });
                            }
                            else
                            {
                                MessageBox.Show("Mã hợp đồng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CapNhatHopDong()
        {
            DateTime ngayBatDau, ngayKetThuc;
            if (CheckInput() != false)
            {
                if (cboMaNV.SelectedIndex > 0 &&
                    DateTime.TryParse(dtpNgayBD.Text, out ngayBatDau) &&
                    DateTime.TryParse(dtpNgayKT.Text, out ngayKetThuc))
                {
                    if (ngayBatDau <= ngayKetThuc)
                    {
                        string tinhTrang = (ngayKetThuc < DateTime.Now) ? "Hết hạn" : "Còn hạn";
                        return hopDongBus.update(new DTO_HopDong
                        {
                            MaHD = txtMaHD.Text,
                            MaNV = cboMaNV.SelectedValue.ToString(),
                            LoaiHD = txtLoaiHD.Text,
                            TuNgay = ngayBatDau,
                            DenNgay = ngayKetThuc,
                            TinhTrang = tinhTrang
                        });

                    }
                    else
                    {
                        MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc hoặc nhân viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
