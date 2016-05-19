using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuHocPhi2.Connect;
using ThuHocPhi2.Models.DuLieuHocPhi;
using System.Data.SqlClient;
using System.Data;

namespace ThuHocPhi2.Controls.DuLieuHocPhi
{
    class ctrl_KhoiTaoHocKy
    {
        Connector con = new Connector();
        //public SqlCommand cmd;
        //public SqlDataAdapter da;
        //public DataSet ds = new DataSet();
        public DataTable GetAllData()
        {
            string sql = "select * from HocKy";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;

        }

        public void ThemMoi(string hk, string hp)
        {
            string sql = "insert HocKy values('" + hk + "','" + hp + "',0)";
            con.ExcuteSql(sql);
        }

        public void Xoa(string id)
        {
            string sql = "delete HocKy where HocKyID = '"+id+"'";
            con.ExcuteSql(sql);
        }

        public void CapNhat(string id, string hk, string hp, bool th)
        {
            int t;
            if (th)
                t = 1;
            else
                t = 0;
            string sql = "update HocKy set HocKy = '" + hk + "', HocPhi = '" + hp + "',TrangThai = '" + t + "' where HocKyID = '"+id+"'";
            con.ExcuteSql(sql);
        }
    }
}
