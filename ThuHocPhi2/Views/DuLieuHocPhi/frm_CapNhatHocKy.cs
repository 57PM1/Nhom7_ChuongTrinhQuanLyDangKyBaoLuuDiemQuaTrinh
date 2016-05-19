using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuHocPhi2.Models.DuLieuHocPhi;
using ThuHocPhi2.Controls.DuLieuHocPhi;

namespace ThuHocPhi2.Views.DuLieuHocPhi
{
    public partial class frm_CapNhatHocKy : Form
    {
        ctrl_KhoiTaoHocKy ctrl = new ctrl_KhoiTaoHocKy();
        public frm_CapNhatHocKy(KhoiTaoHocKy_ett ett)
        {
            InitializeComponent();
            txtID.Text = ett.HocKyID.ToString();
            txtHocKy.Text = ett.HocKy.ToString();
            txtHocPhi.Text = ett.HocPhi.ToString();
            if (ett.TrangThai)
            {
                cbTrangThai.Checked = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool th = false;
            if (cbTrangThai.Checked)
            {
                th = true;
            }
            ctrl.CapNhat(txtID.Text, txtHocKy.Text, txtHocPhi.Text, th);
            this.Close();
        }
    }
}
