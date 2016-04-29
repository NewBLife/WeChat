namespace Aurore.Framework.Core.Ioc
{
    /// <summary>
    /// IoC 入口。
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// 获取或设置当前激活的<see cref="IServiceLocator"/>。
        /// </summary>
        public static IServiceLocator Current { get; set; }
    }
}
