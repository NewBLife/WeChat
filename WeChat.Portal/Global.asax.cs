using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aurore.Framework.Core;
using WeChat.Utils;

namespace WeChat.Portal
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyConfig.RegisterDependency();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Log4NetHelper.SetConfig();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //在出现未处理的错误时运行的代码
            //Exception objExp = HttpContext.Current.Server.GetLastError();
            //string username = "";
            //string userid = "";
            //if (Session["ulogin"] != null)
            //{
            //    string[] uinfo = Session["ulogin"].ToString().Split('|');
            //    userid = uinfo[0];
            //    username = uinfo[1];
            //}
            //Log4NetHelper.WriteError("\r\n用户ID:" + userid + "\r\n用户名:" + username + "\r\n客户机IP:" + Request.UserHostAddress + "\r\n错误地址:" + Request.Url + "\r\n异常信息:" + Server.GetLastError().Message, objExp);

        }

    }
}
