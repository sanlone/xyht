using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace NWR.Model
{

    #region 定义枚举

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum EnumUserType
    {

        /// <summary>
        /// 试用期
        /// </summary>
        [Description("试用期")]
        TrialPeriod = 0,
        /// <summary>
        /// 临时员工
        /// </summary>
        [Description("临时员工")]
        Temporary = 1,
        /// <summary>
        /// 正式员工
        /// </summary>
        [Description("正式员工")]
        Formal = 2,
        /// <summary>
        /// 已离职
        /// </summary>
        [Description("已离职")]
        HasLeft = 3,
        /// <summary>
        /// 已离职
        /// </summary>
        [Description("停用")]
        Disable = 4
    }

    #endregion

    #region 通用数据

    /// <summary>
    /// 通用类
    /// </summary>
    public class CommonClass
    {
    }

    #endregion

}
