#JSON.NET

## Return camelCased JSON from Web API
[source](http://stackoverflow.com/questions/26474436/return-camelcased-json-from-web-api)

```C#
// Serialize with camelCase formatter for JSON.
var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
```
