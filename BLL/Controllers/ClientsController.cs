using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.ClientDt;
using Sharing_Knowledge.Models;

namespace Sharing_Knowledge.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly MockClientRepo _repository = new MockClientRepo();
        //GET api/clients
        [HttpGet]
        public ActionResult <IEnumerable<Client>> GetAllClients()
        {
            var clientItems = _repository.GetAppClients();
            return Ok(clientItems);
        }

        //GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Client> GetCommandById(int id)
        {
            var clientItems = _repository.GetClient(id);
            return Ok(clientItems);
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
