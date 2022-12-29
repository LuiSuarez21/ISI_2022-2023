using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.BookDt;
using DTO.Models;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MockBookRepo _repository = new MockBookRepo();
        //GET api/clients
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var booksItems = _repository.GetAllBooks();
            if (booksItems != null) return Ok(booksItems);
            else
            {
                return NotFound();
            }
        }

        //GET api/clients/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var booksItems = _repository.GetBookById(id);
            if (booksItems != null) return Ok(booksItems);
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
