#JSON.NET

## Return camelCased JSON from Web API

```C#
// Serialize with camelCase formatter for JSON.
var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
```
