
namespace Engine.Users;

public class User
{
    public readonly int Id;
    public  List<ChatMessage> messages = [];
    private readonly EventHub _eventHub;

    public User(int id,EventHub eventHub)
    {
        Id = id;
        _eventHub = eventHub;
        _eventHub.Subscribe(this);
    }

    public void Recieve(ChatMessage message) => messages.Add(message);
}

public record ChatMessage(object content, DateTime dateTime);