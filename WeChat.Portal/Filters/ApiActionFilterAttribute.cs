using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WeChat.Utils;

namespace WeChat.Portal.Filters
{
    public class ApiActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var  request = actionContext.Request;
            string url = request.RequestUri.AbsoluteUri;
            string requestFormat = "Request Url：{0}";
            Log4NetHelper.WriteLog(string.Format(requestFormat, url));
            //获取url中的参数
            string queryString = request.RequestUri.Query;
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
  
}