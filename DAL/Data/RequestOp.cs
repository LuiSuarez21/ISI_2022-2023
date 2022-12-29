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
    }
}
