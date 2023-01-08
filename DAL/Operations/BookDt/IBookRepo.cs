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
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */
namespace DAL.Operations.BookDt
{
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
