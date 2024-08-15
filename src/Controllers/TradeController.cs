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
    public class TradeController : Controller
    {
        private ITradeRepository _tradeRepository;

        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        [HttpGet("/trade/list")]
        public IActionResult GetAll()
        {
            //return array of all trades
            return Ok(_tradeRepository.FindAll());
        }

        [HttpGet("/trade/list/{id}")]
        public IActionResult GetTrade(int id)
        {
            //return first found trade matching id
            return Ok(_tradeRepository.FindByTradeId(id));
        }

        [HttpPost("/trade/add")]
        public IActionResult AddTrade([FromBody] Trade trade)
        {
            // check data valid and save to db, after saving returns "Success"
            if (ModelState.IsValid)
            {
                //if model is valid add trade and return response
                _tradeRepository.Add(trade);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("/trade/update")]
        public IActionResult UpdateTrade([FromBody] Trade trade)
        {
            // check required fields, if valid call service to update trade
            if (ModelState.IsValid)
            {
                try
                {
                    //if model is valid update trade and return response
                    _tradeRepository.Update(trade);
                    return Ok("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Invalid");
                }
            }
            return BadRequest("Invalid");
        }

        [HttpDelete("/trade/{id}")]
        public IActionResult DeleteTrade(int id)
        {
            //find trade to delete
            Trade trade = _tradeRepository.FindByTradeId(id);

            if (trade == null)
            {
                return BadRequest("Invalid");
            }
            else
            {
                _tradeRepository.Delete(trade);
                return Ok("Success");
            }
        }
    }
}