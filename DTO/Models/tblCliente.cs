using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sharing_Knowledge.Models
{
    public class tblCliente
    {
        [Key]
        public int ID_Cliente { get; set; }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Telemovel { get; set; }
        public DateTime DataNascimento { get; set; }


    }
}
