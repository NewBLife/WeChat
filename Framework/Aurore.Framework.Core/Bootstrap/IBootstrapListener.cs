using Hubs1.Infrastructure;

namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// 引导监听器。
    /// </summary>
    public interface IBootstrapListener
    {
        /// <summary>
        /// 引导程序通知插件处理完程序集后，会依次启动所有监听器。
        /// <param name="bootstrap">启动监听器的引导服务实例。</param>
        /// </summary>
        void Start(IBootstrapService bootstrap);
    }
}
