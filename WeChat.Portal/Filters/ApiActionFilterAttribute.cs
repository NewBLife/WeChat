

using System.Web;
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
            var  bases = actionContext.Request;
            string url = bases.RequestUri.AbsoluteUri.ToString().ToLower();
            string requestFormat = "Request Url：{0}";
            Log4NetHelper.WriteLog(string.Format(requestFormat, url));
            //获取url中的参数
            string queryString = bases.RequestUri.Query.ToString();
            //对获取到的参数进行UrlDecode处理
            //queryString = HttpUtility.UrlDecode(queryString);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        //public void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpRequestBase bases = (HttpRequestBase)filterContext.HttpContext.Request;
        //    string url = bases.RawUrl.ToString().ToLower();
        //    string requestFormat ="Request Url：{0}";
        //    Log4NetHelper.WriteLog(string.Format(requestFormat, url));
        //    //获取url中的参数
        //    string queryString = bases.QueryString.ToString();
        //    //对获取到的参数进行UrlDecode处理
        //    //queryString = HttpUtility.UrlDecode(queryString);
        //}

        //public void OnActionExecuted(ActionExecutedContext filterContext)
        //{
            
        //}

       
    }
  
}