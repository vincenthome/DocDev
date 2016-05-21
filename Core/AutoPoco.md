#AutoPoco
[https://autopoco.codeplex.com/](https://autopoco.codeplex.com/)

AutoPoco is a highly configurable framework for the purpose of fluently **building readable test data** from Plain Old CLR Objects.

Install-Package AutoPoco

##Creating a collection of objects
[https://autopoco.codeplex.com/wikipage?title=Generation&referringTitle=Documentation](https://autopoco.codeplex.com/wikipage?title=Generation&referringTitle=Documentation)
Start the process off by calling Session.List<T>

* Session
    * List<T>(int count): Kicks off the generation process for a list of T of size 'count'
        * Impose(x=>x.Property, "Value"): Imposes a value onto the property of every single object, re-returns the **List<T>** object
        * First(int count): Selects the first 'count' items in the collection
            * Impose(x=>x.Property, "Value"): Imposes value onto the property of every single object in the current selection, re-returns the **First** object
            * Next(int count): Selects the next 'count' items in the collection, re-returns the **First** object
            * All(): Returns to the **List<T>** object
        * Random(int count): Selects a random selection of items from the collection of size 'count'
            * Impose(x=>x.Property, "Value"): Imposes value onto the property of every single object in the current selection, re-returns the **Random** object
            * Next(int count):: Selects the next 'count' items in the randomised collection, this will not include any previously selected items
            * All(): Returns to the **List<T>** object
        * Get(): Creates the list of objects with all property modifications applied and returns it


Sample
```csharp
// Perform factory set up (once for entire test run)
IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
{
    x.Conventions(c =>
    {
        c.UseDefaultConventions();
    });
    // allows for the scanning of an assembly
    x.AddFromAssemblyContainingType<User>();

    // Optionally Setting up data sources for an object
    // AutoPoco provided built-in data sources:
    // https://autopoco.codeplex.com/wikipage?title=DataSourceList&referringTitle=Configuration
    x.Include<User>()
        .Setup(c => c.Id).Use<IntegerIdSource>()
        .Setup(c => c.EmailAddress).Use<EmailAddressSource>()
        .Setup(c => c.FirstName).Use<FirstNameSource>()
        .Setup(c => c.CreditCard).Use<CreditCardSource>()
        .Setup(c => c.DOB).Use<DateOfBirthSource>()
        .Setup(c => c.LastName).Use<LastNameSource>()
        .Setup(c => c.State).Use<UsStatesSource>(false) // true: abbreviated
        .Invoke(c => c.SetPassword(Use.Source<String, RandomStringSource>(8, 16))); // String min, max length
});

// Generate one of these per test (factory will be a static variable most likely)
IGenerationSession session = factory.CreateSession();

// Get a collection of users based on data sources ONLY
//IList<User> users = session.List<User>(25).Get();

// Get a collection of users, with Customization
IList<User> users = session.List<User>(100)
    .Impose(x => x.Role, "Admin")
    .Impose(x => x.Age, 21)
    .First(1)
        .Impose(x => x.FirstName, "Vincent")
        .Impose(x => x.LastName, "Leung")
        .Next(1)
            .Impose(x => x.FirstName, "Kayla")
            .Impose(x => x.LastName, "Leung")
        .All()
    .Random(25)
        .Impose(x => x.Role, "Admin")
        .Impose(x => x.Age, 35)
        .Next(25)
            .Impose(x => x.Role, "Guest")
            .Invoke(x => x.SetPassword("Password1"))
        .Next(50)
            .Impose(x => x.Role, "Operator")
        .All()
    .Get();

foreach (var u in users)
{
    Console.WriteLine(u.Id + ", " + u.FirstName + ", " + u.LastName + ", " + u.Age + ", " + u.EmailAddress + ", " + u.DOB
        + ", " + u.CreditCard + ", " + u.Role + ", " + u.State + ", " + u.Password
        );
}

// Get a single user
User user = session.Single<User>().Get();

//Console.ReadLine();
```

```csharp
public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string CreditCard { get; set; }
    public DateTime DOB { get; set; }
    public string State { get; set; }
    public string Role { get; set; }
    public string Password;
    public void SetPassword(string pwd)
    {
        Password = pwd;
    }
}
```