using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.Messaging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace AuthenticationService
{
    public class Program
    {
        private static IMessageQueuePublisher _queue;

        public static void Main(string[] args)
        {
            // RabbitConnectionFactory factory = new RabbitConnectionFactory();
            // RabbitQueueReader queue = new RabbitQueueReader(factory);
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}