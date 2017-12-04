using System;
using System.Collections.Generic;
using System.Text;
using NWR.Model;
using System.Windows.Forms;

namespace NWR.UI
{

    /// <summary>
    /// 通用类
    /// </summary>
    public class CommonClass
    {

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EnumUserType GetUserType(int value)
        {

            EnumUserType userType = EnumUserType.TrialPeriod;

            switch (value)
            {
                case 0: userType = EnumUserType.TrialPeriod; break;
                case 1: userType = EnumUserType.Temporary; break;
                case 2: userType = EnumUserType.Formal; break;
                case 3: userType = EnumUserType.HasLeft; break;
                case 4: userType = EnumUserType.Disable; break;
            }

            return userType;

        }

        /// <summary>
        /// 未处理异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("系统错误，未处理异常/r/n请联系管理员", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LogManager.WriteLog(GetExceptionMsg(e.ExceptionObject as Exception, e.ToString()));
        }

        /// <summary>
        /// 应用线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("系统错误，应用线程异常", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LogManager.WriteLog(GetExceptionMsg(e.Exception, e.ToString()));
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        public static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }

            sb.Append("***************************************************************");

            return sb.ToString();
        }

    }
}
