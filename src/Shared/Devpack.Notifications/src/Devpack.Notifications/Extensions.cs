using System.ComponentModel;
using System.Reflection;

namespace Devpack.Notifications
{
    public static class Extensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text?.Trim());
        }

        public static string GetDescription(this Enum enumerator)
        {
            var type = enumerator.GetType();
            var memberInfo = type.GetMember(Enum.GetName(type, enumerator)!).First();
            var attribute = memberInfo.GetAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : memberInfo.Name;
        }

        private static bool HasAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
        {
            return memberInfo.GetCustomAttributes(typeof(TAttribute), false).Length > 0;
        }

        private static TAttribute? GetAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
        {
            if (memberInfo.HasAttribute<TAttribute>())
                return memberInfo.GetCustomAttributes(typeof(TAttribute), false).First() as TAttribute;

            return null;
        }
    }
}