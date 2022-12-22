using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharing_Knowledge
{
    public class ConnectionDB
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnString { get => $"Server = {Server}; Database = {Database}; User ID = {Username}; Password = {Password}; Trusted_Connection = False; Pooling = False;"; }

        public ConnectionDB()
        {
            this.Server = "JOSEESTEVES";
            this.Database = "TP2_ISI";
            this.Username = "sa";
            this.Password = "1234";
        }

        public string GetConnectionString() => ConnString;
    }
}
