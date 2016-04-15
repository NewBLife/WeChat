using System.Web.Mvc;
using Aurore.Framework.Web.Mvc.Filters;

namespace WeChat.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
