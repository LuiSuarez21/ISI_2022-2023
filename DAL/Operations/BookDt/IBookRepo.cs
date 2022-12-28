using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL.Operations.BookDt
{
    interface IBookRepo
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);
    }
}
