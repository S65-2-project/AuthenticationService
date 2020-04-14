using System.Threading.Tasks;

namespace AuthenticationService.Messaging
{
    public interface IMessageQueuePublisher
    {
        Task PublishMessageAsync<T>(string routingKey, string messageType, T value);

    }
}