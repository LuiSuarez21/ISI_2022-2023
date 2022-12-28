using Sharing_Knowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Operations.ClientDt
{
    public interface IClientRepo
    {
        IEnumerable<Client> GetAppClients();
        Client GetClient(int id);
    }
}
