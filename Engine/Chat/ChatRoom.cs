using Engine.Users;

namespace Engine.Chat;

public class ChatRoom
{
    public readonly List<Party> _users=[];
    private readonly EventHub _hub;
    public readonly Guid Id;
    private readonly Party _party1;
    private readonly Party _party2;
    private  List<ChatMessage> _messages = [];

    public ChatRoom(Party party1, Party party2)
    {
        _party1 = party1;
        _party2 = party2;
        Id= Guid.NewGuid();
    }


    public void Send(Party sender, ChatMessage chatMessage) => _hub.Publish(sender, _party2, chatMessage, Id);
}