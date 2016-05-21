# WebApi.DependencyInjection
Dependency Injection in ASP.NET Web API 2

[http://www.asp.net/web-api/overview/advanced/dependency-injection](http://www.asp.net/web-api/overview/advanced/dependency-injection)

```
Install-Package Unity
```

Create UnityResolover
```csharp
public class UnityResolver : IDependencyResolver
{
    protected IUnityContainer container;

    public UnityResolver(IUnityContainer container)
    {
        if (container == null)
        {
            throw new ArgumentNullException("container");
        }
        this.container = container;
    }

    public object GetService(Type serviceType)
    {
        try
        {
            return container.Resolve(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return null;
        }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        try
        {
            return container.ResolveAll(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return new List<object>();
        }
    }

    public IDependencyScope BeginScope()
    {
        var child = container.CreateChildContainer();
        return new UnityResolver(child);
    }

    public void Dispose()
    {
        container.Dispose();
    }
}
```

Create Interface & Concrete Class
```csharp
public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Add(User user);
}

public class UserRepository : IUserRepository
{
    IList<User> users;
    public UserRepository()
    {
        // Seed Users data. Try AutoPoco.
        // https://github.com/vincenthome/AutoPoco.SeedData
    }

    public IEnumerable<User> GetAll()
    {
        return users;
    }

    public User GetById(int id)
    {
        return users.Where(u => u.Id == id).FirstOrDefault();
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }
}
```

In WebApi.Register() method or Owin Startup.Configuration(). Setup WebApi for Dependency Injection.
```csharp
var container = new UnityContainer();
// Map Inteface against Concrete Type!
container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
config.DependencyResolver = new UnityResolver(container);
```

Use Constructor DI in Controller
```csharp
public class UsersController : ApiController
{
    private IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    // GET api/<controller>
    public IEnumerable<User> Get()
    {
        return _repository.GetAll();
    }

    // GET api/<controller>/5
    public User Get(int id)
    {
        return _repository.GetById(id);
    }


}
```

