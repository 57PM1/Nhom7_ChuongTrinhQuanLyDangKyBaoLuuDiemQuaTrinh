using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuHocPhi2.Connect;
using ThuHocPhi2.Models.DuLieuHocPhi;
using System.Data;
using System.Data.OleDb;

namespace ThuHocPhi2.Controls.DuLieuHocPhi
{
    class ctrl_TuDienMonHoc
    {
        Connector con = new Connector();
        TuDienMonHoc_ett ett = new TuDienMonHoc_ett();
        /// <summary>
        /// Tìm kiếm gần đúng them mã môn học
        /// </summary>
        /// <param name="Ma"></param>
        /// <returns></returns>
        public DataTable TimKiemMaMH(string Ma)
        {
            string sql = "select * from MonHoc where MaMH like '%" + Ma + "%'";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;
        }
        public DataTable GetAllData()
        {
            string sql = "select * from MonHoc";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;
        }

        /// <summary>
        /// Thêm mới Môn Học với 3 tham số
        /// </summary>
        public void ThemMoi(string mamh, string tenmh, string sotchp)
        {

            string sql = "insert MonHoc values('" + mamh + "',N'" + tenmh + "','" + sotchp  + "')";
            con.ExcuteSql(sql);
        }
        /// <summary>
        /// Thêm mới sinh viên chỉ dùng để import
        /// </summary>
        /// <param name="ett"> kiểu model</param>
        private void ThemMoiEtt(TuDienMonHoc_ett ett)
        {
            string sql = "insert MonHoc values('" + ett.MaMH + "',N'" + ett.TenMH + "',N'" + ett.SoTCHP + "')";
            con.ExcuteSql(sql);
        }
        /// <summary>
        /// import file excel 
        /// </summary>
        /// <param name="FilePath">đường dẫn đến file</param>
        /// <returns>số lượng row import thành công</returns>
        public int ImportFileExcel(string FilePath)
        {
            try
            {
                DataTable data = ReadDataFromExcelFile(FilePath);
                int count = ImportIntoDatabase(data);
                return count;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        /// <summary>
        /// đọc file excel 
        /// </summary>
        /// <param name="FilePath"> địa chỉ file</param>
        /// <returns> dữ  liệu file excel dạng table</returns>
        private DataTable ReadDataFromExcelFile(string FilePath)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0";
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                oledbConn.Open();
                //đọc file excel có sheet tên là TDSV
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [TDSV$]", oledbConn);
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                oleda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                oleda.Fill(ds);
                data = ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oledbConn.Close();
            }
            return data;
        }
        /// <summary>
        /// import table vào csdl
        /// </summary>
        /// <param name="data"> bảng cần import</param>
        /// <returns>số lượng dòng thành công</returns>
        private int ImportIntoDatabase(DataTable data)
        {
            try
            {
                int i = 0;
                for (i = 0; i < data.Rows.Count; i++)
                {
                    ett.MaMH = data.Rows[i]["MaMH"].ToString().Trim();
                    ett.TenMH = data.Rows[i]["TenMH"].ToString().Trim();
                    ett.SoTCHP = data.Rows[i]["SoTCHP"].ToString().Trim();
                    ThemMoiEtt(ett);
                }
                return i;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
