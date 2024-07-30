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
            return Ok(_bidlistRepository.FindAll());
        }

        [HttpGet("/bidList/list/{id}")]
        public IActionResult GetBid(int id)
        {
            return Ok(_bidlistRepository.FindByBidListId(id));
        }

        [HttpPost("/bidList/add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBid([FromBody] BidList bidList)
        {
            // TODO: check data valid and save to db
            if (ModelState.IsValid)
            {
                _bidlistRepository.Add(bidList);
                return Ok("Success");
            } else
            {
                return BadRequest();
                //add error log
            } 
        }


        [HttpPut("/bidList/update")]
        public IActionResult UpdateBid([FromBody] BidList bidList)
        {
            // TODO: check required fields, if valid call service to update Bid
            if (ModelState.IsValid)
            {
                try
                {
                    _bidlistRepository.Update(bidList);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return BadRequest();
                    //add error log
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/bidList/{id}")]
        public IActionResult DeleteBid(int id)
        {
            //find bidList to delete
            BidList bidlist = _bidlistRepository.FindByBidListId(id);

            if (bidlist == null)
            {
                return BadRequest();
                //add error log
            } else
            {
                _bidlistRepository.Delete(bidlist);
                return Ok("Success");
            }
        }
    }
}