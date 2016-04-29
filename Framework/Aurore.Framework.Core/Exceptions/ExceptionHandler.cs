using System;

namespace Aurore.Framework.Core.Exceptions
{
    /// <summary>
    /// 异常处理器基类。
    /// </summary>
    /// <typeparam name="TException">待处理的异常的类型。</typeparam>
    public abstract class ExceptionHandler<TException> : IExceptionHandler
        where TException : Exception
    {
        /// <summary>
        /// 处理异常。
        /// </summary>
        /// <param name="ex">待处理的异常。</param>
        protected abstract bool Handle(TException ex);

        /// <summary>
        /// 处理发生的异常。
        /// </summary>
        /// <param name="ex">待处理的异常。</param>
        /// <returns></returns>
        public virtual bool HandleException(Exception ex)
        {
            return Handle(ex as TException);
        }
    }
}
