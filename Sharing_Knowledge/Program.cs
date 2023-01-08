using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Jo�o Riberio/17214;
 * Disciplina: Integra��o de Sistemas de Informa��o;
 * Projecto II;
 * Prop�sito do trabalho: Criar uma API REST Full de ger�ncia de utilizadores e de entrega de livros;
 *
 */
namespace Sharing_Knowledge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
