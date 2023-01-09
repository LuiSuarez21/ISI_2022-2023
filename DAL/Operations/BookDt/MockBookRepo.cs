using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using DAL.Data;
using DTO.Models;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public class MockBookRepo
    {
        #region Funções
        //Função que permite ir buscar todos os livros que existem na DataBase;
        public IEnumerable<Book> GetAllBooks()
        {
            var cs = BookOp.GetBooks();
            if (cs != null) return cs;
            else
            {
                return null;
            }
        }

        //Método que permite buscar um determinado livro a partir de um ID expecifico;
        public Book GetBookById(int id)
        {
            var cs = BookOp.GetBkById(id);
            if (cs != null) return cs.ElementAt<Book>(0);
            else
            {
                return null;
            }
        }

        //Cria um livro novo na DataBase;
        public bool CreateBook(Book b)
        {
            bool y = BookOp.CreateBook(b);

            return y;
        }

        //Actualiza a informação de um dado livro;
        public bool UpdateBook(Book b)
        {
            bool y = BookOp.UpdateBook(b);

            return y;
        }

        //Elimina um determinado livro a partir de um ID;
        public bool DeleteBook(int id)
        {
            bool y = BookOp.DeleteBook(id);
            return y;
        }


        //Nesta funçáo, realizamos uma ligação a uma API externa e realizamos uma operação que permite receber todos os best-sellers do NYT que tem um determinado preço; 
        public string GetBestSellers(int value)
        {
            string myApiKey = GetMyApiKey();
            string connectionTest = string.Format("https://api.nytimes.com/svc/books/v3/lists/best-sellers/history.json?price=" + value.ToString() + "&api-key=" + myApiKey);
            WebRequest request = WebRequest.Create(connectionTest);
            request.Method = "GET";
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                var strResult = sr.ReadToEnd();
                sr.Close();
                if (strResult == null) return null;
                else
                {
                    // Parse the JSON object
                    JObject json = JObject.Parse(strResult);

                    // Initialize an empty string to store the formatted book information
                    string bookInfo = "";

                    // Iterate through the list of books
                    foreach (var book in json["results"])
                    {
                        // Extract the book information
                        string title = book["title"].ToString();
                        string author = book["author"].ToString();
                        string publisher = book["publisher"].ToString();
                        string price = book["price"].ToString();

                        // Format the book information
                        string bookString = $"{title} by {author} ({publisher}) ${price}";

                        // Add the book information to the string
                        bookInfo += bookString + "\n";
                    }

                    // Return the formatted string
                    return bookInfo;
                }
            }
        }


        //Nesta funçáo, realizamos uma ligação a uma API externa e realizamos uma operação que permite receber todos os best-sellers do NYT que tem um determinado autor; 
        public string GetBestSellers2(string name)
        {
            string myApiKey = GetMyApiKey();
            string connectionTest = string.Format("https://api.nytimes.com/svc/books/v3/lists/best-sellers/history.json?author=" + name + "&api-key=" + myApiKey);
            WebRequest request = WebRequest.Create(connectionTest);
            request.Method = "GET";
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                var strResult = sr.ReadToEnd();
                sr.Close();
                if (strResult == null) return null;
                else
                {
                    // Parse the JSON object
                    JObject json = JObject.Parse(strResult);

                    // Initialize an empty string to store the formatted book information
                    string bookInfo = "";

                    // Iterate through the list of books
                    foreach (var book in json["results"])
                    {
                        // Extract the book information
                        string title = book["title"].ToString();
                        string author = book["author"].ToString();
                        string publisher = book["publisher"].ToString();
                        string price = book["price"].ToString();

                        // Format the book information
                        string bookString = $"{title} by {author} ({publisher}) ${price}";

                        // Add the book information to the string
                        bookInfo += bookString + "\n";
                    }

                    // Return the formatted string
                    return bookInfo;
                }
            }
        }
        private string GetMyApiKey()
        {
            string myApiKey = "tndxx4IGfSMbz2gF2N65ghwjd5Tz7JjA";
            return myApiKey;
        }
        #endregion
    }
}
