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
    public class CurveController : Controller
    {
        // TODO: Inject Curve Point service
        private ICurvePointRepository _curvePointRepository;

        public CurveController(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }


        [HttpGet("/curvePoint/list")]
        public IActionResult GetAll()
        {
            return Ok(_curvePointRepository.FindAll());
        }

        [HttpGet("/curvePoint/list/{id}")]
        public IActionResult GetABid(int id)
        {
            return Ok(_curvePointRepository.FindByCurvePointId(id));
        }

        [HttpPost("/curvePoint/add")]
        public IActionResult AddCurvePoint([FromBody]CurvePoint curvePoint)
        {
            // TODO: check data valid and save to db, after saving return bid list
            if (ModelState.IsValid)
            {
                _curvePointRepository.Add(curvePoint);
                return Ok("Success");
            }
            else
            {
                return BadRequest("invalid model state");
                //add error log
            }
        }


        [HttpPut("/curvepoint/update")]
        public IActionResult UpdateCurvePoint([FromBody] CurvePoint curvePoint)
        {
            // TODO: check required fields, if valid call service to update Curve and return Curve list
            if (ModelState.IsValid)
            {
                try
                {
                    _curvePointRepository.Update(curvePoint);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Invalid");
                    //add error log
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/curvepoint/{id}")]
        public IActionResult DeleteBid(int id)
        {
            // TODO: Find Curve by Id and delete the Curve, return to Curve list

            CurvePoint curvepoint = _curvePointRepository.FindByCurvePointId(id);

            if (curvepoint == null)
            {
                return BadRequest("Invalid");
                //add error log
            }
            else
            {
                _curvePointRepository.Delete(curvepoint);
                return Ok();
            }
        }
    }
}