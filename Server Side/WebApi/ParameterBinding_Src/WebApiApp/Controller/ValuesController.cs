using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controller
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("api/values/{id}/{clientid}")]
        public string Get(HttpRequestMessage request, int id, string clientid)
        {
            if (id == 42)
                return "value " + id + " clientid: " + clientid + ". From HttpRequestMessage Injected Parameter: " + request.RequestUri;
            else
                return "value " + id + " clientid: " + clientid + ". From HttpRequestMessage Base Class Property:" + Request.RequestUri;
        }

        // PUT api/<controller>/5
        [Route("api/values/{id}/{clientid}")]
        public string Put(HttpRequestMessage request, int id, string clientid, [FromBody]string value)
        {
            if(id == 42)
                return "you just called put id: " + id + " clientid: " + clientid + " body: " + value + ". From HttpRequestMessage Injected Parameter: " + request.RequestUri;
            else
                return "you just called put id: " + id + " clientid: " + clientid + " body: " + value + ". From HttpRequestMessage Base Class Property:" + Request.RequestUri;
        }

    }
}