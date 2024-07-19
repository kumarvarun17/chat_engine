using System.Threading.Channels;

namespace Engine.Server;

public class ChatRoom 
{
    private Channel _channel;
    private Repository _repository;
    public ChatRoom(Channel channel,Repository repository)
    {
        _channel= channel;
        _repository= repository;
    }
    public void Receive()
    {
        var message = _channel.Receive();
        _repository.Save(message);
         Send(message);
    }

    public void Send(ChatMessage message)
    {
        _channel.Send(message);
    }
}

