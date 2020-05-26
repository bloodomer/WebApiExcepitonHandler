using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiExcepitonHandler.MyFilter
{
    public class MyErrorAttribute:ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // 1. Loglama
            Logger.LogYaz(actionExecutedContext.Exception.Message, actionExecutedContext.Exception.StackTrace);

            // 2. Response Hazırlama 
            MyErrorResponse myErrorResponse = new MyErrorResponse();

            myErrorResponse.ErrorAction = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            myErrorResponse.ErrorController = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            myErrorResponse.ErrorMessage = actionExecutedContext.Exception.ToString();

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, myErrorResponse);
        }
    }
}