using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Aurore.Framework.Core;

namespace Aurore.Framework.Web.Mvc.Filters
{
    public class ApiActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApiActionFilterAttribute()
        {
            _logger = null;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var request = actionContext.Request;
            string url = request.RequestUri.AbsoluteUri;
            string requestFormat = "Request Url：{0}";
            _logger.WriteError(string.Format(requestFormat, url));
            //获取url中的参数
            string queryString = request.RequestUri.Query;
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}