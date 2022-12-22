using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharing_Knowledge.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly MockClientRepo _repository = new MockClientRepo();
        //GET api/clients
        [HttpGet]
        public IActionResult <Enumerable><Client>> GetAllClients()
        {
            var clientItems = _repository.GetAppClients();
            return Ok();
        }

        //GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Clients> GetCommandById(int id)
        {
            var clientItems = _repository.GetCommandById(id);
            return Ok(commandItems);
        }

        /*
        [HttpPost("CreateCliente")]

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("UpdateCliente")]

        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("DeleteCliente")]

        public IActionResult Delete()
        {
            return Ok();
        }
        
        */
    }
}
