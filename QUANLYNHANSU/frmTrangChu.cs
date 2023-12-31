using QUANLYNHANSU.BUS;
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
    public partial class frmTrangChu : Form
    {
        private string maNV;
        private string tenNhanVien;
        private string vaiTro;
        public frmTrangChu(string manv, string tennv, string vaitro)
        {
            InitializeComponent();
            this.tenNhanVien = tennv;
            this.vaiTro = vaitro;
            this.maNV = manv;
            lblThongTin.Text = "Xin chào " + tennv;

            if (vaiTro == "Nhân sự")
            {
                btnPhongBan.Enabled = btnLuong.Enabled = false;
            }
            else if (vaiTro == "Kế toán")
            {
                btnPhongBan.Enabled = btnNhanVien.Enabled = false;
            }
            else
                btnPhongBan.Enabled = btnNhanVien.Enabled = btnLuong.Enabled = true;
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.Show();
        }

        private void thôngTinNhânThânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanThan nt = new frmNhanThan();
            nt.Show();
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDongLaoDong hd = new frmHopDongLaoDong();
            hd.Show();
        }

        private void nghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNghiPhep np = new frmNghiPhep();
            np.Show();
        }

        private void quảnLýPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan pb = new frmPhongBan();
            pb.Show();
        }

        private void quảnLýThưởngPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuongPhat tp = new frmThuongPhat();
            tp.Show();
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTinhLuong tl = new frmTinhLuong();
            tl.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap dn = new frmDangNhap();
            dn.Show();
            this.Hide();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau dmk = new frmDoiMatKhau(maNV, tenNhanVien);
            dmk.Show();
        }
    }
}
