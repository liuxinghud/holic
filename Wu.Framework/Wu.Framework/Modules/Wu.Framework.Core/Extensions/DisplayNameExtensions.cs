using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Framework.Core
{
    public static class DisplayNameExtensions
    {

        public static string GetDisplayName(this Type type)
        {
            return (type.GetCustomAttributes(false)?[0] as System.ComponentModel.DisplayNameAttribute)?.DisplayName;
        }

        public static string GetDisplayName(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("methodInfo");
            }
            return memberInfo.GetAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>(true)?.Name;
        }


        public static DisplayAttribute GetDisplayAttribute(this MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo");
            }
            return methodInfo.GetAttribute<DisplayAttribute>(true);
        }



        public static string GetDisplayName(this FieldInfo fieldInfo)
        {
            return GetDisplayName((MemberInfo)fieldInfo);
        }
        public static TAttribute GetAttribute<TAttribute>(this System.Reflection.MemberInfo memberInfo, bool inherit = true) where TAttribute : System.Attribute
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("memberInfo");
            }
            var attrObjs = memberInfo.GetCustomAttributes(memberInfo.DeclaringType, inherit);
            return attrObjs?[0] as TAttribute;
        }
        public static DisplayAttribute GetDisplayAttribute(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("propertyInfo");
            }
            return propertyInfo.GetAttribute<DisplayAttribute>(true);
        }
    }
}
