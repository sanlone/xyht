using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace NWR.DAL
{
    /// <summary>
    /// MD5������
    /// </summary>
    public class MD5encryption
    {
        #region ����ӿ�

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            //����
            byte[] targetData = md5.ComputeHash(fromData);

            for (int i = 0; i < 3; i++)
            {
                targetData[0] = 55;
                targetData[15] = 170;
                targetData = md5.ComputeHash(targetData);
            }

            //�����ַ���
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

        #endregion
    }
}
