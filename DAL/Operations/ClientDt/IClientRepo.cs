using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
 * DAL: Camada apelidada de DAL (Data Access Layer);
 * Neste projecto, a DAL é onde existe a interação com a base de dados;
 * 
 */

namespace DAL.Operations.ClientDt
{
    //Interface onde vamos defenir as funções a utilizar na MockClientRepo
    interface IClientRepo
    {
        IEnumerable<Client> GetAllClients();
        Client GetClient(int id);
        bool InsertClient(Client c);
        bool UpdateClient(Client c);

        bool DeleteClient(int id);
    }
}
