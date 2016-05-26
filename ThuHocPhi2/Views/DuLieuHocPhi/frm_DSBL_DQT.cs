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
using ThuHocPhi2.Views.DuLieuHocPhi.form_con;

namespace ThuHocPhi2.Views.DuLieuHocPhi
{
    public partial class frm_DSBL_DQT : Form
    {
        public frm_DSBL_DQT()
        {
            InitializeComponent();
        }
        ctrl_DSBL_DQT ctr = new ctrl_DSBL_DQT();

        private void ctrl_DSBL_DQT_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctr.loadDL();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_masv_TextChanged(object sender, EventArgs e)
        {
            string i;
            i=txt_masv.Text;
            dataGridView1.DataSource = ctr.seachDL(i);
        }

        private void sửaBLQTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dong = vt;
            string masv;
            string hoten;
            string lop;
            string mamh;
            string tenmh;
            string diemqt;
            string sotchp;
        
          masv = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            hoten = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            lop = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            mamh = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            tenmh = dataGridView1.Rows[dong].Cells[4].Value.ToString();
            diemqt = dataGridView1.Rows[dong].Cells[8].Value.ToString();
            sotchp = dataGridView1.Rows[dong].Cells[7].Value.ToString();
            bool kt = true;
            frm_DQT fc = new frm_DQT(masv, hoten, lop, mamh, tenmh, diemqt, sotchp,kt);

            fc.Show();

        }
        int vt;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            vt = e.RowIndex;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dong = vt;
            string masv;
            string hoten;
            string lop;
            string mamh;
            string tenmh;
            string diemqt;
            string sotchp;

            masv = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            hoten = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            lop = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            mamh = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            tenmh = dataGridView1.Rows[dong].Cells[4].Value.ToString();
            diemqt = dataGridView1.Rows[dong].Cells[8].Value.ToString();
            sotchp = dataGridView1.Rows[dong].Cells[7].Value.ToString();
            bool kt = true;
            frm_DQT fc = new frm_DQT(masv, hoten, lop, mamh, tenmh, diemqt, sotchp, kt);

            fc.ShowDialog();
            dataGridView1.DataSource = ctr.loadDL();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_DQT fc = new frm_DQT();
            fc.Show();
            dataGridView1.DataSource = ctr.loadDL();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int dong = vt;
            string masv;
            string mamh;
            masv = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            mamh = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            ctr.Xoa(masv,mamh);
            dataGridView1.DataSource = ctr.loadDL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctr.Xoatatca();
            dataGridView1.DataSource = ctr.loadDL();
        }
    }
    
}
