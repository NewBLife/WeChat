namespace Aurore.Framework.Core.Mapper
{
    /// <summary>
    /// 对象映射服务。
    /// </summary>
    public interface IMappingService
    {
        /// <summary>
        /// 将 source 转换为目标类型。
        /// </summary>
        /// <typeparam name="TDestination">目标对象类型。</typeparam>
        /// <typeparam name="TSource">源对象类型。</typeparam>
        /// <param name="source">源对象。</param>
        /// <returns></returns>
        TDestination Map<TDestination, TSource>(TSource source);

        /// <summary>
        /// 将 source 转换为目标类型。
        /// </summary>
        /// <typeparam name="TDestination">目标对象类型。</typeparam>
        /// <typeparam name="TSource">源对象类型。</typeparam>
        /// <param name="source">源对象。</param>
        /// <param name="destination">目标对象。</param>
        /// <returns></returns>
        TDestination Map<TDestination, TSource>(TSource source, TDestination destination);
    }
}
