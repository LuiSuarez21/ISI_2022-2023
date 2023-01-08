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
    public class RequestOp
    {
        public static IEnumerable<Request> GetRqt()
        {
            List<Request> r = new List<Request>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Pedidos]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
           while (sqlrd.Read())
            {
                r.Add(new Request()
                {
                    ID_Pedido = Convert.ToInt32(sqlrd.GetValue(0)),
                    ID_Livro = Convert.ToInt32(sqlrd.GetValue(1))
                });
            }

            if (r.Count() != 0) return r;
            else { return null; }
        }

        public static IEnumerable<Request> GetRqtById(int id)
        {
            List<Request> r = new List<Request>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Pedidos]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlrd.Read())
            {

                if (i == id)
                {
                    r.Add(new Request()
                    {
                        ID_Pedido = Convert.ToInt32(sqlrd.GetValue(0)),
                        ID_Livro = Convert.ToInt32(sqlrd.GetValue(1))
                    });
                }
                i++;
            }

            if (r.Count() != 0) return r;
            else { return null; }
        }

        public static bool CreateRequest(Request request)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection(mainConnection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pedidos (ID_Pedido ,ID_Livro) VALUES (@ID_PEDIDO ,@ID_LIVRO)", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_PEDIDO", request.ID_Pedido);
                    cmd.Parameters.AddWithValue("@ID_LIVRO", request.ID_Livro);
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

        public static bool UpdateRequest(Request request)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection(mainConnection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Pedidos SET ID_Livro=@ID_Livro, ID_Pedido=@ID_Pedido WHERE ID_Livro=@ID_Livro", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_Pedido", request.ID_Pedido);
                    cmd.Parameters.AddWithValue("@ID_Livro", request.ID_Livro);
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

        public static bool DeleteRequest(int id)
        {
            List<Request> r = new List<Request>();
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection conn = new SqlConnection(mainConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Delete from lockers where ID_Pedido=@Id", conn))

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
