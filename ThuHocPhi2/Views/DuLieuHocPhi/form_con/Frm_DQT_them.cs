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
namespace ThuHocPhi2.Views.DuLieuHocPhi.form_con
{
    public partial class Frm_DQT_them : Form
    {
        public Frm_DQT_them()
        {
            InitializeComponent();
        }
        ctrl_DSBL_DQT ctr = new ctrl_DSBL_DQT();


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txt_masv_Enter(object sender, EventArgs e)
        {
            string masv;
            masv = txt_masv.Text;
            dataGridView1.DataSource = ctr.timsv(masv);
            string hoten;
            string lop;
            hoten = dataGridView1.Rows[0].Cells[1].Value.ToString();
            lop = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txt_hoten.Text = hoten;
            txt_lop.Text = lop;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_masv_TextChanged(object sender, EventArgs e)
        {
            string masv;
            masv = txt_masv.Text;
            dataGridView1.DataSource = ctr.timsv(masv);
            string hoten;
            string lop;
            hoten = dataGridView1.Rows[0].Cells[1].Value.ToString();
            lop = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txt_hoten.Text = hoten;
            txt_lop.Text = lop;
        }
    }
}
