using System;
using System.Windows.Forms;
using ThuHocPhi2.Controls.HeThong;
using ThuHocPhi2.Models.HeThong;

namespace ThuHocPhi2.Views.HeThong
{
    public partial class frm_CauHinh : Form
    {
        ctrl_CauHinh ctrl = new ctrl_CauHinh();
        CauHinh_ett ett = new CauHinh_ett();
        public frm_CauHinh()
        {
            InitializeComponent();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            ctrl.SetCauHinh(txtMayChu.Text, txtCSDL.Text, txtTaiKhoan.Text, txtMK.Text);
            try
            {
                ctrl.KetNoi();
                MessageBox.Show("Kết nối thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ctrl.SetCauHinh(txtMayChu.Text, txtCSDL.Text, txtTaiKhoan.Text, txtMK.Text);
            MessageBox.Show("Đã lưu");
            this.Close();
        }

        private void frm_CauHinh_Load(object sender, EventArgs e)
        {
            ett = ctrl.GetCauHinh();
            txtMayChu.Text = ett.server;
            txtCSDL.Text = ett.database;
            txtTaiKhoan.Text = ett.username;
            txtMK.Text = ett.password;
        }
    }
}
