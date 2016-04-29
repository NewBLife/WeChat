using System;
using System.Reflection;

namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// 引导服务接口，负责引导系统的启动。
    /// </summary>
    public interface IBootstrapService
    {
        /// <summary>
        /// 添加程序集过滤器，符合过滤器规则的程序集才会被<see cref="IBootstrapModule"/>处理。
        /// </summary>
        IBootstrapService AddFilter(Predicate<Assembly> filter);

        /// <summary>
        /// 添加程序集过滤器，符合过滤器规则的程序集才会被<see cref="IBootstrapModule"/>处理。
        /// </summary>
        IBootstrapService AddFilters(params Predicate<Assembly>[] filters);

        /// <summary>
        /// 注册新的<see cref="IBootstrapPlugin"/>，必须在启动前调用此方法。
        /// </summary>
        IBootstrapService AddPlugin(IBootstrapPlugin plugin);

        /// <summary>
        /// 注册新的<see cref="IBootstrapPlugin"/>，必须在启动前调用此方法。
        /// </summary>
        IBootstrapService AddPlugins(params IBootstrapPlugin[] plugins);

        /// <summary>
        /// 启动引导程序。
        /// </summary>
        void Start();
    }
}
