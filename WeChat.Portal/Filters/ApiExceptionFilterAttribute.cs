using System.Web.Http.Filters;
using Aurore.Framework.Web.Core;
using Aurore.Framework.Web.Mvc;
using WeChat.Utils;

namespace WeChat.Portal.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var exception = filterContext.Exception;
            var bases = filterContext.Request;

            Log4NetHelper.WriteError("\r\n�ͻ���IP:" + bases.RequestUri.Host + "\r\n�����ַ:" + bases.RequestUri.AbsoluteUri + "\r\n�쳣��Ϣ:" + exception.Message, exception);

            var obj = new ResponseEntity<string>()
            {
                Success = false,
                Data = "�����쳣",
                ErrorCode = exception.HResult.ToString(),
                ErrorMsg = exception.Message

            };
            filterContext.Response = obj.JsonResponse();
        }
    }
}