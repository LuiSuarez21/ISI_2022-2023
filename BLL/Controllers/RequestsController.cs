using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.RequesDt;
using DTO.Models;


namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly MockRequestRepo _repository = new  MockRequestRepo();
        //GET api/clients
        [HttpGet]
        public ActionResult<IEnumerable<Request>> GetAllRequests()
        {
            var requestItems = _repository.GetAllRequests();
            if (requestItems != null) return Ok(requestItems);
            else
            {
                return NotFound();
            }
        }

        //GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Request> GetClientById(int id)
        {
            var requestItems = _repository.GetRequest(id);
            if (requestItems != null) return Ok(requestItems);
            else
            {
                return NotFound();
            }
        }
        /*

        [HttpPost("CreateEncomenda")]

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("UpdateEncomenda")]

        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("DeleteEncomenda")]

        public IActionResult Delete()
        {
            return Ok();
        }
        */
    }
}
