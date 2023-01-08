using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClient" in both code and config file together.
    [ServiceContract]
    public interface IClient
    {
        [OperationContract]
        Task<bool> InsertClientAsync(int Id_Client, string name, string morada, string email, string pass, int telemovel, DateTime DataNascimento);
        //bool InsertClient(int Id_Client, string name, string morada, string email, string pass, int telemovel, DateTime DataNascimento);

        [OperationContract]
        bool InsertBook(int Id_Livros, string title, string author, string genre, double ratings, string cover_type, double price, int quantidade);

        [OperationContract]
        void InsertOrder(int Id_Encomenda, int Id_Pedido, int Id_Client, string Estado);

        [OperationContract]
        void InsertRequest(int Id_Pedido, int Id_Livro);

        [OperationContract]
        void UpdateClient(int Id_Client, string name, string morada, string email, string pass, int telemovel, DateTime DataNascimento);

        [OperationContract]
        void UpdateBook(int Id_Livros, string title, string author, string genre, double ratings, string cover_type, double price, int quantidade);

        [OperationContract]
        void UpdateOrder(int Id_Encomenda, int Id_Pedido, int Id_Client, string Estado);

        [OperationContract]
        void UpdateRequest(int Id_Pedido, int Id_Livro);

        [OperationContract]
        void DeleteClient(int id);

        [OperationContract]
        void DeleteBook(int id);

        [OperationContract]
        void DeleteOrder(int id);

        [OperationContract]
        void DeleteRequest(int id);


    }
}
