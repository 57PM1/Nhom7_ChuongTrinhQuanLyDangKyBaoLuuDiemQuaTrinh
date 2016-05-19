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
    class ctrl_TuDienSinhVien
    {
        Connector con = new Connector();
        TuDienSinhVien_ett ett = new TuDienSinhVien_ett();
        /// <summary>
        /// Tìm kiếm gần đúng them mã sinh viên
        /// </summary>
        /// <param name="Ma"></param>
        /// <returns></returns>
        public DataTable TimKiemMaSV(string Ma)
        {
            string sql = "select * from SinhVien where MaSv like '%"+Ma+"%'";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;
        }
        public DataTable GetAllData()
        {
            string sql = "select * from SinhVien";
            DataTable dt = new DataTable();
            dt = con.GetTable(sql);
            return dt;
        }

        /// <summary>
        /// Thêm mới sinh viên với 3 tham số
        /// </summary>
        /// <param name="masv"></param>
        /// <param name="hoten"></param>
        /// <param name="lop"></param>
        public void ThemMoi(string masv, string hoten, string lop)
        {
            
            string sql = "insert SinhVien values('" + masv + "',N'" + hoten + "',N'"+lop+"')";
            con.ExcuteSql(sql);
        }
        /// <summary>
        /// Thêm mới sinh viên chỉ dùng để import
        /// </summary>
        /// <param name="ett"> kiểu model</param>
        private void ThemMoiEtt(TuDienSinhVien_ett ett)
        {
            string sql = "insert SinhVien values('" + ett.MaSV + "',N'" + ett.HoTen + "',N'" + ett.Lop + "')";
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
                for ( i = 0; i < data.Rows.Count; i++)
                {
                    ett.MaSV = data.Rows[i]["MaSV"].ToString().Trim();
                    ett.HoTen = data.Rows[i]["HoTen"].ToString().Trim();
                    ett.Lop = data.Rows[i]["TenLop"].ToString().Trim();
                    ThemMoiEtt(ett);
                }
                return i;
            }
            catch (Exception )
            {
                return 0;
            }
        }

    }
}
