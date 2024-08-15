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
            //return array of all curvepoints
            return Ok(_curvePointRepository.FindAll());
        }

        [HttpGet("/curvePoint/list/{id}")]
        public IActionResult GetACurvePoint(int id)
        {
            //return first found curvepoint matching id
            return Ok(_curvePointRepository.FindByCurvePointId(id));
        }

        [HttpPost("/curvePoint/add")]
        public IActionResult AddCurvePoint([FromBody]CurvePoint curvePoint)
        {
            // check data valid and save to db, after saving returns "Success"
            if (ModelState.IsValid)
            {
                //if model is valid add curve and return response
                _curvePointRepository.Add(curvePoint);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid");
            }
        }


        [HttpPut("/curvepoint/update")]
        public IActionResult UpdateCurvePoint([FromBody] CurvePoint curvePoint)
        {
            // check required fields, if valid call service to update Curve
            if (ModelState.IsValid)
            {
                try
                {
                    //if model is valid update curve and return response
                    _curvePointRepository.Update(curvePoint);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("Invalid");
                }
            }
            return Ok("Success");
        }

        [HttpDelete("/curvepoint/{id}")]
        public IActionResult DeleteCurvePoint(int id)
        {
            //find bid to delete by id
            CurvePoint curvepoint = _curvePointRepository.FindByCurvePointId(id);

            if (curvepoint == null)
            {
                return BadRequest("Invalid");
            }
            else
            {
                _curvePointRepository.Delete(curvepoint);
                return Ok("Success");
            }
        }
    }
}