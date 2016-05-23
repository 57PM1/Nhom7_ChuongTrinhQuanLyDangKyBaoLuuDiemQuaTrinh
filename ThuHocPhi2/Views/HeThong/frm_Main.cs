using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuHocPhi2.Controls;
using ThuHocPhi2.Views;
namespace ThuHocPhi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tạo đối tượng form tương ứng
            Views.HeThong.frm_DangNhap f = new Views.HeThong.frm_DangNhap();
            //Hiển thị form trong panel           
            Utils.ShowFormInPanel(panel1, f);
            //Hiển thị form vào giữa panel
            Utils.ShowFormCenterOfPanel(f);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            foreach (var i in panel1.Controls)
            {
                if (i is Form)
                {
                    if (i is Views.HeThong.frm_DangNhap)
                    {
                        Form f = (Form)i;
                        Utils.ShowFormCenterOfPanel(f);
                    }
                    else
                    {
                        Form f = (Form)i;
                        Utils.ShowFormFullPanel(f);
                    }
                }
            }
        }

        private void tsm_DangNhap_Click(object sender, EventArgs e)
        {
            //tạo đối tượng form tương ứng
            Views.HeThong.frm_DangNhap f = new Views.HeThong.frm_DangNhap();
            //Hiển thị form trong panel           
            Utils.ShowFormInPanel(panel1, f);
            //Hiển thị form vào giữa panel
            Utils.ShowFormCenterOfPanel(f);
        }

        private void khởiTạoHọcKỳVàMứcHọcPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.DuLieuHocPhi.frm_KhoiTaoHocKy f = new Views.DuLieuHocPhi.frm_KhoiTaoHocKy();
            Utils.ShowFormInPanel(panel1, f);
            Utils.ShowFormCenterOfPanel(f);
        }

        private void importDữLiệuĐăngKýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void từĐiểnSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.DuLieuHocPhi.frm_TuDienSinhVien f = new Views.DuLieuHocPhi.frm_TuDienSinhVien();
            Utils.ShowFormInPanel(panel1, f);
            Utils.ShowFormCenterOfPanel(f);
        }

        private void từĐiểnMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.DuLieuHocPhi.frm_TuDienMonHoc f = new Views.DuLieuHocPhi.frm_TuDienMonHoc();
            Utils.ShowFormInPanel(panel1, f);
            Utils.ShowFormCenterOfPanel(f);
        }
    }
}
