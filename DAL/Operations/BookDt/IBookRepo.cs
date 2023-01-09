using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DTO.Models;

/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Ribeiro/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API SOAP e uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */

/*
 * DAL: Camada apelidada de DAL (Data Access Layer);
 * Neste projecto, a DAL é onde existe a interação com a base de dados;
 * 
 */

namespace DAL.Operations.BookDt
{
    //Interface onde vamos defenir as funções a utilizar na MockBookRepo
    interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);

        bool CreateBook(Book b);

        bool UpdateBook(Book b);

        bool DeleteBook(int id);

        string GetBestSellers(int value);

        string GetBestSellers2(string author);

        string GetMyApiKey();
    }
}
