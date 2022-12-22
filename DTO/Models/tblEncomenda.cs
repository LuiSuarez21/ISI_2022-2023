using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sharing_Knowledge.Models
{
    public class tblEncomenda
    {
        [Key]
        public int ID_Encomenda { get; set; }

        public int ID_Pedido { get; set; }
        public int ID_Cliente { get; set; }
        public string Estado { get; set; }

    }
}
