using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuHocPhi2.Models.HeThong;
using ThuHocPhi2.Connect;
using System.Data.SqlClient;
//using System.Configuration;

namespace ThuHocPhi2.Controls.HeThong
{
    class ctrl_DangNhap
    {
        //Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        MaHoaMD5 mahoa = new MaHoaMD5();
        public bool CheckTaiKhoan(string tk, string mk)
        {
            mk = mahoa.MaHoa(mk);
            string sql = "select * from [THUHOCPHI].[dbo].[user] where username = '" + tk + "' and password = '" + mk + "'";
            try
            {
                Connector con = new Connector();
                SqlCommand cmd = new SqlCommand(sql, con.conn);
                con.openConnection();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    con.closeConnection();
                    return true;
                }
                else
                {
                    con.closeConnection();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public bool CheckCauHinh()
        {
            try
            {
                Connector con = new Connector();
                con.openConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        //public void SetDangNhap(string tk, string mk)
        //{
        //    _config.AppSettings.Settings["tk"].Value = tk;
        //    _config.AppSettings.Settings["mk"].Value = mk;
        //    _config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");
        //}
        //public DangNhap_ett GetDangNhap()
        //{
        //    DangNhap_ett op = new DangNhap_ett();
        //    op.username = ConfigurationManager.AppSettings["tk"].ToString();
        //    op.password = ConfigurationManager.AppSettings["mk"].ToString();
        //    return op;
        //}
    }
}
