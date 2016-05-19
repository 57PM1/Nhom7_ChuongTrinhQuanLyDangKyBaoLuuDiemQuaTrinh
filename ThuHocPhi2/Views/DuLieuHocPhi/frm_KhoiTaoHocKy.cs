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
using ThuHocPhi2.Models.DuLieuHocPhi;

namespace ThuHocPhi2.Views.DuLieuHocPhi
{
    public partial class frm_KhoiTaoHocKy : Form
    {
        ctrl_KhoiTaoHocKy ctrl = new ctrl_KhoiTaoHocKy();
        KhoiTaoHocKy_ett ett = new KhoiTaoHocKy_ett();
        public frm_KhoiTaoHocKy()
        {
            InitializeComponent();
        }

        private void frm_KhoiTaoHocKyVaMucHocPhi_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ctrl.GetAllData();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể tải dữ liệu");
            }
            
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            frm_TaoMoiHocKy f = new Views.DuLieuHocPhi.frm_TaoMoiHocKy();
            f.ShowDialog();
            try
            {
                dataGridView1.DataSource = ctrl.GetAllData();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể tải dữ liệu");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ett.HocKyID = Int32.Parse(dataGridView1.Rows[dong].Cells[0].Value.ToString());
            ett.HocKy = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            ett.HocPhi = float.Parse (dataGridView1.Rows[dong].Cells[2].Value.ToString());
            ett.TrangThai = bool.Parse(dataGridView1.Rows[dong].Cells[3].Value.ToString());
            frm_CapNhatHocKy f = new frm_CapNhatHocKy(ett);
            f.ShowDialog();
            try
            {
                dataGridView1.DataSource = ctrl.GetAllData();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể tải dữ liệu");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string ID =  dataGridView1.Rows[dong].Cells[0].Value.ToString();
            ctrl.Xoa(ID);
            try
            {
                dataGridView1.DataSource = ctrl.GetAllData();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể tải dữ liệu");
            }
        }
        int dong;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }
    }
}
