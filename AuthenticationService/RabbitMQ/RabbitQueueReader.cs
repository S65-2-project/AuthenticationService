using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AuthenticationService.Endpoints
{
    public class RabbitQueueReader
    {
        private RabbitConnectionFactory _connectionFactory;
        private IModel _channel;

        public RabbitQueueReader(RabbitConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            StartAsync();
        }

        public Task StartAsync()
        {
            _channel = _connectionFactory.CreateChannel();
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;
                _channel.BasicAck(ea.DeliveryTag, false);
                HandleBasicDeliver(ea);
            };
            _channel.BasicConsume("AuthenticationService", false, consumer);
            
            return Task.CompletedTask;
        }
        
        
        public void HandleBasicDeliver(BasicDeliverEventArgs ea)
        {
            Console.WriteLine($"Consuming Message");
            
            Console.WriteLine(string.Concat("Message received from the exchange ", ea.Exchange));
            Console.WriteLine(string.Concat("Consumer tag: ", ea.ConsumerTag));
            Console.WriteLine(string.Concat("Delivery tag: ", ea.DeliveryTag));
            Console.WriteLine(string.Concat("Routing tag: ", ea.RoutingKey));
            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(ea.Body)));

        }
    }
}