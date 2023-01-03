using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL.Data;
using DTO.Models;

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
    }
}
