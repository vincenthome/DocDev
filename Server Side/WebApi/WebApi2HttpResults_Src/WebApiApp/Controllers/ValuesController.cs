using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            IEnumerable<string> result = new string[] { "value1", "value2" };
            return Ok(result);
        }

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

        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok(value + " Created Successfully");
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok(id + " " + value + " is updated successfully");
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(id + " deleted successfully!");
        }
    }
}