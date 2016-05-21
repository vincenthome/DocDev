using AutoPoco;
using AutoPoco.Configuration;
using AutoPoco.DataSources;
using AutoPoco.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp
{
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
            users = session.List<User>(100)
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
}