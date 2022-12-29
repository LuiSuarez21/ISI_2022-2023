using Nancy;
using Nancy.Json;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL.Data;

namespace DAL.Operations.ClientDt
{
    public class MockClientRepo : IClientRepo
    {
        public IEnumerable<Client> GetAllClients()
        {
            var cs = ClientOp.GetClt();
            if (cs != null) return cs;
            else
            {
                return null;
            }
        }

        public Client GetClient(int id)
        {
            var cs = ClientOp.GetCltById(id);
            if (cs != null) return cs.ElementAt<Client>(0);
            else
            {
                return null;
            }
        }
    }

    
}
