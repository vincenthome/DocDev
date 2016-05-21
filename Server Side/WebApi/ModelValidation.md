# WebApi.ModelValidation

##Using ModalState.IsValid and create error response using ModelState info
**The validation happens at WebApi Model Binding Phase.**

* Model Field Validation using DataAnnotation Attributes
* Cross-Fields Validation using IValidatableObject

[http://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api](http://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api)

Check Valiation State and return Http Status 400 & error message if failed
```csharp
public IHttpActionResult Post([FromBody]Movie movie)
{
    // Check if Valiation Success
    if (!ModelState.IsValid)
        return BadRequest(ModelState); // return 400 with Failed Valiation Info
    ...
}
```

Sample Error Response
```
{
  "Message": "The request is invalid.",
  "ModelState": {
    "movie": [
      "Error: This is not a family movie",
      "Error: This is not a G, PG or PG-13 movie"
    ]
  }
}
```

Using BOTH DataAnnotation Attributes and IValidatableObject for validation!
```csharp
public class Movie : IValidatableObject
{
    ...

    [Required(ErrorMessage = "Genre must be specified")]
    public string Genre { get; set; }

    [StringLength(5)]
    public string Rating { get; set; }

    // Cross-Fields Validation
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Genre == "Family" && Rating != "G" && Rating != "PG" && Rating != "PG-13")
        {
            // can use multiple yield return new statements to populate IEnumerable<ValidationResult>
            yield return new ValidationResult("Error: This is not a family movie");
            yield return new ValidationResult("Error: This is not a G, PG or PG-13 movie");
        }
    }
}
```