using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NWR.UI
{
    /// <summary>
    /// ��־��
    /// </summary>
    public class LogManager
    {

        /// <summary>
        /// ��־�ļ�·��
        /// </summary>
        private static string _logFilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MW Rubber Documents";

        /// <summary>
        /// ��־�ļ�����
        /// </summary>
        private static string _logFileName = "Error.log";

        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string errorMsg)
        {
            //�ļ�����·��
            string path = _logFilePath + "\\" + _logFileName;

            #region �����ļ���
            if (!Directory.Exists(_logFilePath))
            {
                //�����ļ���
                Directory.CreateDirectory(_logFilePath);
            }
            #endregion

            #region д���ļ�
            if (!File.Exists(path))
            {
                //�ļ������ڣ������ļ�
                using (FileStream fs = File.Create(path))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        sw.WriteLine(errorMsg);
                    }
                }
            }
            else
            {
                //�ļ����ڣ���д
                using (FileStream fs = new FileStream(path, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        sw.WriteLine(errorMsg);
                    }
                }
            }
            #endregion
        }

    }
}
