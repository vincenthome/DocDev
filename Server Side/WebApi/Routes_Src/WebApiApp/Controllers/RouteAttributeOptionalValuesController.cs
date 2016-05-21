using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    public class RouteAttributeOptionalValuesController : ApiController
    {
        // GET api/values/5
        [Route("api/raodata/{id:int?}")]
        public string Get(int? id = null)
        {
            if (id != null)
                return "value " + id;
            else
                return "value - id missing";
        }
    }
}