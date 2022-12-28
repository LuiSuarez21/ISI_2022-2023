using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.OrderDt;
using DTO.Models;

namespace Sharing_Knowledge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MockOrderRepo _repository = new MockOrderRepo();
        //GET api/clients
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllClients()
        {
            var clientItems = _repository.GetAllClients();
            return Ok(clientItems);
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
