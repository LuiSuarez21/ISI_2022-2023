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
    public class BooksController : ControllerBase
    {
        [HttpGet("GetBooks")]

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("CreateBooks")]

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("UpdateBooks")]

        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("DeleteBooks")]

        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
