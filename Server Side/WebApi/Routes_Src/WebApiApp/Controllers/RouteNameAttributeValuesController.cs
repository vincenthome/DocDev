using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    public class RouteNameAttributeValuesController : ApiController
    {
        //http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2#route-names
        //Route names are useful for generating links, so that you can include a link in an HTTP response.

        //To specify the route name, set the Name property on the attribute. The following example shows how to set the route name, 
        //and also how to use the route name when generating a link.

        // GET api/values
        [Route("api/rnadata")]
        public IEnumerable<string> Get()
        {
            var r = Url.Link("RouteNameAttributeValuesGetId", new { id = 42 });
            return new string[] { "value1", "value2", r };
        }

        // GET api/values/5
        [Route("api/rnadata/{id:int}", Name = "RouteNameAttributeValuesGetId")]
        public string Get(int id)
        {
            return "value " + id;
        }


    }
}