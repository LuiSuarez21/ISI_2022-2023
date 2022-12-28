using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace DTO.Models
{
    public class Book
    {
        [Key]
        public int ID_Livros { get; set; }

        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public double ratings { get; set; }
        public string cover_type { get; set; }
        public double price { get; set; }
        public int quantidade { get; set; }

    }
}
