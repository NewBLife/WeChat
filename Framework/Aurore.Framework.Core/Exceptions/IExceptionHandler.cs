using System;

namespace Aurore.Framework.Core.Exceptions
{
    /// <summary>
    /// 异常处理器。
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// 处理发生的异常。
        /// </summary>
        /// <param name="ex">待处理的异常。</param>
        /// <returns></returns>
        bool HandleException(Exception ex);
    }
}
