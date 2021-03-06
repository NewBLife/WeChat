﻿using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Aurore.Framework.Core;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace Aurore.Framework.Web.Mvc.Filters
{
    public class ApiActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApiActionFilterAttribute()
        {
            _logger = DependencyResolver.Current.GetService<ILogger>();
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