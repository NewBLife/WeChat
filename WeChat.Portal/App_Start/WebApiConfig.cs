using System.Web.Http;
using Aurore.Framework.Web.Mvc.Filters;

namespace WeChat.Portal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new ApiExceptionFilterAttribute());
            config.Filters.Add(new ApiActionFilterAttribute());
         
        }
    }
}
