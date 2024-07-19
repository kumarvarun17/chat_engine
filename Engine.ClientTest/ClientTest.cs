using Engine.Client;

namespace Engine.ClientTest;

public class ClientTest
{
    public RabbitMqChannel _rabbitMqChannel = new RabbitMqChannel();
    
    [Fact]
    public void SubscribeTest()
    {
        
        var party1 = new Party(1, _rabbitMqChannel);
        var party2 = new Party(2, _rabbitMqChannel);
        _rabbitMqChannel.Connect();
        party1.Send(new ChatMessage("Hello", party2));
        party2.Receive();
        Assert.Equal("Hello",party2._messages.FirstOrDefault().content);
    }
}
