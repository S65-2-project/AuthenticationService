using System.Threading.Tasks;

namespace AuthenticationService.Messaging
{
    public interface IMessageQueuePublisher
    {
        /// <summary>
        /// Sends messages to specified message queue
        /// </summary>
        /// <param name="routingKey"></param>
        /// <param name="messageType"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task PublishMessageAsync<T>(string routingKey, string messageType, T value);

    }
}