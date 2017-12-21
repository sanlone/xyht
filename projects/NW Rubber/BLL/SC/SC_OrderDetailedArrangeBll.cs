using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Data;
using NWR.Model;
using NWR.DAL;

namespace NWR.BLL
{
    /// <summary>
    /// 业务类
    /// </summary>
    public class SC_OrderDetailedArrangeBll
    {
        #region 私有字段
        /// <summary>
        /// 数据库訪問对象
        /// </summary>
        private SC_OrderDetailedArrangeDao _sC_OrderDetailedArrangeDao = null;
        #endregion
        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public SC_OrderDetailedArrangeBll()
        {
            _sC_OrderDetailedArrangeDao = new SC_OrderDetailedArrangeDao();
        }
        #endregion
        #region 对外接口
        /// <summary>
        /// 增加
        /// </summary>
        public int AddModel(SC_OrderDetailedArrange model)
        {
            try
            {
                return _sC_OrderDetailedArrangeDao.AddModel(model);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int EditModel(SC_OrderDetailedArrange model)
        {
            try
            {
                return _sC_OrderDetailedArrangeDao.EditModel(model);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int DelteModel(int ID)
        {
            try
            {
                return _sC_OrderDetailedArrangeDao.DeleteModel(ID);
            }
            catch
            {
                return -1;
            }
        }
        public SC_OrderDetailedArrange GetModel(int ID)
        {
            try
            {
                return _sC_OrderDetailedArrangeDao.GetModel(ID);
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 私有函数
        #endregion
    }
}
