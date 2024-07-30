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
    public class RuleNameController : Controller
    {
        private IRuleNameRepository _rulenameRepository;

        public RuleNameController(IRuleNameRepository rulenameRepository)
        {
            _rulenameRepository = rulenameRepository;
        }

        [HttpGet("/ruleName/list")]
        public IActionResult GetAll()
        {
            return Ok(_rulenameRepository.FindAll());
        }

        [HttpGet("/ruleName/list/{id}")]
        public IActionResult GetRuleName(int id)
        {
            return Ok(_rulenameRepository.FindByRuleNameId(id));
        }

        [HttpPost("/ruleName/add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddRuleName([FromBody] RuleName ruleName)
        {
            // TODO: check data valid and save to db, after saving return rule name
            if (ModelState.IsValid)
            {
                _rulenameRepository.Add(ruleName);
                return Ok("Success");
            }
            else
            {
                return BadRequest();
                //add error log
            }
        }


        [HttpPut("/ruleName/update")]
        public IActionResult UpdateRuleName([FromBody] RuleName ruleName)
        {
            // TODO: check required fields, if valid call service to update RuleName and return 
            if (ModelState.IsValid)
            {
                try
                {
                    _rulenameRepository.Update(ruleName);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                    //add error log
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/ruleName/{id}")]
        public IActionResult DeleteRuleName(int id)
        {
            //find ruleName to delete
            RuleName ruleName = _rulenameRepository.FindByRuleNameId(id);

            if (ruleName == null)
            {
                return BadRequest();
                //add error log
            }
            else
            {
                _rulenameRepository.Delete(ruleName);
                return Ok();
            }
        }
    }
}