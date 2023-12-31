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
    public partial class frmDangNhap : Form
    {
        BUS_DangNhap dangNhapBUS;
        private bool hienMatKhau = false;
        public frmDangNhap()
        {
            InitializeComponent();
            dangNhapBUS = new BUS_DangNhap();
            txtPW.PasswordChar = '*';
            lblThongBaoLoi.Visible = false;
            picThongBaoLoi.Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void picDongMatKhau_Click_1(object sender, EventArgs e)
        {
            txtPW.PasswordChar = '\0';
            picHienMatKhau.Visible = true;
            picDongMatKhau.Visible = false;
            hienMatKhau = false;
        }

        private void picHienMatKhau_Click(object sender, EventArgs e)
        {
            txtPW.PasswordChar = '*';
            picHienMatKhau.Visible = false;
            picDongMatKhau.Visible = true;
            hienMatKhau = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPW.Text;

            DTO_DangNhap dangnhap = dangNhapBUS.DangNhap(username, password);

            if (dangnhap != null)
            {
                MessageBox.Show("Đăng nhập thành công!");
                frmTrangChu tc = new frmTrangChu(dangnhap.MaNV, dangnhap.TenDN, dangnhap.Vaitro);
                tc.Show();
                this.Hide();
            }
            else
            {
                lblThongBaoLoi.Visible = true;
                lblThongBaoLoi.Text = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
                picThongBaoLoi.Visible = true;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
