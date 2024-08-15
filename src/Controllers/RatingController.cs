using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpGet("/rating/list")]
        public IActionResult GetAll()
        {
            //return array of all ratings
            return Ok(_ratingRepository.FindAll());
        }

        [HttpGet("/rating/list/{id}")]
        public IActionResult GetARating(int id)
        {
            //return first found rating matching id
            return Ok(_ratingRepository.FindByRatingId(id));
        }

        [HttpPost("/rating/add")]
        public IActionResult AddRating([FromBody] Rating rating)
        {
            // check data valid and save to db, after saving returns "Success"
            if (ModelState.IsValid)
            {
                //if model is valid add rating and return response
                _ratingRepository.Add(rating);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("/rating/update")]
        public IActionResult UpdateRating([FromBody] Rating rating)
        {
            // check required fields, if valid call service to update rating
            if (ModelState.IsValid)
            {
                try
                {
                    //if model is valid update rating and return response
                    _ratingRepository.Update(rating);
                    return Ok("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Invalid");
                }
            }
            return BadRequest("Invalid");
        }

        [HttpDelete("/rating/{id}")]
        public IActionResult DeleteRating(int id)
        {
            //find rating to delete matching id
            Rating rating = _ratingRepository.FindByRatingId(id);

            if (rating == null)
            {
                return BadRequest("Invalid");
            }
            else
            {
                _ratingRepository.Delete(rating);
                return Ok("Success");
            }
        }
    }
}