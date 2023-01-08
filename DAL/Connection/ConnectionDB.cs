using System;
using System.Collections.Generic;
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

namespace DAL.Connection
{
    //Classe responável por determinar qual a connection string para conectar ao servidor Azure que contem a API e a database e os métodos para chegar a tal connectio string;
    public class ConnectionDB
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnString { get => $"Server = {Server}; Initial Catalog = {Database}; User ID = {Username}; Password = {Password}; Persist Security Info=False; MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; }

        private ConnectionDB()
        {
            this.Server = "tcp:isi.database.windows.net,1433";
            this.Database = "ISI_TP2";
            this.Username = "ISI_SuperAdmin";
            this.Password = "Teste1234++";
        }


        public string GetConnectionString() => ConnString;

        public static string GetConnectionStr (){

           var cn = new ConnectionDB();
           var connectDB = cn.GetConnectionString();
           return connectDB;

        }
    }
}
