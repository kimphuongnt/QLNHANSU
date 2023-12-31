using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmNhanThan : Form
    {
        private bool dangLoc, dangThem, dangSua, dangTimTheoMa, dangTimTheoTen = false;

        List<DTO_NhanThan> ketQuaTimKiem;

        BUS_NhanThan nhanThanBUS;
        BUS_NhanVien nhanVienBUS;
        BUS_ChucVu chucVuBUS;
        public frmNhanThan()
        {
            InitializeComponent();
            nhanThanBUS = new BUS_NhanThan();
            nhanVienBUS = new BUS_NhanVien();
            chucVuBUS = new BUS_ChucVu();
            LoadComboBox();
            LoadControls();
        }

        private void dgvNhanThan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvNhanThan.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dgvNhanThan.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void LoadControls()
        {
            txtMaNT.Text = txtTenNT.Text = txtNgheNghiep.Text = txtTenNV.Text = masktxtSDTNT.Text = masktxtSDTNV.Text = "";

            cboMaNV.SelectedValue = "Tất cả";
            cboChucVu.SelectedValue = "Tất cả";

            grpNhanThan.Enabled = grpNhanVien.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvNhanThan.ClearSelection();
        }

        private void LoadComboBox()
        {
            List<DTO_NhanVien> nhanVienList = nhanVienBUS.getAll();
            nhanVienList.Insert(0, new DTO_NhanVien { MaNV = "Tất cả", HoTen = "" });
            BindComboBox(cboMaNV, nhanVienList, "MaNV", "MaNV");

            List<DTO_ChucVu> chucVuList = chucVuBUS.getAll();
            chucVuList.Insert(0, new DTO_ChucVu { MaCV = "", TenCV = "Tất cả" });
            BindComboBox(cboChucVu, chucVuList, "TenCV", "MaCV");
        }
        private void LoadData()
        {
            dgvNhanThan.DataSource = null;
            nhanThanBUS = new BUS_NhanThan();
            dgvNhanThan.DataSource = nhanThanBUS.getAll();

            dgvNhanThan.Columns["MaNT"].HeaderText = "Mã Nhân Thân";
            dgvNhanThan.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvNhanThan.Columns["Ten"].HeaderText = "Họ Tên";
            dgvNhanThan.Columns["QuanHe"].HeaderText = "Mối Quan Hệ";
            dgvNhanThan.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvNhanThan.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvNhanThan.Columns["NgheNghiep"].HeaderText = "Nghề Nghiệp";

        }
        private void BindComboBox<T>(ComboBox comboBox, List<T> dataSource, string displayMember, string valueMember, bool isCurrency = false)
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;

            comboBox.DataSource = bindingSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtMaNT.Text) || string.IsNullOrEmpty(txtTenNT.Text)
                || string.IsNullOrEmpty(txtQuanHe.Text) || string.IsNullOrEmpty(dtpNgaySinhNT.Text)
                || cboMaNV.Text == "Tất cả")
                return false;
            else
                return true;
        }

        private bool ThemNhanThan()
        {
            DateTime ngaysinhnt;
            if (cboMaNV.SelectedIndex > 0)
            {
                if (CheckInput())
                {
                    if (nhanThanBUS.KiemTraTrungMa(txtMaNT.Text, cboMaNV.SelectedValue.ToString()))
                    {
                        if (DateTime.TryParse(dtpNgaySinhNT.Text, out ngaysinhnt))
                        {
                            return nhanThanBUS.insert(new DTO_NhanThan
                            {
                                MaNT = txtMaNT.Text,
                                MaNV = cboMaNV.SelectedValue.ToString(),
                                Ten = txtTenNT.Text,
                                QuanHe = txtQuanHe.Text,
                                NgaySinh = ngaysinhnt,
                                SoDienThoai = masktxtSDTNT.Text,
                                NgheNghiep = txtNgheNghiep.Text

                            });
                        }
                        else
                        {
                            MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Mã nhân thân đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private bool CapNhatNhanThan()
        {
            DateTime ngaysinhNT;
            if (CheckInput() != false)
            {
                if (cboMaNV.SelectedIndex > 0 && DateTime.TryParse(dtpNgaySinhNT.Text, out ngaysinhNT))
                {
                    return nhanThanBUS.update(new DTO_NhanThan
                    {
                        MaNT = txtMaNT.Text,
                        MaNV = cboMaNV.SelectedValue.ToString(),
                        NgaySinh = ngaysinhNT,
                        NgheNghiep = txtNgheNghiep.Text,
                        SoDienThoai = masktxtSDTNT.Text,
                        QuanHe = txtQuanHe.Text,
                        Ten = txtTenNT.Text
                    });
                }
                else
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThem == true)
                {
                    if (ThemNhanThan() != false)
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
                else if (dangSua == true)
                {
                    if (dgvNhanThan.SelectedRows.Count > 0)
                    {
                        if (CapNhatNhanThan() != false)
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
                        MessageBox.Show("Vui lòng chọn nhân thân cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dangLoc == true)
                {
                    string selectedMaNV = cboMaNV.SelectedValue.ToString();
                    List<DTO_NhanThan> filterNT = nhanThanBUS.filter(
                        selectedMaNV == "Tất cả" ? "" : selectedMaNV);
                    dgvNhanThan.DataSource = filterNT;
                    dangLoc = false;
                    LoadControls();
                }
                else if (dangTimTheoMa == true)
                {
                    ketQuaTimKiem = null;
                    string maNT = txtMaNT.Text.Trim();
                    ketQuaTimKiem = nhanThanBUS.searchMaNT(maNT);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvNhanThan.DataSource = ketQuaTimKiem;
                        dangTimTheoMa = false;
                        LoadControls();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangTimTheoTen == true)
                {
                    ketQuaTimKiem = null;
                    string tennt = txtTenNT.Text.Trim();
                    ketQuaTimKiem = nhanThanBUS.searchTenNT(tennt);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvNhanThan.DataSource = ketQuaTimKiem;
                        dangTimTheoTen = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
            dangLoc = dangThem = dangSua = dangTimTheoMa = dangTimTheoTen = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvNhanThan.ClearSelection();
            txtMaNT.Text = txtTenNT.Text = txtNgheNghiep.Text = txtTenNV.Text = masktxtSDTNT.Text = masktxtSDTNV.Text = txtQuanHe.Text = "";

            txtMaNT.Enabled = txtTenNT.Enabled = txtQuanHe.Enabled = txtNgheNghiep.Enabled = masktxtSDTNT.Enabled = dtpNgaySinhNT.Enabled = true;

            grpNhanThan.Enabled = false;
            grpNhanVien.Enabled = false;
        }

        private void frmNhanThan_Load(object sender, EventArgs e)
        {
            LoadControls();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanThan.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    List<DTO_NhanThan> dsxoa = new List<DTO_NhanThan>();
                    try
                    {
                        foreach (DataGridViewRow row in dgvNhanThan.SelectedRows)
                        {
                            string maNT = row.Cells["MaNT"].Value.ToString();
                            string maNV = row.Cells["MaNV"].Value.ToString();

                            DTO_NhanThan nhanThan = new DTO_NhanThan();
                            nhanThan.MaNV = maNV;
                            nhanThan.MaNT = maNT;

                            dsxoa.Add(nhanThan);
                        }
                        bool thanhcong = true;
                        foreach (DTO_NhanThan nt in dsxoa)
                        {
                            bool kq = nhanThanBUS.delete(nt);
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
                else
                    return;
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanThan.SelectedRows.Count > 0)
            {
                dangSua = true;
                grpNhanThan.Enabled = true;
                grpNhanVien.Enabled = false;

                btnLuu.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

                txtMaNT.Enabled = false;
                txtNgheNghiep.Enabled = dtpNgaySinhNT.Enabled = txtQuanHe.Enabled = txtTenNT.Enabled = txtTenNV.Enabled = true;
                txtTenNT.Focus();

                masktxtSDTNT.Enabled = true;
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dangLoc = true;
            LoadData();
            dgvNhanThan.ClearSelection();
            grpNhanThan.Enabled = false;
            grpNhanVien.Enabled = true;
            cboMaNV.Enabled = true;
            cboChucVu.Enabled = false;
            masktxtSDTNT.Enabled = true;
            masktxtSDTNV.Enabled = false;

            txtTenNV.Enabled = dtpNgaySinhNV.Enabled = txtNgheNghiep.Enabled = dtpNgaySinhNT.Enabled = txtQuanHe.Enabled = txtTenNT.Enabled = txtTenNV.Enabled = false;

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadControls();
            LoadData();
        }

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoMa = true;
            dgvNhanThan.ClearSelection();
            grpNhanThan.Enabled = true;
            txtMaNT.Enabled = true;
            txtMaNT.Focus();

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaNT.Text = txtNgheNghiep.Text = txtQuanHe.Text = txtTenNT.Text = masktxtSDTNT.Text = "";

            txtNgheNghiep.Enabled = txtQuanHe.Enabled = txtTenNT.Enabled = masktxtSDTNT.Enabled = dtpNgaySinhNT.Enabled = false;
        }

        private void txtMaNT_TextChanged(object sender, EventArgs e)
        {
            if (dangThem == true)
            {
                if (!txtMaNT.Text.StartsWith("NT"))
                {
                    txtMaNT.Text = "NT" + txtMaNT.Text;
                    txtMaNT.SelectionStart = txtMaNT.Text.Length;
                }
            }
        }

        private void txtMaNT_Leave(object sender, EventArgs e)
        {
            if (dangThem == true)
            {
                if (string.IsNullOrWhiteSpace(txtMaNT.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân thân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNT.Focus();
                }
                else if (!txtMaNT.Text.StartsWith("NT"))
                {
                    MessageBox.Show("Mã nhân thân phải bắt đầu bằng 'NT'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNT.Focus();
                }
                else if (txtMaNT.Text.Length < 3)
                {
                    MessageBox.Show("Vui lòng nhập thêm số sau 'NT'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNT.Focus();
                }
            }
        }

        private void tìmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoTen = true;
            dgvNhanThan.ClearSelection();
            grpNhanThan.Enabled = true;
            txtTenNT.Enabled = true;
            txtTenNT.Focus();

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtMaNT.Text = txtNgheNghiep.Text = txtQuanHe.Text = txtTenNT.Text = masktxtSDTNT.Text = "";

            txtNgheNghiep.Enabled = txtQuanHe.Enabled = txtMaNT.Enabled = masktxtSDTNT.Enabled = false;
            dtpNgaySinhNT.Enabled = false;
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex > 0)
            {
                string maNV = cboMaNV.SelectedValue.ToString();


                string tenNV = nhanThanBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = nhanThanBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = nhanThanBUS.LaySDTNhanVienTuMa(maNV);
                string chucVu = nhanThanBUS.LayTenCV(maNV);

                txtTenNV.Text = tenNV;
                dtpNgaySinhNV.Text = ngaySinh;
                masktxtSDTNV.Text = sdt;
                cboChucVu.Text = chucVu;
            }
        }

        private void dgvNhanThan_SelectionChanged(object sender, EventArgs e)
        {
            LoadComboBox();
            dgvNhanThan.Columns["MaNT"].HeaderText = "Mã Nhân Thân";
            dgvNhanThan.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvNhanThan.Columns["Ten"].HeaderText = "Họ Tên Nhân Thân";
            dgvNhanThan.Columns["QuanHe"].HeaderText = "Mối Quan Hệ";
            dgvNhanThan.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvNhanThan.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvNhanThan.Columns["NgheNghiep"].HeaderText = "Nghề Nghiệp";
            if (dgvNhanThan.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgvNhanThan.SelectedRows[0];
                string maNT = selected.Cells["MaNT"].Value.ToString();
                string ten = selected.Cells["Ten"].Value.ToString();
                string quanhe = selected.Cells["QuanHe"].Value.ToString();
                string ngaysinh = selected.Cells["NgaySinh"].Value.ToString();
                string sodienthoai = selected.Cells["SoDienThoai"].Value.ToString();
                string nghenghiep = selected.Cells["NgheNghiep"].Value.ToString();

                txtMaNT.Text = maNT;
                txtTenNT.Text = ten;
                txtQuanHe.Text = quanhe;
                dtpNgaySinhNT.Text = ngaysinh;
                masktxtSDTNT.Text = sodienthoai;
                txtNgheNghiep.Text = nghenghiep;

                string maNV = selected.Cells["MaNV"].Value.ToString();
                string tenNV = nhanThanBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = nhanThanBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = nhanThanBUS.LaySDTNhanVienTuMa(maNV);
                string maCV = nhanThanBUS.LayTenCV(maNV);

                cboMaNV.SelectedValue = maNV;
                txtTenNV.Text = tenNV;
                dtpNgaySinhNV.Text = ngaySinh;
                masktxtSDTNV.Text = sdt;
                cboChucVu.Text = maCV;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ngayHienTai = DateTime.Now.ToString("ddss");
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9);

            LoadData();
            dangThem = true;

            grpNhanThan.Enabled = true;
            grpNhanVien.Enabled = true;

            txtMaNT.Enabled = true;
            txtMaNT.Text = "NT" + randomNumber.ToString() + ngayHienTai + randomNumber.ToString();
            txtMaNT.Focus();
            txtTenNT.Enabled = txtQuanHe.Enabled = txtNgheNghiep.Enabled = masktxtSDTNT.Enabled = dtpNgaySinhNT.Enabled = true;
            txtTenNT.Text = txtQuanHe.Text = txtNgheNghiep.Text = masktxtSDTNT.Text = dtpNgaySinhNT.Text = "";

            txtTenNV.Enabled = dtpNgaySinhNV.Enabled = masktxtSDTNV.Enabled = cboChucVu.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            dgvNhanThan.ClearSelection();

        }
    }
}
