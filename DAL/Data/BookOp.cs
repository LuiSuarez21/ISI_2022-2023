using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DAL.Connection;



namespace DAL.Data
{
    public class BookOp
    {
        public static IEnumerable<Book> GetBooks()
        {
            List<Book> b = new List<Book>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Books]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            while (sqlrd.Read())
            {
                b.Add(new Book()
                {
                    ID_Livros = Convert.ToInt32(sqlrd.GetValue(0)),
                    Title = sqlrd.GetValue(1).ToString(),
                    Author = sqlrd.GetValue(2).ToString(),
                    Genre = sqlrd.GetValue(3).ToString(),
                    Ratings = Convert.ToInt32(sqlrd.GetValue(4)),
                    Cover_type = sqlrd.GetValue(5).ToString(),
                    Price = Convert.ToInt32(sqlrd.GetValue(6)),
                    Quantidade = Convert.ToInt32(sqlrd.GetValue(7))
                });
            }

            if (b.Count() != 0) return b;
            else { return null; }
        }

        public static IEnumerable<Book> GetBkById(int id)
        {
            List<Book> b = new List<Book>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Books]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlrd.Read())
            {

                if (i == id)
                {
                    b.Add(new Book()
                    {
                        ID_Livros = Convert.ToInt32(sqlrd.GetValue(0)),
                        Title = sqlrd.GetValue(1).ToString(),
                        Author = sqlrd.GetValue(2).ToString(),
                        Genre = sqlrd.GetValue(3).ToString(),
                        Ratings = Convert.ToInt32(sqlrd.GetValue(4)),
                        Cover_type = sqlrd.GetValue(5).ToString(),
                        Price = Convert.ToInt32(sqlrd.GetValue(6)),
                        Quantidade = Convert.ToInt32(sqlrd.GetValue(7))

                    });
                }
                i++;
            }

            if (b.Count() != 0) return b;
            else { return null; }
        }

        public static bool CreateBook(Book book)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection(mainConnection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Books (ID_Livros, title, author, genre, ratings, cover_type, price, quantidade) VALUES (@ID_LIVROS, @TITLE, @AUTHOR, @GENRE, @RATINGS, @COVER_TYPE, @PRICE, @QUANTIDADE)", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_LIVROS", book.ID_Livros);
                    cmd.Parameters.AddWithValue("@TITLE", book.Title);
                    cmd.Parameters.AddWithValue("@AUTHOR", book.Author);
                    cmd.Parameters.AddWithValue("@GENRE", book.Genre);
                    cmd.Parameters.AddWithValue("@RATINGS", book.Ratings);
                    cmd.Parameters.AddWithValue("@COVER_TYPE", book.Cover_type);
                    cmd.Parameters.AddWithValue("@PRICE", book.Price);
                    cmd.Parameters.AddWithValue("@QUANTIDADE", book.Quantidade);
                    cmd.ExecuteNonQuery();
                    x++;
                }
            }
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool UpdateBook(Book book)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection(mainConnection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Books SET ID_Livros=@ID_Livros, Title=@Title, Author=@Author, Genre=@Genre, Ratings=@Ratings, Cover_Type=@Cover_Type, Price=@Price, Quantidade=@Quantidade WHERE ID_Livros=@ID_Livros", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_Livros", book.ID_Livros);
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Genre", book.Genre);
                    cmd.Parameters.AddWithValue("@Ratings", book.Ratings);
                    cmd.Parameters.AddWithValue("@Cover_Type", book.Cover_type);
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    cmd.Parameters.AddWithValue("@Quantidade", book.Quantidade);
                    cmd.ExecuteNonQuery();
                    x++;
                }
            }
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool DeleteBook(int id)
        {
            List<Book> b = new List<Book>();
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection conn = new SqlConnection(mainConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Delete from dbo.Books where ID_Livros=@Id", conn))

                {

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    x++;

                }
            }
            if (x != 0) return true;
            else { return false; }

        }
    }
}
