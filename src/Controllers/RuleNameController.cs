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
            //return array of all rulenames
            return Ok(_rulenameRepository.FindAll());
        }

        [HttpGet("/ruleName/list/{id}")]
        public IActionResult GetRuleName(int id)
        {
            //return first found rulename matching id
            return Ok(_rulenameRepository.FindByRuleNameId(id));
        }

        [HttpPost("/ruleName/add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddRuleName([FromBody] RuleName ruleName)
        {
            // check data valid and save to db, after saving returns "Success"
            if (ModelState.IsValid)
            {
                _rulenameRepository.Add(ruleName);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("/ruleName/update")]
        public IActionResult UpdateRuleName([FromBody] RuleName ruleName)
        {
            // check required fields, if valid call service to update rulename 
            if (ModelState.IsValid)
            {
                try
                {
                    //if model is valid update rulename and return response
                    _rulenameRepository.Update(ruleName);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Invalid");
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/ruleName/{id}")]
        public IActionResult DeleteRuleName(int id)
        {
            //find rulename to delete matching id
            RuleName ruleName = _rulenameRepository.FindByRuleNameId(id);

            if (ruleName == null)
            {
                return BadRequest("Invalid");
            }
            else
            {
                _rulenameRepository.Delete(ruleName);
                return Ok("Success");
            }
        }
    }
}