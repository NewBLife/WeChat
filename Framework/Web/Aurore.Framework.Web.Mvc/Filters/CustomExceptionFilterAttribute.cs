using System.Web;
using System.Web.Mvc;
using Aurore.Framework.Core;
using Aurore.Framework.Core.Exceptions;

namespace Aurore.Framework.Web.Mvc.Filters
{
    public class CustomExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        private readonly ILogger _logger;

        public CustomExceptionFilterAttribute()
        {
            _logger = _logger = new Log4NetHelper();
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.ViewData["ErrorMessage"] = filterContext.Exception.Message;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData,
            };
           
            HttpRequestBase bases = filterContext.HttpContext.Request;
            var auroreException = filterContext.Exception as AuroreException;
            var exception = auroreException ?? new AuroreException(filterContext.Exception);
            _logger.WriteError("\r\n客户机IP:" + bases.UserHostAddress + "\r\n错误地址:" + bases.Url + "\r\n异常信息:" + exception.Message, exception);

            filterContext.ExceptionHandled = true;
        }
    }
}