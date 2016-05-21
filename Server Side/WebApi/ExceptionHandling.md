#WebApi Exception Handling

##Prefer to use ApiController.ResponseMessage Method to wrap a HttpResponseMessage instead of exception.

<https://github.com/vincenthome/WebApi2.HttpResults#example>

##Not prefer using Exception inside Action. However, still good idea to use GlobalException

[Good Idea - GlobalException](https://github.com/vincenthome/WebApi.ExceptionHandling/blob/master/README.md#global-exception-handling)

###.

###.

###.

When to Use

Exception loggers are the solution to seeing all unhandled exception caught by Web API.
Exception handlers are the solution for customizing all possible responses to unhandled exceptions caught by Web API.
Exception filters are the easiest solution for processing the subset unhandled exceptions related to a specific action or controller.

##HttpResponseException and CreateErrorResponse

CreateErrorResponse is an extension method defined in the System.Net.Http.HttpRequestMessageExtensions class. Internally, CreateErrorResponse creates an HttpError instance and then creates an HttpResponseMessage that contains the HttpError.

```csharp
public string GetProduct(int id)
{
   throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, 
                    "An Exception is throw here by id: " + id,
                    new ArgumentOutOfRangeException()));
}
```

In this example, if the method is successful, it returns the product in the HTTP response. But if the requested product is not found, the HTTP response contains an HttpError in the request body. The response might look like the following:

HTTP/1.1 404 Not Found
Content-Type: application/json; charset=utf-8
Date: Thu, 09 Aug 2012 23:27:18 GMT
Content-Length: 51

{
  "Message": "Product with id = 12 not found"
}
Notice that the HttpError was serialized to JSON in this example. One advantage of using HttpError is that it goes through the same content-negotiation and serialization process as any other strongly-typed model.

##Exception Filters
http://www.asp.net/web-api/overview/error-handling/exception-handling

```csharp
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
```

There are several ways to register a Web API exception filter:

By action
By controller
Globally

```csharp
// By Action
public class ProductsController : ApiController
{
    [NotImplExceptionFilter]
    public Contact GetContact(int id)
    {
        throw new NotImplementedException("This method is not implemented");
    }
}

// By Controller
[NotImplExceptionFilter]
public class ProductsController : ApiController
{
    // ...
}

// Globally
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.Filters.Add(new ProductStore.NotImplExceptionFilterAttribute());
    }
}
```

##HttpError and Model Validation

For model validation, you can pass the model state to CreateErrorResponse, to include the validation errors in the response:

```csharp
public HttpResponseMessage PostProduct(Product item)
{
    if (!ModelState.IsValid)
         throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));

	...
}
```

This example might return the following response:

```
HTTP/1.1 400 Bad Request
Content-Type: application/json; charset=utf-8
Content-Length: 320

{
  "Message": "The request is invalid.",
  "ModelState": {
    "item": [
      "Required property 'Name' not found in JSON. Path '', line 1, position 14."
    ],
    "item.Name": [
      "The Name field is required."
    ],
    "item.Price": [
      "The field Price must be between 0 and 999."
    ]
  }
}
```

Handling Validation Errors using ActionFilter
http://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api

##Global Exception Handling
[http://www.asp.net/web-api/overview/error-handling/web-api-global-error-handling](http://www.asp.net/web-api/overview/error-handling/web-api-global-error-handling)

* ExceptionHandler
* ExceptionLogger

An exception handler indicates that it has handled an exception by setting the Result property to an action result (for example, an ExceptionResult, InternalServerErrorResult, StatusCodeResult, or a custom result). If the Result property is null, the exception is unhandled and the original exception will be re-thrown.

```csharp

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
            // 2. setting context.Result = null; will give you the 'Yellow Screen of Death'
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



class TraceExceptionLogger : ExceptionLogger
{
   public override void LogCore(ExceptionLoggerContext context)
   {
      Trace.TraceError(context.ExceptionContext.Exception.ToString());
   }
}

```

```csharp
public class ExceptionHandlerContext
{
   public ExceptionContext ExceptionContext { get; set; }
   public IHttpActionResult Result { get; set; }
}

public class ExceptionContext
{
   public Exception Exception { get; set; }
   public HttpRequestMessage Request { get; set; }
   public HttpRequestContext RequestContext { get; set; }
   public HttpControllerContext ControllerContext { get; set; }
   public HttpActionContext ActionContext { get; set; }
   public HttpResponseMessage Response { get; set; }
   public string CatchBlock { get; set; }
   public bool IsTopLevelCatchBlock { get; set; }
}
```

###Registration

```csharp
// Registration. ONLY 1 is allowed. Therefore use 'Replace'
config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

```