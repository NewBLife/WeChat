using System.Reflection;
using Hubs1.Infrastructure;

namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// 引导插件。
    /// </summary>
    public interface IBootstrapPlugin
    {
        /// <summary>
        /// 引导程序先载入所有程序集，然后循环所有插件处理程序集。
        /// </summary>
        /// <param name="bootstrap">启动监听器的引导服务实例。</param>
        /// <param name="assembly">要处理的程序集。</param>
        void Start(IBootstrapService bootstrap, Assembly assembly);
    }
}
