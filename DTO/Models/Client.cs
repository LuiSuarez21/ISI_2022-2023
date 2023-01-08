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
    //Modelo de dados utilizado para defenir um Cliente;
    public class Client
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
