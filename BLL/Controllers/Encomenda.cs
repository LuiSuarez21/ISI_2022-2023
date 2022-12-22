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
    public class Encomenda : ControllerBase
    {
        [HttpGet("GetEncomenda")]

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("CreateEncomenda")]

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("UpdateEncomenda")]

        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("DeleteEncomenda")]

        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
