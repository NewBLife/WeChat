using System;
using System.IO;
using System.Text;
using System.Web;
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
            _logger = new Log4NetHelper();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var request = actionContext.Request;
            string url = request.RequestUri.AbsoluteUri;
            string queryString = request.RequestUri.Query;
            string requestFormat = "Request Url：\r\n{0},Query;{1}";
            _logger.WriteLog(string.Format(requestFormat, url, queryString));
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}