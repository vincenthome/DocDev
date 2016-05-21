using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
     [RoutePrefix("api/rnrpadata")]
    public class RouteNameRoutePrefixAttributeValuesController : ApiController
    {
        // GET api/values
        [Route("")] // This attribute is required even it has EMPTY route templates
        public IEnumerable<string> Get()
        {
            var r = Url.Link("RouteNameRoutePrefixAttributeValuesGetId", new { id = 42 });
            return new string[] { "value1", "value2", r };
        }

        // GET api/values/5
        [Route("{id:int}", Name = "RouteNameRoutePrefixAttributeValuesGetId")]
        public string Get(int id)
        {
            return "value " + id;
        }
    }
}