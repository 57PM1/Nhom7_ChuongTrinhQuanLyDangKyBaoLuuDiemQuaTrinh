using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuHocPhi2.Models.DuLieuHocPhi;
using ThuHocPhi2.Connect;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ThuHocPhi2.Controls.DuLieuHocPhi
{
    class ctrl_DSBL_DQT
    {
        Connector con = new Connector();
        //TuDienSinhVien_ett ett = new TuDienSinhVien_ett();
        public ctrl_DSBL_DQT()
        {

        }
         public DataTable loadDL()
        {
            //Connector con = null;
            //con = new Connector();
            //con.openConnection();
            string sql = "select * from [THUHOCPHI].[dbo].[kqdk_dqt]";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            //SqlCommand cmd = new SqlCommand(sql, con.conn);
            //cmd.CommandType = CommandType.Text;
            //da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "kqdk_dqt");


            //con.closeConnection();
            //return ds.Tables["kqdk_dqt"];
            return dt;
        }
         public DataTable seachDL(string tk)
        {
        
            string sql = "select * from [THUHOCPHI].[dbo].[kqdk_dqt] where MaSV like '%" + tk + "%'";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;

        }
        public void ThemMoi(string masv, string hoten,string lop, string mamh,string tenmh,string diemqt,string sotchp )
        {
            string sql = "insert kqdk_dqt values('" + masv + "','" + hoten + "','" + lop + "','" + mamh + "','" + tenmh + "','" + diemqt + "','" + sotchp + "')";
            con.ExcuteSql(sql);
        }
        public DataTable timsv(string masv)
        {
            string sql = "selcet * from [THUHOCPHI].[dbo].[SinhVien] where MaSv = '"+masv+"'";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;
        }
        public void timmh(string mamh)
        {
            string sql = "selcet * from [THUHOCPHI].[dbo].[MonHoc] where MaMH = '" + mamh + "'";
            con.ExcuteSql(sql);

        }

        public void Xoatatca()
        {
            string sql = "delete from [THUHOCPHI].[dbo].[kqdk_dqt]";
            con.ExcuteSql(sql);
        }

        public void Xoa(string masv, string mamh)
        {
            string sql = "delete [THUHOCPHI].[dbo].[kqdk_dqt] where MaSV = '" + masv + "' and MaMH = '" + mamh + "'";
            con.ExcuteSql(sql);
        }

        public void CapNhat(string masv, string diemqt, string mamh)
        {
           
            string sql = "update [THUHOCPHI].[dbo].[kqdk_dqt] set Diemqt = '" + diemqt + "' where MaSV = '" + masv + "' and MaMH = '" + mamh + "'";
            
            con.ExcuteSql(sql);
        }

    }
}
