using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuHocPhi2.Models.HeThong;
using ThuHocPhi2.Connect;
using System.Data.SqlClient;
using ThuHocPhi2.Controls.HeThong;
using ThuHocPhi2.Models.HeThong;

namespace ThuHocPhi2.Views.HeThong
{
    public partial class QuanLyTaiKhoan : Form
    {
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        ctrl_TaiKhoan ctr = new ctrl_TaiKhoan();
        user ett = new user();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_taikhoan.Text = "";
            txt_matkhau.Text = "";
            txt_nlmatkhau.Text = "";
            txt_hoten.Text = "";
            txt_sdt.Text = "";

        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ctrl_TaiKhoan.loadDL();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = e.RowIndex;
            txt_taikhoan.Text = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            txt_hoten.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = e.RowIndex;
            txt_taikhoan.Text = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            txt_matkhau.Text=dataGridView1.Rows[dong].Cells[1].Value.ToString();
            txt_nlmatkhau.Text = dataGridView1.Rows[dong].Cells[1].Value.ToString();

            txt_hoten.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();


        }

        private void btl_sua_Click(object sender, EventArgs e)
        {
            ett.HoTen = txt_hoten.Text;
            ett.username = txt_taikhoan.Text;
            ctr.CapNhat(txt_taikhoan.Text, txt_hoten.Text, txt_sdt.Text);
            dataGridView1.DataSource = ctrl_TaiKhoan.loadDL();
        }
    }
}
