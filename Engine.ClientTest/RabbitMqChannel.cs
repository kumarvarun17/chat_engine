using System.Text;
using Engine.Client;
using RabbitMQ.Client;
using System.Text.Json;
using RabbitMQ.Client.Events;

namespace Engine.ClientTest;

public class RabbitMqChannel : Channel
{
 
    private IModel _channel;

    public void Connect()
    {
        var factory = new ConnectionFactory(){HostName = "localhost"};
         var connection = factory.CreateConnection();
         _channel = connection.CreateModel();

        _channel.QueueDeclare(queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
    public void Send(ChatMessage message)
    {
        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        _channel.BasicPublish(exchange: string.Empty,
            routingKey: "hello",
            basicProperties: null,
            body: body);
    }



    public ChatMessage? Receive()
    {
        var consumer = new EventingBasicConsumer(_channel);
        ChatMessage? message=null;
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            message = JsonSerializer.Deserialize<ChatMessage>(Encoding.UTF8.GetString(body));
        };
        _channel.BasicConsume(queue: "hello",
            autoAck: true,
            consumer: consumer);
        while (message == null)
        {
           
        }

        return message;

    }
}

