using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NinjaCore2.Data.Entities;
using NinjaCore2.Domain.Services.Abstract;

namespace NinjaCore2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {   
            var res = _userService.GetUserList();
            return res.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _userService.GetUser(id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
                return BadRequest();
            _userService.Create(user);
            return Ok(user);
        }

        [HttpPut]
        public ActionResult<User> Put(User user)
        {
            if (user == null)
                return BadRequest();
            if (!_userService.GetUserList().Any(x => x.Id == user.Id))
                return NotFound();
            _userService.Update(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = _userService.GetUser(id);            
            if (user == null)
                return NotFound();
            _userService.Delete(id);
            return Ok(user);
        }
    }
}
