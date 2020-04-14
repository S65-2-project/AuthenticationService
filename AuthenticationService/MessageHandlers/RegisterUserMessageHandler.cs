using System;
using System.Threading.Tasks;
using AuthenticationService.Messaging;
using AuthenticationService.Models;
using RabbitMQ.Client.Content;

namespace AuthenticationService.MessageHandlers
{
    public class RegisterUserMessageHandler : IMessageHandler<RegisterUser>
    {
        private IMessageQueuePublisher _publisher;

        public RegisterUserMessageHandler(IMessageQueuePublisher publisher)
        {
            _publisher = publisher;
        }

        public Task HandleMessageAsync(string messageType, RegisterUser message)
        {
            Console.WriteLine("Yoinkpik");
            
           // _publisher.PublishMessageAsync("EmailService", "test", "poepje");
            
            return Task.CompletedTask;
        }
    }
}