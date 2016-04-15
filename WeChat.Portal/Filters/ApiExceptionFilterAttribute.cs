using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using WeChat.Core;
using WeChat.Core.Extensions;
using WeChat.Utils;

namespace WeChat.Portal.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var exception = filterContext.Exception;
            var bases = filterContext.Request;

            Log4NetHelper.WriteLog("\r\n客户机IP:" + bases.RequestUri.Host + "\r\n错误地址:" + bases.RequestUri.AbsoluteUri + "\r\n异常信息:" + exception.Message, exception);

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