using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NWR.UI
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class LogManager
    {

        /// <summary>
        /// 日志文件路径
        /// </summary>
        private static string _logFilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MW Rubber Documents";

        /// <summary>
        /// 日志文件名称
        /// </summary>
        private static string _logFileName = "Error.log";

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string errorMsg)
        {
            //文件绝对路径
            string path = _logFilePath + "\\" + _logFileName;

            #region 创建文件夹
            if (!Directory.Exists(_logFilePath))
            {
                //创建文件夹
                Directory.CreateDirectory(_logFilePath);
            }
            #endregion

            #region 写入文件
            if (!File.Exists(path))
            {
                //文件不存在，创建文件
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
                //文件存在，续写
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
