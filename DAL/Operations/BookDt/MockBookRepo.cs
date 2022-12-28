using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL.Data;
using DTO.Models;

namespace DAL.Operations.BookDt
{
    public class MockBookRepo
    {
        public IEnumerable<Order> GetAllClients()
        {
            var cs = OrderOp.GetClt();
            return cs;
        }

        public Order GetClient(int id)
        {
            var cs = ClientOp.GetCltById(id);
            bool find = false;
            for (int i = 0; i < cs.Count(); i++)
            {
                if (i == id) find = true;
            }
            if (find == true) return cs.ElementAt<Client>(id);
            else { return null; }
        }
    }
}
