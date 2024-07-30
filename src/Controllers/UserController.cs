using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _UserRepository;
        //public readonly IPasswordHasher<IdentityUser> _passwordHasher;


        public UserController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }


        [HttpGet("/user/list")]
        public IActionResult GetAll()
        {
            return Ok(_UserRepository.FindAll());
        }


        [HttpPost("/user/add")]
        public IActionResult AddUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                string password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = password;

                _UserRepository.Add(user);
                return Ok("Success");
            }
            else
            {
                return BadRequest();
                //add error log
            }
        }


        [HttpPut("/user/update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            // TODO: check required fields, if valid call service to update Curve and return Curve list
            if (ModelState.IsValid)
            {
                try
                {
                    string password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = password;
                    _UserRepository.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                    //add error log
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            
            User user = _UserRepository.FindByUserId(id);

            if (user == null)
            {
                return BadRequest();
                //add error log
            }
            else
            {
                _UserRepository.Delete(user);
                return Ok();
            }
        }
    }
}