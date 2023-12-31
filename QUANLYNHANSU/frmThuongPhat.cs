using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QUANLYNHANSU
{
    public partial class frmThuongPhat : Form
    {
        private bool dangLoc, dangThem, dangSua, dangTimTheoMa, dangTimTheoNgay = false;

        List<DTO_ChiTietThuongPhat> ketQuaTimKiem;

        BUS_ThuongPhat thuongPhatBUS;
        BUS_ChiTietThuongPhat chiTietThuongPhatBUS;
        BUS_NhanVien nhanVienBUS;
        BUS_ChucVu chucVuBUS;

        public frmThuongPhat()
        {
            InitializeComponent();
            chiTietThuongPhatBUS = new BUS_ChiTietThuongPhat();
            thuongPhatBUS = new BUS_ThuongPhat();
            nhanVienBUS = new BUS_NhanVien();
            chucVuBUS = new BUS_ChucVu();
            LoadComboBox();
            LoadControls();

        }

        private void LoadComboBox()
        {
            List<DTO_NhanVien> nhanVienList = nhanVienBUS.getAll();
            nhanVienList.Insert(0, new DTO_NhanVien { MaNV = "Tất cả", HoTen = "" });
            BindComboBox(cboMaNV, nhanVienList, "MaNV", "MaNV");

            List<DTO_ChucVu> chucVuList = chucVuBUS.getAll();
            chucVuList.Insert(0, new DTO_ChucVu { MaCV = "", TenCV = "Tất cả" });
            BindComboBox(cboChucVu, chucVuList, "TenCV", "MaCV");

            List<DTO_ThuongPhat> thuongPhatList = thuongPhatBUS.getAll();
            thuongPhatList.Insert(0, new DTO_ThuongPhat { MaTP = "", Loai = "Tất cả" });
            BindComboBox(cboLoai, thuongPhatList, "Loai", "MaTP");
        }
        private void BindComboBox<T>(ComboBox comboBox, List<T> dataSource, string displayMember, string valueMember)
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;

            comboBox.DataSource = bindingSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
        private void LoadControls()
        {
            txtCTTP.Text = txtLyDo.Text = txtSoTien.Text = txtSoTien.Text = masktxtSDTNV.Text = "";

            cboMaNV.SelectedValue = "Tất cả";
            cboChucVu.SelectedValue = "Tất cả";
            cboLoai.SelectedValue = "Tất cả";

            grpThuongPhat.Enabled = grpNhanVien.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvThuongPhat.ClearSelection();
        }

        private void dgvThuongPhat_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvThuongPhat.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dgvThuongPhat.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangThem = true;

            grpThuongPhat.Enabled = true;
            grpNhanVien.Enabled = true;

            txtCTTP.Enabled = true;
            cboLoai.Enabled = true;

            txtSoTien.Enabled = dtpNgaySinhNV.Enabled = txtLyDo.Enabled = true;

            txtTenNV.Enabled = dtpNgaySinhNV.Enabled = masktxtSDTNV.Enabled = cboChucVu.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
            txtSoTien.Text = txtLyDo.Text = dtpNgaySinhNV.Text = txtTenNV.Text = masktxtSDTNV.Text = "";

            dgvThuongPhat.ClearSelection();
        }

        private bool ThemThuongPhat()
        {
            DateTime ngay;
            if (CheckInput() != false)
            {
                if (DateTime.TryParse(dtpNgayTP.Text, out ngay))
                {
                    if (chiTietThuongPhatBUS.KiemTraTrungMa(txtCTTP.Text, cboMaNV.SelectedValue.ToString()))
                    {
                        return chiTietThuongPhatBUS.insert(new DTO_ChiTietThuongPhat
                        {
                            MaCTTP = txtCTTP.Text,
                            MaTP = cboLoai.SelectedValue.ToString(),
                            MaNV = cboMaNV.SelectedValue.ToString(),
                            LyDo = txtLyDo.Text,
                            Ngay = ngay,
                            Tien = float.Parse(boFomat(txtSoTien.Text))
                        });
                    }
                    else
                    {
                        MessageBox.Show("Mã đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool CapNhatThuongPhat()
        {
            DateTime ngay;
            if (CheckInput() != false)
            {
                if (cboMaNV.SelectedIndex > 0 && DateTime.TryParse(dtpNgayTP.Text, out ngay))
                {
                    return chiTietThuongPhatBUS.update(new DTO_ChiTietThuongPhat
                    {
                        MaCTTP = txtCTTP.Text,
                        MaTP = cboLoai.SelectedValue.ToString(),
                        MaNV = cboMaNV.SelectedValue.ToString(),
                        LyDo = txtLyDo.Text,
                        Ngay = ngay,
                        Tien = float.Parse(boFomat(txtSoTien.Text))
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThem)
                {
                    if (ThemThuongPhat() != false)
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
                    if (dgvThuongPhat.SelectedRows.Count > 0)
                    {
                        if (CapNhatThuongPhat() != false)
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
                else if (dangLoc)
                {
                    string selectedMaNV = cboMaNV.SelectedValue.ToString();
                    string selectedMaTP = cboLoai.SelectedValue.ToString();
                    List<DTO_ChiTietThuongPhat> filterNT = chiTietThuongPhatBUS.filter(
                        selectedMaNV == "Tất cả" ? "" : selectedMaNV,
                        selectedMaTP == "Tất cả" ? "" : selectedMaTP);
                    dgvThuongPhat.DataSource = filterNT;
                    dangLoc = false;
                    LoadControls();
                }
                else if (dangTimTheoMa)
                {
                    ketQuaTimKiem = null;
                    string matp = txtCTTP.Text.Trim();
                    ketQuaTimKiem = chiTietThuongPhatBUS.searchMaTP(matp);
                    if (ketQuaTimKiem.Count > 0)
                    {
                        dgvThuongPhat.DataSource = ketQuaTimKiem;
                        dangTimTheoMa = false;
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
                    if (DateTime.TryParse(dtpNgayTP.Text, out DateTime Ngay))
                    {
                        ketQuaTimKiem = chiTietThuongPhatBUS.TimTheoNgay(Ngay);
                        if (ketQuaTimKiem.Count > 0)
                        {
                            dgvThuongPhat.DataSource = ketQuaTimKiem;
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

        private void dgvThuongPhat_SelectionChanged(object sender, EventArgs e)
        {
            LoadComboBox();
            if (dgvThuongPhat.SelectedRows.Count > 0)
            {
                DataGridViewRow selected = dgvThuongPhat.SelectedRows[0];
                string macttp = selected.Cells["MaCTTP"].Value.ToString();
                string loai = selected.Cells["MaTP"].Value.ToString();
                string lydo = selected.Cells["LyDo"].Value.ToString();
                string ngay = selected.Cells["Ngay"].Value.ToString();
                string tien = selected.Cells["Tien"].Value.ToString();
                float tienFloat;
                if (float.TryParse(tien, out tienFloat))
                {
                    txtSoTien.Text = FormatCurrency(tienFloat);
                }
                else
                {
                    txtSoTien.Text = "";
                }
                txtCTTP.Text = macttp;
                cboLoai.SelectedValue = loai;
                txtLyDo.Text = lydo;
                dtpNgayTP.Text = ngay;

                string maNV = selected.Cells["MaNV"].Value.ToString();
                string tenNV = chiTietThuongPhatBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = chiTietThuongPhatBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = chiTietThuongPhatBUS.LaySDTNhanVienTuMa(maNV);
                string maCV = chiTietThuongPhatBUS.LayTenCV(maNV);

                cboMaNV.SelectedValue = maNV;
                dtpNgaySinhNV.Text = ngaySinh;
                txtTenNV.Text = tenNV;
                masktxtSDTNV.Text = sdt;
                cboChucVu.Text = maCV;
            }
        }
        private string FormatCurrency(float value)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return string.Format(cul, "{0:0,0}đ", value);
        }
        private string boFomat(string value)
        {
            string cleanValue = value.Replace(",", "").Replace("đ", "").Trim();
            return cleanValue;
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangThem == true)
            {
                string ngayHienTai = DateTime.Now.ToString("ddss");
                Random rand = new Random();
                int randomNumber = rand.Next(1, 9);
                if (cboLoai.SelectedIndex > 0)
                {
                    if (cboLoai.Text != "Tất cả")
                    {
                        if (cboLoai.Text == "Thưởng")
                        {
                            string generatedMaCTTP = "TH" + randomNumber.ToString() + ngayHienTai + randomNumber.ToString();

                            txtCTTP.Text = generatedMaCTTP;
                        }
                        else if (cboLoai.Text == "Phạt")
                        {
                            string generatedMaCTTP = "PH" + randomNumber.ToString() + ngayHienTai + randomNumber.ToString();

                            txtCTTP.Text = generatedMaCTTP;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThuongPhat.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {

                    List<DTO_ChiTietThuongPhat> dsxoa = new List<DTO_ChiTietThuongPhat>();
                    try
                    {
                        foreach (DataGridViewRow row in dgvThuongPhat.SelectedRows)
                        {
                            string maCTTP = row.Cells["MaCTTP"].Value.ToString();

                            DTO_ChiTietThuongPhat thuongphat = new DTO_ChiTietThuongPhat();

                            thuongphat.MaCTTP = maCTTP;

                            dsxoa.Add(thuongphat);
                        }
                        bool thanhcong = true;
                        foreach (DTO_ChiTietThuongPhat tp in dsxoa)
                        {

                            bool kq = chiTietThuongPhatBUS.delete(tp);
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
            if (dgvThuongPhat.SelectedRows.Count > 0)
            {
                dangSua = true;
                grpThuongPhat.Enabled = true;
                grpNhanVien.Enabled = false;

                btnLuu.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

                txtCTTP.Enabled = false;
                txtLyDo.Enabled = dtpNgayTP.Enabled = txtSoTien.Enabled = true;
                txtLyDo.Focus();
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadControls();
            LoadData();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dangLoc = true;
            LoadData();
            dgvThuongPhat.ClearSelection();
            grpThuongPhat.Enabled = true;
            grpNhanVien.Enabled = true;
            cboMaNV.Enabled = true;
            cboLoai.Enabled = true;
            cboChucVu.Enabled = false;
            masktxtSDTNV.Enabled = false;

            txtCTTP.Enabled = txtLyDo.Enabled = txtSoTien.Enabled = dtpNgayTP.Enabled = txtTenNV.Enabled = dtpNgaySinhNV.Enabled = txtCTTP.Enabled = txtLyDo.Enabled = txtSoTien.Enabled = txtTenNV.Enabled = false;

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;
        }

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoMa = true;
            dgvThuongPhat.ClearSelection();
            grpThuongPhat.Enabled = true;
            txtCTTP.Enabled = true;
            txtCTTP.Focus();

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtCTTP.Text = txtLyDo.Text = txtSoTien.Text = "";

            cboLoai.Enabled = txtLyDo.Enabled = txtSoTien.Enabled = dtpNgayTP.Enabled = false;
        }

        private void tìmTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoNgay = true;
            dgvThuongPhat.ClearSelection();
            grpThuongPhat.Enabled = true;
            dtpNgayTP.Enabled = true;

            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

            txtCTTP.Text = txtLyDo.Text = txtSoTien.Text = cboMaNV.Text = txtTenNV.Text = dtpNgaySinhNV.Text = masktxtSDTNV.Text = cboChucVu.Text = "";
            txtLyDo.Enabled = txtSoTien.Enabled = cboLoai.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
            dangLoc = dangThem = dangSua = dangTimTheoMa = dangTimTheoNgay = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvThuongPhat.ClearSelection();
            txtCTTP.Text = txtLyDo.Text = txtSoTien.Text = txtTenNV.Text = masktxtSDTNV.Text = "";

            txtCTTP.Enabled = txtLyDo.Enabled = dtpNgaySinhNV.Enabled = txtSoTien.Enabled = true;

            grpThuongPhat.Enabled = false;
            grpNhanVien.Enabled = false;
        }

        private void txtCTTP_TextChanged(object sender, EventArgs e)
        {
            //if (!txtCTTP.Text.StartsWith("TH"))
            //{
            //    txtCTTP.Text = "PH" + txtCTTP.Text;
            //    txtCTTP.SelectionStart = txtCTTP.Text.Length;
            //}
            ////else if(txtCTTP.Text.StartsWith("TH") && !txtCTTP.Text.StartsWith("PH"))
            ////{
            ////    txtCTTP.Text = "TH" + txtCTTP.Text;
            ////    txtCTTP.SelectionStart = txtCTTP.Text.Length;
            ////}
        }

        public void LoadData()
        {
            dgvThuongPhat.DataSource = null;
            chiTietThuongPhatBUS = new BUS_ChiTietThuongPhat();
            dgvThuongPhat.DataSource = chiTietThuongPhatBUS.getAll();

            dgvThuongPhat.Columns["MaCTTP"].HeaderText = "Mã Chi Tiết Thưởng Phạt";
            dgvThuongPhat.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvThuongPhat.Columns["MaTP"].HeaderText = "Mã Thưởng Phạt";
            dgvThuongPhat.Columns["Tien"].HeaderText = "Số Tiền";
            dgvThuongPhat.Columns["LyDo"].HeaderText = "Lý Do";
            dgvThuongPhat.Columns["Ngay"].HeaderText = "Ngày";

            dgvThuongPhat.Columns["MaTP"].Visible = false;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtCTTP.Text) || string.IsNullOrEmpty(txtLyDo.Text) || cboLoai.Text == "Tất cả"
                || cboMaNV.Text == "Tất cả")
                return false;
            else
                return true;
        }

        private void frmThuongPhat_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadControls();
            LoadComboBox();
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex > 0)
            {
                string maNV = cboMaNV.SelectedValue.ToString();


                string tenNV = chiTietThuongPhatBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = chiTietThuongPhatBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = chiTietThuongPhatBUS.LaySDTNhanVienTuMa(maNV);
                string chucVu = chiTietThuongPhatBUS.LayTenCV(maNV);

                txtTenNV.Text = tenNV;
                dtpNgaySinhNV.Text = ngaySinh;
                masktxtSDTNV.Text = sdt;
                cboChucVu.Text = chucVu;
            }
        }
    }
}
