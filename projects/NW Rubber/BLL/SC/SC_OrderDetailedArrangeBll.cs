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
    /// ҵ����
    /// </summary>
    public class SC_OrderDetailedArrangeBll
    {
        #region ˽���ֶ�
        /// <summary>
        /// ���ݿ��L������
        /// </summary>
        private SC_OrderDetailedArrangeDao _sC_OrderDetailedArrangeDao = null;
        #endregion
        #region ���캯��
        /// <summary>
        /// 
        /// </summary>
        public SC_OrderDetailedArrangeBll()
        {
            _sC_OrderDetailedArrangeDao = new SC_OrderDetailedArrangeDao();
        }
        #endregion
        #region ����ӿ�
        /// <summary>
        /// ����
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
        /// �޸�
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
        /// ɾ��
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
        #region ˽�к���
        #endregion
    }
}
