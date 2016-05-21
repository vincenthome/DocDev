using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace WebApiApp
{

    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var metadata = new ErrorData
            {
                Message = "A Custom GlobalExceptionHandler just caught an Exception",
                DateTime = DateTime.Now,
                ErrorId = Guid.NewGuid(),
                ExceptionMessage = "My ExceptionMessage",
                ExceptionType = context.Exception.GetType().ToString(),
                StackTrace = "My StackTrace: " + context.Request.RequestUri,
                    // ControllerContext and ActionContext will be null most of the time!
                    //context.ExceptionContext.ControllerContext.ControllerDescriptor.ControllerName + ", " +
                    //context.ExceptionContext.ActionContext.ActionDescriptor.ActionName,
                MessageDetail = "My Message Details"
            };
            //log the errors to db etc...
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata); // response is a HttpResponseMessage
            // ResponseMessageResult is a helper which turns a HttpResponseMessage into a IHttpActionResult
            context.Result = new ResponseMessageResult(response);

            // Options to consider:
            // 1. without populating the context.Result will give you the Orignal contentnegotiated error
            // 2. setting context.Result to null will give you the 'Yellow Screen of Death'
        }
    }
    public class ErrorData
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public string MessageDetail { get; set; }
        public DateTime DateTime { get; set; }
        public Guid ErrorId { get; set; }
    }


}