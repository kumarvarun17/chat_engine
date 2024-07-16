using Engine.Users;

namespace Engine.Chat;

public class ChatRoom
{
    public readonly List<Party> _users=[];
    public readonly Guid Id;
    internal readonly Party _party1;
    internal readonly Party _party2;
    public  List<ChatMessage> _messages = [];

    public ChatRoom(Party party1, Party party2)
    {
        _party1 = party1;
        _party2 = party2;
        Id= Guid.NewGuid();
    }

    public void Send(Party sender, ChatMessage chatMessage) => sender._eventHub.Publish( chatMessage,Id);

    public void UpdateChatRoom()
    {
        _party1.UpdateChatRoom(this);
        _party2.UpdateChatRoom(this);
    }
}