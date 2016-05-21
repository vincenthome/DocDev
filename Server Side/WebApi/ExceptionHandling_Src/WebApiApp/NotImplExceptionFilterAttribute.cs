using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApiApp
{
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.NotImplemented,
                    new HttpError("A Custom ExceptionFilterAttribute just caught the an NotImplementedException") { 
                        ExceptionMessage = "My ExceptionMessage",
                        ExceptionType = context.Exception.GetType().ToString(),
                        StackTrace = "My StackTrace: " + context.Request.RequestUri + ", " + 
                            context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName + ", " +
                            context.ActionContext.ActionDescriptor.ActionName,
                        MessageDetail = "My Message Details"
                    });
            }
        }
    }
}