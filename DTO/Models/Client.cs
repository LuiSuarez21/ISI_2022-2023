using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Ribeiro/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API SOAP e uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */

/*
 * DTO: Camada apelidada de DTO (Data Transfer Object);
 * Neste projecto, a DTO é onde são defenidos os objetos com que vamos trabalhar neste projecto;
 * 
 */
namespace DTO.Models
{
    //Modelo de dados utilizado para defenir um Cliente;
    public class Client
    {
        #region Propriedades do Cliente
        [Key]
        public int ID_Cliente { get; set; }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Telemovel { get; set; }
        public DateTime DataNascimento { get; set; }
        #endregion

    }
}
