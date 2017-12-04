using System;
using System.Collections.Generic;
using System.Text;

namespace NWR.DAL
{
    /// <summary>
    /// Base64����
    /// </summary>
    public class Base64encryption
    {
        #region �ӿں���

        /// <summary>
        /// Base64���ܣ�����utf8���뷽ʽ����
        /// </summary>
        /// <param name="source">�����ܵ�����</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }
        /// <summary>
        /// Base64����
        /// </summary>
        /// <param name="codeName">���ܲ��õı��뷽ʽ</param>
        /// <param name="source">�����ܵ�����</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            string enstring = "";
            byte[] bytes = encode.GetBytes(source);
            try
            {
                enstring = Convert.ToBase64String(bytes);
                enstring = "AA" + enstring + "BB";
                bytes = encode.GetBytes(enstring);
                enstring = Convert.ToBase64String(bytes);
            }
            catch
            {
                enstring = source;
            }
            return enstring;
        }

        /// <summary>
        /// Base64���ܣ�����utf8���뷽ʽ����
        /// </summary>
        /// <param name="result">�����ܵ�����</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
        /// <summary>
        /// Base64����
        /// </summary>
        /// <param name="codeName">���ܲ��õı��뷽ʽ��ע��ͼ���ʱ���õķ�ʽһ��</param>
        /// <param name="result">�����ܵ�����</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
                decode = decode.Substring(2, decode.Length - 2);
                decode = decode.Substring(0, decode.Length - 2);
                bytes = Convert.FromBase64String(decode);
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        #endregion
    }
}
