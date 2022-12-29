using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL.Data;

namespace DAL.Operations.OrderDt
{
    public class MockOrderRepo
    {
        public IEnumerable<Order> GetAllOrders()
        {
            var cs = OrderOp.GetOrd();
            if (cs != null) return cs;
            else
            {
                return null;
            }
        }

        public Order GetOrder(int id)
        {
            var cs = OrderOp.GetOrdById(id);
            if (cs != null) return cs.ElementAt<Order>(0);
            else
            {
                return null;
            }
        }
    }
}
