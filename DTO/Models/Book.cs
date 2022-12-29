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

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Ratings { get; set; }
        public string Cover_type { get; set; }
        public double Price { get; set; }
        public int Quantidade { get; set; }

    }
}
