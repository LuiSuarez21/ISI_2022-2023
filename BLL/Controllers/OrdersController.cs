using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.OrderDt;
using DTO.Models;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private readonly MockOrderRepo _repository = new MockOrderRepo();
        //GET api/clients
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

        //GET api/clients/5
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
