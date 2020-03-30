using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NinjaCore2.Data.Repositories;
using NinjaCore2.Domain.Models;

namespace NinjaCore2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;

            if (!_repository.GetUserList().Any())
            {
                _repository.Create(new User { FirstName = "Tom", LastName = "Hunter", Email = "T.H1@email.com", BirthDate = new DateTime(2000, 6, 20) });
                _repository.Create(new User { FirstName = "Tim", LastName = "Hymi", Email = "Hy3@email.com", BirthDate = new DateTime(1990, 2, 7) });
                _repository.Save();
            }
          
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {   
            var res = _repository.GetUserList();
            return res.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _repository.GetUser(id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
                return BadRequest();
            _repository.Create(user);
            _repository.Save();
            return Ok(user);
        }

        [HttpPut]
        public ActionResult<User> Put(User user)
        {
            if (user == null)
                return BadRequest();
            if (!_repository.GetUserList().Any(x => x.Id == user.Id))
                return NotFound();
            _repository.Update(user);
            _repository.Save();            
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = _repository.GetUser(id);            
            if (user == null)
                return NotFound();
            _repository.Delete(id);
            _repository.Save();
            return Ok(user);
        }
    }
}
