using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NWR.DAL
{
    public class CommonClass
    {

        #region ��������

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>

        //public static string ConnectionString = Base64encryption.DecodeBase64(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static string ConnectionString = "Data Source=may;Initial Catalog=AeromatDB;Persist Security Info=True;User ID=sa;password=";

        #endregion

    }
}
