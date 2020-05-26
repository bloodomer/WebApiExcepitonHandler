using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiExcepitonHandler.MyFilter
{
    public class MyActionAttribute:ActionFilterAttribute
    {
        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    actionContext.
        //    base.OnActionExecuting(actionContext);
        //}

        //public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        //}

    }
}