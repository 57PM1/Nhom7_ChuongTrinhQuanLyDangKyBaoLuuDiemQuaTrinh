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
    public partial class frm_ThemMonHoc : Form
    {
        ctrl_TuDienMonHoc ctrl = new ctrl_TuDienMonHoc();
        
        public frm_ThemMonHoc()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
          
            
            try
            {
                ctrl.ThemMoi(txtMaMH.Text, txtTenMH.Text, txtSTC.Text);
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
