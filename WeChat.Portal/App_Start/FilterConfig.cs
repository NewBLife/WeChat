using System.Web;
using System.Web.Mvc;
using WeChat.Portal.Filters;

namespace WeChat.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilterAttribute());
        }
    }
}
