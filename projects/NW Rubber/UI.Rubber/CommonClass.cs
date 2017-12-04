using System;
using System.Collections.Generic;
using System.Text;
using NWR.Model;
using System.Windows.Forms;

namespace NWR.UI
{

    /// <summary>
    /// ͨ����
    /// </summary>
    public class CommonClass
    {

        /// <summary>
        /// ��ȡ�û�����
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
        /// δ�����쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("ϵͳ����δ�����쳣/r/n����ϵ����Ա", "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LogManager.WriteLog(GetExceptionMsg(e.ExceptionObject as Exception, e.ToString()));
        }

        /// <summary>
        /// Ӧ���߳��쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("ϵͳ����Ӧ���߳��쳣", "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LogManager.WriteLog(GetExceptionMsg(e.Exception, e.ToString()));
        }

        /// <summary>
        /// �����Զ����쳣��Ϣ
        /// </summary>
        /// <param name="ex">�쳣����</param>
        /// <param name="backStr">�����쳣��Ϣ����exΪnullʱ��Ч</param>
        /// <returns>�쳣�ַ����ı�</returns>
        public static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************�쳣�ı�****************************");
            sb.AppendLine("������ʱ�䡿��" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("���쳣���͡���" + ex.GetType().Name);
                sb.AppendLine("���쳣��Ϣ����" + ex.Message);
                sb.AppendLine("����ջ���á���" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("��δ�����쳣����" + backStr);
            }

            sb.Append("***************************************************************");

            return sb.ToString();
        }

    }
}
