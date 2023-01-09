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

namespace DAL.Operations.OrderDt
{
    //Interface onde vamos defenir as funções a utilizar na MockOrderRepo

    interface IOrderRepo
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);

        bool CreateOrder(Order o);

        bool UpdateOrder(Order o);

        bool DeleteOrder(int id);

    }
}
