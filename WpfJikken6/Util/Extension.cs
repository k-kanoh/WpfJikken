using System.Reflection;
using System.Runtime.CompilerServices;

namespace WpfJikken6
{
    public static class Extension
    {
        /// <summary>
        /// 指定したカスタム属性が設定されている場合は true を返します。
        /// </summary>
        public static bool AnyCustomAttribute<T>(this MemberInfo member) where T : Attribute
        {
            return member.GetCustomAttributes(typeof(T), false).Length != 0;
        }

        /// <summary>
        /// 指定したカスタム属性を取り出します。
        /// </summary>
        public static T? FirstCustomAttribute<T>(this MemberInfo member) where T : Attribute
        {
            return member.GetCustomAttributes(typeof(T), false).Cast<T>().FirstOrDefault();
        }

        /// <summary>
        /// プロパティにrequired修飾子が付与されている場合はtrueを返します。
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static bool IsRequired(this MemberInfo member)
        {
            return member.AnyCustomAttribute<RequiredMemberAttribute>();
        }
    }
}
