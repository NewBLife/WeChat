using System;

namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// 标记程序集是否是有效的引导程序集。
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class BootstrapAssemblyAttribute : Attribute
    {
    }
}
