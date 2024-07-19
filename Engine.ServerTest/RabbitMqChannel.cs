using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using Engine.Server;
using RabbitMQ.Client.Events;

namespace Engine.ServerTest;

internal class RabbitMqChannel : Channel
{
    private IModel _channel;
    internal RabbitMqChannel()
    {
        var factory = new ConnectionFactory();
        using var connection = factory.CreateConnection();
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
        return message;
    }
}

