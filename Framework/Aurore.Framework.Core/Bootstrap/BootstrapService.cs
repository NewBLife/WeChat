namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// 引导服务入口。
    /// </summary>
    public static class BootstrapService
    {
        static readonly IBootstrapService current = new DefaultBootstrapService();

        /// <summary>
        /// 系统引导服务入口。
        /// </summary>
        public static IBootstrapService Current
        {
            get { return current; }
        }
    }
}
