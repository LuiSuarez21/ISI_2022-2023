using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */
namespace DAL.Operations.RequesDt
{
    interface IRequestRepo
    {
        IEnumerable<Request> GetAllRequests();
        Request GetRequest(int id);

        bool CreateRequest(Request r);

        bool UpdateRequest(Request r);

        bool DeleteRequest(int id);
    }
}
