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
    public partial class frm_TuDienSinhVien : Form
    {
        ctrl_TuDienSinhVien ctrl = new ctrl_TuDienSinhVien();
        TuDienSinhVien_ett ett = new TuDienSinhVien_ett();

        public frm_TuDienSinhVien()
        {
            InitializeComponent();
        }

        private void frmTuDienSinhVien_Load(object sender, EventArgs e)
        {
            if (ctrl.GetAllData().Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sinh viên rỗng");
            }
            else
            {
                dataGridView1.DataSource = ctrl.GetAllData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frm_ThemSinhVien f = new frm_ThemSinhVien();
            f.ShowDialog();
            dataGridView1.DataSource = ctrl.GetAllData();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
           OpenFileDialog file = new OpenFileDialog();
           txtFilePath.Text = file.ShowDialog() == DialogResult.OK ? file.FileName : "";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text =="")
            {
                MessageBox.Show("Chưa chọn file import");
            }
            else
            {
                int count = ctrl.ImportFileExcel(txtFilePath.Text);
                dataGridView1.DataSource = ctrl.GetAllData();
                MessageBox.Show("Đã import " + count + " sinh viên");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ett.MaSV = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            ett.HoTen = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            ett.Lop = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            frm_CapNhatSinhVien f = new frm_CapNhatSinhVien(ett);
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

        int dong;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctrl.TimKiemMaSV(txtMaSV.Text);
        }
    }
}
