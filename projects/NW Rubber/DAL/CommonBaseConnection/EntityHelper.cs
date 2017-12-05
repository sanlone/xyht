using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Reflection;

namespace NWR.DAL
{
    /// <summary>
    /// ����ʵ��ת����
    /// </summary>
    public class EntityHelper
    {
        /// <summary>
        /// �ж�DataSetĬ�ϱ��Ƿ�Ϊ��:true:��Ϊ�� false:Ϊ�ա�
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool CheckDataSet(DataSet ds)
        {
            bool isNull = CheckDataSet(ds, 0);
            return isNull;
        }

        /// <summary>
        /// �ж�DataSetָ���������Ƿ�Ϊ��:true:��Ϊ�� false:Ϊ�ա�
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="tableIndex">�������ֵ</param>
        /// <returns></returns>
        public static bool CheckDataSet(DataSet ds, int tableIndex)
        {
            bool isNull = false;
            if (ds != null && ds.Tables != null && ds.Tables.Count > tableIndex && ds.Tables[tableIndex] != null && ds.Tables[tableIndex].Rows != null && ds.Tables[tableIndex].Rows.Count > 0)
            {
                isNull = true;
            }
            return isNull;
        }

        /// <summary>
        /// �������ݱ�������Ӧ��ʵ������б�
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="srcDT">����</param>
        /// <param name="relation">���ݿ�������������������Ӧ��ϵ�����������ʵ�������������ͬ���ò�����Ϊ��</param>
        /// <returns>�����б�</returns>
        public static List<T> GetEntityListByDT<T>(DataTable srcDT, Hashtable relation)
        {
            List<T> list = null;
            T destObj = default(T);

            if (srcDT != null && srcDT.Rows.Count > 0)
            {

                list = new List<T>();
                foreach (DataRow row in srcDT.Rows)
                {
                    destObj = GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }

            return list;
        }

        /// <summary>
        ///  ��SqlDataReaderת��������ʵ�� add by trenhui
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static T GetEntityListByDT<T>(SqlDataReader dr)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                try
                {
                    if (dr[prop.Name] != null && dr[prop.Name] != DBNull.Value)
                    {
                        SetPropertyValue(prop, destObj, dr[prop.Name]);
                    }
                }
                catch { }
            }
            return destObj;
        }

        /// <summary>
        ///  ��������ת��������ʵ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static T GetEntityListByDT<T>(DataSet ds)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();

            try
            {
                DataRow row = ds.Tables[0].Rows[0];
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (row.Table.Columns.Contains(prop.Name) &&
                        row[prop.Name] != DBNull.Value)
                    {
                        SetPropertyValue(prop, destObj, row[prop.Name]);
                    }
                }
            }
            catch (Exception )
            {

            }

            return destObj;
        }

        /// <summary>
        ///  ��������ת��������ʵ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row">����Datarow</param>
        /// <param name="relation">��Ҫʵ��ת����Hashtable ��Ϊnull</param>
        /// <returns>����һ������</returns>
        public static T GetEntityListByDT<T>(DataRow row, Hashtable relation)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();
            PropertyInfo temp = null;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (row.Table.Columns.Contains(prop.Name) &&
                    row[prop.Name] != DBNull.Value)
                {
                    SetPropertyValue(prop, destObj, row[prop.Name]);
                }
            }

            if (relation != null)
            {

                foreach (string name in relation.Keys)
                {
                    temp = type.GetProperty(relation[name].ToString());
                    if (temp != null &&
                        row[name] != DBNull.Value)
                    {
                        SetPropertyValue(temp, destObj, row[name]);
                    }
                }
            }

            return destObj;
        }

        /// <summary>
        ///  ����������ת��������ʵ���б�
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="row">������</param>
        /// <param name="relation">��Ҫʵ��ת����Hashtable ��Ϊnull</param>
        /// <returns>����List��������</returns>
        public static List<T> GetEntityListByDT<T>(DataRow[] rows, Hashtable relation)
        {
            List<T> list = null;
            T destObj = default(T);

            if (rows != null && rows.Length > 0)
            {

                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    destObj = GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }

            return list;
        }

        /// <summary>
        /// Ϊ��������Ը�ֵ
        /// </summary>
        /// <param name="prop">����</param>
        /// <param name="destObj">Ŀ�����</param>
        /// <param name="value">Դֵ</param>
        private static void SetPropertyValue(PropertyInfo prop, object destObj, object value)
        {
            object temp = ChangeType(prop.PropertyType, value);
            prop.SetValue(destObj, temp, null);
        }

        /// <summary>
        /// �����������ݵĸ�ֵ
        /// </summary>
        /// <param name="type">Ŀ������</param>
        /// <param name="value">ԭֵ</param>
        /// <returns></returns>
        private static object ChangeType(Type type, object value)
        {
            int temp = 0;
            if ((value == null) && type.IsGenericType)
            {
                return Activator.CreateInstance(type);
            }
            if (value == null)
            {
                return null;
            }
            if (type == value.GetType())
            {
                return value;
            }
            if (type.IsEnum)
            {
                if (value is string)
                {
                    return Enum.Parse(type, value as string);
                }
                return Enum.ToObject(type, value);
            }

            if (type == typeof(bool) && typeof(int).IsInstanceOfType(value))
            {
                temp = int.Parse(value.ToString());
                return temp != 0;
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type type1 = type.GetGenericArguments()[0];
                object obj1 = ChangeType(type1, value);
                return Activator.CreateInstance(type, new object[] { obj1 });
            }
            if ((value is string) && (type == typeof(Guid)))
            {
                return new Guid(value as string);
            }
            if ((value is string) && (type == typeof(Version)))
            {
                return new Version(value as string);
            }
            if (!(value is IConvertible))
            {
                return value;
            }
            return Convert.ChangeType(value, type);
        }
    }
}
