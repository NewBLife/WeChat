namespace Aurore.Framework.Core.Mapper
{
    /// <summary>
    /// 对象映射服务入口。
    /// </summary>
    public static class MappingService
    {
        /// <summary>
        /// 获取或设置当前激活的<see cref="IMappingService"/>。
        /// </summary>
        public static IMappingService Current { get; set; }
    }
}
