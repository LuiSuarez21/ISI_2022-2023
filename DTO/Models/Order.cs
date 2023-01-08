using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */
namespace DTO.Models
{
    //Modelo de dados para defenir uma Encomenda;
    public class Order
    {
        [Key]
        public int ID_Encomenda { get; set; }

        public int ID_Pedido { get; set; }
        public int ID_Cliente { get; set; }
        public string Estado { get; set; }

    }
}
