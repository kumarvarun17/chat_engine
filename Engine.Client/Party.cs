
namespace Engine.Client;

public class Party
{
    private Channel _channel;
    private int _id;
    public List<ChatMessage> _messages = new List<ChatMessage>();

    public Party(int id,Channel channel)
    {
        _id = id;
        _channel = channel;
    }

    public void Send(ChatMessage message)
    {
        _messages.Add(message);
        _channel.Send(message);
    }

    public void Receive() => _messages.Add(_channel.Receive());
}

