using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuHocPhi2.Controls.HeThong;
using ThuHocPhi2.Models.HeThong;

namespace ThuHocPhi2.Views.HeThong
{
    public partial class frm_DangNhap : Form
    {
        ctrl_DangNhap ctrl = new ctrl_DangNhap();
        DangNhap_ett ett = new DangNhap_ett();

        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //ctrl.SetDangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
            if (ctrl.CheckCauHinh())
            {
                try
                {
                    if (ctrl.CheckTaiKhoan(txtTenDangNhap.Text, txtMatKhau.Text))
                    {
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi");

                }
            }
            else
            {
                MessageBox.Show("Chưa cài đặt cấu hình hoặc cấu hình sai");
            }
            
                       
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            Views.HeThong.frm_CauHinh f = new Views.HeThong.frm_CauHinh();
            f.Show();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            //ett = ctrl.GetDangNhap();
            //txtTenDangNhap.Text = ett.username;
            //txtMatKhau.Text = ett.password;
        }
    }
}
