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
        // TODO: Inject Trade service

        private ITradeRepository _tradeRepository;

        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        [HttpGet("/trade/list")]
        public IActionResult GetAll()
        {
            return Ok(_tradeRepository.FindAll());
        }

        [HttpGet("/trade/list/{id}")]
        public IActionResult GetTrade(int id)
        {
            return Ok(_tradeRepository.FindByTradeId(id));
        }

        [HttpPost("/trade/add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTrade([FromBody] Trade trade)
        {
            // TODO: check data valid and save to db
            if (ModelState.IsValid)
            {
                _tradeRepository.Add(trade);
                return Ok("Success");
            }
            else
            {
                return BadRequest();
                //add error log
            }
        }


        [HttpPut("/trade/update")]
        public IActionResult UpdateTrade([FromBody] Trade trade)
        {
            // TODO: check required fields, if valid call service to update Trade
            if (ModelState.IsValid)
            {
                try
                {
                    _tradeRepository.Update(trade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                    //add error log
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/trade/{id}")]
        public IActionResult DeleteTrade(int id)
        {
            //find trade to delete
            Trade trade = _tradeRepository.FindByTradeId(id);

            if (trade == null)
            {
                return BadRequest();
                //add error log
            }
            else
            {
                _tradeRepository.Delete(trade);
                return Ok("Success");
            }
        }
    }
}