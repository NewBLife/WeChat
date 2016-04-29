using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aurore.Framework.Core.Asserts;

namespace Aurore.Framework.Core.ExtensionMethods.Reflection
{
    /// <summary>
    /// 扩展<see cref="Assembly"/>。
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<typeparamref name="T"/>的具体类型。
        /// </summary>
        public static IEnumerable<Type> GetDescendentTypes<T>(this Assembly assembly)
        {
            assembly.NotNull(nameof(assembly));

            return assembly.GetDescendentTypes(typeof(T));
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<typeparamref name="T"/>且满足<paramref name="filter" />条件的具体类型。
        /// </summary>
        public static IEnumerable<Type> GetDescendentTypes<T>(this Assembly assembly, Predicate<Type> filter)
        {
            assembly.NotNull(nameof(assembly));
            filter.NotNull(nameof(filter));

            return assembly.GetDescendentTypes(typeof(T), filter);
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<paramref name="baseType"/>的具体类型。
        /// </summary>
        public static IEnumerable<Type> GetDescendentTypes(this Assembly assembly, Type baseType)
        {
            assembly.NotNull(nameof(assembly));
            baseType.NotNull(nameof(baseType));

            return assembly.GetTypes()
                .Where(type => baseType.IsAssignableFrom(type) && type.CanCreate());
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<paramref name="baseType"/>且满足<paramref name="filter" />条件的具体类型。
        /// </summary>
        public static IEnumerable<Type> GetDescendentTypes(this Assembly assembly, Type baseType, Predicate<Type> filter)
        {
            assembly.NotNull(nameof(assembly));
            baseType.NotNull(nameof(baseType));
            filter.NotNull(nameof(filter));

            return assembly.GetTypes()
                .Where(type => baseType.IsAssignableFrom(type) && type.CanCreate() && filter(type));
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<typeparamref name="T"/>的对象实例。
        /// </summary>
        public static IEnumerable<T> CreateDescendentInstances<T>(this Assembly assembly)
        {
            assembly.NotNull(nameof(assembly));

            return assembly.GetDescendentTypes<T>()
                .Where(type => !type.ContainsGenericParameters)
                .Select(type => type.CreateInstance<T>())
                .ToArray();
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<typeparamref name="T"/>且满足<paramref name="filter" />条件的对象实例。
        /// </summary>
        public static IEnumerable<T> CreateDescendentInstances<T>(this Assembly assembly, Predicate<Type> filter)
        {
            assembly.NotNull(nameof(assembly));
            filter.NotNull(nameof(filter));
            
            return assembly.GetDescendentTypes<T>(filter)
                .Where(type => !type.ContainsGenericParameters)
                .Select(type => type.CreateInstance<T>())
                .ToArray();
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<paramref name="baseType"/>的对象实例。
        /// </summary>
        public static IEnumerable<object> CreateDescendentInstances(this Assembly assembly, Type baseType)
        {
            assembly.NotNull(nameof(assembly));
            baseType.NotNull(nameof(baseType));

            return assembly.GetDescendentTypes(baseType)
                .Where(type => !type.ContainsGenericParameters)
                .Select(type => type.CreateInstance())
                .ToArray();
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中的所有继承或实现了<paramref name="baseType"/>且满足<paramref name="filter" />条件的对象实例。
        /// </summary>
        public static IEnumerable<object> CreateDescendentInstances(this Assembly assembly, Type baseType, Predicate<Type> filter)
        {
            assembly.NotNull(nameof(assembly));
            baseType.NotNull(nameof(baseType));
            filter.NotNull(nameof(filter));

            return assembly.GetDescendentTypes(baseType, filter)
                .Where(type => !type.ContainsGenericParameters)
                .Select(type => type.CreateInstance())
                .ToArray();
        }
    }
}
