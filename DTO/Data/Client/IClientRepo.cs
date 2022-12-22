using Sharing_Knowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Data
{
    class IClientRepo
    {
        IEnumerable<tblCliente> GetAppClients();
        tblCliente GetClient(int id);
    }
}
