using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    public class RouteAttributeCatchAllValuesController : ApiController
    {
        // GET api/values
        [Route("api/racatchalldata")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("api/racatchalldata/{id:int}")]
        public string Get(int id)
        {
            return "value " + id;
        }

        // This will CatchAll - all 4 http verbs
        // e.g. api/racatchalldata/123somestring   will get caught in here!!!
        [HttpGet]
        [HttpPost]
        [HttpPut]
        [HttpDelete]
        [Route("api/racatchalldata/{*parameters}")]
        public string Get(string parameters)
        {
            return parameters;
        }
    }
}