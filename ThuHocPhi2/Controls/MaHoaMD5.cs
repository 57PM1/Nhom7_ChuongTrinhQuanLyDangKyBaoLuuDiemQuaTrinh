using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ThuHocPhi2.Controls
{
    class MaHoaMD5
    {
        /// <summary>
        /// Hàm dùng mã hóa ký tự theo kiểu mã md5
        /// </summary>
        /// <param name="toEncrypt">chuỗi ký tự cần mã hóa</param>
        /// <returns>mã md5</returns>
        public string MaHoa(string toEncrypt)//thêm mã hóa vào, ko cần giải mã
        {
            string key = "nhom7";
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string GiaiMa(string toDecrypt)
        {
            return null;
        }
    }
}
