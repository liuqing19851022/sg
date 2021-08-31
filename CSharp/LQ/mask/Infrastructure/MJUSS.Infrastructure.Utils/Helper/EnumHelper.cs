using MJUSS.Infrastructure.Core.CustomAttributes;
using MJUSS.Infrastructure.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>  
    /// 枚举转集合的helper  
    /// </summary>  
    public static class EnumHelper
    {
        /// <summary>  
        /// 获取一个枚举集合类。  
        /// </summary>  
        /// <typeparam name="TEnum"></typeparam>  
        /// <returns></returns>  
        public static List<EnumEntity> ToList<T>() where T : struct
        {
            List<EnumEntity> list = new List<EnumEntity>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumEntity m = new EnumEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Description = da.Description;
                }
                m.EnumValue = Convert.ToInt32(e);
                m.EnumName = e.ToString();
                list.Add(m);
            }
            return list;
        }
        /// <summary>
        /// 通过枚举值获取枚举名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetEnumNameByVal<T>(int val) where T:struct
        {
            return Enum.GetName(typeof(T), val);
        }
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(int enumVal) where T : struct
        {
            string value = string.Empty;
            string resultVal = string.Empty;
            foreach (T t in Enum.GetValues(typeof(T)))
            {

                FieldInfo field = t.GetType().GetField(t.ToString());
                object obj = field.GetValue(t.ToString());
                if ((int)obj == enumVal)
                {
                    value = t.ToString();
                    FieldInfo fieldResult = t.GetType().GetField(value);
                    object[] objs = fieldResult.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (objs == null || objs.Length == 0)
                    {
                        resultVal = value;
                    }
                    else
                    {
                        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
                        resultVal = descriptionAttribute.Description;
                    }
                }
            }
            return resultVal;
        }

        /// <summary>
        /// 获取枚举的目标页面特性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetEnumTargetPage<T>(int enumVal) where T : struct
        {
            string resultVal = string.Empty;
            foreach (T t in Enum.GetValues(typeof(T)))
            {
                FieldInfo field = t.GetType().GetField(t.ToString());
                object obj = field.GetValue(t.ToString());
                if ((int)obj == enumVal)
                {
                    string value = t.ToString();
                    FieldInfo fieldResult = t.GetType().GetField(value);
                    object[] objs = fieldResult.GetCustomAttributes(typeof(AdNavigationPositionPageAttribute), false);
                    if (objs == null || objs.Length == 0)
                    {
                        throw new ServiceException("没有设置目标页面特性");
                    }
                    else
                    {
                        AdNavigationPositionPageAttribute TargetPageAttr = (AdNavigationPositionPageAttribute)objs[0];
                        resultVal = TargetPageAttr.TargetPage;
                        break;
                    }
                }
            }
            return resultVal;
        }
    }

    public static class EnumHelper<T> where T : struct
    {

       private static  Dictionary<T, DisplayAttribute> dic = new Dictionary<T, DisplayAttribute>();

        public static DisplayAttribute GetDisplayNames(T val)
        {
            DisplayAttribute result;
            if (dic.TryGetValue(val, out result))
                return result;

            var attr = typeof(T).GetField(val.ToString()).GetCustomAttributes(typeof(DisplayAttribute),false);
            result =  attr.FirstOrDefault() as DisplayAttribute;

            dic[val] = result;
            return result;

        }

    }


    [Serializable]
    public class EnumEntity
    {
        /// <summary>  
        /// 枚举的描述  
        /// </summary>  
        public string Description { set; get; }

        /// <summary>  
        /// 枚举名称  
        /// </summary>  
        public string EnumName { set; get; }

        /// <summary>  
        /// 枚举对象的值  
        /// </summary>  
        public int EnumValue { set; get; }
    }
}
