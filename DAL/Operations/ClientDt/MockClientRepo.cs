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
            return cs;
        }

        public Client GetClient(int id)
        {
            var cs = ClientOp.GetCltById(id);
            bool find = false;
            for (int i = 0; i < cs.Count(); i++)
            {
                if (i == id) find = true;
            }
            if(find == true)return cs.ElementAt<Client>(id);
            else { return null; }
        }

    }
}
