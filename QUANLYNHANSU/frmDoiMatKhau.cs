using QUANLYNHANSU.BUS;
using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmDoiMatKhau : Form
    {
        private string maNhanVien;
        private string tenDangNhap;
        BUS_DangNhap dangNhapBUS;
        public frmDoiMatKhau(string maNV, string tenDN)
        {
            InitializeComponent();
            dangNhapBUS = new BUS_DangNhap();
            maNhanVien = maNV;
            tenDangNhap = tenDN;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            string mkCu = txtMKCu.Text;
            string mkMoi = txtMKMoi.Text;
            string xnMK = txtKTMK.Text;

            if (mkCu == "" || mkMoi == "" || xnMK == "")
            {
                errorProvider1.SetError(txtMKCu, "Vui lòng nhập mật khẩu cũ!");
                errorProvider2.SetError(txtMKMoi, "Vui lòng nhập mật khẩu mới!");
                errorProvider3.SetError(txtKTMK, "Vui lòng xác nhận mật khẩu mới!");
                return;
            }

            if (!KiemTraMatKhauCu(mkCu))
            {
                errorProvider1.SetError(txtMKCu, "Mật khẩu cũ không chính xác!");
                return;
            }

            if (mkMoi != xnMK)
            {
                errorProvider3.SetError(txtKTMK, "Mật khẩu mới và xác nhận mật khẩu không khớp!");
                return;
            }

            if (dangNhapBUS.DoiMatKhau(maNhanVien, tenDangNhap, mkMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmDangNhap dn = new frmDangNhap();
                dn.Show();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật mật khẩu!");
            }


        }
        private bool KiemTraMatKhauCu(string oldPassword)
        {
            DTO_DangNhap dn = dangNhapBUS.DangNhap(tenDangNhap, oldPassword);
            if (dn != null)
            {
                return true;
            }
            return false;
        }


    }
}
