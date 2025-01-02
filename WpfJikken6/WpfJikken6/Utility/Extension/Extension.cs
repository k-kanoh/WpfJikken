using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WpfJikken6
{
    public static class Extension
    {
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
        public static bool IsRequired(this MemberInfo member)
        {
            return member.FirstCustomAttribute<RequiredMemberAttribute>() != null;
        }

        public static string Combine(this DirectoryInfo dinfo, params string[] name)
        {
            return Path.Combine(new[] { dinfo.FullName }.Concat(name.Select(x => x ?? "")).ToArray());
        }

        public static DirectoryInfo SubDirectory(this DirectoryInfo dinfo, params string[] name)
        {
            return new DirectoryInfo(dinfo.Combine(name));
        }

        public static string GetFileNameWithoutExtension(this FileInfo finfo)
        {
            return Path.GetFileNameWithoutExtension(finfo.FullName);
        }
    }
}
