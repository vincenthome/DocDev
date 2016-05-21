using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    [NotImplExceptionFilter]
    public class ExceptionFilterValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[NotImplExceptionFilter]
        public string Get(int id)
        {           
            // What happens if a Web API controller throws an uncaught exception? 
            // By default, most exceptions are translated into an HTTP response with status code 500, Internal Server Error.
            if(id == 0)
                fooThrownException();
            else if(id != 42)
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.HttpVersionNotSupported, 
                    "An Exception is throw here by id: " + id,
                    new ArgumentOutOfRangeException()));

            return "value " + id;
        }

        private void fooThrownException()
        {
            throw new NotImplementedException();
        }

    }

}