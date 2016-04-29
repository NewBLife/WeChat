namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// <see cref="IBootstrapPlugin"/>扩展。
    /// </summary>
    public static class IBootstrapPluginExtentions
    {
        /// <summary>
        /// 配置完成，结束Fluent调用。
        /// </summary>
        public static void Done(this IBootstrapPlugin that)
        {
            // nothing to do
        }
    }
}
