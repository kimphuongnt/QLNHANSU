using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmPhongBan : Form
    {
        //DONE
        BUS_PhongBan phongBanBUS;
        public frmPhongBan()
        {
            InitializeComponent();
            phongBanBUS = new BUS_PhongBan();
        }
        private void LoadData()
        {
            dgvPhongBan.DataSource = null;
            phongBanBUS = new BUS_PhongBan();
            dgvPhongBan.DataSource = phongBanBUS.getAll();

            dgvPhongBan.Columns["MaPB"].HeaderText = "Mã Phòng Ban";
            dgvPhongBan.Columns["TenPB"].HeaderText = "Tên Phòng Ban";
            dgvPhongBan.Columns["DiaChi"].HeaderText = "Địa Chỉ Phòng Ban";
            dgvPhongBan.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại Phòng Ban";
        }
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = btnHuy.Enabled = false;
            LoadData();
        }

        private void dgvPhongBan_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgvPhongBan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPhongBan.SelectedRows[0];
                string maPB = selectedRow.Cells["MaPB"].Value.ToString();
                string tenPB = selectedRow.Cells["TenPB"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string sodienThoai = selectedRow.Cells["SoDienThoai"].Value.ToString();

                txtMaPhongBan.Text = maPB;
                txtTenPhongBan.Text = tenPB;
                txtDiaChi.Text = diaChi;
                txtSDT.Text = sodienThoai;
                txtTongNV.Text = phongBanBUS.tinhTongNhanVienTrongPhongBan(maPB).ToString();

            }

        }

        private void dgvPhongBan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvPhongBan.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dgvPhongBan.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ngayHienTai = DateTime.Now.ToString("ddss");
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9);
            txtMaPhongBan.Text = "PH" + randomNumber.ToString() + ngayHienTai + randomNumber.ToString();
            dgvPhongBan.ClearSelection();
            txtTenPhongBan.Text = txtDiaChi.Text = txtSDT.Text = "";
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = false;
            txtMaPhongBan.Enabled = txtTenPhongBan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = true;
            txtMaPhongBan.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = false; txtTenPhongBan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = true;
            txtTenPhongBan.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhongBan.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có xác nhận xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        DataGridViewRow selectedRow = dgvPhongBan.SelectedRows[0];
                        string maPB = selectedRow.Cells["MaPB"].Value.ToString();

                        //Khi xóa pb có nv code lỗi không hiện tb

                        DTO_PhongBan phongBanDTO = new DTO_PhongBan();
                        phongBanDTO.MaPB = maPB;
                        bool kq = phongBanBUS.delete(phongBanDTO);
                        if (kq == true)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();
        }

        List<DTO_PhongBan> ketQuaTimKiem;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDiaChi.Enabled == false && txtSDT.Enabled == false) //tìm
                {
                    if (timtheoten == true)
                    {
                        string tenPB = txtTenPhongBan.Text.Trim();
                        ketQuaTimKiem = phongBanBUS.search(tenPB);

                        if (ketQuaTimKiem.Count > 0)
                        {
                            dgvPhongBan.DataSource = ketQuaTimKiem;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    else if (timtheoma == true)
                    {
                        string maPB = txtMaPhongBan.Text.Trim();
                        ketQuaTimKiem = phongBanBUS.searchMa(maPB);

                        if (ketQuaTimKiem.Count > 0)
                        {
                            dgvPhongBan.DataSource = ketQuaTimKiem;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
                else if (txtMaPhongBan.Enabled == true)//thêm
                {
                    if (!string.IsNullOrEmpty(txtMaPhongBan.Text) || !string.IsNullOrEmpty(txtTenPhongBan.Text))
                    {
                        DTO_PhongBan phongBanDTO = new DTO_PhongBan(txtMaPhongBan.Text, txtTenPhongBan.Text, txtDiaChi.Text, txtSDT.Text);

                        if (phongBanBUS.insert(phongBanDTO))
                        {
                            LoadData();
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy nhập đầy đủ mã và tên phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (txtMaPhongBan.Enabled == false)
                {

                    if (dgvPhongBan.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dgvPhongBan.SelectedRows[0];
                        DTO_PhongBan phongBanDTO = new DTO_PhongBan(txtMaPhongBan.Text, txtTenPhongBan.Text, txtDiaChi.Text, txtSDT.Text);
                        if (phongBanBUS.update(phongBanDTO))
                        {

                            LoadData();
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtMaPhongBan.Enabled = txtTenPhongBan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = true;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaPhongBan.Text = txtTenPhongBan.Text = txtDiaChi.Text = txtSDT.Text = txtTongNV.Text = string.Empty;
            txtMaPhongBan.Enabled = txtTenPhongBan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;
            dgvPhongBan.ClearSelection();
        }
        bool timtheoten, timtheoma;

        private void tìmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaPhongBan.Text = txtTenPhongBan.Text = txtDiaChi.Text = txtSDT.Text = "";
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = false;
            txtMaPhongBan.Enabled = true;
            txtTenPhongBan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = false;
            txtMaPhongBan.Focus();
            timtheoten = false;
            timtheoma = true;
        }

        private void txtMaPhongBan_TextChanged(object sender, EventArgs e)
        {
            if (!txtMaPhongBan.Text.StartsWith("PH"))
            {
                txtMaPhongBan.Text = "PH" + txtMaPhongBan.Text;
                txtMaPhongBan.SelectionStart = txtMaPhongBan.Text.Length;
            }
        }

        private void tìmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaPhongBan.Text = txtTenPhongBan.Text = txtDiaChi.Text = txtSDT.Text = "";
            btnLuu.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnTim.Enabled = btnRefresh.Enabled = false;
            txtTenPhongBan.Enabled = true;
            txtMaPhongBan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = false;
            txtTenPhongBan.Focus();
            timtheoten = true;
            timtheoma = false;
        }
    }
}
