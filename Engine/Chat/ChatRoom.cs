using Engine.Users;

namespace Engine.Chat;

public class ChatRoom
{
    public readonly List<User> _users=[];
   private readonly EventHub _hub;
    public ChatRoom(EventHub hub, User user1, User user2, params User[] users)
    {
        _hub=hub;
        _users.AddRange([user1, user2]);
        _users.AddRange(users);
    }

    public void Send(User sender, ChatMessage chatMessage) => _hub.Publish(chatMessage, this, sender);
}