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

            return c;
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

                if (c[i].ID_Cliente == id)
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

    }
}
