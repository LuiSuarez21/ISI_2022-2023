using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.ClientDt;
using DTO.Models;

namespace BLL.Controllers
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
            var clientItems = _repository.GetAllClients();
            if (clientItems != null) return Ok(clientItems);
            else
            {
                return NotFound();
            }
        }

        //GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Client> GetClientById(int id)
        {
            var clientItems = _repository.GetClient(id);
            if (clientItems != null) return Ok(clientItems);
            else
            {
                return NotFound();
            }
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
