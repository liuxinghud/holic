using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.SqlTypes;
using System.Data;
using Newtonsoft.Json;
using NHibernate.Driver;
using NHibernate;
using NHibernate.Engine;
using System.Data.Common;

namespace Wu.Framework.Core
{
    [Serializable]
    public sealed class CustomJsonType<T> : IUserType where T : class
    {
        /// <summary>
        /// 确定指定的 System.Object 是否等于当前的 System.Object。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool IUserType.Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return x.Equals(y);
        }

        /// <summary>
        /// 用作特定类型的哈希函数
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        int IUserType.GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        ///// <summary>
        ///// Gets the value of the field from the System.Data.IDataReader.
        ///// </summary>
        ///// <param name="rs">数据源</param>
        ///// <param name="names">数据列名</param>
        ///// <param name="owner"></param>
        ///// <returns>读取到的数据结果</returns>
        //public object NullSafeGet(IDataReader rs, string[] names, object owner)
        //{
        //    object prop1 = NHibernateUtil.String.NullSafeGet(rs, names[0]);
        //    if (prop1 == null) return null;
        //    string str = (prop1 as string) ?? prop1.ToString();
        //    if (string.IsNullOrEmpty(str)) return null;
        //    try
        //    {
        //        return JsonConvert.DeserializeObject<T>(str);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidCastException($"{names[0]}, {str},Deserialize data to Type {typeof(T).FullName} error:{ ex.Message}");
        //    }
        //}

        ///// <summary>
        ///// 设置参数信息至IDbCommand中
        ///// </summary>
        ///// <param name="cmd">IDbCommand对象</param>
        ///// <param name="value">参数值</param>
        ///// <param name="index">参数索引</param>
        //public void NullSafeSet(IDbCommand cmd, object value, int index)
        //{
        //    if (value == null)
        //    {
        //        ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        string str;
        //        try
        //        {
        //            str = Newtonsoft.Json.JsonConvert.SerializeObject(value); ;
        //        }
        //        catch (Exception ex)
        //        {
                   
        //    throw new InvalidCastException("Error Serialize " + typeof(T).FullName + " to JSON:" + ex.Message, ex);
        //        }
        //        ((IDataParameter)cmd.Parameters[index]).Value = str;
        //    }
        //}
        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            object prop1 = NHibernateUtil.String.NullSafeGet(rs, names[0],session,owner);
            if (prop1 == null) return null;
            string str = (prop1 as string) ?? prop1.ToString();
            if (string.IsNullOrEmpty(str)) return null;
            try
            {
            
             // return JsonUtility.DeserializeObject<T>(str);
            return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"{names[0]}, {str},Deserialize data to Type {typeof(T).FullName} error:{ ex.Message}");
            }
            //  throw new NotImplementedException();
        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (value == null)
            {
                cmd.Parameters[index].Value = DBNull.Value;
            }
            else
            {
                string str;
                try
                {
                    str = Newtonsoft.Json.JsonConvert.SerializeObject(value); ;
                }
                catch (Exception ex)
                {

                    throw new InvalidCastException("Error Serialize " + typeof(T).FullName + " to JSON:" + ex.Message, ex);
                }
                cmd.Parameters[index].Value = str;
            }
        }
        /// <summary>
        /// 深度拷贝对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object DeepCopy(object value)
        {
            if (value == null)
            {
                return null;
            }
           return  JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
        //  return JsonUtility.DeserializeObject<T>(JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 深度拷贝对象
        /// </summary>
        public object Replace(object original, object target, object owner)
        {
            return DeepCopy(original);
        }

        /// <summary>
        /// 深度拷贝对象
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }

        /// <summary>
        /// 深度拷贝对象
        /// </summary>
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }

     

        static readonly SqlType[] s_SqlTypes = new[] { NHibernateUtil.StringClob.SqlType };
        /// <summary>
        /// 此自定义类型对应的数据库类型
        /// </summary>
        public SqlType[] SqlTypes { get { return s_SqlTypes; } }

        static readonly System.Type s_ReturnedType = typeof(T);
        /// <summary>
        /// 此自定义类型的返回对象的类型
        /// </summary>
        public System.Type ReturnedType { get { return s_ReturnedType; } }

        public bool IsMutable { get { return true; } }
    }
}
