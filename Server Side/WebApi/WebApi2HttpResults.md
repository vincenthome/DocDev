# WebApi2.HttpResults
New is WebApi 2. Support Action method returns various implementations of IHttpActionResult.

##IHttpActionResult

The IHttpActionResult interface was introducted in Web API 2. Essentially, it defines an HttpResponseMessage factory. Here are some advantages of using the IHttpActionResult interface:

* Simplifies unit testing your controllers.
* Moves common logic for creating HTTP responses into separate classes.
* Makes the intent of the controller action clearer, by hiding the low-level details of constructing the response.
* It can replace `IEnumerable<MyItem>` and `IQueryable<MyItem>` to replace a list of items

##[System.Web.Http.Results](https://msdn.microsoft.com/en-us/library/system.web.http.results.aspx)
More often, you will use the IHttpActionResult implementations defined in the System.Web.Http.Results namespace. The ApiContoller class defines helper methods that return these built-in action results.

* BadRequestErrorMessageResult
    - returns BadRequest response and performs content negotiation on an see HttpError with Message.
* BadRequestResult
    - returns an empty BadRequest response.
* ConflictResult
    - returns an empty HttpStatusCode.Conflict response.
* CreatedAtRouteNegotiatedContentResult<T>
    - performs route generation and content negotiation and returns a Created response when content negotiation succeeds.
* CreatedNegotiatedContentResult<T>
    - performs content negotiation and returns a Created response when it succeeds.
* ExceptionResult
    - returns a InternalServerError response and performs content negotiation on an HttpError  based on an Exception.
* FormattedContentResult<T>
    - returns formatted content.
* InternalServerErrorResult
    - returns an empty InternalServerError response.
* InvalidModelStateResult
    - returns a BadRequest response and performs content negotiation on an HttpError based on a ModelStateDictionary.
* JsonResult<T>
    - returns an OK response with JSON data.
* NegotiatedContentResult<T>
    - performs content negotiation.
* NotFoundResult
    - returns an empty NotFound response.
* OkNegotiatedContentResult<T>
    - performs content negotiation and returns an HttpStatusCode.OK response when it succeeds.
* OkResult
    - returns an empty HttpStatusCode.OK response.
* RedirectResult
    - an action result for a <see cref="F:System.Net.HttpStatusCode.Redirect"/>.
* RedirectToRouteResult
    - performs route generation and returns a <see cref="F:System.Net.HttpStatusCode.Redirect"/> response.
* ResponseMessageResult
    - returns a specified response message.
* StatusCodeResult
    - returns a specified HTTP status code.
* UnauthorizedResult
    - returns an Unauthorized response.


###Example

```csharp
// GET api/values/5
public IHttpActionResult Get(int id)
{
    if (id == -1)
        return Unauthorized();
    else if (id == 0)
        return NotFound();
    else if (id == 1)
        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotImplemented,
            "Error using HttpActionResult to return StatusCode and Custom Error Message"));
    else if (id == 2)
    {
        try
        {
            throw new NotImplementedException("This is not yet implemented!!!");
        }
        catch (Exception ex)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotImplemented,
            new HttpError("A Custom ExceptionFilterAttribute just caught the an NotImplementedException")
            {
                ExceptionMessage = ex.Message,
                ExceptionType = ex.GetType().ToString(),
                StackTrace = "My StackTrace: " + Request.RequestUri + ", " +
                    ActionContext.ControllerContext.ControllerDescriptor.ControllerName + ", " +
                    ActionContext.ActionDescriptor.ActionName,
                MessageDetail = "My Message Details"
            }));

        }
    }
    else if (id == 42)
        return Ok("value " + id);
    else
        return StatusCode(HttpStatusCode.NoContent);
}

// GET: api/values
// P.S. Replace IQueryable<MyItem> with IHttpActionResult
public IHttpActionResult Get()
{
    // List<MyItem> myItems = new List<MyItem>();
    // myItems.Add(new MyItem { ... });
    return Ok(myItems);
}
```