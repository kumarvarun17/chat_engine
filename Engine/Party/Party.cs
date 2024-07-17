
using Engine.Chat;

namespace Engine.Users;
public class Party
{
    public readonly int Id;
    public  List<ChatRoom> rooms = [];
    internal readonly EventHub _eventHub;

    public Party(int id,EventHub eventHub)
    {
        Id = id;
        _eventHub = eventHub;
        _eventHub.Subscribe(Id);
    }

    public void UpdateChatRoom(ChatRoom chatRoom)
    {
        if (!rooms.Any(x=>x.Id== chatRoom.Id)) rooms.Add(chatRoom);
       var room = rooms.FirstOrDefault(x => x.Id == chatRoom.Id);
       var messages = chatRoom._messages.Except(room._messages);
        room._messages.AddRange(messages);
    }
    public void Send(int receiverId, ChatMessage message)
    {
        var receiver=_eventHub.Party(receiverId);
        var room = rooms.FirstOrDefault(x => x._party1 == this && x._party2==receiver || x._party2 == this && x._party1 == receiver);
        if (room == null)
        {
            room = _eventHub.CreateChatRoom(this, receiver);
            rooms.Add(room);
        }
        room.Send(this, message);
        
    }
}

public record ChatMessage(object content, DateTime dateTime);
