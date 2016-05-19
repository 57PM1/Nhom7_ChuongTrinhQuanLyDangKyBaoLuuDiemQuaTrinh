using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuHocPhi2.Controls.DuLieuHocPhi;

namespace ThuHocPhi2.Views.DuLieuHocPhi
{
    public partial class frm_ThemSinhVien : Form
    {
        ctrl_TuDienSinhVien ctrl = new ctrl_TuDienSinhVien();
        public frm_ThemSinhVien()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.ThemMoi(txtMaSV.Text, txtHoTen.Text, txtLop.Text);
                MessageBox.Show("Thêm mới thành công");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới thất bại");
            }
            
            
        }
    }
}
