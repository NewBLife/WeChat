
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using WeChat.Utils;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;


namespace WeChat.Portal.Filters
{
    public class WeChatFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var exception = filterContext.Exception;
            var bases = filterContext.Request;

            Log4NetHelper.WriteLog("\r\n�ͻ���IP:" + bases.RequestUri.Host + "\r\n�����ַ:" + bases.RequestUri.AbsoluteUri + "\r\n�쳣��Ϣ:" + exception.Message, exception);
            var responseMessage =
               new HttpResponseMessage { Content = new StringContent("�����쳣", Encoding.GetEncoding("UTF-8"), "application/xml") };
            filterContext.Response = responseMessage;
        }
    }

}