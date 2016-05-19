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

namespace ThuHocPhi2.Views.DuLieuHocPhi
{
    public partial class frm_CapNhatSinhVien : Form
    {
        TuDienSinhVien_ett ett = new TuDienSinhVien_ett();
        public frm_CapNhatSinhVien(TuDienSinhVien_ett ett)
        {
            InitializeComponent();
        }

        private void frm_CapNhatSinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}
