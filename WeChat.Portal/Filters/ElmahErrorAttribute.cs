using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WeChat.Portal.Filters
{
    public class ElmahErrorAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null)
                Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}