using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiApp.Controllers
{
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
}