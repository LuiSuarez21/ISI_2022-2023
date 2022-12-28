using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Request
    {
        [Key]
        public int ID_Pedido { get; set; }

        public int ID_Livro { get; set; }

    }
}
