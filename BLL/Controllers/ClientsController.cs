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

/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */

/*
 * BLL: Camada apelidada de BLL (Business Logic Layer);
 * Neste projecto, a BLL é onde existem os Controllers e onde emprementamos os métodos desenvolvidos na camada DAL;
 * 
 */
namespace BLL.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly MockClientRepo _repository = new MockClientRepo();

        #region GET Methods
        //GET api/clients
        //Esta função realiza a operação GET, buscando todos os dados de todos os Clientes registados na database;
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
        //Esta função realiza a operação GET, buscando todos os dados de um Cliente;
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
        #endregion

        #region POST Methods
        //POST api/clients/newClient
        //Esta função realiza a operação POST, criando um novo cliente na database;
        [HttpPost("newClient")]
        public ActionResult<Client> PostClient(Client c)
        {
            var clientItems = _repository.InsertClient(c);
            if (clientItems != false) return Ok(clientItems);
            else
            {
                return NoContent();
            }
        }
        #endregion

        #region PUT Methods
        //PUT api/clients/updClient
        //Esta função realiza a operação PUT, actualizando um determinado cliente;
        [HttpPut("updClient")]
        public ActionResult<Client> UpdateClient(Client c)
        {
            var clientItems = _repository.UpdateClient(c);
            if (clientItems != false) return Ok(clientItems);
            else
            {
                return NoContent();
            }
        }
        #endregion

        #region DELETE Methods
        //DELETE api/clients/delCliente
        //Esta função realiza a operação DELETE, eliminando um determinado cliente;
        [HttpDelete("delClient")]
        public IActionResult DeleteClient(int id)
        {
            var clientItems = _repository.DeleteClient(id);
            if (clientItems != false) return Ok(clientItems);
            else
            {
                return NotFound();
            }
        }
        #endregion

    }
}
