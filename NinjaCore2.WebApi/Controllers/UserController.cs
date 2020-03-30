using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaCore2.Data.DataContext;
using NinjaCore2.Data.Repositories;
using NinjaCore2.Domain.Models;
//using NinjaCore2.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NinjaCore2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        //UserContext _context;

        public UserController(IUserRepository repository/*UserContext context*/)
        {
            _repository = repository;
            //_context = context;

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

            //return _context.Users.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _repository.GetUser(id);

            //User user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
                return BadRequest();

            _repository.Create(user);
            _repository.Save();

            //_context.Users.Add(user);
            //_context.SaveChanges();

            return Ok(user);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public ActionResult<User> Put(User user)
        {
            if (user == null)
                return BadRequest();

            if (!_repository.GetUserList().Any(x => x.Id == user.Id)/*!_context.Users.Any(x => x.Id == user.Id)*/)
                return NotFound();

            _repository.Update(user);
            _repository.Save();

            //_context.Update(user);
            //_context.SaveChanges();
            
            return Ok(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = _repository.GetUser(id);

            //User user = _context.Users.FirstOrDefault(x => x.Id == id);
            
            if (user == null)
                return NotFound();

            _repository.Delete(id);
            _repository.Save();

            //_context.Users.Remove(user);
            //_context.SaveChanges();

            return Ok(user);
        }
    }
}
