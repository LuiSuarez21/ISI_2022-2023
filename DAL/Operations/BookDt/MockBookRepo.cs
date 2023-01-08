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
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */
namespace DAL.Operations.BookDt
{
    public class MockBookRepo
    {
        public IEnumerable<Book> GetAllBooks()
        {
            var cs = BookOp.GetBooks();
            if (cs != null) return cs;
            else
            {
                return null;
            }
        }

        public Book GetBookById(int id)
        {
            var cs = BookOp.GetBkById(id);
            if (cs != null) return cs.ElementAt<Book>(0);
            else
            {
                return null;
            }
        }

        public bool CreateBook(Book b)
        {
            bool y = BookOp.CreateBook(b);

            return y;
        }

        public bool UpdateBook(Book b)
        {
            bool y = BookOp.UpdateBook(b);

            return y;
        }

        public bool DeleteBook(int id)
        {
            bool y = BookOp.DeleteBook(id);
            return y;
        }


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



        public string GetBestSellers2(string author)
        {
            string myApiKey = GetMyApiKey();
            string connectionTest = string.Format("https://api.nytimes.com/svc/books/v3/lists/best-sellers/history.json?author=" + author + "&api-key=" + myApiKey);
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
                    return strResult;
                }
            }
        }
        private string GetMyApiKey()
        {
            string myApiKey = "tndxx4IGfSMbz2gF2N65ghwjd5Tz7JjA";
            return myApiKey;
        }
    }
}
