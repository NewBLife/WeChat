using System.Web;
using System.Web.Mvc;
using WeChat.Utils;

namespace WeChat.Portal.Filters
{
    public class CustomExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.ViewData["ErrorMessage"] = filterContext.Exception.Message;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData,
            };
            var exception = filterContext.Exception;
            HttpRequestBase bases = (HttpRequestBase)filterContext.HttpContext.Request;

            Log4NetHelper.WriteError("\r\n客户机IP:" + bases.UserHostAddress + "\r\n错误地址:" + bases.Url + "\r\n异常信息:" + exception.Message, exception);

            filterContext.ExceptionHandled = true;
        }
    }
}