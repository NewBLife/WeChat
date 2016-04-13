using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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

            //var appFormatterType = config.Formatters.XmlFormatter;
            //for (int i = 0; i < config.Formatters.Count; i++)
            //{
            //    config.Formatters.RemoveAt(0);
            //}
            //config.Formatters.Add(appFormatterType);
            //#region DEBUG

            //#endregion DEBUG
            //var appFormatterType = config.Formatters.XmlFormatter;
            //config.Formatters.Remove(appFormatterType);
        }
    }
}
