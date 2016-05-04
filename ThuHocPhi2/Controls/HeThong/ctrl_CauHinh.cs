using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ThuHocPhi2.Models.HeThong;
using ThuHocPhi2.Connect;

namespace ThuHocPhi2.Controls.HeThong
{
    class ctrl_CauHinh
    {
        Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);      
        public void KetNoi()
        {
            Connector con = new Connector();        
            con.openConnection();
        }
        public void SetCauHinh (string sv, string db, string uname, string pass)
        {
            _config.AppSettings.Settings["Server"].Value = sv;
            _config.AppSettings.Settings["Database"].Value = db;
            _config.AppSettings.Settings["Username"].Value = uname;
            _config.AppSettings.Settings["Password"].Value = pass;
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public CauHinh_ett GetCauHinh()
        {
            CauHinh_ett op = new CauHinh_ett();
            op.server = ConfigurationManager.AppSettings["Server"].ToString();
            op.database = ConfigurationManager.AppSettings["Database"].ToString();
            op.username = ConfigurationManager.AppSettings["Username"].ToString();
            op.password = ConfigurationManager.AppSettings["Password"].ToString();
            return op;
        }

    }
}
