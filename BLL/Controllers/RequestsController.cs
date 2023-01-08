using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.RequesDt;
using DTO.Models;

/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly MockRequestRepo _repository = new  MockRequestRepo();

        //GET api/Requests
        //Esta função realiza a operação GET, buscando todos os dados de todos os pedidos feitos até agora;
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

        //GET api/Requests/5
        //Esta função realiza a operação GET, buscando todos os dados de um pedido a partir de um ID;
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

        //POST api/Requests/newRequest
        //Esta função realiza a operação POST, criando um novo pedido na database;
        [HttpPost("newRequest")]
        public ActionResult<Request> PostRequest(Request r)
        {
            var RequestItems = _repository.CreateRequest(r);
            if (RequestItems != false) return Ok(RequestItems);
            else
            {
                return NoContent();
            }
        }

        //PUT api/Request/updRequest
        //Esta função realiza a operação PUT, actualizando a informação de um dado pedido;
        [HttpPut("updRequest")]
        public ActionResult<Request> UpdateRequest(Request r)
        {
            var RequestItems = _repository.UpdateRequest(r);
            if (RequestItems != false) return Ok(RequestItems);
            else
            {
                return NoContent();
            }
        }

        //DELETE api/Requests/delRequest/5
        //Esta função realiza a operação DELETE, eliminando um determinado pedido;
        [HttpDelete("delRequest/{id}")]
        public IActionResult DeleteRequest(int id)
        {
            var requestItems = _repository.DeleteRequest(id);
            if (requestItems != false) return Ok(requestItems);
            else
            {
                return NotFound();
            }
        }
    }
}
