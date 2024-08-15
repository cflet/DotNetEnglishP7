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
    public class BidListController : Controller
    {
        private IBidListRepository _bidlistRepository;

        public BidListController(IBidListRepository bidListRepository)
        {
            _bidlistRepository = bidListRepository;
        }
         

        [HttpGet("/bidList/list")]
        public IActionResult GetAll()
        {
            //return array of all bidlists
            return Ok(_bidlistRepository.FindAll());
        }

        [HttpGet("/bidList/list/{id}")]
        public IActionResult GetBid(int id)
        {
            //return first found bidlist matching id
            return Ok(_bidlistRepository.FindByBidListId(id));
        }

        [HttpPost("/bidList/add")]
        public IActionResult AddBid([FromBody] BidList bidList)
        {
            // check data valid and save to db, after saving returns "Success"
            if (ModelState.IsValid)
            {
                //if model is valid add bid and return response
                _bidlistRepository.Add(bidList);
                return Ok("Success");
            } else
            {
                return BadRequest("Invalid");
            } 
        }


        [HttpPut("/bidList/update")]
        public IActionResult UpdateBid([FromBody] BidList bidList)
        {
            // check required fields, if valid call service to update Bid
            if (ModelState.IsValid)
            {
                try
                {
                    //if model is valid update bid and return response
                    _bidlistRepository.Update(bidList);
                    return Ok("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                        return BadRequest("Invalid");
                }
            }
            else return BadRequest("Invalid");
        }

        [HttpDelete("/bidList/{id}")]
        public IActionResult DeleteBid(int id)
        {
            //find bid to delete matching id
            BidList bidlist = _bidlistRepository.FindByBidListId(id);

            if (bidlist == null)
            {
                return BadRequest("Invalid");
            } else
            {
                _bidlistRepository.Delete(bidlist);
                return Ok("Success");
            }
        }
    }
}