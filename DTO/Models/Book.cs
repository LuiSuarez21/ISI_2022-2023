﻿using System;
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
    //Modelo de dados utilizado para defenir os livros;
    public class Book
    {
        #region Propriedades dos Livros
        [Key]
        public int ID_Livros { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Ratings { get; set; }
        public string Cover_type { get; set; }
        public double Price { get; set; }
        public int Quantidade { get; set; }
        #endregion

    }
}
