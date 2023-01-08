using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.OrderDt;
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

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private readonly MockOrderRepo _repository = new MockOrderRepo();

        //GET api/Orders
        //Esta função realiza a operação GET, buscando todos os dados de todos as encomendas;
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orderItems = _repository.GetAllOrders();
            if(orderItems != null)return Ok(orderItems);
            else
            {
                return NotFound();
            }
        }

        //GET api/Orders/5
        //Esta função realiza a operação GET, buscando todos os dados de uma dada encomenda;
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var orderItems = _repository.GetOrder(id);
            if (orderItems != null) return Ok(orderItems);
            else
            {
                return NotFound();
            }
        }

        //POST api/Orders/newOrder
        //Esta função realiza a operação POST, criando uma nova encomenda na database;
        [HttpPost("newOrder")]
        public ActionResult<Order> PostOrder(Order o)
        {
            var OrderItems = _repository.CreateOrder(o);
            if (OrderItems != false) return Ok(OrderItems);
            else
            {
                return NoContent();
            }
        }

        //PUT api/Orders/updOrder
        //Esta função realiza a operação PUT, actualizando uma determinada encomenda;
        [HttpPut("updOrder")]
        public ActionResult<Order> UpdateOrder(Order o)
        {
            var OrderItems = _repository.UpdateOrder(o);
            if (OrderItems != false) return Ok(OrderItems);
            else
            {
                return NoContent();
            }
        }

        //DELETE api/Orders/delOrder/5
        //Esta função realiza a operação DELETE, eliminando uma determinada encomenda;
        [HttpDelete("delOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var orderItems = _repository.DeleteOrder(id);
            if (orderItems != false) return Ok(orderItems);
            else
            {
                return NotFound();
            }
        }

    }
}
