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
    public partial class frm_DQT : Form
    {
        ctrl_DSBL_DQT ctr = new ctrl_DSBL_DQT();
       
        public frm_DQT()
        {
            InitializeComponent();
           
        }
        public frm_DQT(string masv, string hoten, string lop, string mamh, string tenmh, string diemqt, string sotchp, bool kt): this()
        {
            txt_masv.Text = masv;
            txt_hoten.Text = hoten;
            txt_lop.Text = lop;
            txt_mamh.Text = mamh;
            txt_tenmh.Text = tenmh;
            txt_dqt.Text = diemqt;
            txt_tchp.Text = sotchp;
            bool sua ;
            sua = kt;
                if(kt)
            {
                txt_masv.ReadOnly = true;
                txt_hoten.ReadOnly = true;
                txt_lop.ReadOnly = true;
                txt_mamh.ReadOnly = true;
                txt_tchp.ReadOnly = true;
                txt_tenmh.ReadOnly = true;
            }
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
           var masv  = txt_masv.Text ;
           var hoten=  txt_hoten.Text;
          var lop =txt_lop.Text ;
           var mamh=txt_mamh.Text;
            var tenmh =txt_tenmh.Text ;
             var diemqt =txt_dqt.Text;
            var sotchp=txt_tchp.Text ;
            ctr.CapNhat(masv, diemqt,mamh);
            this.Close();
        }

        private void txt_hoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_lop_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_mamh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_tenmh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_dqt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txt_tchp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_masv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frm_DQT_Load(object sender, EventArgs e)
        {

        }
    }
}
