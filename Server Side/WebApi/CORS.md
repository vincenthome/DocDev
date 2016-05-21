# WebApi.CORS

[http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api](http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api)

##What the error looks like:

```
// Without CORS support, you will get still Http Status 200 OK, 
// BUT with this error:

XMLHttpRequest cannot load http://localhost:49330/api/values/42. 
No 'Access-Control-Allow-Origin' header is present on the requested resource. 
Origin 'http://localhost:49345' is therefore not allowed access.
```

##WebApi

* Install-Package Microsoft.AspNet.WebApi.Cors
* Startup.cs: config.EnableCors();
* In controller level: [EnableCors(origins: "http://mywebclient.xyz.com", headers: "*", methods: "*")]

```csharp
public void Configuration(IAppBuilder app)
{
    HttpConfiguration config = new HttpConfiguration();
    config.EnableCors();
    ...
}

[EnableCors(origins: "http://localhost:49345", headers: "*", methods: "*")]
public class ValuesController : ApiController
{
 ... 
}
```

##Web Client

```javascript
<div class="row">
    <div class="col-sm-4">
        <select id="method" class="form-control">
            <option value="get">GET</option>
            <option value="post">POST</option>
            <option value="put">PUT</option>
        </select>
    </div>
    <div class="col-sm-2">
        <input type="button" class="btn btn-primary" value="Try it" onclick="sendRequest()" />
    </div>
    <div class="col-sm-6">
        <span id='value1'>(Result)</span>
    </div>
</div>

@section scripts {
    <script>

    function sendRequest() {

        var method = $('#method').val();
        var serviceUrl = 'http://localhost:49330/api/values/';

        if (method === "put")
            serviceUrl += "42"

        $.ajax({
            url: serviceUrl,
            type: method,
            dataType: "json", // aka Accept
            contentType: "application/json",
            data: "\"myData\"",
        })
        .done(function (data, textStatus, jqXHR) {
            $('#value1').html(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            $('#value1').html(jqXHR.responseText || textStatus);
        });
    }
    </script>
}
```

