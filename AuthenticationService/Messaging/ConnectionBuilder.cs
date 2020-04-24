using System;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.Messaging
{
    public static class ConnectionBuilder
    {
        /// <summary>
        /// Used to register consumers to a specified messagequeue name
        /// </summary>
        /// <param name="services"></param>
        /// <param name="queueName"></param>
        /// <param name="builderFn"></param>
        public static void AddMessageConsumer(this IServiceCollection services, string queueName , Action<MessagingBuilder> builderFn = null)
        {
            var builder = new MessagingBuilder(services);
            services.AddHostedService<RabbitQueueReader>();
            services.AddSingleton(new MessageHandlerRepository(builder.MessageHandlers));

            builderFn?.Invoke(builder);
            var queueNameService = new QueueName(queueName);
            services.AddSingleton(queueNameService);
            var connection = new RabbitConnectionFactory();
            services.AddSingleton(connection); 
        }

        /// <summary>
        /// Used to be able to publish messages to a message queue
        /// </summary>
        /// <param name="services"></param>
        public static void AddMessagePublisher(this IServiceCollection services)
        {
            var connection = new RabbitConnectionFactory();
            services.AddSingleton(connection);
            services.AddScoped<IMessageQueuePublisher, RabbitQueuePublisher>();        
        }
    }
}