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

        [HttpPost]
        public ActionResult<Order> PostOrder(Order o)
        {
            var OrderItems = _repository.CreateOrder(o);
            if (OrderItems != false) return Ok(OrderItems);
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<Order> UpdateOrder(Order o)
        {
            var OrderItems = _repository.UpdateOrder(o);
            if (OrderItems != false) return Ok(OrderItems);
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
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
