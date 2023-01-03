using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL.Data;

namespace DAL.Operations.RequesDt
{
    public class MockRequestRepo
    {
        public IEnumerable<Request> GetAllRequests()
        {
            var cs = RequestOp.GetRqt();
            if (cs != null) return cs;
            else
            {
                return null;
            }
        }

        public Request GetRequest(int id)
        {
            var cs = RequestOp.GetRqtById(id);
            if (cs != null) return cs.ElementAt<Request>(0);
            else
            {
                return null;
            }
        }

        public bool CreateRequest(Request r)
        {
            bool y = RequestOp.CreateRequest(r);

            return y;
        }

        public bool UpdateRequest(Request r)
        {
            bool y = RequestOp.UpdateRequest(r);

            return y;
        }

        public bool DeleteRequest(int id)
        {
            bool y = RequestOp.DeleteRequest(id);
            return y;
        }
    }
}
