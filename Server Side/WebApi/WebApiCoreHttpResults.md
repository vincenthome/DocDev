# WebApi.ASP.NET.Core.HttpResults
Web API ActionResult in ASP.NET Core

##IActionResult
The method returns ObjectResult if it finds a ToDo item with a matching ID. Returning ObjectResult is equivalent to returning the CLR model, but it makes the return type IActionResult. That way, the method can return a different action result for other code paths.

When the ID is not found, the method returns HttpNotFound, which translates into a 404 response.
```csharp
[HttpGet("{id:int}", Name = "GetByIdRoute")]
public IActionResult GetById (int id)
{
    var item = _items.FirstOrDefault(x => x.Id == id);
    if (item == null)
    {
        return HttpNotFound();
    }

    return new ObjectResult(item);
}
```
