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
    public partial class frm_TuDienMonHoc : Form
    {
        ctrl_TuDienMonHoc ctrl = new ctrl_TuDienMonHoc();
        TuDienMonHoc_ett ett = new TuDienMonHoc_ett();
        int dong;
        public frm_TuDienMonHoc( )
        {
            InitializeComponent();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ett.MaMH = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            ett.TenMH = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            ett.SoTCHP = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            frm_CapNhatMonHoc f = new frm_CapNhatMonHoc(ett);
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

        private void frm_TuDienMonHoc_Load(object sender, EventArgs e)
        {
            if (ctrl.GetAllData().Rows.Count == 0)
            {
                MessageBox.Show("Danh sách Môn học rỗng");
            }
            else
            {
                dataGridView1.DataSource = ctrl.GetAllData();
            }
        }

        //public static implicit operator frm_TuDienMonHoc(frm_TuDienSinhVien v)
        //{
        //    throw new NotImplementedException();
        //}

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            frm_ThemMonHoc f = new frm_ThemMonHoc();
            f.ShowDialog();
            dataGridView1.DataSource = ctrl.GetAllData();
        }

        private void btnChon_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            txtFilePath.Text = file.ShowDialog() == DialogResult.OK ? file.FileName : "";
        }

        private void btnImport_Click_1(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("Chưa chọn file import");
            }
            else
            {
                int count = ctrl.ImportFileExcel(txtFilePath.Text);
                dataGridView1.DataSource = ctrl.GetAllData();
                MessageBox.Show("Đã import " + count + " môn học");
            }
        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }

        private void txtMaMH_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctrl.TimKiemMaMH(txtMaMH.Text);
        }
    }
}
