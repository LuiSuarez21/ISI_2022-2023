using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Operations.ClientDt
{
    interface IClientRepo
    {
        IEnumerable<Client> GetAllClients();
        Client GetClient(int id);
        bool InsertClient(Client c);
        bool UpdateClient(Client c);

        bool DeleteClient(int id);
    }
}
