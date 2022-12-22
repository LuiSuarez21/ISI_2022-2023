using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharing_Knowledge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pedidos : ControllerBase
    {
        [HttpGet("GetPedidos")]

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("CreatePedidos")]

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("UpdatePedidos")]

        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("DeletePedidos")]

        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
