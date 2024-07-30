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
            return Ok(_ratingRepository.FindAll());
        }

        [HttpGet("/rating/list/{id}")]
        public IActionResult GetRating(int id)
        {
            return Ok(_ratingRepository.FindByRatingId(id));
        }

        [HttpPost("/rating/add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddRating([FromBody] Rating rating)
        {
            // TODO: check data valid and save to db, after saving return rating list
            if (ModelState.IsValid)
            {
                _ratingRepository.Add(rating);
                return Ok("Success");
            }
            else
            {
                return BadRequest();
                //add error log
            }
        }


        [HttpPut("/rating/update")]
        public IActionResult UpdateRating([FromBody] Rating rating)
        {
            // TODO: check required fields, if valid call service to update Rating and return list Rating
            if (ModelState.IsValid)
            {
                try
                {
                    _ratingRepository.Update(rating);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                    //add error log
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/rating/{id}")]
        public IActionResult DeleteRating(int id)
        {
            //find rating to delete
            Rating rating = _ratingRepository.FindByRatingId(id);

            if (rating == null)
            {
                return BadRequest();
                //add error log
            }
            else
            {
                _ratingRepository.Delete(rating);
                return Ok();
            }
        }
    }
}