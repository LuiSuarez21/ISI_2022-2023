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
    }
}
