using Nancy;
using Nancy.Json;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL.Data;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Riberio/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */
namespace DAL.Operations.ClientDt
{
    public class MockClientRepo : IClientRepo
    {
        public IEnumerable<Client> GetAllClients()
        {
            var cs = ClientOp.GetClt();
            if (cs != null) return cs;
            else
            {
                return null;
            }
        }

        public Client GetClient(int id)
        {
            var cs = ClientOp.GetCltById(id);
            if (cs != null) return cs.ElementAt<Client>(0);
            else
            {
                return null;
            }
        }

        public bool InsertClient(Client c)
        {
            bool y = ClientOp.CreateClient(c);

            return y;
        }

        public bool UpdateClient(Client c)
        {
            bool y = ClientOp.UpdateClient(c);

            return y;
        }

        public bool DeleteClient(int id)
        {
            bool y = ClientOp.DeleteClient(id);
            return y;
        }
    }

    
}
