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

/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */

namespace DAL.Data
{
    public class OrderOp
    {
        public static IEnumerable<Order> GetOrd()
        {
            List<Order> o = new List<Order>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Encomenda]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            while (sqlrd.Read())
            {
                o.Add(new Order()
                {
                    ID_Encomenda = Convert.ToInt32(sqlrd.GetValue(0)),
                    ID_Pedido =  Convert.ToInt32(sqlrd.GetValue(1)),
                    ID_Cliente = Convert.ToInt32(sqlrd.GetValue(2)),
                    Estado = sqlrd.GetValue(1).ToString()
                });
            }

            if (o.Count() != 0) return o;
            else { return null; }
        }

        public static IEnumerable<Order> GetOrdById(int id)
        {
            List<Order> o = new List<Order>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Encomenda]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlrd.Read())
            {

                if (i == id)
                {
                    o.Add(new Order()
                    {
                        ID_Encomenda = Convert.ToInt32(sqlrd.GetValue(0)),
                        ID_Pedido = Convert.ToInt32(sqlrd.GetValue(1)),
                        ID_Cliente = Convert.ToInt32(sqlrd.GetValue(2)),
                        Estado = sqlrd.GetValue(1).ToString()
                    });
                }
                i++;
            }

            if (o.Count() != 0) return o;
            else { return null; }
        }

        public static bool CreateOrder(Order order)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Encomenda (ID_Encomenda, ID_Pedido, ID_Cliente, Estado) VALUES (@ID_ENCOMENDA, @ID_PEDIDO, @ID_CLIENTE, @ESTADO)", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_LIVROS", order.ID_Encomenda);
                    cmd.Parameters.AddWithValue("@TITLE", order.ID_Pedido);
                    cmd.Parameters.AddWithValue("@AUTHOR", order.ID_Cliente);
                    cmd.Parameters.AddWithValue("@GENRE", order.Estado);
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

        public static bool UpdateOrder(Order order)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Encomenda SET ID_Livros=@ID_Livros, Title=@Title, Author=@Author, Genre=@Genre WHERE ID_Livros=@ID_Livros", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_Livros", order.ID_Encomenda);
                    cmd.Parameters.AddWithValue("@Title", order.ID_Pedido);
                    cmd.Parameters.AddWithValue("@Author", order.ID_Cliente);
                    cmd.Parameters.AddWithValue("@Genre", order.Estado);
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

        public static bool DeleteOrder(int id)
        {
            List<Order> o = new List<Order>();
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection conn = new SqlConnection(mainConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Delete from dbo.Encomenda where ID_Encomenda=@Id", conn))

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
