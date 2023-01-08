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
    public class ClientOp
    {
        
        public static IEnumerable<Client> GetClt()
        {
            List<Client> c = new List<Client>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Cliente]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            while(sqlrd.Read())
            {
                c.Add(new Client()
                {
                    ID_Cliente = Convert.ToInt32(sqlrd.GetValue(0)),
                    Nome = sqlrd.GetValue(1).ToString(),
                    Morada = sqlrd.GetValue(2).ToString(),
                    Email = sqlrd.GetValue(3).ToString(),
                    Pass = sqlrd.GetValue(4).ToString(),
                    Telemovel = Convert.ToInt32(sqlrd.GetValue(5)),
                    DataNascimento = Convert.ToDateTime(sqlrd.GetValue(6))
                }); 
            }

            if (c.Count() != 0) return c;
            else { return null; }
        }

        public static IEnumerable<Client> GetCltById(int id)
        {
            List<Client> c = new List<Client>();
            string mainConnection = ConnectionDB.GetConnectionStr();
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            string sqlquery = "select * from [dbo].[Cliente]";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            SqlDataReader sqlrd = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlrd.Read())
            {

                if (i == id)
                {
                    c.Add(new Client()
                    {
                        ID_Cliente = Convert.ToInt32(sqlrd.GetValue(0)),
                        Nome = sqlrd.GetValue(1).ToString(),
                        Morada = sqlrd.GetValue(2).ToString(),
                        Email = sqlrd.GetValue(3).ToString(),
                        Pass = sqlrd.GetValue(4).ToString(),
                        Telemovel = Convert.ToInt32(sqlrd.GetValue(5)),
                        DataNascimento = Convert.ToDateTime(sqlrd.GetValue(6))

                    });
                }
                i++;
            }

            if(c.Count() != 0)return c;
            else { return null; }
        }

        public static bool CreateClient(Client client)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection(mainConnection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Cliente (ID_Cliente, Nome, Morada, Email, Pass, Telemovel, DataNascimento) VALUES (@ID_CLIENTE, @NOME, @MORADA, @EMAIL, @PASS, @TELEMOVEL, @DATANASCIMENTO)", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_CLIENTE", client.ID_Cliente);
                    cmd.Parameters.AddWithValue("@NOME", client.Nome);
                    cmd.Parameters.AddWithValue("@MORADA", client.Morada);
                    cmd.Parameters.AddWithValue("@EMAIL", client.Email);
                    cmd.Parameters.AddWithValue("@PASS", client.Pass);
                    cmd.Parameters.AddWithValue("@TELEMOVEL", client.Telemovel);
                    cmd.Parameters.AddWithValue("@DATANASCIMENTO", client.DataNascimento);
                    cmd.ExecuteNonQuery();

                    x++;
                }
            }
            if(x==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool UpdateClient(Client client)
        {
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection sqlConnection = new SqlConnection(mainConnection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Cliente SET ID_Cliente=@ID_Cliente, Nome=@Nome, Morada=@Morada, Email=@Email, Pass=@Pass, Telemovel=@Telemovel, DataNascimento=@DataNascimento WHERE ID_Cliente=@ID_Cliente", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_Cliente", client.ID_Cliente);
                    cmd.Parameters.AddWithValue("@Nome", client.Nome);
                    cmd.Parameters.AddWithValue("@Morada", client.Morada);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@Pass", client.Pass);
                    cmd.Parameters.AddWithValue("@Telemovel", client.Telemovel);
                    cmd.Parameters.AddWithValue("@DataNascimento", client.DataNascimento);
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

        public static bool DeleteClient(int id)
        {
            List<Client> c = new List<Client>();
            int x = 0;
            string mainConnection = ConnectionDB.GetConnectionStr();
            using (SqlConnection conn = new SqlConnection(mainConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Delete from dbo.Cliente where ID_Cliente=@Id", conn))

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
