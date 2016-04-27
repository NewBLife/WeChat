using System.Web.Http.Filters;
using Aurore.Framework.Core;
using Aurore.Framework.Core.Exceptions;
using Aurore.Framework.Web.Core;

namespace Aurore.Framework.Web.Mvc.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApiExceptionFilterAttribute()
        {
            _logger = new Log4NetHelper();
        }
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var bases = filterContext.Request;
            var auroreException = filterContext.Exception as AuroreException;
            var exception = auroreException ?? new AuroreException(filterContext.Exception);
            _logger.WriteError("\r\n客户机IP:" + bases.RequestUri.Host + "\r\n错误地址:" + bases.RequestUri.AbsoluteUri + "\r\n异常信息:" + exception.Message, exception);

            var obj = new ResponseEntity<string>()
            {
                Success = false,
                Data = "请求异常",
                ErrorCode = exception.HResult.ToString(),
                ErrorMsg = exception.Message

            };
            filterContext.Response = obj.JsonResponse();
        }
    }
}