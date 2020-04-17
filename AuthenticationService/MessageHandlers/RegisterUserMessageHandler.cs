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
        /// <summary>
        /// recieves messages send to messagetype RegisterUser
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task HandleMessageAsync(string messageType, RegisterUser message)
        {
            _userService.InsertRegisteredUser(message.Id, message.Email, message.Password);
           // _publisher.PublishMessageAsync("routingkey", "messagetype", "value");
           return Task.CompletedTask;
        }
    }
}