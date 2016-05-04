using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ThuHocPhi2.Connect
{
    public class Connector
    {
        private string strcon = @"Data Source=" + ConfigurationManager.AppSettings["Server"].ToString() + ";Initial Catalog=" + ConfigurationManager.AppSettings["Database"].ToString() + ";Persist Security Info = True; UID = " + ConfigurationManager.AppSettings["Username"].ToString() + ";Password=" + ConfigurationManager.AppSettings["Password"].ToString();
        private SqlCommand cmd = null;
        private SqlConnection conn = null;
        private SqlDataReader dr = null;
        public  Connector()
        {
            conn = new SqlConnection(strcon);
        }
        /// <summary>
        /// Dùng để mở kết nối 
        /// </summary>
        public void openConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                            {
                                conn.Open();
                            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        /// <summary>
        /// Dùng để đóng kết nối 
        /// </summary>
        public void closeConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
