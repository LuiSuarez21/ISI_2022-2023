using Sharing_Knowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Operations.ClientDt
{
    public class MockClientRepo : IClientRepo
    {
        public IEnumerable<Client> GetAppClients()
        {
         
            var clients = new List<Client>
            {
                new Client {ID_Cliente=0, Nome="José", Morada="Rua", Email="jose@ndiened", Pass="mdiefnie", Telemovel=948394398, DataNascimento=DateTime.Now}
            };

            return clients;
        }

        public Client GetClient(int id)
        {
            return new Client { ID_Cliente = 1, Nome = "Luis", Morada = "Rua", Email = "jose@ndiened", Pass = "mdiefnie", Telemovel = 948394398, DataNascimento=DateTime.Now   };
        }

    }
}
