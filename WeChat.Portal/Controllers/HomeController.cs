using System.Web.Mvc;
using Aurore.Framework.Core;

namespace WeChat.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            _logger.WriteLog("Home");
            return View();
        }
    }
}
