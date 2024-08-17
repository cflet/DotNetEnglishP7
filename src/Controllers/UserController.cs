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

        public UserController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }


        [HttpGet("/user/list")]
        public IActionResult GetAll()
        {
            //return array of all users
            return Ok(_UserRepository.FindAll());
        }


        [HttpPost("/user/add")]
        public IActionResult AddUser([FromBody]User user)
        {
            // check data valid and save to db, after saving returns "Success"
            if (ModelState.IsValid)
            {
                //if model is valid add user and return response
                //hash password and update model
                string password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = password;

                _UserRepository.Add(user);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("/user/update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            // check required fields, if valid call service to update user
            if (ModelState.IsValid)
            {
                try
                {
                    //hash password and update model
                    string password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = password;
                    //update user and return response
                    _UserRepository.Update(user);
                    return Ok("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Invalid");
                }
            }
            return BadRequest("Invalid");
        }


        [HttpDelete("/user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            //find user to delete matching id
            User user = _UserRepository.FindByUserId(id);

            if (user == null)
            {
                return BadRequest("Invalid");
            }
            else
            {
                _UserRepository.Delete(user);
                return Ok("Success");
            }
        }

        [HttpGet("/user/login")]
        public IActionResult UserLogin(string username, string password)
        {
            //find user matching userName
            User user = _UserRepository.FindByUserName(username);

            if (user == null)
            {
                return BadRequest("Invalid");
            }
            else
            {
                //if given password matches saved hashed password return True
                if(BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return Ok("True");
                }
                return BadRequest("Invalid");
            }
        }
    }

}
