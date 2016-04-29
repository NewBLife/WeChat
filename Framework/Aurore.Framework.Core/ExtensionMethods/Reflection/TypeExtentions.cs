using System;
using Aurore.Framework.Core.Asserts;

namespace Aurore.Framework.Core.ExtensionMethods.Reflection
{
    /// <summary>
    /// 扩展<see cref="Type"/>。
    /// </summary>
    public static class TypeExtentions
    {
        /// <summary>
        /// 判断类型是否可以实例化。
        /// </summary>
        public static bool CanCreate(this Type type)
        {
            type.NotNull(nameof(type));

            return !type.IsGenericTypeDefinition
                && !type.IsAbstract
                && !type.IsInterface;
        }

        /// <summary>
        /// 创建类型<typeparamref name="T"/>的实例。
        /// </summary>
        public static T CreateInstance<T>(this Type type, params object[] args)
        {
            type.NotNull(nameof(type));

            return (T)Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// 创建类型的实例。
        /// </summary>
        public static object CreateInstance(this Type type, params object[] args)
        {
            type.NotNull(nameof(type));

            return Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// 在<paramref name="type"/>的接口定义中，是否拥有<paramref name="genericInterfaceTypeDefinition"/>指定的泛型接口类型定义 。
        /// </summary>
        public static bool ContainsGenericTypeDefinition(this Type type, Type genericType)
        {
            type.NotNull(nameof(type));

            var items = type.GetInterfaces();
            foreach (var item in items)
            {
                if (item.IsGenericType && item.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            return false;
        }
    }
}
