using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmNghiPhep : Form
    {
        private bool dangThem, dangSua, dangTimTheoNgay, dangTimTheoMaNP, dangLoc = false;
        List<DTO_NghiPhep> ketQuaTimKiem;

        BUS_NghiPhep nghiPhepBUS;
        BUS_NhanVien nhanVienBUS;
        BUS_ChucVu chucVuBUS;

        public frmNghiPhep()
        {
            InitializeComponent();
            nghiPhepBUS = new BUS_NghiPhep();
            nhanVienBUS = new BUS_NhanVien();
            chucVuBUS = new BUS_ChucVu();
            LoadCombobox();
            LoadControls();
        }

        private void frmNghiPhep_Load(object sender, System.EventArgs e)
        {
            LoadData();
            LoadControls();

        }

        private void cboMaNV_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboMaNV.SelectedIndex > 0)
            {
                string maNV = cboMaNV.SelectedValue.ToString();


                string tenNV = nghiPhepBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = nghiPhepBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = nghiPhepBUS.LaySDTNhanVienTuMa(maNV);
                string chucVu = nghiPhepBUS.LayTenCV(maNV);

                txtTenNV.Text = tenNV;
                dtpNgaySinh.Text = ngaySinh;
                masktxtSDT.Text = sdt;
                cboChucVu.Text = chucVu;
            }
        }

        private void dgvNghiPhep_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvNghiPhep.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dgvNghiPhep.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtMaNP.Text) || string.IsNullOrEmpty(txtLyDo.Text)
                || string.IsNullOrEmpty(dtpTuNgay.Text) || string.IsNullOrEmpty(dtpDenNgay.Text)
                || cboMaNV.SelectedValue.ToString() == "Tất cả" || radDaDuyet.Checked == false && radChuaDuyet.Checked == false)
                return false;
            else
                return true;
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            string ngayHienTai = DateTime.Now.ToString("ddss");
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9);
            LoadData();
            dangThem = true;

            grpNghiPhep.Enabled = true;
            grpNhanVien.Enabled = true;

            txtMaNP.Enabled = true;
            txtMaNP.Text = "NP" + randomNumber.ToString() + ngayHienTai + randomNumber.ToString();

            dtpDenNgay.Enabled = dtpTuNgay.Enabled = txtLyDo.Enabled = true;

            txtTenNV.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = cboChucVu.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            txtLyDo.Text = dtpTuNgay.Text = dtpDenNgay.Text = txtTenNV.Text = masktxtSDT.Text = "";
            radChuaDuyet.Enabled = radDaDuyet.Enabled = true;
            radChuaDuyet.Checked = radDaDuyet.Checked = false;

            dgvNghiPhep.ClearSelection();
        }
        private bool CapNhatNghiPhep()
        {
            DateTime tuNgay, denNgay;
            if (CheckInput() != false)
            {
                if (cboMaNV.SelectedIndex > 0 &&
                    DateTime.TryParse(dtpTuNgay.Text, out tuNgay) &&
                    DateTime.TryParse(dtpDenNgay.Text, out denNgay))
                {
                    if (tuNgay <= denNgay)
                    {
                        string tinhTrang = radChuaDuyet.Checked ? "Chưa duyệt" : "Đã duyệt";
                        return nghiPhepBUS.update(new DTO_NghiPhep
                        {
                            MaNP = txtMaNP.Text,
                            MaNV = cboMaNV.SelectedValue.ToString(),
                            LyDo = txtLyDo.Text,
                            TuNgay = tuNgay,
                            DenNgay = denNgay,
                            TinhTrang = tinhTrang
                        });
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dangThem)
                {
                    if (ThemNghiPhep() != false)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LoadControls();
                        dangThem = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại\nVui lòng kiểm tra các trường dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangSua)
                {
                    if (dgvNghiPhep.SelectedRows.Count > 0)
                    {
                        if (CapNhatNghiPhep() != false)
                        {
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
                        MessageBox.Show("Vui lòng chọn dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dangLoc)
                {
                    string selectedMaNV = cboMaNV.SelectedValue.ToString();
                    bool chuaDuyet = radChuaDuyet.Checked;
                    bool daDuyet = radDaDuyet.Checked;
                    List<DTO_NghiPhep> filterHopDong = nghiPhepBUS.filter(
                        selectedMaNV == "Tất cả" ? "" : selectedMaNV,
                        chuaDuyet, daDuyet
                        );
                    dgvNghiPhep.DataSource = filterHopDong;
                    dangLoc = false;
                    LoadControls();
                }
                else if (dangTimTheoMaNP)
                {
                    ketQuaTimKiem = null;
                    string maNP = txtMaNP.Text.Trim();
                    ketQuaTimKiem = nghiPhepBUS.searchMaNP(maNP);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvNghiPhep.DataSource = ketQuaTimKiem;
                        dangTimTheoMaNP = false;
                        LoadControls();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangTimTheoNgay)
                {
                    ketQuaTimKiem = null;
                    if (DateTime.TryParse(dtpTuNgay.Text, out DateTime tuNgay))
                    {
                        ketQuaTimKiem = nghiPhepBUS.TimNghiPhepTheoNgay(tuNgay);
                        if (ketQuaTimKiem.Count > 0)
                        {
                            dgvNghiPhep.DataSource = ketQuaTimKiem;
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

        private void btnHuy_Click(object sender, System.EventArgs e)
        {
            LoadData();
            dangLoc = dangThem = dangSua = dangTimTheoNgay = dangTimTheoMaNP = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvNghiPhep.ClearSelection();
            txtMaNP.Text = txtLyDo.Text = dtpTuNgay.Text = dtpDenNgay.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radChuaDuyet.Checked = radDaDuyet.Checked = false;
            txtLyDo.Enabled = dtpTuNgay.Enabled = dtpDenNgay.Enabled = radChuaDuyet.Enabled = radDaDuyet.Enabled = false;

            grpNghiPhep.Enabled = false;
            grpNhanVien.Enabled = false;
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadData();
            LoadControls();
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (dgvNghiPhep.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    List<DTO_NghiPhep> dsxoa = new List<DTO_NghiPhep>();
                    try
                    {
                        foreach (DataGridViewRow row in dgvNghiPhep.SelectedRows)
                        {
                            string maNP = row.Cells["MaNP"].Value.ToString();

                            DTO_NghiPhep nghiPhep = new DTO_NghiPhep();
                            nghiPhep.MaNP = maNP;

                            dsxoa.Add(nghiPhep);
                        }
                        bool thanhcong = true;
                        foreach (DTO_NghiPhep np in dsxoa)
                        {


                            bool kq = nghiPhepBUS.delete(np);
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
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private bool ThemNghiPhep()
        {
            DateTime tuNgay, denNgay;
            DateTime ngayhientai = DateTime.Now;

            if (cboMaNV.SelectedIndex > 0)
            {
                if (DateTime.TryParse(dtpTuNgay.Text, out tuNgay) &&
                DateTime.TryParse(dtpDenNgay.Text, out denNgay))
                {
                    if (tuNgay <= denNgay)
                    {
                        if (nghiPhepBUS.KiemTraTrungMa(txtMaNP.Text))
                        {
                            bool isChuaDuyet = radChuaDuyet.Checked;

                            string tinhTrang = isChuaDuyet ? "Chưa duyệt" : "Đã duyệt";
                            return nghiPhepBUS.insert(new DTO_NghiPhep
                            {
                                MaNP = txtMaNP.Text,
                                MaNV = cboMaNV.SelectedValue.ToString(),
                                TuNgay = tuNgay,
                                DenNgay = denNgay,
                                LyDo = txtLyDo.Text,
                                TinhTrang = tinhTrang
                            });
                        }
                        else
                        {
                            MessageBox.Show("Mã nghỉ phép đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Nhân viên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvNghiPhep_SelectionChanged(object sender, EventArgs e)
        {
            LoadCombobox();
            dgvNghiPhep.Columns["MaNP"].HeaderText = "Mã Phòng Ban";
            dgvNghiPhep.Columns["TuNgay"].HeaderText = "Từ Ngày";
            dgvNghiPhep.Columns["DenNgay"].HeaderText = "Đến Ngày";
            dgvNghiPhep.Columns["LyDo"].HeaderText = "Lý Do";
            dgvNghiPhep.Columns["TinhTrang"].HeaderText = "Tình Trạng";
            dgvNghiPhep.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            if (dgvNghiPhep.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgvNghiPhep.SelectedRows[0];
                string maNP = selected.Cells["MaNP"].Value.ToString();
                string tuNgay = selected.Cells["TuNgay"].Value.ToString();
                string denNgay = selected.Cells["DenNgay"].Value.ToString();
                string lyDo = selected.Cells["LyDo"].Value.ToString();
                string tinhTrang = selected.Cells["TinhTrang"].Value.ToString();
                if (tinhTrang == "Chưa duyệt")
                {
                    radChuaDuyet.Checked = true;
                    radDaDuyet.Checked = false;
                }
                else
                {
                    radChuaDuyet.Checked = false;
                    radDaDuyet.Checked = true;
                }

                string maNV = selected.Cells["MaNV"].Value.ToString();
                string tenNV = nghiPhepBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = nghiPhepBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = nghiPhepBUS.LaySDTNhanVienTuMa(maNV);
                string maCV = nghiPhepBUS.LayTenCV(maNV);

                txtMaNP.Text = maNP;
                txtLyDo.Text = lyDo;
                cboMaNV.SelectedValue = maNV;
                dtpTuNgay.Text = tuNgay;
                dtpDenNgay.Text = denNgay;
                txtTenNV.Text = tenNV;
                dtpNgaySinh.Text = ngaySinh;
                masktxtSDT.Text = sdt;
                cboChucVu.Text = maCV;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhep.SelectedRows.Count > 0)
            {
                dangSua = true;
                grpNghiPhep.Enabled = true;
                grpNhanVien.Enabled = false;

                btnLuu.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

                txtMaNP.Enabled = false;
                txtLyDo.Enabled = dtpTuNgay.Enabled = dtpDenNgay.Enabled = true;
                txtLyDo.Focus();

                radDaDuyet.Enabled = radChuaDuyet.Enabled = true;
                radChuaDuyet.Checked = radDaDuyet.Checked = false;

            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dangLoc = true;
            LoadData();
            dgvNghiPhep.ClearSelection();
            grpNghiPhep.Enabled = true;
            grpNhanVien.Enabled = true;
            cboMaNV.Enabled = true;
            radChuaDuyet.Enabled = radDaDuyet.Enabled = true;

            txtMaNP.Enabled = txtLyDo.Enabled = dtpTuNgay.Enabled = dtpDenNgay.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = masktxtSDT.Enabled = cboChucVu.Enabled = false;

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
        }

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoMaNP = true;
            dgvNghiPhep.ClearSelection();
            grpNghiPhep.Enabled = true;
            txtMaNP.Enabled = true;
            txtMaNP.Focus();

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaNP.Text = txtLyDo.Text = dtpTuNgay.Text = dtpDenNgay.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radChuaDuyet.Checked = radDaDuyet.Checked = false;
            txtLyDo.Enabled = dtpTuNgay.Enabled = dtpDenNgay.Enabled = radChuaDuyet.Enabled = radDaDuyet.Enabled = false;
        }

        private void tìmTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoNgay = true;
            dgvNghiPhep.ClearSelection();
            grpNghiPhep.Enabled = true;
            dtpTuNgay.Enabled = true;
            dtpDenNgay.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaNP.Text = txtLyDo.Text = dtpTuNgay.Text = dtpDenNgay.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinh.Text = masktxtSDT.Text = cboChucVu.Text = "";
            radChuaDuyet.Checked = radDaDuyet.Checked = false;
            txtLyDo.Enabled = txtMaNP.Enabled = radChuaDuyet.Enabled = radDaDuyet.Enabled = false;
        }

        private void txtMaNP_TextChanged(object sender, EventArgs e)
        {
            if (dangThem == true)
            {
                if (!txtMaNP.Text.StartsWith("NP"))
                {
                    txtMaNP.Text = "NP" + txtMaNP.Text;
                    txtMaNP.SelectionStart = txtMaNP.Text.Length;
                }
            }
        }

        private void LoadControls()
        {

            txtMaNP.Text = txtLyDo.Text = dtpTuNgay.Text = dtpDenNgay.Text = dtpNgaySinh.Text = txtTenNV.Text = masktxtSDT.Text = "";

            cboMaNV.SelectedValue = "Tất cả";
            cboChucVu.SelectedValue = "Tất cả";

            grpNghiPhep.Enabled = grpNhanVien.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvNghiPhep.ClearSelection();
        }
        private void LoadData()
        {
            dgvNghiPhep.DataSource = null;
            nghiPhepBUS = new BUS_NghiPhep();
            dgvNghiPhep.DataSource = nghiPhepBUS.getAll();

            dgvNghiPhep.Columns["MaNP"].HeaderText = "Mã Nghỉ Phép";
            dgvNghiPhep.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvNghiPhep.Columns["TuNgay"].HeaderText = "Từ Ngày";
            dgvNghiPhep.Columns["DenNgay"].HeaderText = "Đến Ngày";
            dgvNghiPhep.Columns["LyDo"].HeaderText = "Lý Do";
            dgvNghiPhep.Columns["TinhTrang"].HeaderText = "Tình Trạng";
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



    }
}
