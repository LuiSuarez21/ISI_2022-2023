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
    }
}
