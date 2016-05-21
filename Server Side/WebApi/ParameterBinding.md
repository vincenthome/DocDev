# WebApi.ParameterBinding

Looks like [FromUri], [FromBody] are not useful anymore with the latest version of WebAPI. 
The binding happens automatically in most cases.

Using multiple parameters [FromUri], [FromBody] and HttpRequestMessage from parameter or base class property

##Using [FromUri] to build Complex type from Uri

To force Web API to read a complex type from the URI, add the [FromUri] attribute to the parameter. The following example defines a GeoPoint type, along with a controller method that gets the GeoPoint from the URI.

```csharp
public class GeoPoint
{
    public double Latitude { get; set; } 
    public double Longitude { get; set; }
}

public ValuesController : ApiController
{
    public HttpResponseMessage Get([FromUri] GeoPoint location) { ... }
}
```

The client can put the Latitude and Longitude values in the query string and Web API will use them to construct a GeoPoint. For example:

http://localhost/api/values/?Latitude=47.678558&Longitude=-122.130989

##Using [FromBody] to build a Simple type from body

To **force Web API to read a simple type from the request body**, add the [FromBody] attribute to the parameter:

```csharp
public HttpResponseMessage Post([FromBody] string name) { ... }
```

In this example, Web API will use a media-type formatter to read the value of name from the request body. Here is an example client request.

```
POST http://localhost:5076/api/values HTTP/1.1
User-Agent: Fiddler
Host: localhost:5076
Content-Type: application/json
Content-Length: 7

"Alice"
```

When a parameter has [FromBody], Web API uses the Content-Type header to select a formatter. In this example, the content type is "application/json" and the request body is a raw JSON string (not a JSON object).

At most one parameter is allowed to read from the message body. So this will not work:

```csharp
// Caution: Will not work!    
public HttpResponseMessage Post([FromBody] int id, [FromBody] string name) { ... }
```

The reason for this rule is that the request body might be stored in a non-buffered stream that can only be read once.

##Multiple Url Parameters including HttpRequestMessage
```csharp
[Route("api/values/{id}/{clientid}")]
public string Get(HttpRequestMessage request, int id, string clientid)
{
    if (id == 42)
        return "value " + id + " clientid: " + clientid + ". From HttpRequestMessage Injected Parameter: " + request.RequestUri;
    else
        return "value " + id + " clientid: " + clientid + ". From HttpRequestMessage Base Class Property:" + Request.RequestUri;
}

[Route("api/values/{id}/{clientid}")]
public string Put(HttpRequestMessage request, int id, string clientid, [FromBody]string value)
{
    if(id == 42)
        return "you just called put id: " + id + " clientid: " + clientid + " body: " + value + ". From HttpRequestMessage Injected Parameter: " + request.RequestUri;
    else
        return "you just called put id: " + id + " clientid: " + clientid + " body: " + value + ". From HttpRequestMessage Base Class Property:" + Request.RequestUri;
}
```