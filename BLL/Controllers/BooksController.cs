using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Operations.BookDt;
using DTO.Models;
using System.Data.SqlClient;
using System.Data;

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

        //Post api/clients/
        [HttpPost]
        public ActionResult<Book> PostBook(Book b)
        {
            var booksItems = _repository.CreateBook(b);
            if (booksItems != false) return Ok(booksItems);
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<Book> UpdateBook(Book b)
        {
            var booksItems = _repository.UpdateBook(b);
            if (booksItems != false) return Ok(booksItems);
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var booksItems = _repository.DeleteBook(id);
            if (booksItems != false) return Ok(booksItems);
            else
            {
                return NotFound();
            }
        }

    }
}
