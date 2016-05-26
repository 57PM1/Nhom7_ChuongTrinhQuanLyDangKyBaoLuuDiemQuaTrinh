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
    public partial class frm_dshpcanthu : Form
    {
        ctrl_dshpcanthu ctr = new ctrl_dshpcanthu();
        public frm_dshpcanthu()
        {
            InitializeComponent();
        }

        private void frm_dshpcanthu_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctr.loadDL();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ctr.seachDL(txt_tk.Text);
        }
    }
}
