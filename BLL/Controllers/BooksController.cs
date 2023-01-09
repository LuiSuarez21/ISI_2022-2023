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
using System.Net;
using System.IO;
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
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MockBookRepo _repository = new MockBookRepo();


        #region GET Methods
        //GET api/Books
        //Esta função realiza a operação GET, buscando todos os dados de todos os livros;
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

        //GET api/Books/best-sellers/10
        //Método que permite assesar a uma outra API e receber os best-sellers ditos pela NYT com um determinado preço;
        [HttpGet("best-sellers/{price}")]
        public ActionResult GetBooks(int price)
        {
           var bestSellers = _repository.GetBestSellers(price); 
           if (bestSellers == null) return NotFound();
           else
           {
               return Ok(bestSellers);
           }
           
        }

        //GET api/Books/best-sellers/title
        //Método que permite assesar a uma outra API e receber os best-sellers ditos pela NYT com um determinado autor;
        [HttpGet("best-sellers/byAuthor/{author}")]
        public ActionResult GetBooks2(string author)
        {
            var bestSellers = _repository.GetBestSellers2(author);
            if (bestSellers == null) return NotFound();
            else
            {
                return Ok(bestSellers);
            }

        }


        //GET api/Books/5
        //Esta função realiza a operação GET, buscando todos os dados de um livro a partir de um dado ID dado pelo o utilizador;
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
        #endregion

        #region POST Methods
        //POST api/Books/newbook
        //Esta função realiza a operação POST, criando um novo livro na database;
        [HttpPost("newbook")]
        public ActionResult<Book> PostBook(Book b)
        {
            var booksItems = _repository.CreateBook(b);
            if (booksItems != false) return Ok(booksItems);
            else
            {
                return NoContent();
            }
        }
        #endregion

        #region PUT Methods
        //PUT api/Books/updbook
        //Esta função realiza a operação PUT, actualizando a informação de um dado livro;
        [HttpPut("updbook")]
        public ActionResult<Book> UpdateBook(Book b)
        {
            var booksItems = _repository.UpdateBook(b);
            if (booksItems != false) return Ok(booksItems);
            else
            {
                return NoContent();
            }
        }
        #endregion

        #region DELETE Methods
        //DELETE api/Books/deltbook/4
        //Esta função realiza a operação DELETE, eliminando um dado livro da database a partir de um dado ID;
        [HttpDelete("delbook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var booksItems = _repository.DeleteBook(id);
            if (booksItems != false) return Ok(booksItems);
            else
            {
                return NotFound();
            }
        }
        #endregion

    }
}
