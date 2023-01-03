using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.ClientDt;
using DTO.Models;
using System.Data.SqlClient;
using System.Data;

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

        //Post api/clients/
        [HttpPost]
        public ActionResult<Client> PostClient(Client c)
        {
            var clientItems = _repository.InsertClient(c);
            if (clientItems != false) return Ok(clientItems);
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<Client> UpdateClient(Client c)
        {
            var clientItems = _repository.UpdateClient(c);
            if (clientItems != false) return Ok(clientItems);
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var clientItems = _repository.DeleteClient(id);
            if (clientItems != false) return Ok(clientItems);
            else
            {
                return NotFound();
            }
        }

    }
}
