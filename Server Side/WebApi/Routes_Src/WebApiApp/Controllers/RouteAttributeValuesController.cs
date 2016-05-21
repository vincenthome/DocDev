using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
    public class RouteAttributeValuesController : ApiController
    {        
        // GET api/values
        [Route("api/radata")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("api/radata/{id:int}")]
        public string Get(int id)
        {
            return "value " + id;
        }

        // POST api/values
        [Route("api/radata")]
        public string Post([FromBody]string value)
        {
            return value + " Created Successfully";
        }

        // PUT api/values/5
        [Route("api/radata/{id:int}")]
        public string Put(int id, [FromBody]string value)
        {
            return id + " " + value + " is updated successfully";
        }

        // DELETE api/values/5
        [Route("api/radata/{id:int}")]
        public string Delete(int id)
        {
            return id + " deleted successfully!";
        }
    }
}