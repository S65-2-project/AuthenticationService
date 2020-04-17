using System;
using System.Threading.Tasks;
using AuthenticationService.Messaging;
using AuthenticationService.Models;
using AuthenticationService.Services;
using RabbitMQ.Client.Content;

namespace AuthenticationService.MessageHandlers
{
    public class RegisterUserMessageHandler : IMessageHandler<RegisterUser>
    {
        private IMessageQueuePublisher _publisher;
        private readonly IUserService _userService;

        public RegisterUserMessageHandler(IMessageQueuePublisher publisher, IUserService userService)
        {
            _publisher = publisher;
            _userService = userService;
        }

        public Task HandleMessageAsync(string messageType, RegisterUser message)
        {
            Console.WriteLine("Message Recieved!");
            _userService.InsertRegisteredUser(message.Id, message.Email, message.Password);
           // _publisher.PublishMessageAsync("EmailService", "test", "poepje");
            
            return Task.CompletedTask;
        }
    }
}