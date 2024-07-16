
using Engine.Chat;

namespace Engine.Users;

public class Party
{
    public readonly int Id;
    public  List<ChatRoom> rooms = [];
    private readonly EventHub _eventHub;

    public Party(int id,EventHub eventHub)
    {
        Id = id;
        _eventHub = eventHub;
        _eventHub.Subscribe(this);
    }

    public void UpdateChatRoom(Guid? chatRoomId)
    {
        var chatRoom=rooms.FirstOrDefault(x => x.Id == chatRoomId);
        if (chatRoom == null)
        {
            var 
            chatRoom = new ChatRoom(this, this);
            rooms.Add(chatRoom);
        }
    }
}

public record ChatMessage(object content, DateTime dateTime);