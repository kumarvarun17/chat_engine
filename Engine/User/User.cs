
namespace Engine.Users;

public class User
{
    public readonly int Id;
    public  List<ChatMessage> messages = new List<ChatMessage>();
    private readonly EventHub _eventHub;

    public User(int id,EventHub eventHub)
    {
        Id = id;
        _eventHub = eventHub;
        _eventHub.Subscribe(this);
    }

    public void Recieve(ChatMessage message)
    {
       messages.Add(message);
    }

    public void Send(User to, ChatMessage message)
    {
        _eventHub.Publish(message, to);
    }

}

public record ChatMessage(object content);