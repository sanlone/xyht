using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;

namespace NWR.DAL
{

    /// <summary>
    /// ʵ���Ķ����࣬���Դ�DataTable�л���DbDataReader��ʵ���н�����ת���ɶ�Ӧ��ʾ��
    /// </summary>
    public sealed class EntityReader
    {
        #region ˽���ֶ�

        private const BindingFlags BindingFlag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// ����������������еĿ�д��δ����������֮�佨��ӳ��
        /// </summary>
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> propertyMappings = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        #endregion

        #region �ӿں���

        /// <summary>
        /// ��DataTable�е���������ת����List<T>����
        /// </summary>
        /// <typeparam name="T">DataTable��ÿ�����ݿ���ת������������</typeparam>
        /// <param name="dataTable">�����п���ת������������T�����ݼ���</param>
        /// <returns></returns>
        public static List<T> GetEntities<T>(DataTable dataTable) where T : new()
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable");
            }
            //���T���������������������ַ�����ValueType������Nullable<ValueType>
            if (typeof(T) == typeof(string) || typeof(T) == typeof(byte[]) || typeof(T).IsValueType)
            {
                return GetSimpleEntities<T>(dataTable);
            }
            else
            {
                return GetComplexEntities<T>(dataTable);
            }
        }

        /// <summary>
        /// ��DbDataReader�е���������ת����List<T>����
        /// </summary>
        /// <typeparam name="T">DbDataReader��ÿ�����ݿ���ת������������</typeparam>
        /// <param name="dataTable">�����п���ת������������T��DbDataReaderʵ��</param>
        /// <returns></returns>
        public static List<T> GetEntities<T>(DbDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            //���T���������������������ַ�����ValueType������Nullable<ValueType>
            if (typeof(T) == typeof(string) || typeof(T).IsValueType)
            {
                return GetSimpleEntities<T>(reader);
            }
            else
            {
                return GetComplexEntities<T>(reader);
            }

        }

        #endregion

        #region ˽�к���

        /// <summary>
        /// ��DataTable�н�ÿһ�еĵ�һ��ת����T���͵�����
        /// </summary>
        /// <typeparam name="T">Ҫת����Ŀ����������</typeparam>
        /// <param name="dataTable">�����п���ת������������T�����ݼ���</param>
        /// <returns></returns>
        private static List<T> GetSimpleEntities<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add((T)GetValueFromObject(row[0], typeof(T)));
            }
            return list;
        }

        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <param name="targetType">Ҫת����Ŀ����������</param>
        /// <returns></returns>
        private static object GetValueFromObject(object value, Type targetType)
        {
            if (targetType == typeof(string))//���Ҫ��valueת����string����
            {
                return GetString(value);
            }
            else if (targetType == typeof(byte[]))//���Ҫ��valueת����byte[]����
            {
                return GetBinary(value);
            }
            else if (targetType.IsGenericType)//���Ŀ�������Ƿ���
            {
                return GetGenericValueFromObject(value, targetType);
            }
            else//����ǻ����������ͣ�������ֵ���͡�ö�ٺ�Guid��
            {
                return GetNonGenericValueFromObject(value, targetType);
            }
        }

        /// <summary>
        /// ��DataTable�ж�ȡ�����������ͼ���
        /// </summary>
        /// <typeparam name="T">Ҫת����Ŀ����������</typeparam>
        /// <param name="dataTable">�����п���ת������������T�����ݼ���</param>
        /// <returns></returns>
        private static List<T> GetComplexEntities<T>(DataTable dataTable) where T : new()
        {
            if (!propertyMappings.ContainsKey(typeof(T)))
            {
                GenerateTypePropertyMapping(typeof(T));
            }
            List<T> list = new List<T>();
            Dictionary<string, PropertyInfo> properties = propertyMappings[typeof(T)];
            T t;
            foreach (DataRow row in dataTable.Rows)
            {
                t = new T();
                foreach (KeyValuePair<string, PropertyInfo> item in properties)
                {
                    //�����Ӧ������������������Դ���������ȡֵ�����ø���Ӧ������
                    if (row[item.Key] != null)
                    {
                        item.Value.SetValue(t, GetValueFromObject(row[item.Key], item.Value.PropertyType), null);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// ��DbDataReader��ʵ���ж�ȡ���ӵ���������
        /// </summary>
        /// <typeparam name="T">Ҫת����Ŀ����</typeparam>
        /// <param name="reader">DbDataReader��ʵ��</param>
        /// <returns></returns>
        private static List<T> GetComplexEntities<T>(DbDataReader reader) where T : new()
        {
            if (!propertyMappings.ContainsKey(typeof(T)))//��鵱ǰ�Ƿ��Ѿ��и�������Ŀ�д����֮���ӳ��
            {
                GenerateTypePropertyMapping(typeof(T));
            }
            List<T> list = new List<T>();
            Dictionary<string, PropertyInfo> properties = propertyMappings[typeof(T)];
            T t;
            while (reader.Read())
            {
                t = new T();
                foreach (KeyValuePair<string, PropertyInfo> item in properties)
                {
                    //�����Ӧ������������������Դ���������ȡֵ�����ø���Ӧ������
                    if (reader[item.Key] != null)
                    {
                        item.Value.SetValue(t, GetValueFromObject(reader[item.Key], item.Value.PropertyType), null);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// ��DbDataReader��ʵ���ж�ȡ���������ͣ�String,ValueType)
        /// </summary>
        /// <typeparam name="T">Ŀ����������</typeparam>
        /// <param name="reader">DbDataReader��ʵ��</param>
        /// <returns></returns>
        private static List<T> GetSimpleEntities<T>(DbDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                list.Add((T)GetValueFromObject(reader[0], typeof(T)));
            }
            return list;
        }


        /// <summary>
        /// ��Objectת�����ַ�������
        /// </summary>
        /// <param name="value">object���͵�ʵ��</param>
        /// <returns></returns>
        private static object GetString(object value)
        {
            return Convert.ToString(value);
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static object GetEnum(object value, Type targetType)
        {
            return Enum.Parse(targetType, value.ToString());
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetBoolean(object value)
        {
            if (value is Boolean)
            {
                return value;
            }
            else
            {
                byte byteValue = (byte)GetByte(value);
                if (byteValue == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetByte(object value)
        {
            if (value is Byte)
            {
                return value;
            }
            else
            {
                return byte.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetSByte(object value)
        {
            if (value is SByte)
            {
                return value;
            }
            else
            {
                return SByte.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetChar(object value)
        {
            if (value is Char)
            {
                return value;
            }
            else
            {
                return Char.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetGuid(object value)
        {
            if (value is Guid)
            {
                return value;
            }
            else
            {
                return new Guid(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetInt16(object value)
        {
            if (value is Int16)
            {
                return value;
            }
            else
            {
                return Int16.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetUInt16(object value)
        {
            if (value is UInt16)
            {
                return value;
            }
            else
            {
                return UInt16.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetInt32(object value)
        {
            if (value is Int32)
            {
                return value;
            }
            else
            {
                return Int32.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetUInt32(object value)
        {
            if (value is UInt32)
            {
                return value;
            }
            else
            {
                return UInt32.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetInt64(object value)
        {
            if (value is Int64)
            {
                return value;
            }
            else
            {
                return Int64.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetUInt64(object value)
        {
            if (value is UInt64)
            {
                return value;
            }
            else
            {
                return UInt64.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetSingle(object value)
        {
            if (value is Single)
            {
                return value;
            }
            else
            {
                return Single.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetDouble(object value)
        {
            if (value is Double)
            {
                return value;
            }
            else
            {
                return Double.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetDecimal(object value)
        {
            if (value is Decimal)
            {
                return value;
            }
            else
            {
                return Decimal.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetDateTime(object value)
        {
            if (value is DateTime)
            {
                return value;
            }
            else
            {
                return DateTime.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static object GetTimeSpan(object value)
        {
            if (value is TimeSpan)
            {
                return value;
            }
            else
            {
                return TimeSpan.Parse(value.ToString());
            }
        }
        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ��ö�����͵�ֵ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <returns></returns>
        private static byte[] GetBinary(object value)
        {
            //������ֶ�ΪNULL�򷵻�null
            if (value == DBNull.Value)
            {
                return null;
            }
            else if (value is Byte[])
            {
                return (byte[])(value);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// ��Object��������ת���ɶ�Ӧ�Ŀɿ���ֵ���ͱ�ʾ
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <param name="targetType">�ɿ���ֵ����</param>
        /// <returns></returns>
        private static object GetGenericValueFromObject(object value, Type targetType)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                //��ȡ�ɿ���ֵ���Ͷ�Ӧ�Ļ�����ֵ���ͣ���int?->int,long?->long
                //Type nonGenericType = genericTypeMappings[targetType];
                Type nonGenericType = targetType.GetGenericArguments()[0];
                return GetNonGenericValueFromObject(value, nonGenericType);
            }
        }

        /// <summary>
        /// ��ָ���� Object ��ֵת��Ϊָ�����͵�ֵ��
        /// </summary>
        /// <param name="value">ʵ�� IConvertible �ӿڵ� Object������Ϊ null</param>
        /// <param name="targetType">Ŀ����������</param>
        /// <returns></returns>
        private static object GetNonGenericValueFromObject(object value, Type targetType)
        {
            if (targetType.IsEnum)//��Ϊ
            {
                return GetEnum(value, targetType);
            }
            else
            {
                switch (targetType.Name)
                {
                    case "Byte": return GetByte(value);
                    case "SByte": return GetSByte(value);
                    case "Char": return GetChar(value);
                    case "Boolean": return GetBoolean(value);
                    case "Guid": return GetGuid(value);
                    case "Int16": return GetInt16(value);
                    case "UInt16": return GetUInt16(value);
                    case "Int32": return GetInt32(value);
                    case "UInt32": return GetUInt32(value);
                    case "Int64": return GetInt64(value);
                    case "UInt64": return GetUInt64(value);
                    case "Single": return GetSingle(value);
                    case "Double": return GetDouble(value);
                    case "Decimal": return GetDecimal(value);
                    case "DateTime": return GetDateTime(value);
                    case "TimeSpan": return GetTimeSpan(value);
                    default: return null;
                }
            }
        }

        /// <summary>
        /// ��ȡ�����������������ݿ��ֶεĶ�Ӧ��ϵӳ��
        /// </summary>
        /// <param name="type"></param>
        private static void GenerateTypePropertyMapping(Type type)
        {
            if (type != null)
            {
                PropertyInfo[] properties = type.GetProperties(BindingFlag);
                Dictionary<string, PropertyInfo> propertyColumnMapping = new Dictionary<string, PropertyInfo>(properties.Length);
                string description = string.Empty;
                Attribute[] attibutes = null;
                string columnName = string.Empty;
                foreach (PropertyInfo p in properties)
                {
                    columnName = string.Empty;
                    attibutes = Attribute.GetCustomAttributes(p);
                    foreach (Attribute attribute in attibutes)
                    {
                        //����Ƿ�������ColumnName����  
                        if (attribute.GetType() == typeof(ColumnNameAttribute))
                        {
                            columnName = ((ColumnNameAttribute)attribute).ColumnName;
                            break;
                        }
                    }
                    //����������ǿɶ�����δ�����Եģ����п�����ʵ���������Զ�Ӧ����ʱ�õ���
                    if (p.CanWrite)
                    {
                        //���û������ColumnName���ԣ���ֱ�ӽ�����������Ϊ���ݿ��ֶε�ӳ��
                        if (string.IsNullOrEmpty(columnName))
                        {
                            columnName = p.Name;
                        }
                        propertyColumnMapping.Add(columnName, p);
                    }
                }
                propertyMappings.Add(type, propertyColumnMapping);
            }
        }

        #endregion
    }


    /// <summary>
    /// �Զ������ԣ�����ָʾ��δ�DataTable����DbDataReader�ж�ȡ�������ֵ
    /// </summary>
    public class ColumnNameAttribute : Attribute
    {
        private string _columnName;
        /// <summary>
        /// �����Զ�Ӧ������
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="columnName">�����Զ�Ӧ������</param>
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }

}
