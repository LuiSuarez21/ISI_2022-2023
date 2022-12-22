using Sharing_Knowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Data.Client
{
    class MockClientRepo : IClientRepo
    {
        public IEnumerable<tblCliente> GetAppClients()
        {
            throw new System.NotImplementedException();
        }

        public tblCliente GetClient(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
