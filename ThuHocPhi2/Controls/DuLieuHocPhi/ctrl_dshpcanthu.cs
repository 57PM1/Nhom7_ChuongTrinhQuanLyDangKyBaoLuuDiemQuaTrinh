using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuHocPhi2.Connect;
using System.Data;


namespace ThuHocPhi2.Controls.DuLieuHocPhi
{
    class ctrl_dshpcanthu
    {
        Connector con = new Connector();
        public ctrl_dshpcanthu()
        {

        }
        public DataTable seachDL(string tk)
        {
           
            string sql = "select MaSV , HoTen,Lop ,(SUM(convert(int,SoTC))) from [THUHOCPHI].[dbo].[kqdk_dqt] where MaSV like '%" + tk + "%' GROUP BY MaSV,HoTen,Lop ";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
           
            return dt;

        }
        public DataTable loadDL()
        {
          
            string sql = "SELECT MaSV , HoTen,Lop ,(SUM(convert(int,SoTC))) FROM kqdk_dqt GROUP BY MaSV,HoTen,Lop";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;
        }
    }
}
