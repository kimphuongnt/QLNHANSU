using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmTinhLuong : Form
    {
        private bool dangLoc, dangThem, dangSua, dangTimTheoTen, dangtinhluong = false;

        List<DTO_NhanThan> ketQuaTimKiem;

        BUS_TinhLuong tinhLuongBUS;
        BUS_NhanVien nhanVienBUS;
        BUS_ChucVu chucVuBUS;

        public frmTinhLuong()
        {
            InitializeComponent();
            tinhLuongBUS = new BUS_TinhLuong();
            nhanVienBUS = new BUS_NhanVien();
            chucVuBUS = new BUS_ChucVu();
            LoadComboBox();
            LoadControls();
        }
        private void LoadControls()
        {
            txtTienThuongPhat.Text = txtSoNgayCong.Text = txtTongLuong.Text = txtTenNV.Text = masktxtSDTNV.Text = "";

            cboMaNV.SelectedValue = "Tất cả";
            cboChucVu.SelectedValue = "Tất cả";
            cboNam.SelectedItem = 1;
            cboThang.SelectedItem = 1;

            grpNhanVien.Enabled = grpLuong.Enabled = false;

            btnTinhLuong.Enabled = btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = btnLoc.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;

            dgvTinhLuong.ClearSelection();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            LoadData();
            tinhLuongBUS.TinhTienThuongPhat(cboMaNV.SelectedValue.ToString(), Convert.ToInt32(cboThang.SelectedItem.ToString()), Convert.ToInt32(cboNam.SelectedItem.ToString()));
            tinhLuongBUS.TinhNgayCong(cboMaNV.SelectedValue.ToString(), Convert.ToInt32(cboThang.SelectedItem.ToString()), Convert.ToInt32(cboNam.SelectedItem.ToString()));
            LoadData();
        }
        private bool ThemTinhLuong()
        {
            int thang, nam;

            if (CheckInput())
            {
                if (int.TryParse(cboThang.SelectedItem.ToString(), out thang) &&
                    int.TryParse(cboNam.SelectedItem.ToString(), out nam))
                {
                    return tinhLuongBUS.insert(new DTO_TinhLuong
                    {
                        MaNV = cboMaNV.SelectedValue.ToString(),
                        Thang = thang,
                        Nam = nam,
                        SoNgayCong = 26,
                        TienThuongPhat = 0,
                        Tongluong = 0

                    });
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }

            return false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dangThem)
                {
                    bool themThanhCong = ThemTinhLuong();

                    if (themThanhCong)
                    {
                        string maNV = cboMaNV.SelectedValue.ToString();
                        int thang = int.Parse(cboThang.SelectedItem.ToString());
                        int nam = int.Parse(cboNam.SelectedItem.ToString());
                        tinhLuongBUS.TinhNgayCong(maNV, thang, nam);
                        tinhLuongBUS.TinhTienThuongPhat(maNV, thang, nam);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LoadControls();
                        dangThem = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (dangtinhluong == true)
                {
                    bool datinhtien = false;
                    if (dgvTinhLuong.SelectedRows.Count > 0)
                    {
                        int selectedDong = dgvTinhLuong.SelectedRows.Count > 0 ? dgvTinhLuong.SelectedRows[0].Index : -1;

                        string maNV = cboMaNV.SelectedValue.ToString();
                        int thang = int.Parse(cboThang.SelectedItem.ToString());
                        int nam = int.Parse(cboNam.SelectedItem.ToString());
                        int soNgayCong = int.Parse(txtSoNgayCong.Text.ToString());
                        bool tinhTienTP = tinhLuongBUS.TinhTienThuongPhat(maNV, thang, nam);
                        if (tinhTienTP == true)
                        {
                            LoadData();
                            if (selectedDong != -1 && dgvTinhLuong.Rows.Count > selectedDong)
                            {
                                dgvTinhLuong.Rows[selectedDong].Selected = true;
                            }

                            float tienthuongphat;

                            if (float.TryParse(txtTienThuongPhat.Text, out tienthuongphat))
                            {
                                if (tinhTienTP)
                                {
                                    tienthuongphat = float.Parse(txtTienThuongPhat.Text);
                                    datinhtien = true;
                                }
                                if (datinhtien == true)
                                {
                                    float tongLuong = tinhLuongBUS.TinhTongLuong(maNV, thang, nam);

                                    bool kq = tinhLuongBUS.updateNutTinhLuong(maNV, thang, nam, soNgayCong, tienthuongphat, tongLuong);

                                    if (kq)
                                    {
                                        MessageBox.Show("Đã cập nhật thành công!");
                                        LoadData();
                                        LoadControls();
                                        dangtinhluong = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật thất bại!");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không thể chuyển đổi giá trị sang kiểu float!");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn dữ liệu");
                    }

                }
                else if (dangSua == true)
                {
                    if (dgvTinhLuong.SelectedRows.Count > 0)
                    {
                        if (CapNhatLuong() != false)
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
                        MessageBox.Show("Vui lòng chọn dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dangLoc == true)
                {
                    string selectedMaNV = cboMaNV.SelectedValue.ToString();
                    int selectedThang = int.Parse(cboThang.SelectedItem.ToString());
                    int selectedNam = int.Parse(cboNam.SelectedItem.ToString());

                    List<DTO_TinhLuong> filterTL;

                    if (selectedMaNV == "Tất cả")
                    {
                        filterTL = tinhLuongBUS.filter("Tất cả", selectedThang, selectedNam);
                    }
                    else
                    {
                        filterTL = tinhLuongBUS.filter(selectedMaNV, selectedThang, selectedNam);
                    }
                    dgvTinhLuong.DataSource = filterTL;
                    dangLoc = false;
                    LoadControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dangThem = true;

            grpLuong.Enabled = true;
            grpNhanVien.Enabled = true;

            btnHuy.Enabled = btnLuu.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLoc.Enabled = false;

            cboMaNV.Enabled = cboThang.Enabled = cboNam.Enabled = true;

            txtSoNgayCong.Enabled = txtTienThuongPhat.Enabled = txtTenNV.Enabled = dtpNgaySinhNV.Enabled = masktxtSDTNV.Enabled = cboChucVu.Enabled = txtTongLuong.Enabled = false;
            txtSoNgayCong.Text = "26";
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex > 0)
            {
                string maNV = cboMaNV.SelectedValue.ToString();


                string tenNV = tinhLuongBUS.LayTenNhanVienTuMa(maNV);
                string ngaySinh = tinhLuongBUS.LayNgaySinhNhanVienTuMa(maNV);
                string sdt = tinhLuongBUS.LaySDTNhanVienTuMa(maNV);
                string chucVu = tinhLuongBUS.LayTenCV(maNV);

                txtTenNV.Text = tenNV;
                dtpNgaySinhNV.Text = ngaySinh;
                masktxtSDTNV.Text = sdt;
                cboChucVu.Text = chucVu;
            }
        }

        private void dgvTinhLuong_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvTinhLuong.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTinhLuong.SelectedRows[0];

                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                string thang = selectedRow.Cells["Thang"].Value.ToString();
                string nam = selectedRow.Cells["Nam"].Value.ToString();
                string soNgayCong = selectedRow.Cells["SoNgayCong"].Value.ToString();
                string tongLuong = selectedRow.Cells["TongLuong"].Value.ToString();
                string tienthuongphat = selectedRow.Cells["TienThuongPhat"].Value.ToString();

                cboMaNV.SelectedValue = maNV;
                cboThang.SelectedItem = thang;
                cboNam.SelectedItem = nam;
                txtSoNgayCong.Text = soNgayCong;
                txtTongLuong.Text = tongLuong;
                txtTienThuongPhat.Text = tienthuongphat;
            }
        }
        private bool CapNhatLuong()
        {

            int thang, nam;

            if (CheckInput() != false)
            {
                if (int.TryParse(cboThang.SelectedItem.ToString(), out thang) &&
                    int.TryParse(cboNam.SelectedItem.ToString(), out nam))
                {
                    return tinhLuongBUS.update(new DTO_TinhLuong
                    {
                        MaNV = cboMaNV.SelectedValue.ToString(),
                        Thang = thang,
                        Nam = nam,
                        SoNgayCong = 26,
                        TienThuongPhat = 0,
                        Tongluong = 0

                    });
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }

            return false;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTinhLuong.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {

                    List<DTO_TinhLuong> dsxoa = new List<DTO_TinhLuong>();
                    try
                    {
                        foreach (DataGridViewRow row in dgvTinhLuong.SelectedRows)
                        {
                            string manv = row.Cells["MaNV"].Value.ToString();
                            int thang = int.Parse(row.Cells["Thang"].Value.ToString());
                            int nam = int.Parse(row.Cells["Nam"].Value.ToString());

                            DTO_TinhLuong tinhluong = new DTO_TinhLuong();

                            tinhluong.MaNV = manv;
                            tinhluong.Thang = thang;
                            tinhluong.Nam = nam;

                            dsxoa.Add(tinhluong);
                        }
                        bool thanhcong = true;
                        foreach (DTO_TinhLuong tp in dsxoa)
                        {
                            bool kq = tinhLuongBUS.delete(tp);
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dangThem = dangSua = dangLoc = dangtinhluong = false;
            LoadControls();
            btnHuy.Enabled = btnLuu.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLoc.Enabled = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTinhLuong.SelectedRows.Count > 0)
            {
                dangSua = true;
                grpLuong.Enabled = true;
                grpNhanVien.Enabled = false;

                btnLuu.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

                txtTienThuongPhat.Enabled = txtSoNgayCong.Enabled = txtTongLuong.Enabled = false;
                cboNam.Enabled = cboThang.Enabled = true;
            }
            else
                MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dangLoc = true;
            LoadData();
            dgvTinhLuong.ClearSelection();
            grpLuong.Enabled = true;
            grpNhanVien.Enabled = true;
            cboMaNV.Enabled = true;
            cboChucVu.Enabled = false;
            masktxtSDTNV.Enabled = false;

            txtTienThuongPhat.Enabled = txtSoNgayCong.Enabled = txtTongLuong.Enabled = false;
            cboNam.Enabled = cboThang.Enabled = cboThang.Enabled = true;
            txtTenNV.Enabled = dtpNgaySinhNV.Enabled = masktxtSDTNV.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnRefresh.Enabled = btnLoc.Enabled = false;

        }

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            dangTimTheoTen = true;
            dgvTinhLuong.ClearSelection();
            grpLuong.Enabled = false;
            grpNhanVien.Enabled = true;

            txtTenNV.Enabled = true;
            txtTenNV.Focus();

            cboMaNV.Enabled = dtpNgaySinhNV.Enabled = masktxtSDTNV.Enabled = cboChucVu.Enabled = false;
            cboMaNV.Text = "Tất cả";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dangtinhluong = true;
            btnHuy.Enabled = btnLuu.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLoc.Enabled = btnTinhLuong.Enabled = false;
        }

        private void txtTienThuongPhat_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void LoadComboBox()
        {
            List<DTO_NhanVien> nhanVienList = nhanVienBUS.getAll();
            nhanVienList.Insert(0, new DTO_NhanVien { MaNV = "Tất cả", HoTen = "" });
            BindComboBox(cboMaNV, nhanVienList, "MaNV", "MaNV");

            List<DTO_ChucVu> chucVuList = chucVuBUS.getAll();
            chucVuList.Insert(0, new DTO_ChucVu { MaCV = "", TenCV = "Tất cả" });
            BindComboBox(cboChucVu, chucVuList, "TenCV", "MaCV");

            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString());
            }

            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 10; i <= currentYear; i++)
            {
                cboNam.Items.Add(i.ToString());
            }

        }
        private void LoadData()
        {
            dgvTinhLuong.DataSource = null;
            tinhLuongBUS = new BUS_TinhLuong();
            dgvTinhLuong.DataSource = tinhLuongBUS.getAll();
            string maNV = cboChucVu.SelectedValue.ToString();
            
            //tinhLuongBUS.TinhNgayCong(cboMaNV.SelectedValue.ToString(), Convert.ToInt32(cboThang.SelectedItem.ToString()), Convert.ToInt32(cboNam.SelectedItem.ToString()));
            //tinhLuongBUS.TinhTienThuongPhat(cboMaNV.SelectedValue.ToString(), Convert.ToInt32(cboThang.SelectedItem.ToString()), Convert.ToInt32(cboNam.SelectedItem.ToString()));

            dgvTinhLuong.DataSource = null;
            dgvTinhLuong.DataSource = tinhLuongBUS.getAll();

            dgvTinhLuong.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvTinhLuong.Columns["Thang"].HeaderText = "Tháng";
            dgvTinhLuong.Columns["Nam"].HeaderText = "Năm";
            dgvTinhLuong.Columns["SoNgayCong"].HeaderText = "Số Ngày Công";
            dgvTinhLuong.Columns["TienThuongPhat"].HeaderText = "Số Tiền Thưởng/Phạt";
            dgvTinhLuong.Columns["TongLuong"].HeaderText = "Tổng Lương";

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
            if (cboMaNV.Text == "Tất cả")
                return false;
            else
                return true;
        }
    }
}
