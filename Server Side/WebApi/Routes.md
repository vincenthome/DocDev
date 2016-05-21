# WebApi.Routes
Show examples of different types of routes

##Routing

###Centralized Routes

WebApi:
(HttpConfiguration)config.(HttpRouteCollection)Routes.MapHttpRoute(...)

MVC:
(RouteCollection)routes.MapRoute(...)

In routeTemplate, define param as **{id}**. Should **match action method's param**

WebApi Sample:
```csharp
config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);
// Action Method
public Order Get(int id) {...}
```

####Action Method Selection
* Inferred from method name
* [Http*] attributes
* Method Params matches the routeTemplate placeholders param

####Centralized routing problems - sub-resource issue
* GET api/teams
* GET api/teams/1
* GET api/teams/1/**players**

To support the above together will require a custom route with **explicit controller name, custom param name** in addition to the regular default route:
```csharp
config.Routes.MapHttpRoute(
    name: "players",
    routeTemplate: "api/teams/{teamid}/players",
    defaults: new { controller = "teams" }
);
config.Routes.MapHttpRoute(
    ...,
    routeTemplate: "api/{controller}/{id}",
    ...
);

public IEnumerable<Team> GetTeams() { ... } // api/teams
public Team GetTeam(int id) { ... } // api/teams/1
public IEnumerable<Player> GetPlayers(int teamId) { ... } // api/teams/1/players
```

###Direct/Attribute Routes
Avoid centralized routes' explicit controller name issue.

**DON'T FORGET TO USE config.MapHttpAttributeRoutes();**

```csharp
config.MapHttpAttributeRoutes();
// Still need the DefaultApi route here for others
config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);
```

```csharp
public class TeamsController : ApiController
{
    [Route("api/teams")]
    public IEnumerable<Team> GetTeams() { ... }
    [Route("api/teams/{id}")]
    public Team GetTeam(int id) { ... }
    [Route("api/teams/{teamId}/players")]
    public IEnumerable<Player> GetPlayers(int teamId) { ... }
}

// Simplified More with RoutePrefix
[RoutePrefix("api/teams")]
public class TeamsController : ApiController
{
    [Route] // STILL NEED the Route Attibute here!!!
    public IEnumerable<Team> GetTeams() { ... }
    [Route("{id}")]
    public Team GetTeam(int id) { ... }
    [Route("{teamId}/players")]
    public IEnumerable<Player> GetPlayers(int teamId) { ... }
}
```

WebApi will scan the attributes, implicitly figure out the controller name, build the route and add it to the HttpRouteCollection together with the Default routes.

####Http* Attributes

[HttpGet]/[HttpPost]/[HttpPut]/[HttpDelete]

####Default Value - compare

* Attribute:[Route("items/{id**:int=VALUE**}")] // ':' is part of it
* Centralized: defaults: new { **id = VALUE** }
* C# method signature: HttpResponseMessage Get(int **id = VALUE**) { ... }

####Optional Value - compare

* Attribute:[Route("items/{id:int**?**}")]
    - If a route parameter is optional, you must define a default value for the method parameter. e.g. void foo(int? id = null) { ... }
* Centralized: defaults: new { **id = RouteParameter.Optional** }
* C# method signature: HttpResponseMessage Get(int**? id = null**) { ... }

####2+ Optional Values - compare

* Attribute: [Route("orders/{skip**?**},{take**?**}")]
* Centralized: routeTemplate: "orders/{skip},{take}}", defaults: new {**skip=RouteParameter.Optional, take=RouteParameter.Optional**}
* C# method signature: HttpResponseMessage foo(int**? skip = null**, int**? take = null**) { ... }
* [http://stackoverflow.com/questions/27692606/multiple-optional-parameters-routing](http://stackoverflow.com/questions/27692606/multiple-optional-parameters-routing)

####Constraints - :constraint1:constraint2

**alpha/bool/datetime/decimal/double/float/guid/int/length/long/maxlength/max/minlength/min/range/regex + CompoundRouteConstraint() & HttpMethodConstraint()**

* Attribute:[Route("items/{id**:int**}")] // ':' is part of it
* Centralized: **constraints: new { id = new IntRouteConstraint() }**

####2+ Constraints

* Attribute:[Route("items/{id**:int:min(0)**}")] // ':' is part of it
* Centralized: 
    constraints: new { id = **new CompoundRouteConstraint ( new List<IHttpRouteConstraint> { new IntRouteConstraint(), new MinRouteConstraint(0)} )** }

####Custom Constraint: Impl. IHttpRouteConstraint's Match method. R.3-5

####Catch-all {*params}

* MUST be the last segment
* Typical usage: as a proxy forwards that portion of the Url to the method(string params) parameter.
* Attribute: [Route("proxy/**{*params}**")]
* Centralized: **routeTemplate: "proxy/{*params}"**

```csharp
[Route("proxy/{*params}")]
public HttpResponseMessage Get(string params)

config.Routes.MapHttpRoute(
    ...
    routeTemplate: "proxy/{*params}"
);
```

####Stop - Action Method will not be called. What will be the Http Response???
[NonAction]

####Ignore - pass through to the underlying pipeline
Use HttpRouteCollection.IgnoreRoute(...) Extension Method during Config. Let certain routes to pass through WebApi framework to the underlying web server(e.g. static files) or other OWIN middleware.

```csharp
config.Routes.IgnoreRoute("Content", "content/{*params}");

config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new { id = RouteParameter.Optional });

```

