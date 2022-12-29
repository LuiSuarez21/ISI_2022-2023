using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL.Operations.RequesDt
{
    interface IRequestRepo
    {
        IEnumerable<Request> GetAllRequests();
        Request GetRequest(int id);
    }
}
