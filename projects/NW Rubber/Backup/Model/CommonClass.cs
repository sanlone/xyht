using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace NWR.Model
{

    #region ����ö��

    /// <summary>
    /// �û�����
    /// </summary>
    public enum EnumUserType
    {

        /// <summary>
        /// ������
        /// </summary>
        [Description("������")]
        TrialPeriod = 0,
        /// <summary>
        /// ��ʱԱ��
        /// </summary>
        [Description("��ʱԱ��")]
        Temporary = 1,
        /// <summary>
        /// ��ʽԱ��
        /// </summary>
        [Description("��ʽԱ��")]
        Formal = 2,
        /// <summary>
        /// ����ְ
        /// </summary>
        [Description("����ְ")]
        HasLeft = 3,
        /// <summary>
        /// ����ְ
        /// </summary>
        [Description("ͣ��")]
        Disable = 4
    }

    #endregion

    #region ͨ������

    /// <summary>
    /// ͨ����
    /// </summary>
    public class CommonClass
    {
    }

    #endregion

}
