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
    //Modelo de dados para defenir um Pedido feito por um determinado Cliente, servindo de ligação entre Encomendas, Livros e Pedidos;
    public class Request
    {
        #region Propriedades de um Pedido
        [Key]
        public int ID_Pedido { get; set; }

        public int ID_Livro { get; set; }
        #endregion

    }
}
