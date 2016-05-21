using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiApp.Controllers
{
// Without CORS support, you will get
// 1. Http Status 200 OK, but
// 2. XMLHttpRequest cannot load http://localhost:49330/api/values/42. 
//    No 'Access-Control-Allow-Origin' header is present on the requested resource. 
//    Origin 'http://localhost:49345' is therefore not allowed access.

// The Client-side $.ajax code can be found in WebMVCApp -> Views -> Home -> index.cshtml 

    [EnableCors(origins: "http://localhost:49345", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value " + id;
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            return value + " Created Successfully";
        }

        // PUT api/values/5
        public string Put(int id, [FromBody]string value)
        {
            return id + " " + value + " is updated successfully";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return id + " deleted successfully!";
        }
    }
}