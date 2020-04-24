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
        private readonly IUserService _userService;

        public RegisterUserMessageHandler(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Recieves messages send to messagetype RegisterUser
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task HandleMessageAsync(string messageType, RegisterUser message)
        {
            _userService.InsertRegisteredUser(message.Id, message.Email, message.Password);
           return Task.CompletedTask;
        }
    }
}